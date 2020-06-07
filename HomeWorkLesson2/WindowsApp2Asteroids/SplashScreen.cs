using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsApp2Asteroids
{
    class SplashScreen
    {
        public static int Width {get;set;}
        public static int Height {get;set;}
        private static Form splashForm;
        /// <summary>
        /// Инициализация меню приложения
        /// </summary>
        public static void Init(Form form)
        {
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            splashForm = form;
            splashForm.BackColor = Color.LightGreen;
            Label labelHeader = new Label
            {
                Text = "Урок 2. Продвинутый курс C#. Объектно-ориентированное программирование. Часть 2.",
                Location = new System.Drawing.Point((Width-1000)/2,10),
                Size = new System.Drawing.Size(1000,60),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 17F),
            };
            form.Controls.Add(labelHeader);
            Label labelName = new Label
            {
                Text = "Игра \"Астероиды\"",
                Location = new System.Drawing.Point((Width-1000)/2,100),
                Size = new System.Drawing.Size(1000,50),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 26F),
            };
            form.Controls.Add(labelName);
            Button buttonGame = new Button
            {
                Text = "Начало игры",
                Location = new System.Drawing.Point((Width-400)/2,250),
                Size = new System.Drawing.Size(400,50),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 20F),
            };
            form.Controls.Add(buttonGame);
            buttonGame.Click += buttonGame_Click;
            Button buttonExit = new Button
            {
                Text = "Выход",
                Location = new System.Drawing.Point((Width-400)/2,310),
                Size = new System.Drawing.Size(400,50),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 20F),
            };
            form.Controls.Add(buttonExit);
            buttonExit.Click += buttonExit_Click;
            Label labelAuthor = new Label
            {
                Text = "Рассахатский",
                Location = new System.Drawing.Point((Width-500)/2,500),
                Size = new System.Drawing.Size(500,50),
                TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(160))),
            };
            form.Controls.Add(labelAuthor);
        }
        private static void buttonGame_Click(object sender, EventArgs e)
        {
            splashForm.Controls.Clear();
            Game.Init(splashForm);
            splashForm.Show();
            Game.Draw();
        }
        private static void buttonExit_Click(object sender, EventArgs e)
        {
            splashForm.Close();
        }

    }
}
