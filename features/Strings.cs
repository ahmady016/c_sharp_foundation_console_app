public static class Strings
{
    public static void Run()
    {
        string firstName = "Ahmed";
        string lastName = "Hamdy";
        string fullName = $"{firstName} {lastName}";
        string greeting = $"Hello, {fullName}! Welcome to C# programming.";
        Console.WriteLine(greeting);
    }
}
