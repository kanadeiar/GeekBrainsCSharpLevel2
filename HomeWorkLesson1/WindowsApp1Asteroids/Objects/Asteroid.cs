using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp1Asteroids.Objects
{
    /// <summary>
    /// Астероид
    /// </summary>
    class Asteroid : Star
    {
        private static Image[] asteroidImages;
        /// <summary> Количество разновидностей астероидов </summary>
        public static int CountImages { get; private set; }
        static Asteroid()
        {
            Image[] tmpImages =
            {
                Image.FromFile("Images\\Asteroid1.png"),
                Image.FromFile("Images\\Asteroid2.png"),
                Image.FromFile("Images\\Asteroid3.png"),
                Image.FromFile("Images\\Asteroid4.png"),
                Image.FromFile("Images\\Asteroid5.png"),
            };
            asteroidImages = tmpImages;
            CountImages = tmpImages.Length;
        }
        private int currentImages;
        public Asteroid(Point pos, Point dir, Size size, int currentImages) : base(pos, dir, size)
        {
            this.currentImages = currentImages;
        }
        /// <summary> Обновление астероида </summary>
        public override void Update()
        {
            pos.X += dir.X;
            pos.Y += dir.Y;
            if (pos.X + size.Width < 0)
            {
                pos.X = Game.Width + size.Width + Game.rand.Next(Game.Width);
                pos.Y = Game.rand.Next(Game.Height - size.Height);
                currentImages = Game.rand.Next(CountImages);
            }
        }
        /// <summary> Отрисовка астероида </summary>
        public override void Draw(Graphics g)
        {
            g.DrawImage(asteroidImages[currentImages], new Rectangle(pos, size));
        }
    }
}
