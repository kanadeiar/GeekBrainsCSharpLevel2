using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApp1Asteroids
{
    class SplashScreen
    {
        private static Form myForm;
        private static int Width { get; set; }
        private static int Height { get; set; }
        public static void Init(Form form)
        {
            myForm = form;
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Label labelHeader = new Label
            {
                Text = "Geekbrains. C# Уровень 2.\nЛекция 1. Объектно-ориентированное программирование. Часть 1.",
                Size = new Size(800,50),
                Location = new Point((Width-800)/2,20),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, (byte)(160)),
            };
            form.Controls.Add(labelHeader);
            Label labelHead = new Label
            {
                Text = "Игра \"Астероиды\"",
                Size = new Size(500,50),
                Location = new Point((Width-500)/2,180),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, (byte)(160)),
            };
            form.Controls.Add(labelHead);
            Button buttonGame = new Button
            {
                Text = "Начало игры",
                Size = new Size(400,50),
                Location = new Point((Width-400)/2,250),
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, (byte)(160)),
            };
            buttonGame.Click += (sender, args) =>
            {
                myForm.Controls.Clear();
                Game.Init(myForm);
                myForm.Show();
                Game.Draw();
            };
            form.Controls.Add(buttonGame);
            Button buttonExit = new Button
            {
                Text = "Выход",
                Size = new Size(400,50),
                Location = new Point((Width-400)/2,390),
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, (byte)(160)),
            };
            buttonExit.Click += (sender, args) =>
            {
                myForm.Close();
            };
            form.Controls.Add(buttonExit);
            Label labelAbout = new Label
            {
                Text = "Выполнил: Рассахатский Андрей",
                Size = new Size(500,50),
                Location = new Point((Width-500)/2,500),
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, (byte)(160)),
            };
            form.Controls.Add(labelAbout);
        }
    }
}
