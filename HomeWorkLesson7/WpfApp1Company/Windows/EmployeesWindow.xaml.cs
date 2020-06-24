using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApp1Company.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeesWindow.xaml
    /// </summary>
    public partial class EmployeesWindow : Window
    {
        /// <summary> Соединение с БД lesson7 </summary>
        private SqlConnection _connection;
        /// <summary> Адаптер отделов </summary>
        private SqlDataAdapter _adapter;
        /// <summary> Таблица отделов </summary>
        private DataTable _table;
        public EmployeesWindow(SqlConnection connection)
        {
            InitializeComponent();
            _connection = connection;
        }
        private void EmployeesWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT id,fam,name,age,salary,department_id FROM Employee;", _connection);
            _adapter.SelectCommand = command;
            _table = new DataTable();
            _adapter.Fill(_table);
            DataGridEmployees.DataContext = _table.DefaultView;
        }
        /// <summary> Обновление данных на форме </summary>
        private void RefreshDataEmployees()
        {
            _table.Clear();
            _adapter.Fill(_table);
        }
        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            
        }


    }
}
