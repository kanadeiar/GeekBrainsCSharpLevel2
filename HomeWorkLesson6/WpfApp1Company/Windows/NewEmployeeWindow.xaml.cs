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
            if (string.IsNullOrEmpty(TextBoxNameEmployee.Text))
            {
                MessageBox.Show("Введите хоть какое-либо имя сотрудника!", "Так нельзя", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxAgeEmployee.Text))
            {
                MessageBox.Show("Введите хоть какой нибудь возраст сотрудника!", "Так нельзя", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            int age = 0;
            if (!int.TryParse(TextBoxAgeEmployee.Text, out age))
            {
                MessageBox.Show("Возраст сотрудника нужно ввести целым числом!", "Так нельзя", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (age < 18)
            {
                MessageBox.Show("Несовершеннолетним нельзя работать!", "Так нельзя", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (age > 60)
            {
                MessageBox.Show("Пенсионерам нельзя работать!", "Так нельзя", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxSalaryEmployee.Text))
            {
                MessageBox.Show("Введите хоть какую-нибудь зарплату сотрудника!", "Так нельзя", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            double salary = 0.0;
            if (!double.TryParse(TextBoxSalaryEmployee.Text, out salary))
            {
                MessageBox.Show("Зарплату сотрудника нужно ввести вещественным числом!", "Так нельзя", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            if (salary < 1000.0)
            {
                MessageBox.Show("Зарплата сотрудника должна быть выше прожиточного минимума!", "Так нельзя", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (salary > 90000.0)
            {
                MessageBox.Show("Зарплата сотрудника должна быть ниже зарплаты директора!", "Так нельзя", MessageBoxButton.OK, MessageBoxImage.Information);
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
