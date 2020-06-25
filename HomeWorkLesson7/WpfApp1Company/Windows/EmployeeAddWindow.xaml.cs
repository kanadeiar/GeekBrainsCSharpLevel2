using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApp1Company.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAddWindow.xaml
    /// </summary>
    public partial class EmployeeAddWindow : Window
    {
        /// <summary> Добавляемый сотрудник </summary>
        private DataRow _resultRow;
        /// <summary> Соединение с БД lesson7 </summary>
        private SqlConnection _connection;
        /// <summary> Адаптер отделов </summary>
        private SqlDataAdapter _adapterDep;
        /// <summary> Таблица отделов </summary>
        private DataTable _tableDep;
        public EmployeeAddWindow(DataRow dataRow, SqlConnection connection)
        {
            InitializeComponent();
            _resultRow = dataRow;
            _connection = connection;
        }
        private void EmployeeAddWindow_OnLoaded(object sender, RoutedEventArgs e)
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
        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
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
