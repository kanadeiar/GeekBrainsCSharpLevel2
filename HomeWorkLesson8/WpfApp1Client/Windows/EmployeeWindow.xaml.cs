using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using WpfApp1Client.Models;

namespace WpfApp1Client.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        private static HttpClient _client;
        private TextBlock _textBlockStatus;
        public EmployeeWindow(HttpClient client, TextBlock textStatus)
        {
            InitializeComponent();
            _client = client;
            _textBlockStatus = textStatus;
            ButtonExit.Click += delegate { DialogResult = true; };
        }
        private async void EmployeeWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _textBlockStatus.Text = "Состояние: Получение данных с сервиса";
            var employees = await GetEmployeeAsync(_client.BaseAddress + "api/employee");
            DataGridEmployees.ItemsSource = employees;
            _textBlockStatus.Text = "Готов";
        }
        static async Task<IEnumerable<Employee>> GetEmployeeAsync(string path)
        {
            IEnumerable<Employee> employees = null;
            try
            {
                var response = await _client.GetAsync(path);
                response.EnsureSuccessStatusCode();
                employees = await response.Content.ReadAsAsync<IEnumerable<Employee>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения данных с сервиса:\n" + ex.Message);
            }
            return employees;
        }
    }
}
