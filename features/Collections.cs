public class Collections
{
    private static readonly Random random = new();

    // method to get a list of random numbers given the desired length
    private static List<int> GetRandomNumbers(int length = 10)
    {
        List<int> randomNumbers = new(length);
        for (int i = 0; i < length; i++)
            randomNumbers.Add(random.Next(1, 1000));
        return randomNumbers;
    }
    // method to get a list of random string Ids given the desired length
    // each id is a letter from A to Z and a three-digit number
    private static List<string> GetRandomIds(int length = 10)
    {
        List<string> randomIds = new(length);
        for (int i = 0; i < length; i++)
            randomIds.Add($"{Convert.ToChar(random.Next(65, 91))}{random.Next(1, 1000):000}");
        return randomIds;
    }

    // method to demonstrate the use of the GetRandomNumbers and GetRandomIds methods
    // collect the user name and the length of the list to generate
    // generate the list of random numbers and ids using the same length
    // finally print the user name, list count and list of random numbers and ids
    public static void ShowRandomNumbersAndIds()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Random Numbers and Ids");
        Console.WriteLine("---------------------");
        try
        {
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("you must enter your name");

            Console.Write("Enter the length of the list: ");
            if (!int.TryParse(Console.ReadLine() ?? string.Empty, out int length))
                throw new ArgumentException("Invalid length format. Please enter a valid number.");

            List<int> randomNumbers = GetRandomNumbers(length);
            List<string> randomIds = GetRandomIds(length);

            Console.WriteLine("---------------------");
            Console.WriteLine($"Hi {userName}, list of {length} random numbers and ids are generated successfully:");
            Console.WriteLine($"numbers: [{string.Join(", ", randomNumbers)}]");
            Console.WriteLine($"ids: [{string.Join(", ", randomIds)}]");
            Console.WriteLine("---------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}
