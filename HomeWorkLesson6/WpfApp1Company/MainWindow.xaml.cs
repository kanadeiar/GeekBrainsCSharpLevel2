using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfApp1Company.Objects;
using WpfApp1Company.Windows;

namespace WpfApp1Company
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            (Company.Departments, Company.Employees) = Company.GetSamples();
            ListViewDepartaments.ItemsSource = Company.Departments;
            ComboBoxDepartaments.ItemsSource = Company.Departments;
        }

        private void ComboBoxDepartaments_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ListViewDepartaments.SelectedIndex = ComboBoxDepartaments.SelectedIndex;
        }


        
        private void ButtonAddDepartment_Click(object sender, RoutedEventArgs e)
        {
            NewDepartmentWindow newDepartment = new NewDepartmentWindow();
            newDepartment.Department = new Department
            {
                Id = Company.Departments.Max(d => d.Id) + 1,
                Name = string.Empty,
            };
            newDepartment.ShowDialog();
            if (newDepartment.DialogResult == true)
            {
                Company.Departments.Add(newDepartment.Department);
            }
        }
        private void ButtonEditDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (null == ListViewDepartaments.SelectedItem)
                return;
            Department editIt = (Department)ListViewDepartaments.SelectedItem;
            if (editIt.Id == 0)
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Это не отдел, его нельзя редактировать!", "Ошибочка вышла...", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }
            EditDepartmentWindow editDepartment = new EditDepartmentWindow();
            editDepartment.Department = editIt;
            editDepartment.ShowDialog();
        }
        private void ButtonDeleteDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (null == ListViewDepartaments.SelectedItem)
                return;
            Department deleteIt = (Department)ListViewDepartaments.SelectedItem;
            if (deleteIt.Id == 0)
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Это не отдел, его нельзя удалять!", "Ошибочка вышла...", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }
            if (deleteIt.Employees.Length > 0)
            {
                MessageBox.Show("Нельзя удалить отдел, в котором еще работают сотрудники!", "Так нельзя",
                    MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }
            MessageBoxResult res = MessageBox.Show($"Действительно удалить отдел с названием \"{deleteIt.Name}\"?",
                "Удаление отдела", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
                Company.Departments.Remove(deleteIt);
        }

        private void ButtonAddEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            NewEmployeeWindow newEmployee = new NewEmployeeWindow();
            newEmployee.Employee = new Employee
            {
                Id = Company.Employees.Max(em => em.Id) + 1,
                Fam = string.Empty,
                Name = string.Empty,
                Age = default,
                Salary = default,
                DepartmentId = default,
            };
            newEmployee.ShowDialog();
            if (newEmployee.DialogResult == true)
            {
                Company.Employees.Add(newEmployee.Employee);
            }
            int tmp = ListViewDepartaments.SelectedIndex;
            ListViewDepartaments.SelectedIndex = -1;
            ListViewDepartaments.SelectedIndex = tmp;
        }
        private void ButtonDeleteEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            if (null == ListViewEmployees.SelectedItem)
                return;
            Employee deleteIt = (Employee) ListViewEmployees.SelectedItem;
            MessageBoxResult res = MessageBox.Show($"Действительно уволить сотрудника {deleteIt.Fam} {deleteIt.Name}?",
                "Увольнение сотрудника", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
                Company.Employees.Remove(deleteIt);
            int tmp = ListViewDepartaments.SelectedIndex;
            ListViewDepartaments.SelectedIndex = -1;
            ListViewDepartaments.SelectedIndex = tmp;
        }
    }
}
