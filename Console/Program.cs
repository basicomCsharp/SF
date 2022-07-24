using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var name = "";
            var age = 0;
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            Console.WriteLine("What is your age?");
            
            var res = int.TryParse(Console.ReadLine(), out age);
            
            while (!res)
            {
                Console.WriteLine("What is your age?");
                res = int.TryParse(Console.ReadLine(), out age);
            }
            if (age > 200)
            {
                Console.WriteLine("Your name is Dinosaur {0} and age is {1} ", name, age);

            }
            else
            {
                Console.WriteLine("Your name is {0} and age is {1} ", name, age);
            }
            Console.Write("Write your birthday ");
            var day = Console.ReadLine();
            Console.WriteLine("Your birthday is {0}", day);
            Console.ReadKey();
        }
    }
}
