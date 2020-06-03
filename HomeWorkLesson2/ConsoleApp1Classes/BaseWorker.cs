using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1Classes
{
    /// <summary>
    /// Работник абстрактный
    /// </summary>
    abstract class BaseWorker : IComparable
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        protected BaseWorker(string surname, string name, int age)
        {
            Surname = surname;
            Name = name;
            Age = age;
        }
        public abstract double GetMoney();
        public int CompareTo(object obj)
        {
            return String.Compare(Surname, ((BaseWorker) obj).Surname, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
