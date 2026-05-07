using System.Text;

public static class Methods
{
    private static readonly Random random = new();

    private static bool ValidIPv4Length(string[] numbers)
    {
        return numbers.Length == 4;
    }
    private static bool ValidIPv4Number(string[] numbers)
    {
        foreach (string number in numbers)
            if (number.Length > 1 && number.StartsWith('0'))
                return false;

        return true;
    }
    private static bool ValidIPv4NumberRange(string[] numbers)
    {
        foreach (string number in numbers)
            if (!byte.TryParse(number, out byte _))
                return false;

        return true;
    }

    public static void ValidateIPv4Addresses()
    {
        string[] ips = [
            "107.31.1.5",
            "255.0.0.255",
            "555..0.555",
            "055.175.255.045",
            "255.-1.25.255"
        ];

        Console.WriteLine("------------------------");
        Console.WriteLine("Validating IPv4 addresses...");
        Console.WriteLine("------------------------");

        string[] currentIPAddress;
        foreach (string ip in ips)
        {
            currentIPAddress = ip.Split('.', StringSplitOptions.RemoveEmptyEntries);
            if (ValidIPv4Length(currentIPAddress) && ValidIPv4Number(currentIPAddress) && ValidIPv4NumberRange(currentIPAddress))
                Console.WriteLine($"{ip} is a valid IPv4 address.");
            else
                Console.WriteLine($"{ip} is an invalid IPv4 address.");
        }
    }

    private static string ReverseStringCharacters(string str)
    {
        StringBuilder reversedString = new();
        for (int i = str.Length - 1; i >= 0; i--)
            reversedString.Append(str[i]);
        return reversedString.ToString();
    }
    private static string ReverseStringWords(string sentence)
    {
        StringBuilder reversedSentence = new();
        string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
            reversedSentence
                .Append(ReverseStringCharacters(word))
                .Append(' ');
        return reversedSentence.ToString().TrimEnd();
    }

    public static void ReverseSentences()
    {
        string[] sentences = [
            "This is a sample sentence to demonstrate string reversal.",
            "C# is a great programming language, Learning C# is fun and rewarding.",
            "The quick brown fox jumps over the lazy dog.",
            "I love coding. It's my favorite hobby and I enjoy it every day.",
            "String manipulation is an essential skill for any programmer."
        ];

        Console.WriteLine("------------------------");
        Console.WriteLine("Reversing Words in (5) Sentences...");
        Console.WriteLine("------------------------");

        foreach (string sentence in sentences)
        {
            Console.WriteLine($"Original Sentence: {sentence}");
            Console.WriteLine($"Reversed Sentence: {ReverseStringWords(sentence)}");
            Console.WriteLine("------------------------");
        }
    }

    private static void SwapElements(string[] array, int randomIndex, int i)
    {
        string temp = array[i];
        array[i] = array[randomIndex];
        array[randomIndex] = temp;
    }

    private static void RandomizeArray(string[] array)
    {
        int randomIndex, nextIndex;
        for (int i = 0; i < array.Length - 1; i++)
        {
            // If it's the second to last element get the last index as the random index
            // if not get random index from the next element to the end of the array
            nextIndex = i + 1;
            randomIndex = (i == array.Length - 2) ? nextIndex : random.Next(nextIndex, array.Length);
            // Swap the current element with the random element
            SwapElements(array, randomIndex, i);
        }
    }

    public static void RandomizeCountries()
    {
        string[] countries = [
            "United States", "Canada", "United Kingdom", "Australia",
            "Germany", "France", "Italy", "Spain", "Brazil", "India"
        ];
        Console.WriteLine("------------------------");
        Console.WriteLine("Randomizing Countries...");
        Console.WriteLine("------------------------");
        Console.WriteLine($"Original Countries: {string.Join(", ", countries)}");
        RandomizeArray(countries);
        Console.WriteLine($"Shuffled Countries: {string.Join(", ", countries)}");
    }

    public static void RandomizeUserIds()
    {
        string[] userIds = [
            "A750", "B123", "C456", "D789", "E000", "F001", "G002", "H003", "I004",
            "J005", "K006", "L007", "M008", "N009", "O010", "P011", "Q012", "R013",
            "S014", "T015", "U016", "V017", "W018", "X019", "Y020", "Z021"
        ];
        Console.WriteLine("------------------------");
        Console.WriteLine("Randomizing UserIds...");
        Console.WriteLine("------------------------");
        Console.WriteLine($"Original UserIds:\n{string.Join(", ", userIds)}");
        RandomizeArray(userIds);
        Console.WriteLine($"Shuffled UserIds:\n{string.Join(", ", userIds)}");
    }

