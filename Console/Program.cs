using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsConsole
{
    internal class Program
    {
        static bool CheckEnter(in string sData, out int iData)
        {            
            return Int32.TryParse(sData, out iData);
        }
        static (string FirstName, string LastName, int Age, int CountPet, string[] NamePet) InfoOwnerAndPet()
        {
            (string FirstName, string LastName, int Age, int CountPet, string[] NamePet) IOAP;

            Console.WriteLine("Введите свое имя:");
            IOAP.FirstName = Console.ReadLine();

            Console.WriteLine("Введите свою фамилию:");
            IOAP.LastName = Console.ReadLine();

            Console.WriteLine("Введите свой возраст:");
            string inputString = Console.ReadLine();
            int age;                        
            while(!CheckEnter(inputString, out age) || (age == 0))
            {
                Console.WriteLine("Введите свой возраст:");
                inputString = Console.ReadLine();
            }
            IOAP.Age = age;
            Console.WriteLine("У Вас есть питомец? Y/N");
            int _countPet = 0;
            if (Console.ReadLine().ToUpper().Equals("Y"))
            {                
                Console.WriteLine("Введите количество питомцев:");
                inputString = Console.ReadLine();
                while (!CheckEnter(inputString, out _countPet) && (_countPet > 0))
                {
                    Console.WriteLine("Вы подтвердили, что у Вас есть питомцы, напишите их количество цифрами:");
                    inputString = Console.ReadLine();
                }
            }
            IOAP.CountPet = _countPet;
            IOAP.NamePet = new string[_countPet];
            for (int i=0; i < _countPet ; i++)
            {
                Console.WriteLine("Введите кличку питомца:");               
                IOAP.NamePet[i] = Console.ReadLine(); 
            }
            return IOAP;            
        }
        static void ShowMessageToConsole(ref myPets)
        {
            myPets
        }
       static void Main(string[] args)
        {
            public var MyFamalyAndOtherPets = InfoOwnerAndPet();
            //ShowMessageToConsole(ref MyFamalyAndOtherPets);
            Console.ReadKey();
            
            #region
            //for (int i = 5; i > 1; i--)
            //{
            //    Console.WriteLine("Iteration {0}", i);
            //    switch (Console.ReadLine())
            //    {
            //        case "red":
            //            Console.BackgroundColor = ConsoleColor.Red;
            //            Console.ForegroundColor = ConsoleColor.Black;

            //            Console.WriteLine("Your color is red!");
            //            break;

            //        case "green":
            //            Console.BackgroundColor = ConsoleColor.Green;
            //            Console.ForegroundColor = ConsoleColor.Black;

            //            Console.WriteLine("Your color is green!");
            //            break;

            //        case "cyan":
            //            Console.BackgroundColor = ConsoleColor.Cyan;
            //            Console.ForegroundColor = ConsoleColor.Black;

            //            Console.WriteLine("Your color is cyan!");
            //            break;
            //        default:
            //            Console.BackgroundColor = ConsoleColor.Yellow;
            //            Console.ForegroundColor = ConsoleColor.Black;

            //            Console.WriteLine("Your color is yellow!");
            //            break;
            //    }
            //}
            //Console.WriteLine("Your ");
            //Console.WriteLine("Your ");
            //Console.WriteLine("Your ");
            //Console.WriteLine("Your ");

            //Console.ReadKey();
            //var name = "";
            //var age = 0;
            //Console.WriteLine("What is your name?");
            //name = Console.ReadLine();
            //Console.WriteLine("What is your age?");

            //var res = int.TryParse(Console.ReadLine(), out age);

            //while (!res)
            //{
            //    Console.WriteLine("What is your age?");
            //    res = int.TryParse(Console.ReadLine(), out age);
            //}
            //if (age > 200)
            //{
            //    Console.WriteLine("Your name is Dinosaur {0} and age is {1} ", name, age);

            //}
            //else
            //{
            //    Console.WriteLine("Your name is {0} and age is {1} ", name, age);
            //}
            //Console.Write("Write your birthday ");
            //var day = Console.ReadLine();
            //Console.WriteLine("Your birthday is {0}", day);
            //Console.ReadKey();
            #endregion
        }
    }
}
