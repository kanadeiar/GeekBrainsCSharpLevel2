using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1Company.Objects;

namespace WpfApp1Company
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Задачи 1-4.
        /// Создать WPF-приложение для ведения списка сотрудников компании.
        /// Создать сущности Employee и Department и заполнить списки
        /// сущностей начальными данными.
        /// Для списка сотрудников и списка департаментов предусмотреть
        /// визуализацию (отображение). Это можно сделать, например, с
        /// использованием ComboBox или ListView.
        /// Предусмотреть редактирование сотрудников и департаментов.
        /// Должна быть возможность изменить департамент у сотрудника.
        /// Список департаментов для выбора можно выводить в ComboBox, и
        /// все это можно выводить на дополнительной форме.
        /// Предусмотреть возможность создания новых сотрудников и
        /// департаментов.
        /// Реализовать это либо на форме редактирования, либо сделать
        /// новую форму.
        /// Рассахатский
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Company company = new Company("Пупкин и Ко.");
            (company.Departaments, company.Employees) = Company.GetSamples();


        }
    }
}
