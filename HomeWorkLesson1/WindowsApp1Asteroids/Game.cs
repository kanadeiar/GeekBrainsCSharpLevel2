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
    static class Game
    {
        private static BufferedGraphicsContext context;
        private static BaseObject[] objs;
        private static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
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
            Timer timer = new Timer {Interval = 30};
            timer.Tick += (sender, args) =>
            {
                Update();
                Draw();
            };
            timer.Start();
        }
        private static void Load()
        {
            objs = new BaseObject[30];
            for (int i = 0; i < objs.Length; i++)
                objs[i] = new BaseObject(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20));
        }
        private static void Update()
        {
            foreach (var obj in objs)
                obj.Update();
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (var obj in objs)
                obj.Draw(Buffer.Graphics);
            Buffer.Render();
        }
    }
}
