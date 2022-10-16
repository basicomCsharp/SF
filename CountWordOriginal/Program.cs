using static System.Net.Mime.MediaTypeNames;

namespace CountWordOriginal
{
    internal class Program
    {
        private static string[] ReadTestOfFile()
        {
            try
            {
                // читаем весь файл с рабочего стола в строку текста
                string text = File.ReadAllText("G:\\SF\\Text1.txt");

                var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
                // Сохраняем символы-разделители в массив
                char[] delimiters = new char[] { ' ', '\r', '\n', ',' };

                // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
                var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                // выводим количество
                return words;
            }
            catch
            { throw; }
        }        
        static void Main(string[] args)
        {            
            var text = ReadTestOfFile();
            var dict = new Dictionary<string, int>();
            foreach(string word in text)
            {
                try
                {
                    if(!dict.TryAdd(word, 1))
                        if (dict.TryGetValue(word, out int value))
                            dict[word] = value + 1;
                }
                catch (ArgumentException)
                {
                    if (dict.TryGetValue(word, out int value))
                        dict[word] = value + 1;
                }
                catch { throw; }
            }
            List<KeyValuePair<string, int>> sotredWord = dict.OrderBy(d => d.Value).ToList();
            Console.WriteLine("Чаще всего встречаются в тексте следующие слова: ");
            for(int i = 1; i<11; i++)
            {
                var number = sotredWord.Count - i;
                Console.WriteLine(sotredWord[number] + " раз");
            }
            Console.ReadLine();
        }
    }
}