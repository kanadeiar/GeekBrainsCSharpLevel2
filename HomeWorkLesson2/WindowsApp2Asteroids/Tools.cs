using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp2Asteroids
{
    /// <summary>
    /// Полезные инструменты
    /// </summary>
    static class Tools
    {
        /// <summary>
        /// Поворот изображения
        /// </summary>
        /// <param name="image">изображение</param>
        /// <param name="offset">Точка поворота</param>
        /// <param name="angle">Угол поворота</param>
        /// <returns>Повернутое изображение</returns>
        public static Bitmap RotateBitmap(Image image, PointF offset, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            Graphics g = Graphics.FromImage(rotatedBmp);
            g.TranslateTransform(offset.X, offset.Y);
            g.RotateTransform(angle);
            g.TranslateTransform(-offset.X, -offset.Y);
            g.DrawImage(image, new PointF(0, 0));
            return rotatedBmp;
        }
    }
}
