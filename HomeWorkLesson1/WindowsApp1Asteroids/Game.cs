using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsApp1Asteroids.Objects;

namespace WindowsApp1Asteroids
{
    /// <summary>
    /// Менеджер игры
    /// </summary>
    static class Game
    {
        private static BufferedGraphicsContext context;
        private static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static Random rand = new Random();
        /// <summary> Звезды на фоне </summary>
        public static BaseObject[] fonStars;
        /// <summary> Астероиды </summary>
        public static BaseObject[] asteroids;
        static Game()
        {
        }
        public static void Init(Form form)
        {
            Graphics g;
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer {Interval = 10};
            timer.Tick += (sender, args) =>
            {
                Update();
                Draw();
            };
            timer.Start();
        }
        /// <summary> Загрузка элементов в начальном состоянии </summary>
        private static void Load()
        {
            fonStars = new BaseObject[150];
            for (int i = 0; i < 120; i++) //мелкие звезды
            {
                int randomsize = rand.Next(3, 9);
                int speed = randomsize / 3;
                fonStars[i] = new Star(new Point(rand.Next(Width - randomsize), rand.Next(Height - randomsize)), new Point(-speed,0), new Size(randomsize,randomsize));
            }
            for (int i = 120; i < 150; i++) //крупные звезды
            {
                int randomsize = rand.Next(10, 20);
                int speed = randomsize / 4;
                fonStars[i] = new Star(new Point(rand.Next(Width - randomsize), rand.Next(Height - randomsize)), new Point(-speed,0), new Size(randomsize,randomsize));
            }
            asteroids = new BaseObject[10];
            for (int i = 0; i < asteroids.Length; i++)
                asteroids[i] = new Asteroid(new Point(Width + rand.Next(Width), rand.Next(Height - 30)), new Point(-6,0), new Size(40,40),rand.Next(Asteroid.CountImages));
        }
        /// <summary> Обновление всех элементов </summary>
        private static void Update()
        {
            foreach (var star in fonStars)
                star.Update();
            foreach (var asteroid in asteroids)
                asteroid.Update();
        }
        /// <summary> Отрисовка всех элементов в окне </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (var star in fonStars)
                star.Draw(Buffer.Graphics);
            foreach (var asteroid in asteroids)
                asteroid.Draw(Buffer.Graphics);
            Buffer.Render();
        }
    }
}
