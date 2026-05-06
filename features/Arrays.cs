public static class Arrays
{
    private static readonly Random random = new();

    // method to generate random string Ids giving the count of Ids to generate
    // each Id is a letter from A to Z and a three-digit number
    // and return an array of them
    private static string[] GenerateRandomIds(ushort count)
    {
        string[] ids = new string[count];
        for (int i = 0; i < ids.Length; i++)
        {
            char letter = Convert.ToChar(random.Next(65, 91));
            string threeDigitNumber = random.Next(1, 1000).ToString("000");
            ids[i] = $"{letter}{threeDigitNumber}";
        }
        return ids;
    }

    public static void OldArrayInitialization()
    {
        string[] userIds = new string[5];
        userIds[0] = "123e4567-e89b-12d3-a456-426614174000";
        userIds[1] = "123e4567-e89b-12d3-a456-426614174001";
        userIds[2] = "123e4567-e89b-12d3-a456-426614174002";
        userIds[3] = "123e4567-e89b-12d3-a456-426614174003";
        userIds[4] = "123e4567-e89b-12d3-a456-426614174004";

        Console.WriteLine("---------------------");
        Console.WriteLine("Old Array Initialization:");
        Console.WriteLine("---------------------");
        Console.WriteLine($"Array Length: {userIds.Length}");
        Console.WriteLine(string.Join(", ", userIds));
    }

    public static void NewArrayInitialization()
    {
        string[] userIds = [
            "123e4567-e89b-12d3-a456-426614174000",
            "123e4567-e89b-12d3-a456-426614174001",
            "123e4567-e89b-12d3-a456-426614174002",
            "123e4567-e89b-12d3-a456-426614174003",
            "123e4567-e89b-12d3-a456-426614174004"
        ];

        Console.WriteLine("---------------------");
        Console.WriteLine("New Array Initialization:");
        Console.WriteLine("---------------------");
        Console.WriteLine($"Array Length: {userIds.Length}");
        Console.WriteLine(string.Join(", ", userIds));
    }

    public static void NewArrayInitializationWithForeachLoop()
    {
        string[] userIds = [
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString()
        ];

        Console.WriteLine("---------------------");
        Console.WriteLine("New Array Initialization with Foreach Loop:");
        Console.WriteLine("---------------------");
        Console.WriteLine($"Array Length: {userIds.Length}");
        foreach (string userId in userIds)
            Console.WriteLine(userId);
    }

    public static void GetRandomNumbersAndTheirSum()
    {
        int[] randomNumbers = [
            random.Next(1, 1000),
            random.Next(1, 1000),
            random.Next(1, 1000),
            random.Next(1, 1000),
            random.Next(1, 1000)
        ];

        int sum = 0;
        foreach (int number in randomNumbers)
            sum += number;

        Console.WriteLine("---------------------");
        Console.WriteLine("Random Numbers and Their Sum:");
        Console.WriteLine("---------------------");
        Console.WriteLine($"Random Numbers: {string.Join(", ", randomNumbers)}");
        Console.WriteLine($"Numbers Total: {sum}");
    }

    public static void GetRandomNumbersAndPrintOddNumbers()
    {
        int[] randomNumbers = [
            random.Next(1, 1000),
            random.Next(1, 1000),
            random.Next(1, 1000),
            random.Next(1, 1000),
            random.Next(1, 1000)
        ];

        Console.WriteLine("---------------------");
        Console.WriteLine("Random Numbers and Print Odd Numbers:");
        Console.WriteLine("---------------------");
        Console.WriteLine($"({randomNumbers.Length}) Random Numbers: [{string.Join(", ", randomNumbers)}]");
        Console.WriteLine("Odd Numbers:");
        foreach (int number in randomNumbers)
            if (number % 2 != 0)
                Console.WriteLine(number);
    }

    public static void SortAndReverseArray()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Sorting and Reversing an Array:");
        Console.WriteLine("---------------------");

        string[] randomIds = GenerateRandomIds(10);
        Console.WriteLine($"Original Array: [{string.Join(", ", randomIds)}]");
        Array.Sort(randomIds);
        Console.WriteLine($"Sorted Array: [{string.Join(", ", randomIds)}]");
        Array.Reverse(randomIds);
        Console.WriteLine($"Reversed Array: [{string.Join(", ", randomIds)}]");
    }

    // method to reverse a string given from the user and print it
    // using string.Split() and string.Join() methods
    public static void ReverseStringWords()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Reversing a String With Split and Join:");
        Console.WriteLine("---------------------");

        string userInput;
        do
        {
            Console.WriteLine("Enter a string to be reversed:");
            userInput = Console.ReadLine() ?? string.Empty;
        } while (string.IsNullOrWhiteSpace(userInput));

        string[] charArray = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string reversedString = string.Join(" ", charArray.Reverse());

        Console.WriteLine($"Original String: {userInput}");
        Console.WriteLine($"Reversed String: {reversedString}");
    }

    // method to reverse a string given from the user and print it
    // using string.ToCharArray() and Array.Reverse() methods
    public static void ReverseStringCharacters()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Reversing a String With Char Array:");
        Console.WriteLine("---------------------");

        string userInput;
        do
        {
            Console.WriteLine("Enter a string to be reversed:");
            userInput = Console.ReadLine() ?? string.Empty;
        } while (string.IsNullOrWhiteSpace(userInput));

        char[] charArray = userInput.ToCharArray();
        Array.Reverse(charArray);
        string reversedString = new(charArray);

        Console.WriteLine($"Original String: {userInput}");
        Console.WriteLine($"Reversed String: {reversedString}");
    }

    // The following code creates five random UserIDs
    // UserIDs consist of a letter from A to Z
    // and a three-digit number. like. A123.
    public static void GenerateRandomUserIds()
    {
        string[] userIds = GenerateRandomIds(5);
        Console.WriteLine("---------------------");
        Console.WriteLine("Random User IDs:");
        Console.WriteLine("---------------------");
        Console.WriteLine($"[{string.Join(", ", userIds)}]");
    }

    private static string CalculateStudentGrade(float score)
    {
        return score switch
        {
            >= 97 => "A+",
            >= 93 => "A",
            >= 90 => "A-",
            >= 87 => "B+",
            >= 83 => "B",
            >= 80 => "B-",
            >= 77 => "C+",
            >= 73 => "C",
            >= 70 => "C-",
            >= 67 => "D+",
            >= 63 => "D",
            >= 60 => "D-",
            _ => "F"
        };
    }

    private static void CalculateStudentScore(string studentName, byte[] scores)
    {
        short totalScore = 0;
        foreach (byte score in scores)
            totalScore += score;
        float averageScore = (float)(totalScore / scores.Length);
        string grade = CalculateStudentGrade(averageScore);

        Console.WriteLine($"{studentName}'s Scores: [{string.Join(", ", scores)}]");
        Console.WriteLine($"{studentName}'s Total Score: {totalScore}");
        Console.WriteLine($"{studentName}'s Average Score: {averageScore:F2}");
        Console.WriteLine($"{studentName}'s Grade: {grade}");
    }

    public static void CalculateStudentsScores()
    {
        byte[] ahmedScores = [85, 90, 78, 92, 88];
        byte[] saraScores = [90, 95, 80, 85, 91];
        byte[] omarScores = [80, 85, 88, 90, 92];
        byte[] emanScores = [88, 92, 85, 90, 87];
        byte[] fawzyScores = [75, 88, 66, 93, 77];

        Console.WriteLine("---------------------");
        Console.WriteLine("Calculating students' scores and grades...");
        Console.WriteLine("---------------------");
        CalculateStudentScore("Ahmed", ahmedScores);
        CalculateStudentScore("Sara", saraScores);
        CalculateStudentScore("Omar", omarScores);
        CalculateStudentScore("Eman", emanScores);
        CalculateStudentScore("Fawzy", fawzyScores);
    }
}