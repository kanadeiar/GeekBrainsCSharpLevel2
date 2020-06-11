using System.Drawing;

namespace WindowsApp1Asteroids.Objects
{
    /// <summary> Столкновение </summary>
    interface ICollision
    {
        /// <summary> Границы </summary>
        Rectangle Rect { get; }
        /// <summary> Столкновение? </summary>
        /// <param name="obj">Другой</param>
        /// <returns>Столкновение!</returns>
        bool Collision(ICollision obj);
    }
}
