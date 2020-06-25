using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Configuration;
using WpfApp1Company.Windows;

namespace WpfApp1Company
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Задачи 1-4.
        /// Изменить WPF-приложение для ведения списка сотрудников компании (из урока 5), используя связывание данных,
        /// DataGrid и ADO.NET.
        /// 1. Создать сущности Employee и Department и заполнить списки сущностей начальными данными.
        /// 2. Для списка сотрудников и списка департаментов предусмотреть визуализацию (отображение). Это можно
        /// сделать, например, с использованием ComboBox или ListView.
        /// 3. Предусмотреть редактирование сотрудников и департаментов. Должна быть возможность изменить департамент
        /// у сотрудника. Список департаментов для выбора можно выводить в ComboBox, и все это можно выводить на
        /// дополнительной форме.
        /// 4. Предусмотреть возможность создания новых сотрудников и департаментов. Реализовать это либо на форме
        /// редактирования, либо сделать
        /// новую форму.
        /// Рассахатский
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary> Соединение с БД lesson7 </summary>
        private SqlConnection _connection;
        /// <summary> Адаптер представления всех сотрудников с отделами </summary>
        private SqlDataAdapter _adapter;
        /// <summary> Таблица всех сотрудников с отделами </summary>
        private DataTable _table;
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            CreateConnectionToDataBase();
            DataGridViewEmployees.DataContext = _table;
        }
        #region Работа с БД
        /// <summary> Установка соединения с базой данных </summary>
        private void CreateConnectionToDataBase()
        {
            try
            {
                AppSettingsReader ar = new AppSettingsReader();
                var connBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = (string) ar.GetValue("DataSource", typeof(string)),
                    InitialCatalog = (string) ar.GetValue("InitialCatalog", typeof(string)),
                    IntegratedSecurity = true,
                    Pooling = true,
                };
                string connectionString = connBuilder.ConnectionString;
                _connection = new SqlConnection(connectionString);
                _connection.StateChange += (s, e0) =>
                {
                    var c = s as SqlConnection;
                    TextSource.Text = $"Источник данных: {c.DataSource}";
                    TextStatus.Text = $"Состояние соединения: {e0.CurrentState}";
                };
                _adapter = new SqlDataAdapter();
                SqlCommand selectCommand =
                    new SqlCommand(
                        "SELECT e.id,e.fam,e.name,e.age,e.salary,d.department FROM Employee e INNER JOIN Department d ON e.department_id=d.id;",
                        _connection);
                _adapter.SelectCommand = selectCommand;
                _table = new DataTable();
                _adapter.Fill(_table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка связи с базой данных!\nРаботы программы невозможна.\n" + ex.Message,
                    "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }
        /// <summary> Обновление сведений в таблице БД </summary>
        public void RefreshDataEmployees()
        {
            _table.Clear();
            _adapter.Fill(_table);
        }
        #endregion
        private void ButtonRefresh_OnClick(object sender, RoutedEventArgs e)
        {
            RefreshDataEmployees();
        }
        private void ButtonDepartments_OnClick(object sender, RoutedEventArgs e)
        {
            DepartmentsWindow departmentsWindow = new DepartmentsWindow(_connection);
            departmentsWindow.ShowDialog();
            RefreshDataEmployees();
        }
        private void ButtonEmployees_OnClick(object sender, RoutedEventArgs e)
        {
            EmployeesWindow employeesWindow = new EmployeesWindow(_connection);
            employeesWindow.ShowDialog();
            RefreshDataEmployees();
        }

    }
}
