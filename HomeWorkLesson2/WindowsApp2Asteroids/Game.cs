using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsApp2Asteroids.Objects;

namespace WindowsApp2Asteroids
{
    /// <summary>
    /// Менеджер игры
    /// </summary>
    static class Game
    {
        private static BufferedGraphicsContext context;
        private static BufferedGraphics buffer;
        /// <summary> Звезды на фоне </summary>
        private static BaseObject[] fonStars;
        /// <summary> Астероиды </summary>
        private static BaseObject[] asteroids;
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static Random Rand = new Random();
        static Game()
        {
        }
        /// <summary> Загрузка элементов в начальном состоянии </summary> <param name="form">окно приложения</param>
        public static void Init(Form form)
        {
            Graphics g;
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
            load();
            Timer timer = new Timer {Interval = 10};
            timer.Tick += (sender, args) =>
            {
                update();
                Draw();
            };
            timer.Start();
        }
        /// <summary> загрузка элементов в начальном состоянии </summary>
        private static void load()
        {
            fonStars = new BaseObject[200];

            for (int i = 0; i < 200; i++)
            {
                int randSize;
                int speed;
                switch (i)
                {
                    case int k when k < 150:
                        randSize = Rand.Next(3, 6);
                        speed = randSize / 3;
                        break;
                    case int k when k < 180:
                        randSize = Rand.Next(9, 12);
                        speed = randSize / 3;
                        break;
                    default:
                        randSize = Rand.Next(15, 20);
                        speed = randSize / 3;
                        break;
                }
                fonStars[i] = new Star(new Point(Rand.Next(Width - randSize), Rand.Next(Height - randSize)), new Point(-speed,0), new Size(randSize,randSize));
            }
            asteroids = new BaseObject[8];
            for (int i = 0; i < asteroids.Length; i++)
            {
                asteroids[i] = new Asteroid(new Point(Width + Rand.Next(Width), Rand.Next(Height - 30)), new Point(-6, 0), new Size(40, 40), Rand.Next(Asteroid.CountImages));
            }
        }
        /// <summary> обновление всех элементов </summary>
        private static void update()
        {
            foreach (var star in fonStars)
                star.Update();
            foreach (var asteroid in asteroids)
                asteroid.Update();
        }
        /// <summary> Отрисовка всех элементов в окне </summary>
        public static void Draw()
        {
            buffer.Graphics.Clear(Color.Black);
            foreach (var star in fonStars)
                star.Draw(buffer.Graphics);
            foreach (var asteroid in asteroids)
                asteroid.Draw(buffer.Graphics);
            buffer.Render();
        }
    }
}
