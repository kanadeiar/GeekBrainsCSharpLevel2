﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp3Asteroids.Objects
{
    /// <summary> Пуля </summary>
    class Bullet : ObjBase
    {
        private static readonly Image image = Image.FromFile(@"Images\Bullet.png");
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        /// <summary> Просьба удалить пулю </summary>
        public bool DeleteMe { get; set; } = false;
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
            g.DrawImage(image, new Rectangle(pos, size));
        }
    }
}
