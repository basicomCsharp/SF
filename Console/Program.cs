using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsConsole
{
    internal class Program
    {             
        static string[] ArrayInputFromConsole(in int countArr, string textMessage)
        {
            var ArrayOut = new string[countArr];
            for (int i = 0; i < countArr; i++)
            {
                Console.WriteLine(textMessage);
                ArrayOut[i] = Console.ReadLine();
            }
            return ArrayOut;
        }
        static bool CheckEnter(in string sData, out int iData)
        {
            iData = 0;
            return Int32.TryParse(sData, out iData);
        }
        static (string FirstName, string LastName, int Age, int CountPet, string[] NamePet, int CountColor, string[] NameColor) GetInfoOwnerAndPet()
        {
            (string FirstName, string LastName, int Age, int CountPet, string[] NamePet, int CountColor, string[] NameColor) IOAP;

            Console.WriteLine("Введите свое имя:");
            IOAP.FirstName = Console.ReadLine();

            Console.WriteLine("Введите свою фамилию:");
            IOAP.LastName = Console.ReadLine();

            Console.WriteLine("Введите свой возраст:");
            string inputString = Console.ReadLine();                                    
            while(!CheckEnter(inputString, out IOAP.Age) || (IOAP.Age == 0))
            {
                Console.WriteLine("Введите свой возраст:");
                inputString = Console.ReadLine();
            }            
            
            Console.WriteLine("У Вас есть питомец? Y/N");
            if (Console.ReadLine().ToUpper().Equals("Y"))
            {
                Console.WriteLine("Введите количество питомцев:");
                inputString = Console.ReadLine();
                while (!CheckEnter(inputString, out IOAP.CountPet) && (IOAP.CountPet > 0))
                {
                    Console.WriteLine("Вы подтвердили, что у Вас есть питомцы, напишите их количество цифрами:");
                    inputString = Console.ReadLine();
                }
            }
            else
                IOAP.CountPet = 0;

            IOAP.NamePet = ArrayInputFromConsole(IOAP.CountPet, "Введите кличку питомца:");
            Console.WriteLine("Введите количество любимых цветов:");            
            inputString = Console.ReadLine();
            while (!CheckEnter(inputString, out IOAP.CountColor) && (IOAP.CountColor > 0))
            {
                Console.WriteLine("Напишите количество цифрами:");
                inputString = Console.ReadLine();
            }
            IOAP.NameColor = ArrayInputFromConsole(IOAP.CountColor, "Напишите название любимого цвета:");

            return IOAP;            
        }
        static void ShowMessageToConsole((string FirstName, string LastName, int Age, int CountPet, string[] NamePet, int CountColor, string[] NameColor) IOAP)
        {
            Console.WriteLine($"Анкета {IOAP.FirstName} {IOAP.LastName}");
            Console.WriteLine($"Возраст {IOAP.Age} \n Количество питомцев {IOAP.CountPet} \n Клички питомцев:");
            foreach(string nickname in IOAP.NamePet)
            {
                Console.WriteLine(nickname + "\n");
            }
            Console.WriteLine("Любимые цвета:");
            foreach (string colorname in IOAP.NameColor)
            {
                Console.WriteLine(colorname + "\n");
            }
        }
        static void Main(string[] args)
        {            
            ShowMessageToConsole(GetInfoOwnerAndPet());
            Console.WriteLine("Для выхода из программы нажмите любую клавишу");
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
