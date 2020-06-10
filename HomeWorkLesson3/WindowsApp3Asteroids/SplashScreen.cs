using System.Drawing;

using System.Windows.Forms;

namespace WindowsApp3Asteroids
{
    /// <summary>
    /// Меню-заставка игры
    /// </summary>
    internal class SplashScreen
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        private static Form splashForm;

        /// <summary>
        /// Инициализация меню приложения
        /// </summary>
        public static void Init(Form form)
        {
            splashForm = form;
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            splashForm.BackColor = Color.LightGreen;
            Label labelHeader = new Label
            {
                Text = "Методичка 3. Продвинутый курс C#. Объектно-ориентированное программирование. Часть 3",
                Location = new System.Drawing.Point((Width - 1000) / 2, 10),
                Size = new System.Drawing.Size(1000, 60),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 17F),
            };
            form.Controls.Add(labelHeader);
            Label labelName = new Label
            {
                Text = "Игра \"Астероиды\"",
                Location = new System.Drawing.Point((Width - 1000) / 2, 100),
                Size = new System.Drawing.Size(1000, 50),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 26F),
            };
            form.Controls.Add(labelName);
            Button buttonGame = new Button
            {
                Text = "Начало игры",
                Location = new System.Drawing.Point((Width - 400) / 2, 250),
                Size = new System.Drawing.Size(400, 50),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 20F),
            };
            form.Controls.Add(buttonGame);
            buttonGame.Click += (s, a) =>
            {
                splashForm.Controls.Clear();
                Game.Init(splashForm);
                splashForm.Show();
            };
            Button buttonExit = new Button
            {
                Text = "Выход",
                Location = new System.Drawing.Point((Width - 400) / 2, 310),
                Size = new System.Drawing.Size(400, 50),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 20F),
            };
            buttonExit.Click += (s, a) =>
            {
                splashForm.Close();
            };
            form.Controls.Add(buttonExit);
            Label labelAuthor = new Label
            {
                Text = "Выполнил: Рассахатский Андрей",
                Location = new System.Drawing.Point((Width - 500) / 2, 500),
                Size = new System.Drawing.Size(500, 50),
                TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(160))),
            };
            form.Controls.Add(labelAuthor);
        }
    }
}