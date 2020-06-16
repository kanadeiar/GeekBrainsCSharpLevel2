using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using WpfApp1Company.Objects;

namespace WpfApp1Company
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Задачи 1-4.
        /// Создать WPF-приложение для ведения списка сотрудников компании.
        /// 1. Создать сущности Employee и Department и заполнить списки сущностей начальными данными.
        /// 2. Для списка сотрудников и списка департаментов предусмотреть визуализацию (отображение). Это можно
        /// сделать, например, с использованием ComboBox или ListView.
        /// 3. Предусмотреть редактирование сотрудников и департаментов. Должна быть возможность изменить департамент
        /// у сотрудника. Список департаментов для выбора можно выводить в ComboBox, и все это можно выводить на
        /// дополнительной форме.
        /// 4. Предусмотреть возможность создания новых сотрудников и департаментов. Реализовать это либо на форме
        /// редактирования, либо сделать
        /// новую форму.
        /// Рассахатский
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Company company = new Company("Пупкин и Ко.");
            (company.Departaments, company.Employees) = Company.GetSamples();
            DrawEmployersToForm(company.Employees, listBoxEmployees);
            DrawDepsToForm(company.Departaments, comboBoxDepartament);
        }

        /// <summary> Вывод сотрудников на форму </summary>
        /// <param name="employees">Сотрудники</param>
        /// <param name="selectorEmployees">Элемент формы</param>
        private static void DrawEmployersToForm(IList<Employee> employees, Selector selectorEmployees)
        {
            int tmp = selectorEmployees.SelectedIndex;
            selectorEmployees.Items.Clear();
            foreach (var el in employees)
                selectorEmployees.Items.Add($"{el.Fam} {el.Name}");
            if (tmp < employees.Count)
                selectorEmployees.SelectedIndex = tmp;
            else
                selectorEmployees.SelectedIndex = employees.Count - 1;
        }
        /// <summary> Вывод отделов на форму </summary>
        /// <param name="departaments">отделы</param>
        /// <param name="selectorDepartaments">Элемент формы</param>
        private static void DrawDepsToForm(IList<Departament> departaments, Selector selectorDepartaments)
        {
            int tmp = selectorDepartaments.SelectedIndex;
            selectorDepartaments.Items.Clear();
            foreach (var el in departaments)
                selectorDepartaments.Items.Add($"{el.Name}");
            if (tmp < departaments.Count)
                selectorDepartaments.SelectedIndex = tmp;
            else
                selectorDepartaments.SelectedIndex = departaments.Count - 1;
        }
        /// <summary> Вывод детальный сотрудника на форму </summary>
        /// <param name="employees"></param>
        /// <param name="departaments"></param>
        /// <param name="selectedIndexEmployee"></param>
        /// <param name="textFam"></param>
        /// <param name="textName"></param>
        /// <param name="textAge"></param>
        /// <param name="textSalary"></param>
        /// <param name="selectorDepartaments"></param>
        private static void DrawDetailEmployeeToForm(IList<Employee> employees, IList<Departament> departaments,
            int selectedIndexEmployee, TextBoxBase textFam, TextBoxBase textName, TextBoxBase textAge,
            TextBoxBase textSalary, Selector selectorDepartaments)
        {

        }

    }
}
