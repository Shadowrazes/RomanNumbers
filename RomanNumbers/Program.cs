public class Program
{
    public static void Main()
    {
        RomanNumber a = new RomanNumber(1434);
        RomanNumber b = new RomanNumber(2368);
        Console.WriteLine(a.ToString());
        Console.WriteLine(b.ToString());
        RomanNumber c = RomanNumber.Sub(b, a);
        Console.WriteLine(c.ToString());
    }
}

