using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp1Asteroids.Objects
{
    /// <summary>
    /// Базовая фигура пространства
    /// </summary>
    class BaseObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;
        protected BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }
        /// <summary>
        /// Обновление объекта - заглушки
        /// </summary>
        public virtual void Update()
        {
            pos.X += dir.X;
            pos.Y += dir.Y;
            if (pos.X < 0) dir.X = -dir.X;
            if (pos.X + size.Width > Game.Width) dir.X = -dir.X;
            if (pos.Y < 0) dir.Y = -dir.Y;
            if (pos.Y + size.Height > Game.Height) dir.Y = -dir.Y;
        }
        /// <summary>
        /// Отрисовка объекта - заглушки
        /// </summary>
        public virtual void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.White, new Rectangle(pos,size));
        }
    }
}
