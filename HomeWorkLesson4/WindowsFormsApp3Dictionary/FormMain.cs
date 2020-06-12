using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3Dictionary
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Задача 3
        /// * Дан фрагмент программы:
        /// Dictionary<string, int> dict = new Dictionary<string, int>()
        /// {
        ///     {"four",4 },
        ///     {"two",2 },
        ///     { "one",1 },
        ///     {"three",3 },
        /// };
        /// var d = dict.OrderBy(delegate(KeyValuePair<string,int> pair) { return pair.Value; });
        /// foreach (var pair in d)
        /// {
        ///     Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
        /// }
        /// а. Свернуть обращение к OrderBy с использованием лямбда-выражения =>.
        /// b. * Развернуть обращение к OrderBy с использованием делегата .
        /// Рассахатский
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            labelHeader.Text = "Методичка 4. Продвинутый курс C#. Объектно-ориентированное программирование. Часть 4.\n" +
                               "Задача 3. Работа со словарем.";
        }
        private Dictionary<string, int> dict = new Dictionary<string, int>
        {
            {"two",2},
            {"one",1},
            {"three",3},
            {"four",4},
            {"five",5},
        };
        private void buttonLambda_Click(object sender, EventArgs e)
        {
            var dct = dict.OrderBy(n => n.Value);
            StringBuilder sb = new StringBuilder();
            foreach (var el in dct)
                sb.AppendLine($"{el.Key} - {el.Value}");
            textBoxLambda.Text = sb.ToString();
        }
        private void buttonDelegate_Click(object sender, EventArgs e)
        {
            Func<KeyValuePair<string, int>, int> keySelector = delegate (KeyValuePair<string, int> pair) { return pair.Value; };
            var dct = dict.OrderBy(keySelector);
            StringBuilder sb = new StringBuilder();
            foreach (var el in dct)
                sb.AppendLine($"{el.Key} - {el.Value}");
            textBoxDelegate.Text = sb.ToString();
        }
    }
}
