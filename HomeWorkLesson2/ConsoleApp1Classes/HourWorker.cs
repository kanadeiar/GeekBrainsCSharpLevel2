using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1Classes
{
    /// <summary>
    /// Работник с почасовой оплатой
    /// </summary>
    class HourWorker : BaseWorker
    {
        private readonly double hourMoney;
        public HourWorker(string surname, string name, int age, double hourMoney) : base(surname, name, age)
        {
            this.hourMoney = hourMoney;
        }
        /// <summary> Срденемесячная зарплата </summary> <returns>зарплата</returns>
        public override double GetMoney()
        {
            return 20.8 * 8.0 * hourMoney;
        }
    }
}
