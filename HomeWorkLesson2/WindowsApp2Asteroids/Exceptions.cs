using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp2Asteroids
{
    static class Exceptions
    {
        /// <summary>
        /// Пользовательское исключение
        /// </summary>
        public class GameObjectException : ApplicationException
        {
            public string Details {get;set;}
            public GameObjectException(string message, string details) : base(message)
            {
                Details = details;
            }
        }
    }
}
