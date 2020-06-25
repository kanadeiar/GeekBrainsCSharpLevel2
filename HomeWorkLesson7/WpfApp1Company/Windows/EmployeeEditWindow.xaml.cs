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
    /// Логика взаимодействия для EmployeeEditWindow.xaml
    /// </summary>
    public partial class EmployeeEditWindow : Window
    {
        /// <summary> Редактируемый сотрудник </summary>
        private DataRow _resultRow;
        /// <summary> Соединение с БД lesson7 </summary>
        private SqlConnection _connection;
        /// <summary> Адаптер отделов </summary>
        private SqlDataAdapter _adapterDep;
        /// <summary> Таблица отделов </summary>
        private DataTable _tableDep;
        public EmployeeEditWindow(DataRow dataRow, SqlConnection connection)
        {
            InitializeComponent();
            _resultRow = dataRow;
            _connection = connection;
        }
        private void EmployeeEditWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            TextBoxFam.Text = _resultRow["fam"].ToString();
            TextBoxName.Text = _resultRow["name"].ToString();
            TextBoxAge.Text = _resultRow["age"].ToString();
            TextBoxSalary.Text = _resultRow["salary"].ToString();
            _adapterDep = new SqlDataAdapter();
            SqlCommand command = new SqlCommand("SELECT id,department FROM Department;", _connection);
            _adapterDep.SelectCommand = command;
            _tableDep = new DataTable();
            _adapterDep.Fill(_tableDep);
            ComboBoxDepartament.ItemsSource = _tableDep.DefaultView;
            ComboBoxDepartament.DisplayMemberPath = "department";
            ComboBoxDepartament.SelectedValuePath = "id";
            ComboBoxDepartament.SelectedValue = _resultRow["department_id"];
        }
        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            _resultRow["fam"] = TextBoxFam.Text;
            _resultRow["name"] = TextBoxName.Text;
            _resultRow["age"] = TextBoxAge.Text;
            _resultRow["salary"] = TextBoxSalary.Text;
            _resultRow["department_id"] = ComboBoxDepartament.SelectedValue;
            DialogResult = true;
        }
        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
