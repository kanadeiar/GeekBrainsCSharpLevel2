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
        
        public int Energy { get; set; } = 100;
        public int Score { get; set; } = default;
        private bool up, down, left, right;
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
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
                if (pos.X + size.Width < Game.Size.Width) pos.X += dir.X;
            }
        }

        public override void Reset()
        {
            
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(image, new Rectangle(pos, size));
        }

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
