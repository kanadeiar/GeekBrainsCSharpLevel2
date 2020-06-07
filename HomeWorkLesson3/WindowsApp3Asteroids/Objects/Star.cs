using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp3Asteroids.Objects
{
    /// <summary>
    /// Звезда на фоне
    /// </summary>
    class Star : ObjBase
    {
        private static readonly Image image = Image.FromFile(@"Images\Star.png");
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        /// <summary> Обновление звезды </summary>
        public override void Update()
        {
            pos.X += dir.X;
            if (pos.X + size.Width < 0)
                Reset();
        }
        /// <summary> Сброс на начальную позицию </summary>
        public override void Reset()
        {
            pos.X = Game.Size.Width + size.Width;
            pos.Y = Game.Rand.Next(Game.Size.Height - size.Height);
        }
        /// <summary> Отрисовка звезды </summary>
        /// <param name="g">Полотно</param>
        public override void Draw(Graphics g)
        {
            g.DrawImage(image, new Rectangle(pos, size));
        }
    }
}
