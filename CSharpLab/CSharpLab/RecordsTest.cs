namespace CSharpLab;

internal static class RecordsTest
{
    public static void Run()
    {
        Console.WriteLine("Testing records...");
        TestRecord();

        Console.WriteLine("Testing record structs...");
        TestRecordStruct();
    }

    private static void TestRecordStruct()
    {
        Rectangle rect = new(2, 1);
        Rectangle rectTwo = rect with { Length = 3 };
        rectTwo.Width = 2;
        Console.WriteLine($"rect: {rect}\nrectTwo: {rectTwo}");
    }

    private static void TestRecord()
    {
        Person boy = new("Tom", "Hanson");
        Person girl = boy with { Firstname = "Summer", Lastname = "Finn" };
        Console.WriteLine($"Boy, {boy}");
        Console.WriteLine($"Girl, {girl}");

        Person anotherBoy = new("Tom", "Hanson");
        Console.WriteLine($"boy {boy} is the same as another boy {anotherBoy} {boy == anotherBoy}");
    }

    private record Person(string Firstname, string Lastname);

    private record struct Rectangle(double Length, double Width);
}
