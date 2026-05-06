/*
C# supports four types of iteration statements: for, foreach, do-while, and while.
Microsoft's language reference documentation describes these statements as follows:
The for statement: executes its body while a specified Boolean expression (the 'condition') evaluates to true.
The foreach statement: enumerates the elements of a collection and executes its body for each element of the collection.
The do-while statement: conditionally executes its body one or more times.
The while statement: conditionally executes its body zero or more times.
*/

using System.Text;

public static class Loops
{
    // method to get all sentences from an array of paragraphs
    // using nested loops, IndexOf() Substring() and Join() methods
    // to extract array of all paragraphs sentences and print them
    public static void GetSentencesFromParagraphs()
    {
        string[] paragraphs = [
            "This is the first paragraph. It has two sentences. It is short.",
            "This is the second paragraph. It has three sentences. It is longer than the first one.",
            "This is the third paragraph. It has one sentence. It is the longest paragraph of all.",
            "This is the fourth paragraph. It has two sentences. It is short."
        ];

        Console.WriteLine("---------------------");
        Console.WriteLine("Sentences from Paragraphs:");
        Console.WriteLine("---------------------");
        char sentenceDelimiter = '.';
        int periodIndex, lastCharacterIndex;
        string currentParagraph, currentSentence;
        StringBuilder sentencesBuilder = new();
        for (int i = 0; i < paragraphs.Length; i++)
        {
            currentParagraph = paragraphs[i];
            periodIndex = currentParagraph.IndexOf(sentenceDelimiter);
            lastCharacterIndex = currentParagraph.Length - 1;
            while (periodIndex != -1 && periodIndex < lastCharacterIndex)
            {
                currentSentence = currentParagraph[..periodIndex];
                sentencesBuilder.AppendLine(currentSentence.Trim());

                currentParagraph = currentParagraph[(periodIndex + 2)..];
                periodIndex = currentParagraph.IndexOf(sentenceDelimiter);
                lastCharacterIndex = currentParagraph.Length - 1;
            }
            sentencesBuilder.AppendLine(currentParagraph.Trim());
        }
        Console.WriteLine(sentencesBuilder.ToString());
    }

    // method that take a string array each string is a comma separated list of cities
    // and print a list of all cities in the world using nested loops
    public static void PrintCities()
    {
        string[] citiesGroups = [
            "New York, Los Angeles, Chicago",
            "London, Paris, Berlin",
            "Tokyo, Beijing, Seoul",
            "Cairo, Mumbai, Rome"
        ];

        Console.WriteLine("---------------------");
        Console.WriteLine("List of Cities in the World:");
        Console.WriteLine("---------------------");
        foreach (string group in citiesGroups)
        {
            string[] cities = group.Split(", ");
            foreach (string city in cities)
                Console.WriteLine(city);
        }
    }
    // method to loop util the user input a valid role from the list of roles
    // using do - while loop and Trim() and lower() methods to validate the user input
    public static void GetUserRole()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Enter your role to get access to the system.");
        Console.WriteLine("---------------------");
        string[] validRoles = ["admin", "manager", "editor", "viewer", "user"];
        string userRole;
        do
        {
            Console.Write("Enter your role (admin, manager, editor, viewer, user): ");
            userRole = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

            if (!validRoles.Contains(userRole))
                Console.WriteLine("Invalid role. Try again.");
            else
                Console.WriteLine($"your role ({userRole}) is a valid role.");

        } while (!validRoles.Contains(userRole));
    }

    // method to get the week day when the user input a valid integer between 1 and 7
    // using do - while loop and byte.TryParse() method to validate the user input
    public static void GetWeekDay()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Enter day number to get the week day.");
        Console.WriteLine("---------------------");
        byte dayNumber;
        do
        {
            Console.Write("Enter a number between 1 and 7: ");
            bool isValid = byte.TryParse(Console.ReadLine(), out dayNumber);

            if (!isValid)
                Console.WriteLine("Invalid Day Number. Try again.");
            else if (dayNumber < 1 || dayNumber > 7)
                Console.WriteLine("Day Number out of range. Try again.");
            else
                Console.WriteLine($"you entered ({dayNumber}) a valid day number.");

        } while (dayNumber < 1 || dayNumber > 7);

        string weekDay = dayNumber switch
        {
            1 => "Sunday",
            2 => "Monday",
            3 => "Tuesday",
            4 => "Wednesday",
            5 => "Thursday",
            6 => "Friday",
            7 => "Saturday",
            _ => "Invalid day"
        };
        Console.WriteLine($"The WeekDay is: {weekDay}");
    }

    // method to play a country guessing game where the user must guess the best country in the world
    // until they guess it right or they type 'EXIT' to quit
    public static void CountryGuessGame()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Welcome to the Country Guessing Game!");
        Console.WriteLine("Try to guess the best country in the world! type 'EXIT' to quit.");
        Console.WriteLine("---------------------");
        const string BEST_COUNTRY = "EGYPT";
        const string EXIT = "EXIT";
        string userGuess;
        do
        {
            Console.Write("Enter your guess: ");
            userGuess = Console.ReadLine() ?? string.Empty;
            if (!userGuess.Equals(BEST_COUNTRY, StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("Wrong guess. Try again!");
            else Console.WriteLine("Congratulations! You guessed it right!");
        } while (
                !userGuess.Equals(BEST_COUNTRY, StringComparison.OrdinalIgnoreCase) &&
                !userGuess.Equals(EXIT, StringComparison.OrdinalIgnoreCase)
            );
    }

    // method to play a hero vs monster battle game
    // where the hero and the monster start with 100 health each
    // and they take turns to damage each other until one of them reaches 0 health
    // using do - while loop and Random class to generate random damage between 1 and 20
    public static void HeroBattleGame()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Welcome to the Hero vs Monster Game!");
        Console.WriteLine("The hero and the monster start with 100 health each. Let the battle begin!");
        Console.WriteLine("---------------------");

        Random random = new();
        byte heroHealth = 100,
            monsterHealth = 100,
            monsterDamage,
            heroDamage;
        do
        {
            monsterDamage = (byte)random.Next(1, 21);
            monsterHealth = (byte)((monsterDamage > monsterHealth) ? 0 : (monsterHealth - monsterDamage));
            Console.WriteLine($"The monster damaged by {monsterDamage} and now has {monsterHealth} health left.");

            if (monsterHealth == 0) continue;

            heroDamage = (byte)random.Next(1, 21);
            heroHealth = (byte)((heroDamage > heroHealth) ? 0 : (heroHealth - heroDamage));
            Console.WriteLine($"The hero damaged by {heroDamage} and now has {heroHealth} health left.");

        } while (heroHealth > 0 && monsterHealth > 0);

        string result = heroHealth > 0 ? "Game over! The hero wins!" : "Game over! The monster wins!";
        Console.WriteLine(result);
    }

}
