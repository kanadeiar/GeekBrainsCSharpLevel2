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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1Client.Models;
using WpfApp1Client.Windows;

namespace WpfApp1Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Задачи 1,2,3
        /// Изменить WPF-приложение для ведения списка сотрудников компании
        /// (из урока 7), используя веб-сервисы. Разделите приложение на 
        /// две части. Первая часть – клиентское приложение, отображающее 
        /// данные. Вторая часть – веб-сервис и код, связанный с извлечением 
        /// данных из БД. Приложение реализует только просмотр данных. При 
        /// разработке приложения допустимо использовать любой из рассмотренных 
        /// типов веб-сервисов.
        /// Создать таблицы Employee и Department в БД MSSQL Server и 
        /// заполнить списки сущностей начальными данными;
        /// Для списка сотрудников и списка департаментов предусмотреть 
        /// визуализацию (отображение);
        /// Разработать формы для отображения отдельных элементов списков 
        /// сотрудников и департаментов.
        /// Рассахатский
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _client = new HttpClient();
            _client.BaseAddress = new Uri(@"https://localhost:44364/");
            TextSource.Text = $"Адрес: {_client.BaseAddress} ";
        }

        private static HttpClient _client;
        private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            TextStatus.Text = "Состояние: Получение данных с сервиса";
            var employeeViews = await GetEmployeesViewAsync(_client.BaseAddress + "api/employeeview");
            ListViewEmployeesDeps.ItemsSource = employeeViews;
            TextStatus.Text = "Состояние: Готов";
        }
        static async Task<IEnumerable<EmployeeView>> GetEmployeesViewAsync(string path)
        {
            IEnumerable<EmployeeView> employeeViews = null;
            try
            {
                var response = await _client.GetAsync(path);
                response.EnsureSuccessStatusCode();
                employeeViews = await response.Content.ReadAsAsync<IEnumerable<EmployeeView>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения данных с сервиса:\n" + ex.Message);
            }
            return employeeViews;
        }
        private void ButtonDepartments_OnClick(object sender, RoutedEventArgs e)
        {
            DepartmentsWindow departmentsWindow = new DepartmentsWindow(_client, TextStatus);
            departmentsWindow.ShowDialog();
        }
        private void ButtonEmployees_OnClick(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow(_client, TextStatus);
            employeeWindow.ShowDialog();
        }
        private async void ButtonRefresh_OnClick(object sender, RoutedEventArgs e)
        {
            TextStatus.Text = "Состояние: Получение данных с сервиса";
            var employeeViews = await GetEmployeesViewAsync(_client.BaseAddress + "api/employeeview");
            ListViewEmployeesDeps.ItemsSource = employeeViews;
            TextStatus.Text = "Состояние: Готов";
        }
    }
}
