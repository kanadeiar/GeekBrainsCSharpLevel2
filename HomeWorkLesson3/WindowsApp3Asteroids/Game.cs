using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using WindowsApp3Asteroids.Objects;

namespace WindowsApp3Asteroids
{
    /// <summary>
    /// Менеджер игры
    /// </summary>
    internal class Game
    {
        private static BufferedGraphicsContext _context;
        private static BufferedGraphics _buffer;
        private static Size _size;
        private static readonly Timer Timer = new Timer { Interval = 10 };
        /// <summary> Размеры окна </summary>
        public static Size Size
        {
            get => _size;
            private set
            {
                if (value.Width > 1600 || value.Width < 300)
                    throw new ArgumentOutOfRangeException("Ширина окна должна быть в пределах от 300 до 1600");
                if (value.Height > 900 || value.Height < 200)
                    throw new ArgumentOutOfRangeException("Высота окна должна быть в пределах от 200 до 900");
                _size = value;
            }
        }
        /// <summary> Случайное число </summary>
        public static Random Rand = new Random();
        /// <summary> Сообщение о проишедшем событии </summary>
        public static Action<string> DebugMessage;
        /// <summary> Сообщение о конце игры </summary>
        //public delegate void MessageGameOver();

        static Game()
        { }

        /// <summary> Инициализация игры </summary>
        /// <param name="form">окно</param>
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Size = form.ClientSize;
            _buffer = _context.Allocate(g, new Rectangle(new Point(0, 0), Size));
            Load();
            Timer.Tick += (s, a) =>
            {
                Update();
                if (Timer.Enabled) Draw();
            };
            Timer.Start();
            form.KeyDown += Form_KeyDown;
            form.KeyUp += Form_KeyUp;
        }
        ///////////////////////////////////////////////////////////////
        private static readonly Image space = Image.FromFile(@"Images\Space.jpg");
        private static float _moveSpace;
        /// <summary> Звезды на фоне </summary>
        private static ObjBase[] fonStars;
        /// <summary> Астероиды </summary>
        private static ObjBase[] asteroids;
        /// <summary> Корабль </summary>
        private static Ship ship;
        /// <summary> Пули </summary>
        private static List<Bullet> bullets;
        /// <summary> Аптечка </summary>
        private static Energy energy;
        /// <summary> Загрузка элементов </summary>
        private static void Load()
        {
            fonStars = new Star[200];
            Point pos = new Point();
            for (int i = 0; i < 200; i++)
            {
                int randSize;
                int speed;
                switch (i)
                {
                    case int k when k < 150:
                        randSize = Rand.Next(3, 6);
                        speed = 1;
                        break;

                    case int k when k < 180:
                        randSize = Rand.Next(9, 12);
                        speed = 2;
                        break;

                    default:
                        randSize = Rand.Next(15, 20);
                        speed = 3;
                        break;
                }
                pos.X = Rand.Next(Size.Width - randSize);
                pos.Y = Rand.Next(Size.Height - randSize);
                fonStars[i] = new Star(pos, new Point(-speed, 0), new Size(randSize, randSize));
            }
            asteroids = new Asteroid[10];
            for (int i = 0; i < asteroids.Length; i++)
            {
                pos.X = Size.Width + Rand.Next(Size.Width);
                pos.Y = Rand.Next(Size.Height - 40);
                asteroids[i] = new Asteroid(pos, new Point(-4, 0), new Size(40, 40), Rand.Next(Asteroid.CountImages), Rand.Next(2,4));
            }
            ship = new Ship(new Point(5, Game.Size.Height / 2), new Point(4,4), new Size(100,25) );
            Ship.MessageGameOver += GameOver; //конец игры
            bullets = new List<Bullet>();
            energy = new Energy(new Point(Size.Width + Rand.Next(Size.Width - 30), Rand.Next(Size.Height - 30)), new Point(-4,0), new Size(30,30));
        }

        /// <summary> Обновление состояния </summary>
        private static void Update()
        {
            foreach (var star in fonStars)
                star.Update();
            foreach (var asteroid in asteroids)
            {
                asteroid.Update();
                foreach (var bullet in bullets)
                    if (asteroid.Collision(bullet))
                    {
                        SystemSounds.Hand.Play();
                        asteroid.Reset();
                        bullet.DeleteMe = true;
                        ship.Score++;
                        DebugMessage("Пуля сбила астероид!");
                    }
                if (asteroid.Collision(ship))
                {
                    SystemSounds.Asterisk.Play();
                    asteroid.Reset();
                    ship.Energy -= 10;
                    DebugMessage("Астероид подбил корабль!");
                }
            }
            ship?.Update();
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].DeleteMe)
                {
                    bullets.Remove(bullets[i]);
                    continue;
                }
                bullets[i].Update();
            }
            energy?.Update();
            if (energy?.Collision(ship) == true)
            {
                SystemSounds.Asterisk.Play();
                energy.Reset();
                ship.Energy += 10;
                if (ship.Energy > 100)
                    ship.Energy = 100;
                DebugMessage("Корабль подлатался!");
            }
            if (ship?.Energy <= 0)
                ship?.Die(); //гибель корабля
        }

        /// <summary> Отрисовка элементов </summary>
        private static void Draw()
        {
            _buffer.Graphics.DrawImage(space, 0 - _moveSpace, 0);
            _buffer.Graphics.DrawImage(space, space.Width - _moveSpace, 0);
            _moveSpace += 0.2F;
            if (_moveSpace > space.Width)
                _moveSpace = 0.0F;
            foreach (var star in fonStars)
                star.Draw(_buffer.Graphics);
            foreach (var asteroid in asteroids)
                asteroid.Draw(_buffer.Graphics);
            ship?.Draw(_buffer.Graphics);
            if (ship != null)
                _buffer.Graphics.DrawString($"Количество очков: {ship.Score}", new Font(FontFamily.GenericSansSerif, 14), Brushes.White, 760,10);
            foreach (var bullet in bullets)
                bullet.Draw(_buffer.Graphics);
            energy?.Draw(_buffer.Graphics);
            _buffer.Render();
        }
        ////////////////////////////////////////////////////////////////
        private static void Form_KeyDown(object s, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                Point pos = new Point(ship.Rect.X + ship.Rect.Width - 25, ship.Rect.Y + 8);
                bullets.Add(new Bullet(pos, new Point(5,0), new Size(18,5)));

            }
            if (e.KeyCode == Keys.Up) ship.Up();
            if (e.KeyCode == Keys.Down) ship.Down();
            if (e.KeyCode == Keys.Left) ship.Left();
            if (e.KeyCode == Keys.Right) ship.Right();
        }
        private static void Form_KeyUp(object s, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) ship.UpOff();
            if (e.KeyCode == Keys.Down) ship.DownOff();
            if (e.KeyCode == Keys.Left) ship.LeftOff();
            if (e.KeyCode == Keys.Right) ship.RightOff();
        }

        private static void GameOver(string message)
        {
            Timer.Stop();
            _buffer.Graphics.DrawString(message, new Font(FontFamily.GenericSansSerif, 80), Brushes.Red, 150, 140);
            _buffer.Render();
        }
    }
}