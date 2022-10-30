using System;
using System.Collections.Generic;
using System.Linq;

namespace LINK14._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var classes = new[]
{
               new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
               new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
               new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
           };
            var allStudents = GetAllStudents(classes);

            Console.WriteLine(string.Join(" ", allStudents));
            Console.ReadKey();
        }
        /// <summary>
        /// Метод, который соберет всех учеников всех классов в один список, используя LINQ.
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        static string[] GetAllStudents(Classroom[] classes)
        {
            return classes.SelectMany(s => s.Students).ToArray();
        }

        public class Classroom
        {
            public List<string> Students = new List<string>();
        }
    }
}