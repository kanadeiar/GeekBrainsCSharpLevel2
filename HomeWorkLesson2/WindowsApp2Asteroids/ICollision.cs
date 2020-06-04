using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp2Asteroids
{
    /// <summary>
    /// Столкновение объектов
    /// </summary>
    interface ICollision
    {
        /// <summary> Границы </summary>
        Rectangle Rect { get; }
        /// <summary> Столкновение </summary>
        /// <param name="obj">Другой объект</param>
        /// <returns>Столкнулись</returns>
        bool Collision(ICollision obj);
    }
}
