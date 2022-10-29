namespace LINQ14
{
    using System.Linq;
    using System.Numerics;
    using System.Xml.Linq;
    using static System.Net.Mime.MediaTypeNames;

    public class Contact
    {
        public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));
            #region
            //while (true)
            //{
            //    //Console.Clear();
            //    Console.WriteLine("Введите номер страницы:");
            //    var text = Console.ReadLine();
            //    if (int.TryParse(text, out int number))
            //    {
            //        var page = phoneBook.Skip(number * 2).Take(2);
            //        foreach(var contact in page)
            //            Console.WriteLine(contact.Name + " " + contact.Phone);
            //    }                
            //}
            #endregion
            //отсортировать контакты в телефонной книге сперва по имени, а затем по фамилии
            var phoneBookSort = phoneBook.OrderBy(n => n.Name).OrderBy(n => n.LastName);
            Console.WriteLine("Результат сортровки телефонной книги по имени, а затем по фамилии:");
            foreach (var entry in phoneBookSort)
                Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

            Console.ReadKey();
            #region
            //while (true)
            //{
            //    // Читаем введенный с консоли символ
            //    var input = Console.ReadKey().KeyChar;

            //    // проверяем, число ли это
            //    var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

            //    // если не соответствует критериям - показываем ошибку
            //    if (!parsed || pageNumber < 1 || pageNumber > 3)
            //    {
            //        Console.WriteLine();
            //        Console.WriteLine("Страницы не существует");
            //    }
            //    // если соответствует - запускаем вывод
            //    else
            //    {
            //        // пропускаем нужное количество элементов и берем 2 для показа на странице
            //        var pageContent = phoneBookSort.Skip((pageNumber - 1) * 20).Take(20);
            //        Console.WriteLine();

            //        // выводим результат
            //        foreach (var entry in pageContent)
            //            Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);
                    
            //        Console.WriteLine();
            //    }
            //}
            #endregion
        }
    }
}