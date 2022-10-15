using System.Diagnostics;

namespace SpeedWorkLinkAndLinckedLink
{
    internal class Program
    {
        //  Объявим  простой  словарь
        private static List<string> TextBook = new List<string>() {};
        private static string[] ReadTestOfFile()
        {
            try
            {
                // читаем весь файл с рабочего стола в строку текста
                string text = File.ReadAllText("G:\\SF\\Text1.txt");

                // Сохраняем символы-разделители в массив
                char[] delimiters = new char[] { ' ', '\r', '\n' };

                // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
                var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                // выводим количество
                return words;
            }
            catch
            { throw; }
        }
            

        static void Main(string[] args)
        {
            var text = ReadTestOfFile();
            // Запустим таймер
            var watchTwo = Stopwatch.StartNew();
            foreach(string word in text)
            {
                // Выполним вставку
                TextBook.Add(word);
            }            

            // Выведем результат
            Console.WriteLine($"Вставка в коллецию List длилась: {watchTwo.Elapsed.TotalMilliseconds}  мс");
            Console.WriteLine($"Размер коллеции до вставки тестового слова в середину: {TextBook.Count} слов");
            watchTwo = Stopwatch.StartNew();
            var indexElement = TextBook.IndexOf("лень");
            TextBook.Insert(indexElement, "testOfWord");
            Console.WriteLine($"Вставка в середину коллецию List тестового слова длилась: {watchTwo.Elapsed.TotalMilliseconds}  мс");
            Console.WriteLine($"Размер коллеции после вставки тестового слова в середину: {TextBook.Count} слов");

            Console.ReadLine();
        }
    }
}