using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace WpfApp1Company.Windows
{
    /// <summary>
    /// Логика взаимодействия для DepartmentsWindow.xaml
    /// </summary>
    public partial class DepartmentsWindow : Window
    {
        /// <summary> Соединение с БД lesson7 </summary>
        private SqlConnection _connection;
        /// <summary> Адаптер отделов </summary>
        private SqlDataAdapter _adapter;
        /// <summary> Таблица отделов </summary>
        private DataTable _table;
        public DepartmentsWindow(SqlConnection Connection)
        {
            InitializeComponent();
            _connection = Connection;
        }
        private void DepartmentsWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _adapter = new SqlDataAdapter();
            SqlCommand selectCommand = new SqlCommand("SELECT id,department FROM Department;", _connection);
            _adapter.SelectCommand = selectCommand;
            _table = new DataTable();
            _adapter.Fill(_table);
            DataGridDepartments.DataContext = _table.DefaultView;
        }
        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            DataRow newRow = _table.NewRow();
            DepartmentAddWindow departmentAddWindow = new DepartmentAddWindow(newRow);
            departmentAddWindow.ShowDialog();
            if (departmentAddWindow.DialogResult.HasValue && departmentAddWindow.DialogResult.Value)
            {
                _table.Rows.Add(newRow);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(_adapter);
                try
                {
                    _adapter.Update(_table);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }
        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
