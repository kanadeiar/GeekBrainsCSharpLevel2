using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApp3Asteroids
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        static void Main(string[] args)
        {
            Form form = new Form
            {
                Width = 1024,
                Height = 768,
                Text = "Geekbrains C# Уровень 2. Методичка 2. Задачи № 1 - 5. Доработка игры \"Астероиды\"",
                StartPosition = FormStartPosition.CenterScreen,
            };

            form.Show();

            Application.Run(form);
        }
    }
}
