using System.Windows;
using System.Windows.Controls;
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
            newDepartment.ShowDialog();
        }
        private void ButtonEditDepartment_Click(object sender, RoutedEventArgs e)
        {
            EditDepartmentWindow editDepartment = new EditDepartmentWindow();
            editDepartment.ShowDialog();
        }
        private void ButtonDeleteDepartment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
