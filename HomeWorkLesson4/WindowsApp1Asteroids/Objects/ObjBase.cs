using System.Drawing;

namespace WindowsApp1Asteroids.Objects
{
    abstract class ObjBase : ICollision
    {
        protected Point pos;
        protected Point dir;
        protected Size size;
        /// <summary> Границы </summary>
        public Rectangle Rect => new Rectangle(pos, size);
        protected ObjBase(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }
        /// <summary> Обновение </summary>
        public abstract void Update();
        /// <summary> Сброс </summary>
        public abstract void Reset();
        /// <summary> Отрисовка </summary>
        /// <param name="g">Поверхность</param>
        public virtual void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.White, new Rectangle(pos, size));
        }
        /// <summary> Столкновение с другим </summary>
        /// <param name="obj">Другой</param>
        /// <returns>Столкновение!</returns>
        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }
    }
}
