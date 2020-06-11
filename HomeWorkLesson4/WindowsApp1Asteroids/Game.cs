using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WindowsApp1Asteroids.Objects;


namespace WindowsApp1Asteroids
{
    /// <summary> Менеджер игры </summary>
    static class Game
    {
        private static BufferedGraphicsContext _context;
        private static BufferedGraphics _buffer;
        private static Size _size;
        private static readonly Timer timer = new Timer {Interval = 10};
        /// <summary> Размеры окна </summary>
        public static Size Size
        {
            get => _size;
            set
            {
                if (value.Width > 1600 || value.Width < 300)
                    throw new ArgumentOutOfRangeException("Ширина вне диапазона 300-1600");
                if (value.Height > 900 || value.Height < 200)
                    throw new ArgumentOutOfRangeException("Высота вне диапазона 200-900");
                _size = value;
            }
        }
        /// <summary> Случайное число </summary>
        public static Random Rand = new Random();
        /// <summary> Сообщение о произошедшем событии </summary>
        public static Action<string> EventMessage;
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
            timer.Tick += (s, a) =>
            {
                Update();
                if (timer.Enabled)
                    Draw();
            };
            timer.Start();
            form.KeyDown += Form_KeyDown;
            form.KeyUp += Form_KeyUp;
        }
        #region Объекты
        ///////////////////////////////////////////////////
        /// <summary> Задний фон </summary>
        private static readonly Image space = Image.FromFile(@"Images\Space.jpg");
        private static float _moveSpace;
        /// <summary> Звезды на фоне </summary>
        private static ObjBase[] fonStars;
        /// <summary> Астероиды </summary>
        private static ObjBase[] asteroids;
        #endregion
        #region Методы-обработчики
        ///////////////////////////////////////////////////
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
                asteroids[i] = new Asteroid(pos, new Point(-4, 0), new Size(40, 40), Rand.Next(Asteroid.CountImages) );
            }

        }
        /// <summary> Обновление состояния </summary>
        private static void Update()
        {
            _moveSpace += 0.2F;
            if (_moveSpace > space.Width)
                _moveSpace = 0.0F;
            foreach (var star in fonStars)
                star.Update();
            foreach (var asteroid in asteroids)
            {
                asteroid.Update();
            }

        }

        public static void Draw()
        {
            _buffer.Graphics.DrawImage(space, 0 - _moveSpace, 0);
            _buffer.Graphics.DrawImage(space, space.Width - _moveSpace, 0);
            foreach (var star in fonStars)
                star.Draw(_buffer.Graphics);
            foreach (var asteroid in asteroids)
                asteroid.Draw(_buffer.Graphics);



            _buffer.Render();
        }
        /// <summary> Конец игры </summary>
        /// <param name="message">сообщение окончания игры</param>
        private static void GameOver(string message)
        {
            timer.Stop();
            _buffer.Graphics.DrawString(message, new Font(FontFamily.GenericSansSerif, 80), Brushes.Red, 140, 140 );
            _buffer.Render();
        }
        #endregion
        #region Кнопки на клавиатуре
        ///////////////////////////////////////////////////
        private static void Form_KeyDown(object s, KeyEventArgs e)
        {

        }
        private static void Form_KeyUp(object s, KeyEventArgs e)
        {

        }
        #endregion
    }
}
