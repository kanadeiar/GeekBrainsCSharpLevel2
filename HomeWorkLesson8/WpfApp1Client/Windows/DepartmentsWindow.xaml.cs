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
    /// Логика взаимодействия для DepartmentsWindow.xaml
    /// </summary>
    public partial class DepartmentsWindow : Window
    {
        private static HttpClient _client;
        private TextBlock _textBlockStatus;
        public DepartmentsWindow(HttpClient client, TextBlock textStatus)
        {
            InitializeComponent();
            _client = client;
            _textBlockStatus = textStatus;
            ButtonExit.Click += delegate { DialogResult = true; };
        }
        private async void DepartmentsWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _textBlockStatus.Text = "Состояние: Получение данных с сервиса";
            var departments = await GetDepatmentAsync(_client.BaseAddress + "api/department");
            DataGridDepartments.ItemsSource = departments;
            _textBlockStatus.Text = "Готов";
        }
        static async Task<IEnumerable<Department>> GetDepatmentAsync(string path)
        {
            IEnumerable<Department> departments = null;
            try
            {
                var response = await _client.GetAsync(path);
                response.EnsureSuccessStatusCode();
                departments = await response.Content.ReadAsAsync<IEnumerable<Department>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения данных с сервиса:\n" + ex.Message);
            }
            return departments;
        }
    }
}
