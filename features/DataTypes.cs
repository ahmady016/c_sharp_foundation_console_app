using System.Text;

public static class DataTypes
{
    // a method to do the flowing giving array of string inputs:
    // If the value is alphabetical, concatenate it to form a message.
    // If the value is numeric, add it to the total.
    // finally print the message and the total.
    public static void StringToNumberConversions()
    {
        string[] userInputs = [
            "123", "3.14", "-42", "Hello", "1000", "World", "2.71828",
            "to", "be", "or not", "to", "be",
            "0.001", "1.0", "2.5", "3", "4.5", "5", "6.0", "7", "8.5", "9", "10.0",
            "This", "is", "a", "test", "of", "string", "to", "number", "conversions."
        ];

        Console.WriteLine("----------------------");
        Console.WriteLine("String To Numbers Conversions");
        Console.WriteLine("----------------------");

        StringBuilder message = new();
        float total = 0;
        foreach (string input in userInputs)
        {
            if (float.TryParse(input, out float number))
                total += number;
            else
                message.Append($" {input}");
        }

        Console.WriteLine($"Message: {message.ToString().TrimStart()}");
        Console.WriteLine($"Total: {total}");
    }

    // a method to print the range of values for each of the integral types in C#.
    public static void Integers()
    {
        Console.WriteLine("----------------------");
        Console.WriteLine("Signed integral types:");
        Console.WriteLine("----------------------");
        Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}");
        Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
        Console.WriteLine($"int    : {int.MinValue} to {int.MaxValue}");
        Console.WriteLine($"long   : {long.MinValue} to {long.MaxValue}");

        Console.WriteLine("----------------------");
        Console.WriteLine("Unsigned integral types:");
        Console.WriteLine("----------------------");
        Console.WriteLine($"byte   : {byte.MinValue} to {byte.MaxValue}");
        Console.WriteLine($"ushort : {ushort.MinValue} to {ushort.MaxValue}");
        Console.WriteLine($"uint   : {uint.MinValue} to {uint.MaxValue}");
        Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");
    }

    // a method to print the range of values for each of the floating-point types in C#.
    public static void Decimals()
    {
        Console.WriteLine("----------------------");
        Console.WriteLine("Decimal types:");
        Console.WriteLine("----------------------");
        Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
        Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
        Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");
    }
}
