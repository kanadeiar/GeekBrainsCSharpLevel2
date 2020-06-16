using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Controls.Primitives;
using WpfApp1Company.Objects;
using Microsoft.VisualBasic;

namespace WpfApp1Company
{
    /// <summary>
    /// Логика взаимодействия для DepsEditWindow.xaml
    /// </summary>
    public partial class DepsEditWindow : Window
    {
        public List<Departament> Departments { get; set; }
        public DepsEditWindow()
        {
            InitializeComponent();
        }
        //Результат выполнения - что-то изменилось
        private static bool dialogRes = false;
        #region Обработчики событий формы
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void DepsEditWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            DrawDepsToForm(Departments, listBoxDepartments);
        }
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            DepAddDialog(Departments);
            DrawDepsToForm(Departments, listBoxDepartments);
            dialogRes = true;
        }
        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            DepEditSelect(Departments, listBoxDepartments.SelectedIndex);
            DrawDepsToForm(Departments, listBoxDepartments);
            dialogRes = true;
        }
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            
            dialogRes = true;
        }
        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = dialogRes;
        }
        #endregion

        #region Сопровождение формы
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
        /// <summary> Добавление нового отдела через диалог </summary>
        /// <param name="departaments">отделы</param>
        private static void DepAddDialog(IList<Departament> departaments)
        {
            string newName = Interaction.InputBox("Введите название нового отдела",
                "Добавление нового департамента", "");
            if (string.IsNullOrEmpty(newName))
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Пожалуйста, обязательно введите название нового отдела!");
                return;
            }
            int newId = 1;
            while (departaments.Count(d => d.Id == newId) != 0)
                newId++;
            departaments.Add
            (
                new Departament
                {
                    Id = newId,
                    Name = newName,
                }
            );
        }
        /// <summary> Редактирование отдела </summary>
        /// <param name="departaments">отделы</param>
        /// <param name="selectedIndexDepartment">выбранный отдел</param>
        private static void DepEditSelect(IList<Departament> departaments, int selectedIndexDepartment)
        {
            int index = selectedIndexDepartment;
            if (index > departaments.Count)
                throw new ApplicationException("Индекс selectedIndexDepartment вне диапазона!");
            if (index == -1)
                return;
            string currentName = departaments[selectedIndexDepartment].Name;
            currentName = Interaction.InputBox("Введите новое название выбранного отдела",
                "Редактирование отдела", currentName);
            departaments[selectedIndexDepartment].Name = currentName;
        }



        #endregion


    }
}
