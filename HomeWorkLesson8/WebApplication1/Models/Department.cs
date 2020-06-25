using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    /// <summary> Отдел </summary>
    public class Department
    {
        #region Поля модели
        /// <summary> Идентификатор </summary>
        public int Id { get; set; }
        /// <summary> Название </summary>
        public string Dep { get; set; }
        #endregion
        private static SqlDataAdapter _adapter = new SqlDataAdapter();
        private static DataTable _table = new DataTable();
        static Department()
        {
            SqlCommand command = new SqlCommand("SELECT id,department FROM Department;", 
                DataBaseSource.Connection);
            _adapter.SelectCommand = command;
        }
        /// <summary> Все отделы </summary>
        public static IList<Department> Departments => GetTable();
        /// <summary> Один отдел </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>отдел</returns>
        public static Department OneDepartment(int id)
        {
            return GetTable().FirstOrDefault(d => d.Id == id);
        }
        private static IList<Department> GetTable()
        {
            _table.Clear();
            _adapter.Fill(_table);
            IList<Department> departments = new List<Department>();
            foreach (DataRow el in _table.Rows)
            {
                departments.Add(new Department
                {
                    Id = Convert.ToInt32(el.ItemArray[0]),
                    Dep = el.ItemArray[1].ToString(),
                });
            }
            return departments;
        }
    }
}