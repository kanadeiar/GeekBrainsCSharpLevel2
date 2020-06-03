using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApp1Asteroids
{
    class Program
    {
        /// <summary>
        /// Задача 1.
        /// 1. Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон,
        /// похожий на полет в звездном пространстве.
        /// 2. * Заменить кружочки картинками, используя метод DrawImage.
        /// Рассахатский Андрей
        /// </summary>
        static void Main(string[] args)
        {
            Form form = new Form
            {
                Width = 1024,
                Height = 768,
                Text = "Geekbrains C# Уровень 2. Задачи № 1 и 2. Доработка игры \"Астероиды\"",
                StartPosition = FormStartPosition.CenterScreen,
            };
            SplashScreen.Init(form);
            Application.Run(form);
        }
    }
}
