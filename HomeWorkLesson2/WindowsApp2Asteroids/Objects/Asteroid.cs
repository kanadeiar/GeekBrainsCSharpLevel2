using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp2Asteroids.Objects
{
    /// <summary>
    /// Астероид
    /// </summary>
    class Asteroid : Star
    {
        private static readonly Image[] astImages;
        static Asteroid()
        {
            Image[] tmpImages =
            {
                Image.FromFile(@"Images\Asteroid1.png"),
                Image.FromFile(@"Images\Asteroid2.png"),
                Image.FromFile(@"Images\Asteroid3.png"),
                Image.FromFile(@"Images\Asteroid4.png"),
                Image.FromFile(@"Images\Asteroid5.png"),
            };
            astImages = tmpImages;
        }
        /// <summary> Количество разновидностей астероидов </summary>
        public static int CountImages => astImages.Length;
        private int currImage;
        private float angle;
        private float angledir;
        public Asteroid(Point pos, Point dir, Size size, int currImage, float angledir) : base(pos, dir, size)
        {
            this.currImage = currImage;
            this.angledir = angledir;
        }
        /// <summary> Обновление астероида </summary>
        public override void Update()
        {
            pos.X += dir.X;
            pos.Y += dir.Y;
            if (pos.X + size.Width < 0)
            {
                pos.X = Game.Width + size.Width + Game.Rand.Next(Game.Width);
                pos.Y = Game.Rand.Next(Game.Height - size.Height);
                currImage = Game.Rand.Next(CountImages);
            }
        }
        /// <summary> Отрисовка астероида </summary>
        /// <param name="g">Графическое полотно</param>
        public override void Draw(Graphics g)
        {
            Image image = Tools.RotateBitmap(astImages[currImage], new PointF(50, 50), angle);
            angle += angledir;
            g.DrawImage(image, new Rectangle(pos, size));
        }
    }
}
