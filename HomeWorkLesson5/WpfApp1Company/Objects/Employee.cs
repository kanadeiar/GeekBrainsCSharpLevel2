using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1Company.Objects
{
    /// <summary> Сотрудник компании </summary>
    public class Employee
    {
        /// <summary> Фамилия </summary>
        public string Fam { get; set; }
        /// <summary> Имя </summary>
        public string Name { get; set; }
        /// <summary> Возраст </summary>
        public int Age { get; set; }
        /// <summary> Зарплата </summary>
        public double Salary { get; set; }
        /// <summary> Идентификатор департамента </summary>
        public int IdDepartament { get; set; }
    }
}
