using System;
using System.Drawing;

namespace WindowsApp1Asteroids.Objects
{
    /// <summary> Космический корабль </summary>
    class Ship : ObjBase
    {
        private static readonly Image _image = Image.FromFile(@"Images\Ship.png");
        private bool up, down, left, right;
        /// <summary> Здоровье корабля </summary>
        public int Energy { get; set; } = 100;
        /// <summary> Счет игры </summary>
        public int Score { get; set; } = default;
        /// <summary> Сообщение о окончании игры </summary>
        public static event Action<string> MessageGameOver;
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        { }
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
                if (pos.X + size.Width < Game.Size.Width / 2) pos.X += dir.X;
            }
        }
        /// <summary> Сброс корабля </summary>
        public override void Reset()
        {
            MessageGameOver?.Invoke("Конец игры!");
        }
        /// <summary> Перерисование корабля </summary>
        /// <param name="g">Поверхность</param>
        public override void Draw(Graphics g)
        {
            g.DrawImage(_image, new Rectangle(pos, size));
            g.DrawRectangle(new Pen(Color.White), new Rectangle(pos.X, pos.Y - 10, 100, 6));
            g.DrawRectangle(new Pen(Color.GreenYellow), new Rectangle(pos.X + 2, pos.Y - 8, (int)(96 * (Energy / 100.0F)), 2 ));
        }
        ////////////////////////////////////////////////////////////
        // Команды перемещения корабля
        public void Up() => up = true;
        public void UpN() => up = false;
        public void Down() => down = true;
        public void DownN() => down = false;
        public void Left() => left = true;
        public void LeftN() => left = false;
        public void Right() => right = true;
        public void RightN() => right = false;
    }
}
