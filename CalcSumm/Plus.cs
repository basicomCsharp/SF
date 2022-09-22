using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class Plus : ICalcPlus
    {
        ILogger Logger { get; }
        public Plus(ILogger logger)
        {
            Logger = logger;
        }
        double ICalcPlus.PlusAandB(double aa, double bb)
        {
            try
            {
                Logger.Event("Идёт процесс сложение двух чисел...");
                return aa + bb;
            }
            catch (Exception e)
            {
                Logger.Error("При сложении произошла ошибка!");
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
