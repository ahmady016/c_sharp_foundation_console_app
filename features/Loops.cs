/*
C# supports four types of iteration statements: for, foreach, do-while, and while.
Microsoft's language reference documentation describes these statements as follows:
The for statement: executes its body while a specified Boolean expression (the 'condition') evaluates to true.
The foreach statement: enumerates the elements of a collection and executes its body for each element of the collection.
The do-while statement: conditionally executes its body one or more times.
The while statement: conditionally executes its body zero or more times.
*/

using System.Globalization;
using System.Text;

public static class Loops
{
    // random field to generate random numbers
    private static readonly Random random = new();

    // method to generate random id as
    // each id is a letter from A to Z and a three-digit number
    private static string GenerateRandomId()
    {
        char letter = Convert.ToChar(random.Next(65, 91));
        string threeDigitNumber = random.Next(1, 1000).ToString("000");
        return $"{letter}{threeDigitNumber}";
    }

    // method to randomly assign ids to employees as
    // ask the user to enter employee name or 0 to quit
    // loop util the user enter 0 and generate random id for each employee
    // finally print list of employees and their ids
    public static void RandomlyAssignIdsToEmployees()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Randomly Assign Ids to Employees:");
        Console.WriteLine("---------------------");

        Dictionary<string, string> employees = [];
        string employeeName;
        do
        {
            Console.Write("Enter Employee Name or 0 to quit: ");
            employeeName = Console.ReadLine()?.Trim() ?? string.Empty;
            if (employeeName != "0")
                employees.Add(GenerateRandomId(), employeeName);
        } while (employeeName != "0");

