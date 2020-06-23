using System;
using System.Collections.Generic;
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
using WpfApp1Company.Objects;

namespace WpfApp1Company.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployersWindow.xaml
    /// </summary>
    public partial class EmployersWindow : Window
    {
        public EmployersWindow()
        {
            InitializeComponent();
        }

        private void EmployersWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            DataGridEmployees.ItemsSource = Company.Employees;
            DataGridComboBoxDepartments.ItemsSource = Company.Departments;
        }

        private void ButtonExit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonDeleteEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataGridEmployees.SelectedValue is Employee em)
            {
                Company.Employees.Remove(em);
            }
        }
    }
}
