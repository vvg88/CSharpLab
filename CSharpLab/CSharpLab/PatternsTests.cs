using System.Collections;

namespace CSharpLab;

internal static class PatternsTests
{
    public static void Run()
    {
        PropertyPatternTest();
        Console.WriteLine();
        LogicalPatternTest();
        Console.WriteLine();
        TypePatternTest();
        Console.WriteLine();
        RelationalPatternTest();
    }

    private record Point(double x, double y);
    private record Shape(Point center);
    private record Circle(Point center, double radius) : Shape(center);
    private record Square(Point center, double size) : Shape(center);
    private static void PropertyPatternTest()
    {
        Console.WriteLine("Property pattern test...");
        
        Shape shape = new Circle(new Point(0, 0), 1);
        Console.WriteLine(GetShapeDescription(shape));

        shape = shape with { center = new Point(1, 1) };
        Console.WriteLine(GetShapeDescription(shape));

        shape = (shape as Circle) with { radius = 5 };
        Console.WriteLine(GetShapeDescription(shape));

        shape = new Square(shape.center, 3);
        Console.WriteLine(GetShapeDescription(shape));

        if (shape is Square sqr)
        {
            shape = sqr with { size = 5 };
        }
        Console.WriteLine(GetShapeDescription(shape));

        static string GetShapeDescription(Shape shape) => $"{shape}: This is " +
            shape switch
            {
                Circle { radius: 5 } => "a circle with radius 5",
                Circle { radius: 10 } => "a circle with radius 10",
                Circle { center.x: 0, center.y: 0 } => "a circle with the center on {0; 0}",
                Square { size: 3 } => "a square of size 3",
                Square => "a square",
                _ => "something else",
            };
    }

    private static void LogicalPatternTest()
    {
        Console.WriteLine("Logical pattern test:");
        Console.WriteLine(GetWorkingShift(new(2023, 10, 22)));
        Console.WriteLine(GetWorkingShift(new(2023, 10, 23)));
        Console.WriteLine(GetWorkingShift(new(2023, 10, 24)));
        
        static string GetWorkingShift(DateOnly date) => $"On {date} we work: " +
            date.DayOfWeek switch
            {
                DayOfWeek.Monday or DayOfWeek.Wednesday or DayOfWeek.Friday => "Morning shift",
                DayOfWeek.Tuesday or DayOfWeek.Thursday => "Evening shift",
                _ => "weekend",
            };
    }

    private static void RelationalPatternTest()
    {
        Console.WriteLine(GetWaterCondition(-5));
        Console.WriteLine(GetWaterCondition(5));
        Console.WriteLine(GetWaterCondition(11));
        Console.WriteLine(GetWaterCondition(40));
        Console.WriteLine(GetWaterCondition(70));
        Console.WriteLine(GetWaterCondition(55));
        Console.WriteLine(GetWaterCondition(150));

        static string GetWaterCondition(short temp) =>
            $"Water having the temperature {temp} degrees is "
            + temp switch
        {
            <= 0 => "Ice",
            > 0 and <= 10 => "cold",
            > 10 and <= 30 => "warm",
            > 30 and <= 50 => "hot",
            > 50 and <= 100 => "very hot",
            > 100 => "Steam",
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

        static string GetMsg<T>(T arg) => arg switch
        {
            Array => "This is an array",
            ICollection => "This is a collection",
            _ => "This is something else",
        };
    }
}
