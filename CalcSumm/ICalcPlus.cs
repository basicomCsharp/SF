using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public interface ICalcPlus
    {
        /// <summary>
        /// Функция сложения двух чисел
        /// </summary>
        /// <param name="a">слагаемое</param>
        /// <param name="b">слагаемое</param>
        /// <returns>результат</returns>
        public double PlusAandB(double a, double b);        
    }
}
