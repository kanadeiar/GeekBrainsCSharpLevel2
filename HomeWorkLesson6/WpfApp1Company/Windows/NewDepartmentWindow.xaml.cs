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
    /// Логика взаимодействия для NewDepartmentWindow.xaml
    /// </summary>
    public partial class NewDepartmentWindow : Window
    {
        /// <summary> Созданный отдел </summary>
        public Department Department { get; set; }
        public NewDepartmentWindow()
        {
            InitializeComponent();
        }

        private void NewDepartmentWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Binding binding = new Binding
            {
                Source = Department,
                Path = new PropertyPath("Name"),
            };
            TextBoxNameDepartment.SetBinding(TextBox.TextProperty, binding);
        }
        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxNameDepartment.Text))
            {
                MessageBox.Show("Введите хоть какое-то имя отдела!", "Так нельзя", MessageBoxButton.OK, MessageBoxImage.Stop);
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
