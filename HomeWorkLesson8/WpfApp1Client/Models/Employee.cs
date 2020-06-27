using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1Client.Models
{
    /// <summary> Сотрудник </summary>
    class Employee
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
    }
}
