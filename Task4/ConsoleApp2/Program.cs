using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    public class Program
    {
        static void Main(string[] args)            
        {           
            var FileName = String.Empty;
            Console.WriteLine("Введите путь и имя файла для бинарного чтения");
            do
            {
                FileName = Console.ReadLine();
                if (File.Exists(FileName))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
                    {
                        try
                        {
                            Student[] students = (Student[])formatter.Deserialize(fs);
                            Console.WriteLine(students[0].Name);
                            Console.WriteLine(students[0].Group);
                            Console.WriteLine(students[0].DateOfBirth.ToShortDateString());
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Путь указан не верно или файл не существует, \nповторите ввод или закройте программу");
                }
            } while (true);
            Console.ReadKey();
        }        
    }
}
