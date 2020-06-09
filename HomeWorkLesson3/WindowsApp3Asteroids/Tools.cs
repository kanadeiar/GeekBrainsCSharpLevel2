using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp3Asteroids
{
    /// <summary> Полезные инструменты </summary>
    static class Tools
    {
        private static readonly Bitmap rotatedBmpAsteroid = new Bitmap(100, 100);
        /// <summary> Поворот изображения астероида</summary>
        /// <param name="image">изображение</param>
        /// <param name="offset">Точка поворота</param>
        /// <param name="angle">Угол поворота</param>
        /// <returns>Повернутое изображение</returns>
        public static Bitmap RotateBitmapAsteroid(Image image, PointF offset, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            rotatedBmpAsteroid.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            Graphics g = Graphics.FromImage(rotatedBmpAsteroid);
            g.Clear(Color.Transparent);
            g.TranslateTransform(offset.X, offset.Y);
            g.RotateTransform(angle);
            g.TranslateTransform(-offset.X, -offset.Y);
            g.DrawImage(image, new PointF(0, 0));
            return rotatedBmpAsteroid;
        }
    }
}
