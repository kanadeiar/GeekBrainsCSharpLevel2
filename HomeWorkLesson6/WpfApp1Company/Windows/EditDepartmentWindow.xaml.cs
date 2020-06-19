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
    /// Логика взаимодействия для EditDepartmentWindow.xaml
    /// </summary>
    public partial class EditDepartmentWindow : Window
    {
        /// <summary> Отдел на редактировании </summary>
        public Department Department { get; set; }
        public EditDepartmentWindow()
        {
            InitializeComponent();
        }

        private void EditDepartmentWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Binding binding = new Binding
            {
                Source = Department,
                Path = new PropertyPath("Name"),
            };
            TextBoxNameDepartment.SetBinding(TextBox.TextProperty, binding);
        }
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
