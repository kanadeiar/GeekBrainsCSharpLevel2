using System.Data;
using System.Windows;

namespace WpfApp1Company.Windows
{
    /// <summary>
    /// Логика взаимодействия для DepartmentEditWindow.xaml
    /// </summary>
    public partial class DepartmentEditWindow : Window
    {
        /// <summary> Редактируемый отдел </summary>
        private DataRow _resultRow;
        public DepartmentEditWindow(DataRow dataRow)
        {
            InitializeComponent();
            _resultRow = dataRow;
        }
        private void DepartmentEditWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            TextBoxDepartment.Text = _resultRow["department"].ToString();
        }
        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
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
