using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApp1Company.Objects
{
    /// <summary>
    /// Компания
    /// </summary>
    public class Company : INotifyPropertyChanged
    {
        private string _name;
        #region Свойства зависимостей
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
        #endregion
        public ObservableCollection<Department> Departments { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        /// <summary> Тестовые данные </summary>
        /// <returns>Две наблюдаемые коллекции с тестовыми данными</returns>
        public static (ObservableCollection<Department>, ObservableCollection<Employee>) GetSamples()
        {
            var collE = new ObservableCollection<Employee>()
            {
                new Employee {Fam = "Заярный", Name = "Андрей", Age = 20, Salary = 10_000.0},
                new Employee {Fam = "Камянецкий", Name = "Сергей", Age = 22, Salary = 20_000.0},
                new Employee {Fam = "Муратов", Name = "Роман", Age = 18, Salary = 25_000.0},
                new Employee {Fam = "Феофанов", Name = "Илья", Age = 19, Salary = 30_000.0},
                new Employee {Fam = "Другов", Name = "Антон", Age = 21, Salary = 25_000.0},
                new Employee {Fam = "Шмачилин", Name = "Павел", Age = 23, Salary = 20_000.0},
            };
            var collD = new ObservableCollection<Department>()
            {
                new Department
                {
                    Name = "Питонщики", Employees = new ObservableCollection<Employee>{collE[0]},
                },
                new Department
                {
                    Name = "Шарписты", Employees = new ObservableCollection<Employee>{collE[1], collE[2]},
                },
                new Department
                {
                    Name = "Джависты", Employees = new ObservableCollection<Employee>{collE[3], collE[4], collE[5]},
                },
            };
            collE[0].Department = collD[0];
            collE[1].Department = collD[1];
            collE[2].Department = collD[1];
            collE[3].Department = collD[2];
            collE[4].Department = collD[2];
            collE[5].Department = collD[2];
            return (collD, collE);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string prop)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
