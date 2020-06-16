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
        public List<Departament> Departaments { get; set; }
        public List<Employee> Employees { get; set; }
        public static (List<Departament>, List<Employee>) GetSamples()
        {
            List<Departament> listD = new List<Departament>
            {
                new Departament {Id = 1, Name = "Отдел финансов"},
                new Departament {Id = 2, Name = "Отдел маркетинга"},
                new Departament {Id = 3, Name = "Отдел рекламы"},
            };
            List<Employee> listE = new List<Employee>
            {
                new Employee {Fam = "Иванов", Name = "Иван", Age = 18, Salary = 12000, IdDepartament = 1},
                new Employee {Fam = "Федотов", Name = "Федот", Age = 18, Salary = 12000, IdDepartament = 1},
                new Employee {Fam = "Петров", Name = "Петя", Age = 18, Salary = 12000, IdDepartament = 1},
                new Employee {Fam = "Агафонов", Name = "Михаил", Age = 18, Salary = 12000, IdDepartament = 1},
                new Employee {Fam = "Яварова", Name = "Яна", Age = 18, Salary = 12000, IdDepartament = 1},
                new Employee {Fam = "Агафонова", Name = "Аня", Age = 18, Salary = 12000, IdDepartament = 1},
            };
            return (listD, listE);
        }
        public Company(string name)
        {
            Name = name;
            Departaments = new List<Departament>();
            Employees = new List<Employee>();
        }
    }
}
