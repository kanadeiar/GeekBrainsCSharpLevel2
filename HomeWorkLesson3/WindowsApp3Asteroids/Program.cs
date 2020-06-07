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
                Text = "Методичка 3. Продвинутый курс C#. Задачи № 1 - 5. Доработка игры \"Астероиды\"",
                StartPosition = FormStartPosition.CenterScreen,
            };
            SplashScreen.Init(form);
            Application.Run(form);
        }
    }
}
