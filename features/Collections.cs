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

    // method to get the user name
    private static string GetUserName()
    {
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrEmpty(userName))
            throw new ArgumentNullException("you must enter your name");
        return userName;
    }
    // method to get a city from the user
    private static string GetCityFromUser()
    {
        Console.Write("Enter a city you visit (enter 0 to quit): ");
        string userResponse = Console.ReadLine()?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(userResponse))
            throw new ArgumentNullException("you must enter a city you visited");
        return userResponse;

    }
    // method to list all the cities user was visited as
    // first collect the user name
    // loop until the user enter 0 to quit and collect the user visited cities
    // if the city is not in the list add it to the list
    // if the city is in the list print "Oops, you visited this city before"
    // finally print the user name and list of visited cities sorted alphabetically
    public static void ListVisitedCities()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("List of Visited Cities");
        Console.WriteLine("---------------------");

        List<string> visitedCities = [];
        try
        {
            string userName = GetUserName();
            string userResponse = GetCityFromUser();
            while (userResponse != "0")
            {
                if (!visitedCities.Contains(userResponse, StringComparer.OrdinalIgnoreCase))
                    visitedCities.Add(userResponse);
                else
                    Console.WriteLine("Oops, you visited this city before");

                userResponse = GetCityFromUser();
            }

            visitedCities.Sort();
            Console.WriteLine("---------------------");
            Console.WriteLine($"Hi {userName}, here is your list of visited cities:");
            Console.WriteLine($"[{string.Join(", ", visitedCities)}]");
            Console.WriteLine("---------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to get an employee name from the user
    private static string GetEmployeeNameFromUser()
    {
        Console.Write("Enter an employee name (enter 0 to quit): ");
        string userResponse = Console.ReadLine()?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(userResponse))
            throw new ArgumentNullException("you must enter an employee name");
        return userResponse;
    }
    // method to assign employees to departments as
    // givin the const list of Departments in the company and an empty dictionary
    // loop until the user enter 0 to quit and collect the employees names one by one
    // if the employee is not in the dictionary add it and assign a random department
    // if the employee is in the list print "Oops, this employee already exists"
    // finally print the list of employees and their departments sorted alphabetically
    // and print each department and its employees count
    public static void AssignEmployeesToDepartments()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Assign Employees to Departments");
        Console.WriteLine("---------------------");

        IReadOnlyList<string> DEPARTMENTS = ["IT", "HR", "Sales", "Operations"];
        Dictionary<string, string> employees = [];
        try
        {
            string userResponse = GetEmployeeNameFromUser();
            while (userResponse != "0")
            {
                if (!employees.ContainsKey(userResponse))
                    employees.Add(userResponse, DEPARTMENTS[random.Next(0, DEPARTMENTS.Count)]);
                else
                    Console.WriteLine("Oops, this employee already exists");

                userResponse = GetEmployeeNameFromUser();
            }

            Console.WriteLine("---------------------");
            Console.WriteLine("List of Employees and their Departments:");
            Console.WriteLine("---------------------");
            SortedDictionary<string, string> sortedEmployees = new(employees);
            foreach (var (name, department) in employees)
                Console.WriteLine($"{name} -> {department}");
            Console.WriteLine("---------------------");

            Console.WriteLine("---------------------");
            Console.WriteLine("Departments and their Employees Count:");
            Console.WriteLine("---------------------");
            SortedDictionary<string, int> sortedDepartments = [];
            foreach (var (name, department) in employees)
            {
                if(!sortedDepartments.TryGetValue(department, out int value))
                    sortedDepartments.Add(department, 1);
                else
                    sortedDepartments[department] = ++value;
            }
            foreach (var (department, count) in sortedDepartments)
                Console.WriteLine($"{department} => {count}");
            Console.WriteLine("---------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}
