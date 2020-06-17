using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1Company.Objects;

namespace WpfApp1Company.Objects
{
    /// <summary> Сотрудник компании </summary>
    public class Employee : INotifyPropertyChanged
    {
        private string fam;
        private string name;
        private int age;
        private double salary;
        private Department department;
        #region Свойства зависимостей
        /// <summary> Фамилия </summary>
        public string Fam
        {
            get => fam;
            set
            {
                if (this.fam != value)
                {
                    this.fam = value;
                    this.NotifyPropertyChanged("Fam");
                }
            }
        }
        /// <summary> Имя </summary>
        public string Name
        {
            get => name;
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }
        /// <summary> Возраст </summary>
        public int Age
        {
            get => age;
            set
            {
                if (this.age != value)
                {
                    this.age = value;
                    this.NotifyPropertyChanged("Age");
                }
            }
        }
        /// <summary> Зарплата </summary>
        public double Salary
        {
            get => salary;
            set
            {
                if (this.salary != value)
                {
                    this.salary = value;
                    this.NotifyPropertyChanged("Salary");
                }
            }
        }
        /// <summary> Отдел </summary>
        public Department Department
        {
            get => department;
            set
            {
                if (this.department != value)
                {
                    this.department = value;
                    this.NotifyPropertyChanged("Department");
                }
            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string prop)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
