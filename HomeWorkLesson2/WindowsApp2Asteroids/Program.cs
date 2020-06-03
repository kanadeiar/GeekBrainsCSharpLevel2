using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApp2Asteroids
{
    class Program
    {
        /// <summary>
        /// Задачи 2, 3, 4 и 5.
        /// 2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
        /// 3. Сделать так, чтобы при столкновении пули с астероидом они регенерировались в разных концах экрана.
        /// 4. Сделать проверку на задание размера экрана в классе Game. Если высота или ширина (Width, Height) 
        ///    больше 1000 или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException().
        /// 5. *Создать собственное исключение GameObjectException, которое появляется при попытке  создать 
        ///    объект с неправильными характеристиками (например, отрицательные размеры, слишком большая скорость 
        ///    или неверная позиция).
        /// Рассахатский Андрей
        /// </summary>
        static void Main(string[] args)
        {
            Form form = new Form
            {
                Width = 1024,
                Height = 768,
                Text = "Geekbrains C# Уровень 2. Методичка 2. Задачи № 2, 3, 4 и 5. Доработка игры \"Астероиды\"",
                StartPosition = FormStartPosition.CenterScreen,
            };

            Application.Run(form);
        }
    }
}
