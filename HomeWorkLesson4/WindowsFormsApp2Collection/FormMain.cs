﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1Collection
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Задача 2
        /// Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
        /// - для целых чисел;
        /// - * для обобщенной коллекции;
        /// - ** используя Linq.
        /// Рассахатский
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            labelHeader.Text = "Методичка 4. Продвинутый курс C#. Объектно-ориентированное программирование. Часть 4.\n" +
                "Задача 2. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции.";
        }
        private void buttonCalcNumbers_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>
            {
                1,1,1,2,2,3,4,4,4,4,5,5,6,6,6,7,8,8,8,8,9,9,9,9,9,
            };
            var dict = GetDigitsCounts(list);
            OutDictionaryToTextBox(dict, textBoxResultNumbers);
        }
        private void buttonCalcGenCollection_Click(object sender, EventArgs e)
        {
            List<float> list = new List<float>
            {
                1.5F,1.5F,1.5F,2.1F,2.1F,3,4.5F,4.5F,4.5F,4.5F,5.1F,5.1F,6.5F,6.5F,6.5F,7.5F,8.1F,8.1F,8.1F,8.1F,9.5F,9.5F,9.5F,9.5F,9.5F,
            };
            var dict = GetGenCounts(list);
            OutGenDictionaryToTextBox(dict, textBoxResultGenCollection);
        }
        private void buttonCalcLINQ_Click(object sender, EventArgs e)
        {
            List<float> list = new List<float>
            {
                1.5F,1.5F,1.5F,2.1F,2.1F,3,4.5F,4.5F,4.5F,4.5F,5.1F,5.1F,6.5F,6.5F,6.5F,7.5F,8.1F,8.1F,8.1F,8.1F,9.5F,9.5F,9.5F,9.5F,9.5F,
            };
            var arrg = list.GroupBy(l => l)
                .Select(g => new {Value = g.Key, Count = g.Count()});
            StringBuilder sb = new StringBuilder();
            foreach (var el in arrg)
                sb.AppendLine($"Число {el.Value} встречается в массиве {el.Count} раз. ");
            textBoxResultLINQ.Text = sb.ToString();
        }
        /// <summary> Подсчет количества чисел в коллекции </summary>
        /// <param name="list">коллекция</param>
        /// <returns>кол-во элементов</returns>
        static Dictionary<int, int> GetDigitsCounts(List<int> list)
        {
            var dct = new Dictionary<int, int>();
            foreach (var l in list)
                if (dct.ContainsKey(l))
                    dct[l]++;
                else
                    dct.Add(l, 1);
            return dct;
        }
        /// <summary> Подсчет количества чисел в обобщенной коллекции </summary>
        /// <typeparam name="T">тип</typeparam>
        /// <param name="list">коллекция</param>
        /// <returns>кол-во элементов</returns>
        static Dictionary<T, int> GetGenCounts<T>(List<T> list)
        {
            var dct = new Dictionary<T, int>();
            foreach (var l in list)
                if (dct.ContainsKey(l))
                    dct[l]++;
                else
                    dct.Add(l, 1);
            return dct;
        }
        /// <summary> Вывод информации из словаря в текстовое поле на форме </summary>
        /// <param name="dict">словарь</param>
        /// <param name="textBox">текстовое поле</param>
        static void OutDictionaryToTextBox(Dictionary<int, int> dict, TextBox textBox)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var d in dict)
                sb.AppendLine($"Число {d.Key} встречается в массиве {d.Value} раз.");
            textBox.Text = sb.ToString();
        }
        /// <summary> Вывод информации из обобщенного словаря в текстовое поле на форму </summary>
        /// <typeparam name="T">тип</typeparam>
        /// <param name="dict">словарь</param>
        /// <param name="textBox">текстовое поле</param>
        static void OutGenDictionaryToTextBox<T>(Dictionary<T, int> dict, TextBox textBox)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var d in dict)
                sb.AppendLine($"Число {d.Key} встречается в массиве {d.Value} раз.");
            textBox.Text = sb.ToString();
        }
    }
}
