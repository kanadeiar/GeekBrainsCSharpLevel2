using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsApp1Asteroids
{
    /// <summary> Менеджер игры </summary>
    static class Game
    {
        private static BufferedGraphicsContext _context;
        private static BufferedGraphics _buffer;
        private static Size _size;
        private static readonly Timer timer = new Timer {Interval = 10};
        /// <summary> Размеры окна </summary>
        public static Size Size
        {
            get => _size;
            set
            {
                if (value.Width > 1600 || value.Width < 300)
                    throw new ArgumentOutOfRangeException("Ширина вне диапазона 300-1600");
                if (value.Height > 900 || value.Height < 200)
                    throw new ArgumentOutOfRangeException("Высота вне диапазона 200-900");
                _size = value;
            }
        }
        /// <summary> Случайное число </summary>
        public static Random Rand = new Random();
        /// <summary> Сообщение о произошедшем событии </summary>
        public static Action<string> EventMessage;
        static Game()
        { }
        /// <summary> Инициализация игры </summary>
        /// <param name="form">окно</param>
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Size = form.ClientSize;
            _buffer = _context.Allocate(g, new Rectangle(new Point(0, 0), Size));
            Load();
            timer.Tick += (s, a) =>
            {
                Update();
                if (timer.Enabled) 
                    Draw();
            };
            timer.Start();
            form.KeyDown += Form_KeyDown;
            form.KeyUp += Form_KeyUp;
        }
        #region Объекты
        ///////////////////////////////////////////////////
        /// <summary> Задний фон </summary>
        private static readonly Image space = Image.FromFile(@"Images\Space.jpg");
        private static float _moveSpace;


        #endregion
        #region Методы-обработчики
        ///////////////////////////////////////////////////
        /// <summary> Загрузка элементов </summary>
        private static void Load()
        {

        }
        /// <summary> Обновление состояния </summary>
        private static void Update()
        {
            _moveSpace += 0.2F;
            if (_moveSpace > space.Width)
                _moveSpace = 0.0F;


        }

        public static void Draw()
        {
            _buffer.Graphics.DrawImage(space, 0 - _moveSpace, 0);
            _buffer.Graphics.DrawImage(space, space.Width - _moveSpace, 0);



            _buffer.Render();
        }
        /// <summary> Конец игры </summary>
        /// <param name="message">сообщение окончания игры</param>
        private static void GameOver(string message)
        {
            timer.Stop();
            _buffer.Graphics.DrawString(message, new Font(FontFamily.GenericSansSerif, 80), Brushes.Red, 140, 140 );
            _buffer.Render();
        }
        #endregion
        #region Кнопки на клавиатуре
        ///////////////////////////////////////////////////
        private static void Form_KeyDown(object s, KeyEventArgs e)
        {

        }
        private static void Form_KeyUp(object s, KeyEventArgs e)
        {

        }
        #endregion
    }
}
