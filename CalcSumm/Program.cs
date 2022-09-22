namespace Calc
{
    class Program
    {
        public static void Main()
        {
            ILogger log = new Logger();
            double a;
            double b;
            try
            {
                Console.WriteLine("Введите первое слагаемое");
                a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите второе слагаемое");
                b = Convert.ToDouble(Console.ReadLine());
                Plus summator = new Plus(log);
                var summ = ((ICalcPlus)summator).PlusAandB(a, b);
                Console.WriteLine($"Сумма введёных чисел равна {summ}");
            }
            catch
            {
                log.Error("Введено не корректное значение");
            }                        
            Console.ReadLine();
        }
    }
}
