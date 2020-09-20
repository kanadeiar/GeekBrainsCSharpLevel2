using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    /// <summary> Сотрудники с отделами </summary>
    public class EmployeeView
    {
        #region Поля модели
        /// <summary> Идентификатор </summary>
        public int Id { get; set; }
        /// <summary> Фамилия </summary>
        public string Fam { get; set; }
        /// <summary> Имя </summary>
        public string Name { get; set; }
        /// <summary> Возраст </summary>
        public int Age { get; set; }
        /// <summary> Зарплата </summary>
        public int Salary { get; set; }
        /// <summary> Отдел </summary>
        public string Dep { get; set; }
        #endregion
        /// <summary> Все сотрудники </summary>
        public static IList<EmployeeView> EmployeeViews => GetData();
        /// <summary>
        /// Один сотрудник
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Сотрудник</returns>
        public static EmployeeView OneEmployeeView(int id)
        {
            return GetData().FirstOrDefault(e => e.Id == id);
        }
        private static IList<EmployeeView> GetData()
        {
            IList<EmployeeView> employeeViews = new List<EmployeeView>();
            var emps = Employee.Employees;
            foreach (Employee el in emps)
            {
                employeeViews.Add(new EmployeeView
                {
                    Id = el.Id,
                    Fam = el.Fam,
                    Name = el.Name,
                    Age = el.Age,
                    Salary = el.Salary,
                    Dep = Department.OneDepartment(el.DepId).Dep,
                });
            }
            return employeeViews;
        }
    }
}