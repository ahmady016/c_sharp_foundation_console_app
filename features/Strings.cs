using System.Text;

public static class Strings
{
    private static readonly Random random = new();

    // method to extract, replace, and remove data from an input html string
    // using string methods like replace and trim
    // extract the title, unit price, quantity, and total price from the html string
    public static void RemoveTagsFromHtmlString()
    {
        string htmlString = @"
            <div>
                <h1>Ahmed Hamdy Order</h1>
                <p>
                    <span>Unit Price: </span>
                    <span>$19.99</span>
                </p>
                <p>
                    <span>Quantity: </span>
                    <span>10</span>
                </p>
                <p>
                    <span>Total Price: </span>
                    <span>$199.90</span>
                </p>
            </div>
        ";

        string[] tagsToRemove = ["<div>", "</div>", "<h1>", "</h1>", "<p>", "</p>", "<span>", "</span>"];
        foreach (string tag in tagsToRemove)
            htmlString = htmlString.Replace(tag, string.Empty);

        Console.WriteLine("-----------------------");
        Console.WriteLine("Extracted and Replaced tags from HTML String:");
        Console.WriteLine("-----------------------");

        string[] lines = htmlString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < lines.Length; i++)
            lines[i] = lines[i].Trim();
        Console.WriteLine(string.Join(' ', lines).Trim());
    }

    // method to get all occurrences of a substring in a given string
    // and construct a new string with the found substrings separated by commas
    public static void GetAllOccurrencesOfSubstring()
    {
        string text = "(What if) The quick brown fox jumps (more than once) over the lazy dog. (The dog was not happy) The dog barked at the fox. (The dog was very angry) with the fox.";

        const char START_DELIMITER = '(';
        const char END_DELIMITER = ')';

        int startIndex, endIndex;
        StringBuilder result = new();
        while(true)
        {
            // get the index of the start delimiter
            startIndex = text.IndexOf(START_DELIMITER);
            // if the start delimiter is not found, break the loop
            if (startIndex == -1) break;
            // move the start index to the character after the start delimiter
            startIndex++;
            // get the index of the end delimiter
            endIndex = text.IndexOf(END_DELIMITER);
            // substring the text between the start and end indices
            // and append it to the result line by line
            result.AppendLine(text[startIndex..endIndex]);
            // update the original text
            // to continue from the remaining part after the found substring
            text = text[(endIndex + 1)..];
        }

        Console.WriteLine("-----------------------");
        Console.WriteLine("Get All Occurrences of Substring:");
        Console.WriteLine("-----------------------");
        // get the result as a single line with commas separating the found substrings
        Console.WriteLine(string.Join(", ", result.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)));
    }

    // method to get a substring using indexOf and substring methods
    // given the two substring delimiters, it will extract the substring between them
    public static void GetSubstring()
    {
        string text = "Hello, my name is Ahmed Hamdy. <span>I am learning C# programming.</span> I am enjoying it!";

        string startDelimiter = "<span>";
        string endDelimiter = "</span>";
        int startIndex = text.IndexOf(startDelimiter) + startDelimiter.Length;
        int endIndex = text.IndexOf(endDelimiter);

        string extractedSubstring = text[startIndex..endIndex];
        Console.WriteLine("-----------------------");
        Console.WriteLine("Extracted Substring:");
        Console.WriteLine("-----------------------");
        Console.WriteLine(extractedSubstring);
    }

    // method to generate a random PIN of 6 digits
    // ensuring it is always 6 digits long by padding with zeros if necessary
    private static string GenerateRandomPIN()
    {
        return random.Next(111, 999999).ToString().PadLeft(6, '0');
    }

    public static void GenerateRandomPINs(ushort count)
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine($"Generated {count} Random 6 digits PINs:");
        Console.WriteLine("-----------------------");
        for (int i = 0; i < count; i++)
            Console.WriteLine(GenerateRandomPIN());
    }
    public static void StringNumericFormatting()
    {
        decimal price = 67.55m;
        decimal salePrice = 59.99m;
        string result = $"You saved {price - salePrice:C2} from original price {price:C2}";
        result += $" with discount of {((price - salePrice) / price):P2}";

        Console.WriteLine("-----------------------");
        Console.WriteLine("String Numeric Formatting:");
        Console.WriteLine("-----------------------");
        Console.WriteLine(result);
    }
    public static void NumberFormatting()
    {
        double number = 12345.6789;
        string formattedNumber = number.ToString("N2");

        Console.WriteLine("-----------------------");
        Console.WriteLine("Number Formatting:");
        Console.WriteLine("-----------------------");
        Console.WriteLine(formattedNumber);
    }
    public static void PercentageFormatting()
    {
        double percentage = 0.85345;
        string formattedPercentage = percentage.ToString("P2");

        Console.WriteLine("-----------------------");
        Console.WriteLine("Percentage Formatting:");
        Console.WriteLine("-----------------------");
        Console.WriteLine(formattedPercentage);
    }
    public static void CurrencyFormatting()
    {
        decimal price = 19.955m;
        string formattedPrice = price.ToString("C2");

        Console.WriteLine("-----------------------");
        Console.WriteLine("Currency Formatting:");
        Console.WriteLine("-----------------------");
        Console.WriteLine(formattedPrice);
    }
    public static void StringCompositeFormatting()
    {
        string firstName = "Ahmed";
        string lastName = "Hamdy";
        string fullName = string.Format("{0} {1}", firstName, lastName);
        string greeting = string.Format("Hello, {0}! Welcome to C# programming.", fullName);

        Console.WriteLine("-----------------------");
        Console.WriteLine("String Composite Formatting:");
        Console.WriteLine("-----------------------");
        Console.WriteLine(greeting);
    }
    public static void StringInterpolation()
    {
        string firstName = "Ahmed";
        string lastName = "Hamdy";
        string fullName = $"{firstName} {lastName}";
        string greeting = $"Hello, {fullName}! Welcome to C# programming.";

        Console.WriteLine("-----------------------");
        Console.WriteLine("String Interpolation:");
        Console.WriteLine("-----------------------");
        Console.WriteLine(greeting);
    }
}
