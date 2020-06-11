using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp1Asteroids.Objects
{
    /// <summary> Звезда на фоне </summary>
    internal class Star : ObjBase
    {
        private static readonly Image Image = Image.FromFile(@"Images\Star.png");
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        { }
        /// <summary> Обновление звезды </summary>
        public override void Update()
        {
            pos.X += dir.X;
            pos.Y += dir.Y;
            if (pos.X + size.Width < 0)
                Reset();
        }
        /// <summary> Сброс на начало </summary>
        public override void Reset()
        {
            pos.X = Game.Size.Width + size.Width;
            pos.Y = Game.Rand.Next(Game.Size.Height - size.Height);
        }
        /// <summary> Отрисовка звезды </summary>
        /// <param name="g">Поверхность</param>
        public override void Draw(Graphics g)
        {
            g.DrawImage(Image, new Rectangle(pos, size));
        }
    }
}
