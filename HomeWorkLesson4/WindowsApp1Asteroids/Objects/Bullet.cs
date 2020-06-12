using System.Drawing;

namespace WindowsApp1Asteroids.Objects
{
    /// <summary> Пуля </summary>
    class Bullet :ObjBase
    {
        private static readonly Image _image = Image.FromFile(@"Images\Bullet.png");
        /// <summary> Команда удалить пулю </summary>
        public bool DeleteMe { get; set; } = false;
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        { }
        /// <summary> Обновление пули </summary>
        public override void Update()
        {
            pos.X += dir.X;
            pos.Y += dir.Y;
            if (pos.X > Game.Size.Width)
                Reset();
        }
        /// <summary> Удаление пули </summary>
        public override void Reset()
        {
            DeleteMe = true;
        }
        /// <summary> Отрисовка пули </summary>
        /// <param name="g">Поверхность</param>
        public override void Draw(Graphics g)
        {
            g.DrawImage(_image, new Rectangle(pos, size));
        }
    }
}
