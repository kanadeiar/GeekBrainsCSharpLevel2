using System.Drawing;
using System.Drawing.Imaging;

namespace WindowsApp1Asteroids.Objects
{
    /// <summary> Астероид </summary>
    internal class Asteroid : Star
    {
        //массив изображений астероидов покадрово
        private static readonly Image[,] _astImages;
        //количество кадров
        private static readonly int _cadrSize = 16;
        /// <summary> количество разновидностей астероидов </summary>
        public static int CountImages => _astImages.GetLength(0);
        static Asteroid()
        {
            _astImages = new Image[5,_cadrSize];
            for (int i = 0; i < _astImages.GetLength(0); i++)
            {
                Image image = Image.FromFile($@"Images\Asteroid{i+1}Animation.png");
                for (int j = 0; j < _cadrSize; j++)
                {
                    Rectangle rectangle = new Rectangle(j*100,0,100,100);
                    Bitmap pic = (Bitmap)image;
                    _astImages[i,j] = pic.Clone(rectangle, PixelFormat.Format32bppArgb);
                }
            }
        }
        //текущий вид астероида
        private int _currentImage;
        //текущий кадр
        private float _currCadr = 0.0F;
        //скорость смещения кадров
        private float _cadrDir = -0.2F;
        public Asteroid(Point pos, Point dir, Size size, int currentImage) : base(pos, dir, size)
        {
            _currentImage = currentImage;
        }
        /// <summary> Сброс на начало </summary>
        public override void Reset()
        {
            pos.X = Game.Size.Width + size.Width + Game.Rand.Next(Game.Size.Width);
            pos.Y = Game.Rand.Next(Game.Size.Height - size.Height);
            _currentImage = Game.Rand.Next(CountImages);
        }
        /// <summary> Отрисовка астероида </summary>
        /// <param name="g">Поверхность</param>
        public override void Draw(Graphics g)
        {
            g.DrawImage(_astImages[_currentImage,(int)_currCadr], new Rectangle(pos, size));
            _currCadr += _cadrDir;
            if (_currCadr >= _cadrSize)
                _currCadr = 0;
            if (_currCadr < 0)
                _currCadr = _cadrSize - 1;
        }
    }
}
