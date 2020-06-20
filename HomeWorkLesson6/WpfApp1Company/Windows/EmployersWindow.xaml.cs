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
            
        }

        private void ButtonExit_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
