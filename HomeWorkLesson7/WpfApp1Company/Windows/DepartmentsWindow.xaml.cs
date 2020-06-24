using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

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
        /// <summary> Обновление данных на форме </summary>
        private void RefreshDataDepartments()
        {
            _table.Clear();
            _adapter.Fill(_table);
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
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка добавления нового отдела\n" + ex.Message, "Ошибка добавления отдела",
                        MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
            RefreshDataDepartments();
        }
        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            DataRowView selectRow = (DataRowView)DataGridDepartments.SelectedItem;
            if (selectRow == null)
            {
                return;
            }
            selectRow.BeginEdit();
            DepartmentEditWindow departmentEditWindow = new DepartmentEditWindow(selectRow.Row);
            departmentEditWindow.ShowDialog();
            if (departmentEditWindow.DialogResult.HasValue && departmentEditWindow.DialogResult.Value)
            {
                selectRow.EndEdit();
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(_adapter);
                try
                {
                    _adapter.Update(_table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка редактирования выбранного отдела\n" + ex.Message,
                        "Ошибка редактирования отдела", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
            else
            {
                selectRow.CancelEdit();
            }
            RefreshDataDepartments();
        }
        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            DataRowView selectRow = (DataRowView)DataGridDepartments.SelectedItem;
            if (selectRow == null)
            {
                return;
            }
            selectRow.Row.Delete();
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(_adapter);
            try
            {
                _adapter.Update(_table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления выбранного отдела\n" + ex.Message,
                    "Ошибка удаления отдела", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            RefreshDataDepartments();
        }


    }
}
