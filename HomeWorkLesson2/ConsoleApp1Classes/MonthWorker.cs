using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1Classes
{
    /// <summary>
    /// Работник с фиксированной оплатой
    /// </summary>
    class MonthWorker : BaseWorker
    {
        private readonly double fixedMonthMoney;
        public MonthWorker(string surname, string name, int age, double fixedMonthMoney) : base(surname, name, age)
        {
            this.fixedMonthMoney = fixedMonthMoney;
        }
        /// <summary> Срденемесячная зарплата </summary> <returns>зарплата</returns>
        public override double GetMoney()
        {
            return fixedMonthMoney;
        }
    }
}
