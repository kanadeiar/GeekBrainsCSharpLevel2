using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
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
            _company = new Company("Камянецкий и Ко.");
        }
        private readonly Company _company;

        #region Обработчики событий формы
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            textCompanyName.Text = $"Название компании: \"{_company.Name}\"";
            (_company.Departments, _company.Employees) = Company.GetSamples();
            DrawEmployersToForm(_company.Employees, listBoxEmployees);
            DrawDepsToForm(_company.Departments, comboBoxDepartment);
            DrawDetailEmployeeToForm(_company.Employees, _company.Departments, listBoxEmployees.SelectedIndex, 
                textBoxFam, textBoxName, textBoxAge, textBoxSalary, comboBoxDepartment);
        }
        private void ListBoxEmployees_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DrawDetailEmployeeToForm(_company.Employees, _company.Departments, listBoxEmployees.SelectedIndex, 
                textBoxFam, textBoxName, textBoxAge, textBoxSalary, comboBoxDepartment);
        } private void ButtonAddEmp_OnClick(object sender, RoutedEventArgs e)
        {
            EmployeeAddEmpty(_company.Employees);
            DrawEmployersToForm(_company.Employees, listBoxEmployees);
            listBoxEmployees.SelectedIndex = _company.Employees.Count - 1;
        }
        private void ButtonEditEmp_OnClick(object sender, RoutedEventArgs e)
        {
            EmployeeSaveEdit(_company.Employees, _company.Departments, listBoxEmployees.SelectedIndex, 
                textBoxFam, textBoxName, textBoxAge, textBoxSalary, comboBoxDepartment.SelectedIndex);
            DrawEmployersToForm(_company.Employees, listBoxEmployees);
        }
        private void ButtonDelEmp_OnClick(object sender, RoutedEventArgs e)
        {
            EmployeeDeleteSelect(_company.Employees, listBoxEmployees.SelectedIndex);
            DrawEmployersToForm(_company.Employees, listBoxEmployees);
        }
        private void ButtonEditDeps_OnClick(object sender, RoutedEventArgs e)
        {
            DepsEditWindow depsEditWindow = new DepsEditWindow(_company.Employees);
            depsEditWindow.Departments = _company.Departments;
            depsEditWindow.Owner = this;
            bool? result = depsEditWindow.ShowDialog();
            if (result == true)
            {
                _company.Departments = depsEditWindow.Departments;
                DrawDepsToForm(_company.Departments, comboBoxDepartment);
            }
        }
        #endregion

        #region Сопровождение формы
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
        /// <param name="departments">отделы</param>
        /// <param name="selectorDepartaments">Элемент формы</param>
        private static void DrawDepsToForm(IList<Departament> departments, Selector selectorDepartaments)
        {
            int tmp = selectorDepartaments.SelectedIndex;
            selectorDepartaments.Items.Clear();
            foreach (var el in departments)
                selectorDepartaments.Items.Add($"{el.Name}");
            if (tmp < departments.Count)
                selectorDepartaments.SelectedIndex = tmp;
            else
                selectorDepartaments.SelectedIndex = departments.Count - 1;
        }
        /// <summary> Вывод детальный сотрудника на форму </summary>
        /// <param name="employees">сотрудники</param>
        /// <param name="departments">отделы</param>
        /// <param name="selectedIndexEmployee">номер выбранного сотрудника</param>
        /// <param name="textFam">фамилия</param>
        /// <param name="textName">имя</param>
        /// <param name="textAge">возраст</param>
        /// <param name="textSalary">зарплата</param>
        /// <param name="selectorDepartments">отдел</param>
        private static void DrawDetailEmployeeToForm(IList<Employee> employees, IList<Departament> departments,
            int selectedIndexEmployee, TextBox textFam, TextBox textName, TextBox textAge, TextBox textSalary, 
            Selector selectorDepartments)
        {
            int index = selectedIndexEmployee;
            if (index > employees.Count)
                throw new ApplicationException("Индекс selectedIndexEmployee вне диапазона!");
            if (index == -1)
            {
                textFam.Text = string.Empty;
                textName.Text = string.Empty;
                textAge.Text = "0";
                textSalary.Text = "0";
                selectorDepartments.SelectedIndex = -1;
                return;
            }
            textFam.Text = employees[index].Fam;
            textName.Text = employees[index].Name;
            textAge.Text = employees[index].Age.ToString();
            textSalary.Text = employees[index].Salary.ToString(CultureInfo.InvariantCulture);
            if (employees[index].IdDepartament != -1)
            {
                var dep = departments
                    .First(d => d.Id == employees[index].IdDepartament);
                if (dep is Departament department)
                    selectorDepartments.SelectedIndex = departments.IndexOf(department);
                else
                    throw new ApplicationException("Элемент employees[index].IdDepartament в departments не найден!");
            }
            else
                selectorDepartments.SelectedIndex = -1;
        }
        /// <summary> Добавление нового сотрудника </summary>
        /// <param name="employees">сотрудники</param>
        private static void EmployeeAddEmpty(IList<Employee> employees)
        {
            employees.Add
            (
                new Employee
                {
                    Fam = "",
                    Name = "",
                    Age = 18,
                    Salary = 5000.0F,
                    IdDepartament = -1,
                }
            );
        }
        /// <summary> Сохранение изменений у сотрудника </summary>
        /// <param name="employees">сотрудники</param>
        /// <param name="departments">отделы</param>
        /// <param name="selectedIndexEmployee">выбранный сотрудник</param>
        /// <param name="textFam">фамилия</param>
        /// <param name="textName">имя</param>
        /// <param name="textAge">возраст</param>
        /// <param name="textSalary">зарплата</param>
        /// <param name="selectedIndexDepartment">отдел</param>
        private static void EmployeeSaveEdit(IList<Employee> employees, IList<Departament> departments, 
            int selectedIndexEmployee, TextBox textFam, TextBox textName, TextBox textAge, TextBox textSalary, 
            int selectedIndexDepartment)
        {
            int index = selectedIndexEmployee;
            if (index > employees.Count)
                throw new ApplicationException("Индекс selectedIndexEmployee вне диапазона!");
            if (index == -1)
                return;
            employees[index].Fam = textFam.Text;
            employees[index].Name = textName.Text;
            if (int.TryParse(textAge.Text, out var tage))
                employees[index].Age = tage;
            else 
                throw new ApplicationException("Значение возраста должно быть числом!");
            if (double.TryParse(textSalary.Text, out var tsalary))
                employees[index].Salary = tsalary;
            else 
                throw new ApplicationException("Значение зарплаты должно быть вещественным числом");
            if (selectedIndexDepartment != -1)
                employees[index].IdDepartament = departments[selectedIndexDepartment].Id;
        }
        /// <summary> Удаление выбранного сорудника </summary>
        /// <param name="employees">сотрудники</param>
        /// <param name="selectedIndexEmployee">выбранный</param>
        private static void EmployeeDeleteSelect(IList<Employee> employees, int selectedIndexEmployee)
        {
            int index = selectedIndexEmployee;
            if (index > employees.Count)
                throw new ApplicationException("Индекс selectedIndexEmployee вне диапазона!");
            if (index == -1)
                return;
            employees.RemoveAt(index);
        }
        #endregion


    }
}
