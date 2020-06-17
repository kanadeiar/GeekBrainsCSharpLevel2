using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1Company.Objects
{
    /// <summary>
    /// Компания
    /// </summary>
    public class Company
    {
        /// <summary> Название </summary>
        public string Name { get; set; }
        public List<Departament> Departments { get; set; }
        public List<Employee> Employees { get; set; }
        public static (List<Departament>, List<Employee>) GetSamples()
        {
            List<Departament> listD = new List<Departament>
            {
                new Departament {Id = 1, Name = "Отдел шарпистов"},
                new Departament {Id = 2, Name = "Отдел игродела"},
                new Departament {Id = 3, Name = "Отдел веба"},
            };
            List<Employee> listE = new List<Employee>
            {
                new Employee {Fam = "Шмачилин", Name = "Павел", Age = 18, Salary = 12000, IdDepartament = 1},
                new Employee {Fam = "Камянецкий", Name = "Сергей", Age = 22, Salary = 18000, IdDepartament = 2},
                new Employee {Fam = "Муратов", Name = "Роман", Age = 19, Salary = 10000, IdDepartament = 2},
                new Employee {Fam = "Феофанов", Name = "Илья", Age = 26, Salary = 15000, IdDepartament = 3},
                new Employee {Fam = "Другов", Name = "Антон", Age = 38, Salary = 32000, IdDepartament = 3},
                new Employee {Fam = "Зарядный", Name = "Андрей", Age = 28, Salary = 22000, IdDepartament = 3},
            };
            return (listD, listE);
        }
        public Company(string name)
        {
            Name = name;
            Departments = new List<Departament>();
            Employees = new List<Employee>();
        }
    }
}
