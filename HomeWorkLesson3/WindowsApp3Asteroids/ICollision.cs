using System.Drawing;

namespace WindowsApp3Asteroids
{
    /// <summary> Столкновение </summary>
    internal interface ICollision
    {
        /// <summary> Границы </summary>
        Rectangle Rect { get; }

        /// <summary> Столкновение </summary>
        /// <param name="obj">Другой объект</param>
        /// <returns>Столкнулись</returns>
        bool Collision(ICollision obj);
    }
}