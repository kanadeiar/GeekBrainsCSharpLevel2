using System.Windows.Forms;

namespace WindowsApp3Asteroids
{
    class Program
    {
        /// <summary>
        /// Задачи 1-5.
        /// 1. Добавить космический корабль, как описано в уроке.
        /// 2. Доработать игру «Астероиды»:
        ///    a. Добавить ведение журнала в консоль с помощью делегатов;
        ///    b. * добавить это и в файл.
        /// 3. Разработать аптечки, которые добавляют энергию.
        /// 4. Добавить подсчет очков за сбитые астероиды.
        /// 5. * Добавить в пример Lesson3 обобщенный делегат.
        /// Рассахатский Андрей
        /// </summary>
        static void Main(string[] args)
        {
            Form form = new Form
            {
                Width = 1024,
                Height = 768,
                Text = "Методичка 3. Продвинутый курс C#. Задачи № 1 - 5. Доработка игры \"Астероиды\"",
                StartPosition = FormStartPosition.CenterScreen,
            };
            SplashScreen.Init(form);
            Application.Run(form);
        }
    }
}
