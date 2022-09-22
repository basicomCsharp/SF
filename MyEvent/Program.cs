// See https://aka.ms/new-console-template for more information

try
{
    List<String> Family = new List<String>();
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("Введите {0}-ю фамилию",i+1);
        var str = Console.ReadLine();
        if(str != null) 
            Family.Add(str);        
    }
    Console.WriteLine("Введите 1 для сортировки фамилий по алфавиту или 2 в обратном порядке");
    var FlagSort = Console.ReadLine();
    if (FlagSort !=null)
    {
        if (FlagSort.Equals("1"))
            Sort.AlfaSort(Family);
        else if (FlagSort.Equals("2"))
            Sort.OmegaSort(Family);
    }
    Console.ReadKey();

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
public delegate void SortFamilyDelegate(List<String> fs);
//public event SortFamilyDelegate EventSort  OmegaSort;
public static class Sort
{
    public static void OmegaSort(List<String> fs)
    {
        fs.Sort();
        fs.Reverse();
        foreach (var f in fs)
        {
            Console.WriteLine(f);
        }
    }
    public static void AlfaSort(List<String> fs)
    {
        fs.Sort();
        foreach(var f in fs)
        {
            Console.WriteLine(f);
        }
    }
}
