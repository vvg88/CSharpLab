namespace CSharpLab
{
    internal static class RangesTest
    {
        public static void Run()
        {
            var array = new[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(array.EnumerableToString());

            var arrayTmp = array[1..];
            Console.WriteLine(arrayTmp.EnumerableToString());

            arrayTmp = array[^2..];
            Console.WriteLine(arrayTmp.EnumerableToString());

            arrayTmp = array[..^2];
            Console.WriteLine(arrayTmp.EnumerableToString());

            arrayTmp = array[1..^2];
            Console.WriteLine(arrayTmp.EnumerableToString());
        }
    }
}
