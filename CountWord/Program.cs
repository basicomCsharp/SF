namespace CountWord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // читаем весь файл с рабочего стола в строку текста
                string text = File.ReadAllText("G:\\SF\\SF\\CountWord\\cdev_Text.txt");

                // Сохраняем символы-разделители в массив
                char[] delimiters = new char[] { ' ', '\r', '\n' };

                // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
                var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                // выводим количество
                Console.WriteLine(words.Length);
            }
            catch
            { throw; }
        }
    }
}