using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    /// <summary> Сотрудник </summary>
    public class Employee
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
        /// <summary> Идентификатор отдела </summary>
        public int DepId { get; set; }
        #endregion
        private static SqlDataAdapter _adapter = new SqlDataAdapter();
        private static DataTable _table = new DataTable();
        static Employee()
        {
            SqlCommand command = new SqlCommand("SELECT id,fam,name,age,salary,department_id FROM Employee;", 
                DataBaseSource.Connection);
            _adapter.SelectCommand = command;
        }
        /// <summary> Все сотрудники </summary>
        public static IList<Employee> Employees => GetData();
        /// <summary> Один сотрудник </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Сотрудник</returns>
        public static Employee OneEmployee(int id)
        {
            return GetData().FirstOrDefault(e => e.Id == id);
        }
        private static IList<Employee> GetData()
        {
            _table.Clear();
            _adapter.Fill(_table);
            IList<Employee> employees = new List<Employee>();
            foreach (DataRow el in _table.Rows)
            {
                employees.Add(new Employee
                {
                    Id = Convert.ToInt32(el.ItemArray[0]),
                    Fam = el.ItemArray[1].ToString(),
                    Name = el.ItemArray[2].ToString(),
                    Age = Convert.ToInt32(el.ItemArray[3]),
                    Salary = Convert.ToInt32(el.ItemArray[4]),
                    DepId = Convert.ToInt32(el.ItemArray[5]),
                });
            }
            return employees;
        }
    }
}