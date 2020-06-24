using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для DepartmentAddWindow.xaml
    /// </summary>
    public partial class DepartmentAddWindow : Window
    {
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
