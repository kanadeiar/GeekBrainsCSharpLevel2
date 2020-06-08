using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp3Asteroids.Objects
{
    /// <summary> Аптечка </summary>
    class Energy : ObjBase
    {
        private static readonly Image image = Image.FromFile(@"Images\Energy.png");
        public Energy(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        /// <summary> Обновление состояния аптечки </summary>
        public override void Update()
        {
            pos.X += dir.X;
            pos.Y += dir.Y;
            if (pos.X + size.Width < 0)
                Reset();
        }
        /// <summary> Установка аптечки на начальную позицию </summary>
        public override void Reset()
        {
            pos.X = Game.Size.Width + size.Width + Game.Rand.Next(Game.Size.Width);
            pos.Y = Game.Rand.Next(Game.Size.Height - size.Height);
        }
        /// <summary> Перерисование аптечки </summary>
        /// <param name="g">Поверхность</param>
        public override void Draw(Graphics g)
        {
            g.DrawImage(image, new Rectangle(pos, size));
        }
    }
}
