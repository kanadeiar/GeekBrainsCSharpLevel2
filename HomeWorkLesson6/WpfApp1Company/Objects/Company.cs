using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApp1Company.Objects
{
    /// <summary>
    /// Компания
    /// </summary>
    public static class Company
    {
        public static ObservableCollection<Department> Departments { get; set; }
        public static ObservableCollection<Employee> Employees { get; set; }
        static Company()
        { }
        #region Тестовые данные
        /// <summary> Тестовые данные </summary>
        /// <returns>Две наблюдаемые коллекции с тестовыми данными</returns>
        public static (ObservableCollection<Department>, ObservableCollection<Employee>) GetSamples()
        {
            Random rand = new Random();
            int sizeDeps = 100;
            int sizeEmpl = 1_000;
            var collD = new ObservableCollection<Department>();
            for (int i = 0; i < sizeDeps; i++)
            {
                collD.Add(new Department(i + 1, $"Отдел теста {rand.Next(1000)}"));
            }
            var collE = new ObservableCollection<Employee>();
            for (int i = 0; i < sizeEmpl; i++)
            {
                collE.Add(new Employee(i + 1, $"Тестов{rand.Next(1000)}", $"Тест{rand.Next(1000)}", rand.Next(18, 90), rand.Next(50_000), rand.Next(1, sizeDeps + 1)));
            }
            return (collD, collE);
        }
        #endregion
    }
}
