using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        var res = GetCoords();

        var p1 = new Point();
        var p2 = new Point();

        Select(() => Console.ReadKey(true).Key == ConsoleKey.Y, ref p1, ref p2).X = 5;

        Log(nameof(p1), p1);
        Log(nameof(p2), p2);
    }

    private static void Log(string name, Point point) => Console.WriteLine($"{name}: x:{point.X}, y:{point.Y}");

    private static void Test1(object o)
    {
        if (o is int i || (o is string s && int.TryParse(s, out i)))
            Console.WriteLine($"i={i}");
    }

    private static void Test2(object value)
    {
        switch (value)
        {
            case int x when x > 0:
                Console.WriteLine($"value is int {x}");
                break;
            case double x when x == 0:
                Console.WriteLine($"value is int {x}");
                break;
            default:
                Console.WriteLine("don't know x type");
                break;
            case null:
                throw new ArgumentNullException(nameof(value));
        }
    }

    private static (int X, int Y) GetCoords() => (1, 2);

    private static ref Point Select(Func<bool> choose, ref Point a, ref Point b)
    {
        switch (choose())
        {
            case true:
                return ref a;
            default:
                return ref b;
        }
    }

    public int Fibonacci(int x)
    {
        if (x < 0)
            throw new ArgumentException("Less negativity please!", nameof(x));

        return Fib(x).current;

        (int current, int previous) Fib(int i)
        {
            if (i == 0)
                return (1, 0);

            var (p, pp) = Fib(i - 1);

            return (p + pp, p);
        }
    }

    public IEnumerable<T> Filter<T>(IEnumerable<T> source, Func<T, bool> filter)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (filter == null) throw new ArgumentNullException(nameof(filter));

        return Iterator();

        IEnumerable<T> Iterator()
        {
            foreach (var element in source)
            {
                if (filter(element)) { yield return element; }
            }
        }
    }

    private (int, int, int) CheckLiterals()
    {
        var d = 123_456;
        var x = 0xAB_CD_EF;
        var b = 0b1010_1011_1100_1101_1110_1111;

        return (d, x, b);
    }
}

public class Point
{
    public int X { get; set; }

    public int Y { get; set; }

    public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
}

class Person
{
    private static ConcurrentDictionary<int, string> names = new ConcurrentDictionary<int, string>();

    private int id;

    private string Name;

    public string GetFirstName()
    {
        var parts = Name.Split(' ');
        return (parts.Length > 0) ? parts[0] : throw new InvalidOperationException("No name!");
    }

    public string GetLastName() => throw new NotImplementedException();

    //public Person(string name) => names.TryAdd(id, name); // constructors

    //~Person() => names.TryRemove(id, out var res);              // destructors

    //public string Name
    //{
    //    get => names[id];                                 // getters
    //    set => names[id] = value;                         // setters
    //}
}