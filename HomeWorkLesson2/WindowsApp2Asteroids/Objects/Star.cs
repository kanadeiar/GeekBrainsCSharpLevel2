using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp2Asteroids.Objects
{
    /// <summary>
    /// Фоновая звезда
    /// </summary>
    class Star : BaseObject
    {
        private static readonly Image drawImage = Image.FromFile(@"Images\Star.png");
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        /// <summary> Обновление звезды </summary>
        public override void Update()
        {
            pos.X += dir.X;
            if (pos.X + size.Width < 0) //звезда за границей экрана
            {
                pos.X = Game.Width + size.Width;
                pos.Y = Game.Rand.Next(Game.Height - size.Height);
            }
        }
        /// <summary> Отрисовка звезды </summary>
        /// <param name="g">Графическое полотно</param>
        public override void Draw(Graphics g)
        {
            g.DrawImage(drawImage, new Rectangle(pos, size));
        }
    }
}
