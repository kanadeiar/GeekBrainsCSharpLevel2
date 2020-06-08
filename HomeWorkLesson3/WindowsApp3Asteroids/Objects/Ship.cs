using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp3Asteroids.Objects
{
    /// <summary> Космический корабль </summary>
    class Ship : ObjBase
    {
        private static Image image = Image.FromFile("Images\\Ship.png");
        /// <summary> Здровье корабля </summary>
        public int Energy { get; set; } = 100;
        /// <summary> Количество сбитых астероидов </summary>
        public int Score { get; set; } = default;
        private bool up, down, left, right;
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        /// <summary> Обновление корабля </summary>
        public override void Update()
        {
            if (up)
            {
                if (pos.Y > 0) pos.Y -= dir.Y;
            }
            else if (down)
            {
                if (pos.Y + size.Height < Game.Size.Height) pos.Y += dir.Y;
            }
            if (left)
            {
                if (pos.X > 5) pos.X -= dir.X;
            }
            else if (right)
            {
                if (pos.X + size.Width < Game.Size.Width/2) pos.X += dir.X;
            }
        }
        /// <summary> Уничтожение корабля </summary>
        public override void Reset()
        { }
        /// <summary> Перерисование корабля </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            g.DrawImage(image, new Rectangle(pos, size));
            g.DrawString($"Энергия: {Energy}", new Font(FontFamily.GenericSansSerif, 10), Brushes.White, pos.X, pos.Y - 30);
            g.DrawRectangle(new Pen(Color.White), new Rectangle(pos.X, pos.Y - 10, 100, 6));
            g.DrawRectangle(new Pen(Color.GreenYellow), new Rectangle(pos.X+2, pos.Y - 8, (int)(96 * (Energy / 100.0)), 2));
        }
        ///////////////////////////////////////////////////////////////
        // Команды перемещения корабля
        public void Up() => up = true;
        public void UpOff() => up = false;
        public void Down() => down = true;
        public void DownOff() => down = false;
        public void Left() => left = true;
        public void LeftOff() => left = false;
        public void Right() => right = true;
        public void RightOff() => right = false;
    }
}
