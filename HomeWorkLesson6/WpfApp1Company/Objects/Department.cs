using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApp1Company.Objects
{
    /// <summary> Отдел компании </summary>
    public class Department : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        public ObservableCollection<Employee> Employees { get; set; }
        #region Свойства зависимостей
        /// <summary> Название отдела </summary>
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
        /// <summary> Название отдела </summary>
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
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string prop)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