        Console.WriteLine("---------------------");
        Console.WriteLine("List of Employees and their Ids:");
        Console.WriteLine("---------------------");
        int count = 1;
        foreach (var (id, name) in employees)
            Console.WriteLine($"employee#{count++}: {id} -> {name}");
    }

    // method to randomly assign role to user as
    // while the user enter y generate random number between 1 and 5
    // if the random number is 1 assign viewer role
    // if the random number is 2 assign editor role
    // if the random number is 3 assign developer role
    // if the random number is 4 assign manager role
    // if the random number is 5 assign admin role
    // finally when the user enter n stop the loop
    // and print total users count and each role count
    public static void RandomlyAssignRoleToUsers()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Randomly Assign Role to Users:");
        Console.WriteLine("---------------------");

        int totalUsersCount = 0, viewerCount = 0, editorCount = 0,
        developerCount = 0, managerCount = 0, adminCount = 0;
        string userResponse;
        byte roleNumber;
        do
        {
            Console.Write("would you like to randomly assigned to a role [admin, supervisor, guest]? [y/n]: ");
            userResponse = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
            if (userResponse == "y")
            {
                roleNumber = (byte)random.Next(1, 6);
                totalUsersCount++;
                switch (roleNumber)
                {
                    case 1:
                        {
                            viewerCount++;
                            Console.WriteLine($"user#{totalUsersCount} assigned to viewer role");
                            break;
                        }
                    case 2:
                        {
                            editorCount++;
                            Console.WriteLine($"user#{totalUsersCount} assigned to editor role");
                            break;
                        }
                    case 3:
                        {
                            developerCount++;
                            Console.WriteLine($"user#{totalUsersCount} assigned to developer role");
                            break;
                        }
                    case 4:
                        {
                            managerCount++;
                            Console.WriteLine($"user#{totalUsersCount} assigned to manager role");
                            break;
                        }
                    case 5:
                        {
                            adminCount++;
                            Console.WriteLine($"user#{totalUsersCount} assigned to admin role");
                            break;
                        }
                    default: break;
                }
            }
        } while (userResponse != "n");

        Console.WriteLine("---------------------");
        Console.WriteLine($"total users: {totalUsersCount}");
        Console.WriteLine($"viewer count: {viewerCount}");
        Console.WriteLine($"editor count: {editorCount}");
        Console.WriteLine($"developer count: {developerCount}");
        Console.WriteLine($"manager count: {managerCount}");
        Console.WriteLine($"admin count: {adminCount}");
        Console.WriteLine("---------------------");
    }

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

    // method to print a table of multiplication using nested loops
    public static void MultiplicationTable(byte limit = 12)
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Multiplication Table:");
        Console.WriteLine("---------------------");
        for (int i = 1; i <= limit; i++)
            for (int j = 1; j <= limit; j++)
                Console.WriteLine($"({i} * {j}) = {i * j}");
    }

    // method to check for valid username and password as
    // collect the username and password from the user
    // the user has only 3 attempts
    // check if the username is "admin" and the password is "2026"
    // then print "Successful login, welcome admin" and exit the loop
    // otherwise print "Invalid username or password" and continue the loop
    // finally print "You have reached the maximum number of attempts" and exit the loop
    public static void LoginChecker()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Welcome to the Login Checker!");
        Console.WriteLine("---------------------");

        const string USERNAME = "admin";
        const string PASSWORD = "2026";
        const int MAX_ATTEMPTS = 3;

        string username, password;
        int attempts = 1;
        while(attempts <= MAX_ATTEMPTS)
        {
            Console.WriteLine($"Attempt #{attempts} of {MAX_ATTEMPTS}:");
            Console.WriteLine("------------------");
            Console.Write("Enter your username: ");
            username = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
            Console.Write("Enter your password: ");
            password = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
            if(username == USERNAME && password == PASSWORD)
            {
                Console.WriteLine("Successful Login, Welcome Admin");
                break;
            }
            else if(attempts < MAX_ATTEMPTS)
                Console.WriteLine("Invalid username or password try again");
            else
                Console.WriteLine("Opps you reached 3 attempts and you are not the admin");

            attempts++;
        }
    }

    private static (string username, string mobileNumber) GetUsernameAndMobileNumber()
    {
            Console.Write("Enter your name: ");
            string username = Console.ReadLine()?.Trim() ?? string.Empty;
            if(string.IsNullOrEmpty(username))
                throw new ArgumentNullException("you must enter your name");

            Console.Write("Enter your mobile number: ");
            string mobileNumber = Console.ReadLine()?.Trim() ?? string.Empty;
            if(string.IsNullOrEmpty(mobileNumber))
                throw new ArgumentNullException("you must enter your mobile number");

        return (username, mobileNumber);
    }

    // method to check mobile number as
    // collect the user name and mobile number
    // check if the mobile number starts with 01 and has 11 digits
    // check if the mobile number contains only digits
    // then print "Valid mobile number"
    // otherwise print "Invalid mobile number"
    public static void MobileNumberChecker()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Welcome to the Mobile Number Checker!");
        Console.WriteLine("---------------------");

        string username, mobileNumber;
        try
        {
            (username, mobileNumber) = GetUsernameAndMobileNumber();
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            (username, mobileNumber) = GetUsernameAndMobileNumber();
        }

        const string DIGITS = "0123456789";
        char invalidCharacter = char.MinValue;
        if (!mobileNumber.StartsWith("01") || mobileNumber.Length != 11)
            Console.WriteLine($"Hi {username}, your mobile number must start with 01 and have 11 digits");
        else
        {
            foreach (char c in mobileNumber)
                if (!DIGITS.Contains(c))
                {
                    invalidCharacter = c;
                    break;
                }
            if(invalidCharacter != char.MinValue)
                Console.WriteLine($"Hi {username}, the character {invalidCharacter} is invalid in your mobile number");
            else
                Console.WriteLine($"Hi {username}, your mobile number is ({mobileNumber})");
        }
    }

    public static (string username, string sentence) GetUsernameAndSentence()
    {
        Console.Write("Enter your name: ");
        string username = Console.ReadLine()?.Trim() ?? string.Empty;
        if(string.IsNullOrEmpty(username))
            throw new ArgumentNullException("you must enter your name");

        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine()?.Trim() ?? string.Empty;
        if(string.IsNullOrEmpty(sentence))
            throw new ArgumentNullException("you must enter a sentence");

        return (username, sentence);
    }
    // method to make a vowel counter as
    // collect the user name and a sentence
    // count the number of vowels in the sentence
    // finally print the user name and the number of vowels and constants in the sentence
    public static void VowelCounter()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Welcome to the Vowel Counter!");
        Console.WriteLine("---------------------");

        string username, sentence;
        try
        {
            (username, sentence) = GetUsernameAndSentence();
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            (username, sentence) = GetUsernameAndSentence();
        }

        const string VOWELS = "aeiouAEIOU";
        int vowelsCount = 0, constantsCount;
        foreach (char c in sentence)
            if (VOWELS.Contains(c))
                vowelsCount++;
        constantsCount = sentence.Length - vowelsCount;

        Console.WriteLine($"Hi {username}, the number of vowels in your sentence is {vowelsCount}\nand the number of constants in your sentence is {constantsCount}.");
    }

    private static bool GetUserResponse()
    {
        Console.Write("Do you want to book a ticket? [y/n]: ");
        string isBookingTicket = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
        if(string.IsNullOrEmpty(isBookingTicket) || (isBookingTicket != "y" && isBookingTicket != "n"))
            throw new ArgumentException("only [y] or [n] are allowed");
        return isBookingTicket == "y";
    }

    // method to make a ticket booker as
    // collect the user name
    // ask if he want to book a ticket [y/n]
    // if the user wants to book a ticket print "ticket#01 has been booked"
    // loop until the user does not want to book a ticket
    // finally print the user name and the number of tickets he has booked
    // and if he has not booked any ticket
    // print "Opps [username], you have not booked any tickets."
    public static void TicketBooker()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Welcome to the Ticket Booker!");
        Console.WriteLine("---------------------");

        try
        {
            Console.Write("Enter your name: ");
            string username = Console.ReadLine()?.Trim() ?? string.Empty;
            if(string.IsNullOrEmpty(username))
                throw new ArgumentNullException("you must enter your name");

            int ticketsCount = 0;
            while (GetUserResponse())
                Console.WriteLine($"Ok {username}, ticket#{++ticketsCount} has been booked.");

            string message = ticketsCount > 0
                ? $"Thanks {username}, you have booked ({ticketsCount}) tickets."
                : $"Opps {username}, you have not booked any tickets.";
            Console.WriteLine(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}
