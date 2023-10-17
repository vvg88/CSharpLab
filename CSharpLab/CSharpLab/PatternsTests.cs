using System.Collections;

namespace CSharpLab;

internal static class PatternsTests
{
    public static void Run()
    {
        TypePatternTest();
        Console.WriteLine();
        RelationalPatternTest();
    }

    private static void RelationalPatternTest()
    {
        Console.WriteLine(GetWaterCondition(-5));
        Console.WriteLine(GetWaterCondition(55));
        Console.WriteLine(GetWaterCondition(150));

        string GetWaterCondition(short temp) =>
            $"Water having the temperature {temp} degrees is "
            + temp switch
        {
            < 0 => "Ice",
            > 100 => "Steam",
            _ => "Liquid",
        };
    }

    private static void TypePatternTest()
    {
        Console.WriteLine("Type pattern test:");
        var arr = new[] { 1, 2, 3 };
        var lst = new List<char> { 'a', 'b', 'c', };
        var str = "Some string";

        Console.WriteLine($"{GetMsg(arr)}: {arr.AsString()}");
        Console.WriteLine($"{GetMsg(lst)}: {lst.AsString()}");
        Console.WriteLine($"{GetMsg(str)}: {str}");

        string GetMsg<T>(T arg) => arg switch
        {
            Array => "This is an array",
            ICollection => "This is a collection",
            _ => "This is something else",
        };
    }
}
