using Newtonsoft.Json;
using System.Text.Json;
try
{
    Count counter = new Count();
    Console.WriteLine("Iнiцiалiзацiю лiчильника значеннями за замовчуванням(1) i довiльними значеннями(2)");
    int a = Convert.ToInt32(Console.ReadLine());
    counter.count = 0;
    if (a == 1)
    {
        counter.count = 0;
        counter.start = 0;
        counter.end = 20;
    }
    else if (a == 2)
    {
        Console.WriteLine("Виберiть початок дiапазону");
        counter.start = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Виберiть кiнець дiапазону");
        counter.end = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Виберiть число в заданому дiапазонi");
        counter.count = Convert.ToInt32(Console.ReadLine());
    }
    else
    {
        Console.WriteLine("Такого варiанту немає");
    }
    for (int i = 0; i < counter.end; i++)
    {
        Console.WriteLine("Збiльшення лiчильника(1), зменшення(2) або поточний стан(3)");
        counter.opt = Convert.ToInt32(Console.ReadLine());
        if (counter.opt == 1)
        {
            counter.Increment();
        }
        else if (counter.opt == 2)
        {
            counter.Decrement();
        }
        else if (counter.opt == 3)
        {
            counter.Print();
        }
        else
        {
            Console.WriteLine("Такого варiанту немає");
        }
    }
    static void Serialize(Count counter)
    {
        var json = JsonConvert.SerializeObject(counter);
        File.WriteAllText(@"D:\count.json", json);
    }
    static void Deserialize(Count counter)
    {
        string jsonString = File.ReadAllText(@"D:\count.json");
        Count cast = System.Text.Json.JsonSerializer.Deserialize<Count>(jsonString)!;
    }
    Serialize(counter);
    Deserialize(counter);
}
catch
{
    Console.WriteLine("Некоректнi данi");
}
Console.ReadKey();
class Count
{
    public int start;
    public int end;
    public int opt;
    public int count;
    public void Increment()
    {
        count++;
    }
    public void Decrement()
    {
        count--;
    }
    public void Print()
    {
        Console.WriteLine("Поточний стан "+count);
    }
    private int State
    {
        get
        {
            return count;
        }
        set
        {
            count = value;
        }
    }
}