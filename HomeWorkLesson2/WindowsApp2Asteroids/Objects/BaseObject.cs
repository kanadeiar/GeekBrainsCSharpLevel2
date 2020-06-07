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
            if (pos.X>9000 || pos.X<0 || pos.Y>9000 || pos.Y<0) throw new Exceptions.GameObjectException("Неверная позиция объекта","pos");
            if (dir.X>9000 || dir.X<-9000 || dir.Y>9000 || dir.Y<-9000) throw new Exceptions.GameObjectException("Неверная скорость движения","dir");
            if (size.Width>9000 || size.Width<1 || size.Height>9000 || size.Height<1) throw new Exceptions.GameObjectException("Неверные размеры объекта","size");
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
