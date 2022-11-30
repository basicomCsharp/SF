namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iterator = 0;
            int[] array = { 1, 2, 3, 4, 5, 6 };
            var f = array.Where(n => n > 3).Select(_ => iterator++);
            Console.WriteLine(f.First());
            Console.WriteLine(iterator);
        }
    }
}