    private static double CalculateTotal(params double[] prices)
    {
        double total = 0;
        foreach (double price in prices)
            total += price;
        return total;
    }

    public static void CalculateTotalPrices()
    {
        double[] prices = new double[10];
        for (int i = 0; i < prices.Length; i++)
            prices[i] = Math.Round(random.NextDouble() * 100, 2);

        Console.WriteLine("------------------------");
        Console.WriteLine("Calculating Total Purchase Prices...");
        Console.WriteLine("------------------------");
        Console.WriteLine($"Purchase Prices: [{string.Join(", ", prices)}]");
        double total = CalculateTotal(prices);
        Console.WriteLine($"Total Price: {total:F2}");
    }

    // method to calculate the BMI rate based on weight in kg and height in cm
    private static double CalculateBMIRate(double weightInKg, double heightInCm)
    {
        double heightInMeters = heightInCm / 100;
        return weightInKg / (heightInMeters * heightInMeters);
    }
    // based on the BMI rate returns its category
    // using switch expression with relational patterns
    private static string GetBMICategory(double bmiRate)
    {
        return bmiRate switch
        {
            < 18.5 => "Underweight",
            >= 18.5 and < 25 => "Normal",
            >= 25 and < 30 => "Overweight",
            _ => "Obese"
        };
    }
    // method that takes user info as a list of key value pairs
    // keys must be Name, Gender, WeightInKg, HeightInCm
    // and returns a dictionary with the same info and calculates the BMI rate and category
    private static Dictionary<string, string> GetUserInfo(params KeyValuePair<string, string>[] userInfos)
    {
        // the required keys for the user info
        string[] requiredKeys = ["Name", "Gender", "WeightInKg", "HeightInCm"];
        // check if more or less than the required keys are provided
        if (userInfos.Length != requiredKeys.Length)
            throw new ArgumentException($"Exactly {requiredKeys.Length} key-value pairs are required.");
        // check if any duplicate keys are provided
        HashSet<string> uniqueKeys = [];
        foreach (var (key, value) in userInfos)
            if (!uniqueKeys.Add(key))
                throw new ArgumentException($"Duplicate key: {key}.");
        // check if the provided unique keys are valid
        foreach (string key in uniqueKeys)
            if (!requiredKeys.Contains(key))
                throw new ArgumentException($"Invalid key: {key}.");

        // constructing the user info dictionary from the valid provided key value pairs
        Dictionary<string, string> userInfoDict = [];
        foreach (var (key, value) in userInfos)
            userInfoDict[key] = value;

        // calculating the BMI rate and category and adding them to the user info dictionary
        if (
            double.TryParse(userInfoDict["WeightInKg"], out double weight) &&
            double.TryParse(userInfoDict["HeightInCm"], out double height)
        )
        {
            double bmiRate = CalculateBMIRate(weight, height);
            userInfoDict["BMIRate"] = bmiRate.ToString("F2");
            userInfoDict["BMICategory"] = GetBMICategory(bmiRate);
        }
        else
            throw new ArgumentException("Weight and Height must be valid numbers.");

        // finally return the valid user info dictionary
        // with the calculated BMI rate and category
        return userInfoDict;
    }
    // helper method to print the user info in a formatted way
    private static void PrintUserInfo(Dictionary<string, string> userInfo)
    {
        Console.WriteLine("--------------------");
        Console.WriteLine("User Information:");
        Console.WriteLine("--------------------");
        foreach (var (key, value) in userInfo)
            Console.WriteLine($"{key}: {value}");
    }

    public static void GetUserInfoAndCalculateBMI()
    {
        Console.WriteLine("--------------------");
        Console.WriteLine("Getting User Info and Calculating BMI...");
        Console.WriteLine("--------------------");

        var result = GetUserInfo(
            new KeyValuePair<string, string>("Name", "Ahmad Hamdy"),
            new KeyValuePair<string, string>("Gender", "Male"),
            new KeyValuePair<string, string>("WeightInKg", "75"),
            new KeyValuePair<string, string>("HeightInCm", "180")
        );
        PrintUserInfo(result);
        result = GetUserInfo(
            new KeyValuePair<string, string>("Name", "Sara Ali"),
            new KeyValuePair<string, string>("Gender", "Female"),
            new KeyValuePair<string, string>("WeightInKg", "60"),
            new KeyValuePair<string, string>("HeightInCm", "165")
        );
        PrintUserInfo(result);
    }

}
