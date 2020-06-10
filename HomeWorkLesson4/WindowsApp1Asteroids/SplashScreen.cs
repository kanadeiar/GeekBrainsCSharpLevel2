using System.Drawing;
using System.Windows.Forms;

namespace WindowsApp1Asteroids
{
    /// <summary> Меню-заставка </summary>
    class SplashScreen
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        private static Form splashForm;
        /// <summary> Инициализация приложения </summary>
        /// <param name="form">Форма приложения</param>
        public static void Init(Form form)
        {
            splashForm = form;
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            splashForm.BackColor = Color.Black;
            form.BackgroundImage = Image.FromFile(@"Images\SplashFon.png");
            Label labelHeader = new Label
            {
                Text = "Методичка 4. Продвинутый курс C#. Объектно-ориентированное программирование. Часть 4.",
                Location = new Point((Width - 1000) / 2, 10),
                Size = new Size(1000, 60),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(FontFamily.GenericSansSerif, 17F),
                ForeColor = Color.White,
            };
            form.Controls.Add(labelHeader);
            Label labelName = new Label
            {
                Text = "Игра \"Астероиды\"",
                Location = new Point((Width - 1000) / 2, 100),
                Size = new Size(1000, 70),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(FontFamily.GenericSansSerif, 32F),
                ForeColor = Color.White,
            };
            form.Controls.Add(labelName);
            Button buttonGame = new Button
            {
                Text = "Начало игры",
                Location = new Point((Width - 400) / 2, 250),
                Size = new Size(400, 50),
                Font = new Font(FontFamily.GenericSansSerif, 20F),
                BackColor = Color.LightSeaGreen
            };
            buttonGame.Click += (s, a) =>
            {
                splashForm.Controls.Clear();

            };
            form.Controls.Add(buttonGame);
            Button buttonExit = new Button
            {
                Text = "Выход",
                Location = new Point((Width - 400) / 2, 350),
                Size = new Size(400, 50),
                Font = new Font(FontFamily.GenericSansSerif, 20F),
                BackColor = Color.LightSeaGreen,
            };
            buttonExit.Click += (s, a) => splashForm.Close();
            form.Controls.Add(buttonExit);
            Label labelAuthor = new Label
            {
                Text = "Выполнил: Рассахатский Андрей",
                Location = new Point((Width - 500) / 2, 650),
                Size = new Size(500, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(FontFamily.GenericSansSerif, 18F, FontStyle.Regular, GraphicsUnit.Point, (byte)160),
                ForeColor = Color.White,
            };
            form.Controls.Add(labelAuthor);
        }
    }
}
