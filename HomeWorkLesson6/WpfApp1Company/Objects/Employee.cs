using System;
using System.ComponentModel;
using System.Linq;

namespace WpfApp1Company.Objects
{
    /// <summary> Сотрудник компании </summary>
    public class Employee : INotifyPropertyChanged
    {
        private int _id;
        private string _fam;
        private string _name;
        private int _age;
        private double _salary;
        private int _departmentId;
        public Employee() { }
        public Employee(int id, string fam, string name, int age, double salary, int departmentId)
        {
            _id = id;
            _fam = fam;
            _name = name;
            _age = age;
            _salary = salary;
            _departmentId = departmentId;
        }
        #region Свойства зависимостей
        /// <summary> Ид </summary>
        public int Id
        {
            get => _id;
            set
            {
                if (this._id != value)
                {
                    this._id = value;
                    this.NotifyPropertyChanged("Id");
                }
            }
        }
        /// <summary> Фамилия </summary>
        public string Fam
        {
            get => _fam;
            set
            {
                if (this._fam != value)
                {
                    this._fam = value;
                    this.NotifyPropertyChanged("Fam");
                }
            }
        }
        /// <summary> Имя </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (this._name != value)
                {
                    this._name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }
        /// <summary> Возраст </summary>
        public int Age
        {
            get => _age;
            set
            {
                if (this._age != value)
                {
                    this._age = value;
                    this.NotifyPropertyChanged("Age");
                }
            }
        }
        /// <summary> Зарплата </summary>
        public double Salary
        {
            get => _salary;
            set
            {
                if (Math.Abs(this._salary - value) > 0.1)
                {
                    this._salary = value;
                    this.NotifyPropertyChanged("Salary");
                }
            }
        }
        /// <summary> Отдел </summary>
        public int DepartmentId
        {
            get => _departmentId;
            set
            {
                if (this._departmentId != value)
                {
                    this._departmentId = value;
                    this.NotifyPropertyChanged("DepartmentId");
                }
            }
        }
        /// <summary> Отдел из коллекции отделов </summary>
        public Department Department
        {
            get => Company.Departments.First(d => d.Id == _departmentId);
            set
            {
                var valueId = Company.Departments.First(d => d == value).Id;
                if (this._departmentId != valueId)
                {
                    this._departmentId = valueId;
                    this.NotifyPropertyChanged("Departament");
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
