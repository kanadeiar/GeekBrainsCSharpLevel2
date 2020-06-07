using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApp3Asteroids
{
    /// <summary>
    /// Менеджер игры
    /// </summary>
    class Game
    {
        private static BufferedGraphicsContext _context;
        private static BufferedGraphics _buffer;
        private static Size _size;
        /// <summary> Размеры окна </summary>
        public static Size Size
        {
            get => _size;
            private set
            {
                if (value.Width > 1600 || value.Width < 300)
                    throw new ArgumentOutOfRangeException("Ширина окна должна быть в пределах от 300 до 1600");
                if (value.Height > 900 || value.Height < 200)
                    throw new ArgumentOutOfRangeException("Высота окна должна быть в пределах от 200 до 900");
                _size = value;
            }
        }
        /// <summary> Случайное число </summary>
        public static Random Rand = new Random();
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
            Timer timer = new Timer {Interval = 10};
            timer.Tick += (s, a) =>
            {
                Update();
                Draw();
            };
            timer.Start();
        }
        ///////////////////////////////////////////////////////////////
        private static readonly Image space = Image.FromFile(@"Images\Space.jpg");
        private static float _moveSpace;
        /// <summary> Перемещение фона </summary>
        private static void DoMoveSpace()
        {
            _moveSpace += 0.2F;
            if (_moveSpace > space.Width)
                _moveSpace = 0.0F;
        }

        /// <summary>
        /// Загрузка элементов
        /// </summary>
        private static void Load()
        {

        }
        /// <summary>
        /// Обновление состояния
        /// </summary>
        private static void Update()
        {

        }
        /// <summary>
        /// Отрисовка элементов
        /// </summary>
        private static void Draw()
        {
            _buffer.Graphics.DrawImage(space, 0 - _moveSpace, 0);
            _buffer.Graphics.DrawImage(space, space.Width - _moveSpace, 0);
            DoMoveSpace();
            
            _buffer.Render();
        }
    }
}
