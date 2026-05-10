public static class DatesAndTimes
{
    // method to calculate years passed from the given iso data string
    private static int CalculateElapsedYears(string isoDateString)
    {
        // 1. Parse the ISO string (e.g., "1990-05-24")
        if (!DateTime.TryParse(isoDateString, out DateTime startDate))
            throw new ArgumentException("Invalid date format. Please use ISO 8601.");

        // 2. Get the current date and calculate the elapsed years between them
        DateTime today = DateTime.Today;
        int elapsedYears = today.Year - startDate.Year;

        // 3. Check if the start date has passed this year
        if ((today.Month < startDate.Month) || (today.Month == startDate.Month && today.Day < startDate.Day))
            elapsedYears--;

        // 4. Finally, return the elapsed years
        return elapsedYears;
    }
    // method to calculate person age from the given birth date string
    public static void CalculatePersonAge()
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine("Calculating Person Age");
        Console.WriteLine("-----------------------");
        string birthDateString;
        try
        {
            Console.Write("Enter Person Birth Date (YYYY-MM-DD): ");
            birthDateString = Console.ReadLine()?.Trim() ?? string.Empty;
            int age = CalculateElapsedYears(birthDateString);
            Console.WriteLine($"Person Birth Date: {birthDateString}");
            Console.WriteLine($"Person Age: {age} years");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    // method to calculate employee experience from the given hire date string
    public static void CalculateEmployeeExperience()
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine("Calculating Employee Experience");
        Console.WriteLine("-----------------------");
        string hireDateString;
        try
        {
            Console.Write("Enter Employee Hire Date (YYYY-MM-DD): ");
            hireDateString = Console.ReadLine()?.Trim() ?? string.Empty;
            int experience = CalculateElapsedYears(hireDateString);
            Console.WriteLine($"Employee Hire Date: {hireDateString}");
            Console.WriteLine($"Employee Experience: {experience} years");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to make countdown timer from the given total seconds
    public static async Task CountDownFrom(int totalSeconds)
    {
        // Set the starting countdown duration
        TimeSpan duration = TimeSpan.FromSeconds(totalSeconds);
        // Print the starting seconds to begin the countdown
        Console.WriteLine($"Countdown Timer from {totalSeconds} seconds.");
        // Loop until the duration is zero
        while(duration.TotalSeconds >= 0)
        {
            // Clear the line and rewrite the updated time remaining
            Console.Write($"\rTime Remaining: {duration:mm\\:ss}");
            // Wait precisely 1 second
            await Task.Delay(1000);
            // Subtract 1 second from the total duration
            duration = duration.Subtract(TimeSpan.FromSeconds(1));
        }
        // Print the final message
        Console.WriteLine("\nCountdown Timer Finished Successfully.");
    }
    // method to simulate a remaining timer for file download as
    // ask the user to enter the file size in MB
    // and ask the user to enter the download speed in Mbs
    // and calculate the remaining time in seconds
    // finally use the countdown timer to show the remaining time
    public static async Task SimulateFileDownloadTimer()
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine("Simulating File Download Timer");
        Console.WriteLine("-----------------------");

        Console.Write("Enter File Size (MB): ");
        float fileSize = float.Parse(Console.ReadLine()?.Trim() ?? string.Empty);
        Console.Write("Enter Download Speed (Mbs): ");
        float downloadSpeed = float.Parse(Console.ReadLine()?.Trim() ?? string.Empty);
        int remainingSeconds = (int)Math.Ceiling((fileSize * 8) / downloadSpeed);
        await CountDownFrom(remainingSeconds);
    }

    // method to show the current date and time
    public static void ShowCurrentDateAndTime()
    {
        DateTime now = DateTime.Now;
        Console.WriteLine($"Current date and time: {now}");
    }

}
