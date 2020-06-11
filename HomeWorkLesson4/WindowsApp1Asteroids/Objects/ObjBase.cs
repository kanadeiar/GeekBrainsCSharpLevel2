using System.Drawing;

namespace WindowsApp1Asteroids.Objects
{
    abstract class ObjBase : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        /// <summary> Границы </summary>
        public Rectangle Rect => new Rectangle(Pos, Size);
        protected ObjBase(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        /// <summary> Обновение </summary>
        public abstract void Update();
        /// <summary> Сброс </summary>
        public abstract void Reset();
        /// <summary> Отрисовка </summary>
        /// <param name="g">Поверхность</param>
        public virtual void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.White, new Rectangle(Pos, Size));
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
