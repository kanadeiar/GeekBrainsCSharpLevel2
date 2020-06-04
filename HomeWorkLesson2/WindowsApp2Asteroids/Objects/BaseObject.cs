using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp2Asteroids.Objects
{
    /// <summary>
    /// Базовая фигура пространства
    /// </summary>
    abstract class BaseObject : ICollision
    {
        protected Point pos;
        protected Point dir;
        protected Size size;
        public Rectangle Rect => new Rectangle(pos, size);
        protected BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }
        /// <summary> Обновление состояния </summary>
        public abstract void Update();
        /// <summary> Установка в начальную позицию </summary>
        public abstract void Reset();
        /// <summary> Отрисовка на графической поверхности </summary>
        /// <param name="g">Поверхность</param>
        public virtual void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.White, new Rectangle(pos, size));
        }
        /// <summary> Столкновение с другим объектом </summary>
        /// <param name="obj">другой объект</param>
        /// <returns>столкнулись</returns>
        public virtual bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }
    }
}
