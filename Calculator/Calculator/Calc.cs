using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calc
    {
        public int Sum(int a, int b)
        {
            return checked(a + b);
        }

        public Size GetSize(int sizeNumber)
        {
            if (sizeNumber >= 500)
                return Size.Big;
            if (sizeNumber < 100)
                return Size.Small;
            return Size.Normal;
        }

        public bool IsWeekend(DateTime dt)
        {
            return dt.DayOfWeek == DayOfWeek.Saturday ||
                   dt.DayOfWeek == DayOfWeek.Sunday;
        }

        public bool IsWeekendToday()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Saturday ||
                   DateTime.Now.DayOfWeek == DayOfWeek.Sunday;
        }
    }

    public enum Size
    {
        Big,
        Normal,
        Small
    }

}
