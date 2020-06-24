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
    /// Логика взаимодействия для DepartmentEditWindow.xaml
    /// </summary>
    public partial class DepartmentEditWindow : Window
    {
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
