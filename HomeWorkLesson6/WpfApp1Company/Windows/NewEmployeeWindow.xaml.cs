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
    /// Логика взаимодействия для NewEmployeeWindow.xaml
    /// </summary>
    public partial class NewEmployeeWindow : Window
    {
        /// <summary> Созданный сотрудник </summary>
        public Employee Employee { get; set; }
        public NewEmployeeWindow()
        {
            InitializeComponent();
        }

        private void NewEmployeeWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Binding bindingFam = new Binding
            {
                Source = Employee,
                Path = new PropertyPath("Fam"),
            };
            TextBoxFamEmployee.SetBinding(TextBox.TextProperty, bindingFam);
            Binding bindingName = new Binding
            {
                Source = Employee,
                Path = new PropertyPath("Name"),
            };
            TextBoxNameEmployee.SetBinding(TextBox.TextProperty, bindingName);
            Binding bindingAge = new Binding
            {
                Source = Employee,
                Path = new PropertyPath("Age"),
            };
            TextBoxAgeEmployee.SetBinding(TextBox.TextProperty, bindingAge);
            Binding bindingSalary = new Binding
            {
                Source = Employee,
                Path = new PropertyPath("Salary"),
            };
            TextBoxSalaryEmployee.SetBinding(TextBox.TextProperty, bindingSalary);
            Binding bindingDepartment = new Binding
            {
                Source = Employee,
                Path = new PropertyPath("Department"),
            };
            ComboBoxDepartaments.SetBinding(ComboBox.SelectedItemProperty, bindingDepartment);

            ComboBoxDepartaments.ItemsSource = Company.Departments;
        }

        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxFamEmployee.Text))
            {
                MessageBox.Show("Введите хоть какую-то фамилию сотрудника!", "Так нельзя", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            DialogResult = true;
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
