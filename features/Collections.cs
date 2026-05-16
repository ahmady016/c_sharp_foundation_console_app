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

    // method to get the employee name and job title from the user
    private static string GetEmployeeDetailsFromUser()
    {
        Console.Write("Enter an employee name and job title separated by comma and space (enter 0 to quit): ");
        string userResponse = Console.ReadLine()?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(userResponse))
            throw new ArgumentNullException("you must enter an employee name and job title separated by comma and space");
        if( userResponse != "0" && !userResponse.Contains(", "))
            throw new ArgumentException("you must enter an employee name and job title separated by comma and space");
        return userResponse;
    }
    // method to list employees and their job titles as
    // create an empty sorted dictionary
    // loop until the user enter 0 to quit
    // and collect the employee name and job title in one input separated by comma and space
    // if the employee is not in the dictionary add it as key with its job title as value
    // if the employee is in the list print "Oops, this employee already exists"
    // finally print the user name and list of employees and their job titles sorted alphabetically
    public static void ListEmployeesAndJobTitles()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("List of Employees and their Job Titles");
        Console.WriteLine("---------------------");

        string userResponse;
        SortedDictionary<string, string> employees = [];
        try
        {
            userResponse = GetEmployeeDetailsFromUser();
            while (userResponse != "0")
            {
                var employeeDetails = userResponse.Split(", ", 2, StringSplitOptions.RemoveEmptyEntries);
                if (!employees.ContainsKey(employeeDetails[0]))
                    employees.Add(employeeDetails[0], employeeDetails[1]);
                else
                    Console.WriteLine("Oops, this employee already exists");

                userResponse = GetEmployeeDetailsFromUser();
            }

            Console.WriteLine("---------------------");
            Console.WriteLine("List of Employees and their Job Titles:");
            Console.WriteLine("---------------------");
            foreach (var (name, jobTitle) in employees)
                Console.WriteLine($"{name} -> {jobTitle}");
            Console.WriteLine("---------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to get the shopping list item and its price from the user
    private static string GetShoppingListItemFromUser()
    {
        Console.Write("Enter an item and its price separated by comma and space (enter 0 to quit): ");
        string userResponse = Console.ReadLine()?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(userResponse))
            throw new ArgumentNullException("you must enter an item and its price separated by comma and space");
        if (userResponse != "0" && !userResponse.Contains(", "))
            throw new ArgumentException("you must enter an item and its price separated by comma and space");
        return userResponse;
    }
    // method to get and validate the item price
    private static double GetItemPrice(string itemPrice)
    {
        if(!double.TryParse(itemPrice, out double price) || price <= 0)
            throw new ArgumentException("price must be a number greater than 0");
        return price;
    }

    // method to get the shopping list and calculate its total price as
    // first collect the user name
    // loop until the user enter 0 to quit
    // and collect the shopping list item one by one with its price in one input separated by comma and space
    // if the item is not in the dictionary add it as key with its price as value
    // if the item is in the list add sum the given price with the existing one
    // finally print the user name, items count, total price and average item price
    public static void ShoppingListCalculator()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Welcome to the Shopping List Calculator!");
        Console.WriteLine("---------------------");

        string username, userResponse;
        SortedDictionary<string, double> shoppingList = [];
        int itemsCount; double totalPrice = 0.0, averageItemPrice;
        try
        {
            username = GetUserName();
            userResponse = GetShoppingListItemFromUser();
            while (userResponse != "0")
            {
                var itemDetails = userResponse.Split(", ", 2, StringSplitOptions.RemoveEmptyEntries);
                if (!shoppingList.ContainsKey(itemDetails[0]))
                    shoppingList.Add(itemDetails[0], GetItemPrice(itemDetails[1]));
                else
                    shoppingList[itemDetails[0]] += GetItemPrice(itemDetails[1]);
                userResponse = GetShoppingListItemFromUser();
            }

            itemsCount = shoppingList.Count;
            foreach (var (item, price) in shoppingList)
                totalPrice += price;
            averageItemPrice = totalPrice / itemsCount;

            Console.WriteLine("---------------------");
            Console.WriteLine($"Hi {username}, here is your list of items:");
            Console.WriteLine("---------------------");
            foreach (var (item, price) in shoppingList)
                Console.WriteLine($"{item} -> {price}");
            Console.WriteLine("---------------------");
            Console.WriteLine($"Items Count: {itemsCount}");
            Console.WriteLine($"Total Price: {totalPrice}");
            Console.WriteLine($"Average Item Price: {averageItemPrice}");
            Console.WriteLine("---------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to demonstrate how to
    // use Enumerable Range to create a list of numbers
    // use collection expressions and LINQ query syntax to map, filter the list of numbers as
    // generate list of numbers between 101 and 999
    // print the list of numbers and its count and sum
    // print the list of odd numbers and its count and sum
    // print the list of even numbers and its count and sum
    public static void ListOfNumbers()
    {
        List<int> numbers, oddNumbers, evenNumbers;
        numbers = [..from _ in Enumerable.Range(1, 20) select random.Next(101, 999)];
        oddNumbers = [..from n in numbers where n % 2 != 0 select n];
        evenNumbers = [..from n in numbers where n % 2 == 0 select n];

        Console.WriteLine("---------------------");
        Console.WriteLine("List of Numbers between 101 and 999:");
        Console.WriteLine("---------------------");

        Console.WriteLine($"numbers ({numbers.Count}): [{string.Join(", ", numbers)}]");
        Console.WriteLine($"numbers sum: ({numbers.Sum()}) and average: ({numbers.Average()})");
        Console.WriteLine("---------------------");

        Console.WriteLine($"odd numbers ({oddNumbers.Count}): [{string.Join(", ", oddNumbers)}]");
        Console.WriteLine($"odd numbers sum: ({oddNumbers.Sum()}) and average: ({oddNumbers.Average():F2})");
        Console.WriteLine("---------------------");

        Console.WriteLine($"even numbers ({evenNumbers.Count}): [{string.Join(", ", evenNumbers)}]");
        Console.WriteLine($"even numbers sum: ({evenNumbers.Sum()}) and average: ({evenNumbers.Average():F2})");
        Console.WriteLine("---------------------");
    }

    // method to demonstrate again use collection expression and LINQ query syntax as
    // given the dictionary<string, string[]> of employees
    // the key is the employee id like (A215)
    // and the value is the employee name, job title and annual salary
    // construct a new dictionary<string, string> of employees sorted by name as
    // key is the employee id and the value is the "employee name - job title - salary" string
    // and construct a list of string of employees sorted by name as
    // "{name} is an employee with id {id}, he worked as {job title} and earns ${salary}"
    // finally print the list of employees
    public static void PrintEmployeesInfo()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("List of Employees with Info:");
        Console.WriteLine("---------------------");

        // the source dictionary
        Dictionary<string, string[]> employees = new()
        {
            { "A215", ["John Doe", "Developer", "50000"] },
            { "B123", ["Jane Smith", "Manager", "60000"] },
            { "C456", ["Alice Johnson", "Designer", "55000"] },
            { "D789", ["Bob Brown", "Tester", "48000"] },
            { "E987", ["Eve Davis", "Developer", "52000"] },
            { "F321", ["Charlie Wilson", "Designer", "56000"] },
            { "G654", ["David Lee", "Tester", "49000"] },
            { "H012", ["Emily Clark", "Developer", "53000"] },
            { "I345", ["Frank Thompson", "Manager", "58000"] },
            { "J678", ["Grace Young", "Designer", "54000"] }
        };

        // construct the sorted dictionary
        var employeesInfoDict =
            from employeePair in employees
            let employeeId = employeePair.Key
            let employeeName = employeePair.Value[0]
            let employeeInfo = $"{employeeName}, {employeePair.Value[1]}, {employeePair.Value[2]}"
            orderby employeeName
            select KeyValuePair.Create(employeeId, employeeInfo);

        Console.WriteLine("The sorted dictionary:");
        Console.WriteLine("---------------------");
        foreach (var (employeeId, employeeInfo) in employeesInfoDict)
            Console.WriteLine($"{employeeId} => {employeeInfo}");
        Console.WriteLine("---------------------");

        // construct the sorted list
        string[] employeesInfoList = [..
            from employeePair in employees
            let employeeId = employeePair.Key
            let employeeName = employeePair.Value[0]
            let jobTitle = employeePair.Value[1]
            let salary = employeePair.Value[2]
            orderby employeeName
            select $"{employeeName} is an employee with id {employeeId}, he worked as {jobTitle} and earns ${salary}"
        ];

        Console.WriteLine("The sorted list:");
        Console.WriteLine("---------------------");
        foreach (var employeeInfo in employeesInfoList)
            Console.WriteLine($"{employeeInfo}");
        Console.WriteLine("---------------------");
    }

}
