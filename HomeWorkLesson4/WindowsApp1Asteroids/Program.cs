using System.Drawing;
using System.Windows.Forms;

namespace WindowsApp1Asteroids
{
    class Program
    {
        /// <summary>
        /// Задача № 1.
        /// 1. Добавить в программу коллекцию астероидов. Как только она
        /// заканчивается (все астероиды сбиты), формируется новая коллекция,
        /// в которой на один астероид больше.
        /// Рассахатский Андрей
        /// </summary>
        static void Main(string[] args)
        {
            Form form = new Form
            {
                Width = 1024,
                Height = 768,
                Text = "Методичка 4. Продвинутый курс C#. Задача № 1. Доработка игры \"Астероиды\"",
                StartPosition = FormStartPosition.CenterScreen,
                Icon = Icon.ExtractAssociatedIcon(@"Images\Avatar.ico"),
            };
            SplashScreen.Init(form);

            Application.Run(form);
        }
    }
}
