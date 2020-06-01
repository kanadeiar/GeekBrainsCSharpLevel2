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
        static void Main(string[] args)
        {
            Form form = new Form
            {
                Width = 1024,
                Height = 768,
                Text = "Geekbrains C# Уровень 2. Задачи № 1 и 2. Доработка игры \"Астероиды\"",
                StartPosition = FormStartPosition.CenterScreen,
            };
            //Game.Init(form);
            //form.Show();
            //Game.Draw();
            SplashScreen.Init(form);
            Application.Run(form);
        }
    }
}
