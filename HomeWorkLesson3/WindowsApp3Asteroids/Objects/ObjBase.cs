using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp3Asteroids.Objects
{
    /// <summary> Базовый объект </summary>
    abstract class ObjBase : ICollision
    {
        protected Point pos;
        protected Point dir;
        protected Size size;
        public Rectangle Rect => new Rectangle(pos, size);
        protected ObjBase(Point pos, Point dir, Size size)
        {
            
            
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }
        /// <summary> Обновление состояния </summary>
        public abstract void Update();
        /// <summary> Сброк на старт </summary>
        public abstract void Reset();
        /// <summary> Отрисовка объекта </summary>
        /// <param name="g">Поверзность</param>
        public virtual void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.White, new Rectangle(pos, size));
        }
        /// <summary> Столкновение с другим </summary>
        /// <param name="obj">Другой объект</param>
        /// <returns>Столкнулись</returns>
        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }
    }
}
