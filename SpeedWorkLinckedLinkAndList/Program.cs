using System.Diagnostics;

namespace SpeedWorkLinckedLinkAndList
{
    internal class Program
    {
        //  Объявим  простой  словарь
        private static LinkedList<string> TextBook = new LinkedList<string>() { };
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
            foreach (string word in text)
            {
                // Выполним вставку
                TextBook.AddLast(word);
            }
            // Выведем результат
            Console.WriteLine($"Вставка в коллецию LinkedList длилась: {watchTwo.Elapsed.TotalMilliseconds}  мс");
            Console.WriteLine($"Размер коллеции до вставки тестового слова в середину: {TextBook.Count} слов");
            watchTwo = Stopwatch.StartNew();
            var resultFind = TextBook.Find("лень");
            if (resultFind != null)
            {
                TextBook.AddAfter(resultFind, "testOfWord");
                Console.WriteLine($"Вставка в середину LinkedList длилась: {watchTwo.Elapsed.TotalMilliseconds}  мс");
            }
            Console.WriteLine($"Размер коллеции после вставки тестового слова в середину: {TextBook.Count} слов");
            Console.ReadLine();
        }
    }
}