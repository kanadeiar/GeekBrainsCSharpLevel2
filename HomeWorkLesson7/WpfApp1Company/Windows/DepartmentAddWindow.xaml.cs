using System.Data;
using System.Windows;

namespace WpfApp1Company.Windows
{
    /// <summary>
    /// Логика взаимодействия для DepartmentAddWindow.xaml
    /// </summary>
    public partial class DepartmentAddWindow : Window
    {
        /// <summary> Добавляемый отдел </summary>
        private DataRow _resultRow;
        public DepartmentAddWindow(DataRow dataRow)
        {
            InitializeComponent();
            _resultRow = dataRow;
        }
        private void DepartmentAddWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            TextBoxDepartment.Text = _resultRow["department"].ToString();
        }
        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            _resultRow["department"] = TextBoxDepartment.Text;
            DialogResult = true;
        }
        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
