using System.ComponentModel;

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
        private Department _department;
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
                if (this._salary != value)
                {
                    this._salary = value;
                    this.NotifyPropertyChanged("Salary");
                }
            }
        }
        /// <summary> Отдел </summary>
        public Department Department
        {
            get => _department;
            set
            {
                if (this._department != value)
                {
                    this._department = value;
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
