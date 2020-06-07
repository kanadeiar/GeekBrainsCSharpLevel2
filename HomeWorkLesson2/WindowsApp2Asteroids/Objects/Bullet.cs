using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp2Asteroids.Objects
{
    /// <summary>
    /// Пуля
    /// </summary>
    class Bullet : BaseObject
    {
        private static readonly Image drawImage = Image.FromFile(@"Images\Bullet.png");
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        /// <summary> Обновление состояния пули </summary>
        public override void Update()
        {
            pos.X += dir.X;
            pos.Y += dir.Y;
            if (pos.X > Game.Width)
                Reset();
        }
        /// <summary> Установка объекта на начальную позицию </summary>
        public override void Reset()
        {
            pos.X = 0;
            pos.Y = Game.Height / 2;
        }
        /// <summary> Пререрисовка пули </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            g.DrawImage(drawImage, new Rectangle(pos, size));
        }
    }
}
