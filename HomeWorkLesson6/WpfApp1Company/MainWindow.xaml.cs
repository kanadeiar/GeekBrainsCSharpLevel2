using System.Windows;
using WpfApp1Company.Objects;

namespace WpfApp1Company
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Company _company;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _company = new Company();
            (_company.Departments, _company.Employees) = Company.GetSamples();
            ListViewDepartaments.ItemsSource = _company.Departments;
            ComboBoxDepartaments.ItemsSource = _company.Departments;
        }
    }
}
