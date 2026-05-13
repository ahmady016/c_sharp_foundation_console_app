public static class DatesAndTimes
{
    // method to calculate years passed from the given iso data string
    public static int CalculateElapsedYears(string isoDateString)
    {
        // 1. Parse the ISO string (e.g., "1990-05-24")
        if (!DateTime.TryParse(isoDateString, out DateTime startDate))
            throw new ArgumentException("Invalid date format. Please use ISO 8601.");

        // 2. Get the current date and calculate the elapsed years between them
        DateTime today = DateTime.Today;
        int elapsedYears = today.Year - startDate.Year;

        // 3. Check if the start date has not passed this year yet then subtract one year
        if (today < startDate.AddYears(elapsedYears))
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
        while (duration.TotalSeconds >= 0)
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

    // method to log user activity with current date and time
    // first collect user name and his current activity
    // finally print the user name and current activity
    public static void LogUserActivity()
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine("Logging User Activity");
        Console.WriteLine("-----------------------");

        Console.Write("Enter User Name: ");
        string userName = Console.ReadLine()?.Trim() ?? string.Empty;
        Console.Write("Enter User Activity: ");
        string userActivity = Console.ReadLine()?.Trim() ?? string.Empty;
        DateTime now = DateTime.UtcNow;
        Console.WriteLine($"Hi {userName}, you are currently doing: {userActivity}.\nActivity started at: ({now:yyyy-MM-dd HH:mm:ss}) UTC.");
    }

    // method estimate flight arrival datetime with destination timezone
    // from the given departure datetime, flight duration in minutes and destination timezone
    // finally print the estimated arrival datetime
    public static void EstimateFlightArrivalTime()
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine("Estimating Flight Arrival Time");
        Console.WriteLine("-----------------------");

        Console.WriteLine("Timezone IDs:");
        foreach (var timezone in TimeZoneInfo.GetSystemTimeZones())
            Console.WriteLine($"{timezone.DisplayName} - {timezone.Id}: [{timezone.BaseUtcOffset.Hours} hours]");
        Console.WriteLine("-----------------------");

        try
        {
            Console.Write("Enter Flight Departure Date and Time (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine()?.Trim() ?? string.Empty, out DateTime departureDateTime))
                throw new ArgumentException("Invalid date format. Please use ISO 8601.");

            Console.Write("Enter Flight Duration in Minutes: ");
            if (!int.TryParse(Console.ReadLine()?.Trim() ?? string.Empty, out int flightDurationInMinutes))
                throw new ArgumentException("Invalid duration format. Please enter a valid integer.");
            else if (flightDurationInMinutes <= 0)
                throw new ArgumentException("Flight duration cannot be zero or negative.");

            Console.Write("Enter Destination Timezone: ");
            TimeZoneInfo destinationTimezone = TimeZoneInfo.FindSystemTimeZoneById(Console.ReadLine()?.Trim() ?? string.Empty);

            departureDateTime = TimeZoneInfo.ConvertTimeToUtc(departureDateTime);
            Console.WriteLine($"Flight Departure Time In UTC: {departureDateTime:yyyy-MM-dd HH:mm} - UTC");

            DateTime arrivalDateTime = departureDateTime.AddMinutes(flightDurationInMinutes);
            Console.WriteLine($"Estimated Flight Arrival Time In UTC: {arrivalDateTime:yyyy-MM-dd HH:mm} - UTC");

            DateTime arrivalDateTimeZone = TimeZoneInfo.ConvertTimeFromUtc(arrivalDateTime, destinationTimezone);
            Console.WriteLine($"Estimated Flight Arrival Time In Timezone: {arrivalDateTimeZone:yyyy-MM-dd HH:mm} - ({destinationTimezone.BaseUtcOffset.Hours} hours) - {destinationTimezone.Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to estimate end DateTime from start DateTime and duration in minutes
    // accept duration in minutes and start DateTime or current DateTime as default
    // finally return the estimated end DateTime
    private static DateTime EstimateEndDateTimeUTC(int durationInMinutes, DateTime startDateTime = default)
    {
        if (durationInMinutes <= 0)
            throw new ArgumentException("duration must be a positive number of minutes.");

        startDateTime = (startDateTime == default)
            ? DateTime.UtcNow
            : (startDateTime.Kind != DateTimeKind.Utc)
                ? TimeZoneInfo.ConvertTimeToUtc(startDateTime)
                : startDateTime;

        return startDateTime.AddMinutes(durationInMinutes);
    }

    // method to demonstrate the use of the EstimateEndDateTimeUTC method
    public static void EstimateEndDateTime()
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine("Estimating End DateTime");
        Console.WriteLine("-----------------------");
        try
        {
            Console.Write("Enter Duration in Minutes: ");
            if(!int.TryParse(Console.ReadLine()?.Trim() ?? string.Empty, out int durationInMinutes))
                throw new ArgumentException("Invalid duration format. Please enter a valid integer.");

            DateTime endDateTimeUtc = EstimateEndDateTimeUTC(durationInMinutes);
            Console.WriteLine($"Estimated End DateTime: {endDateTimeUtc:yyyy-MM-dd HH:mm} +00:00 - UTC");

            DateTime endDateTimeLocal = TimeZoneInfo.ConvertTimeFromUtc(endDateTimeUtc, TimeZoneInfo.Local);
            Console.WriteLine($"Estimated End DateTime: {endDateTimeLocal:yyyy-MM-dd HH:mm zzz} - {TimeZoneInfo.Local.Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to get display name and hoursOffset of a timezone using its id
    // accept the timezone id
    // finally return the display name and hoursOffset as tuple
    private static (string displayName, int hoursOffset) GetTimezoneInfo(string timezoneId = "UTC")
    {
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);
        return (tz.DisplayName, tz.BaseUtcOffset.Hours);
    }

    // method to get hoursOffset from timezone id
    // accept the timezone id
    // finally return the hoursOffset as string
    private static (string hoursOffset, string name) GetTimeZoneNameAndHoursOffset(string timezoneId)
    {
        if(string.IsNullOrEmpty(timezoneId))
            throw new ArgumentNullException(nameof(timezoneId));

        string displayName = TimeZoneInfo.FindSystemTimeZoneById(timezoneId).DisplayName;
        string[] nameParts = displayName.Split(' ');
        string hoursOffset = nameParts[0];
        string name = string.Join(' ', nameParts[1..]);
        return (hoursOffset[4..^1], name);
    }

    // method to converts a UTC datetime to the destination timezone's local time.
    // accept the destination timezone id and the UTC datetime or current datetime as default
    // finally return the converted datetime
    private static DateTime ConvertToDestinationTime(string timeZoneId = "UTC", DateTime dateTime = default)
    {
        if (dateTime == default)
            dateTime = DateTime.UtcNow;
        else if (dateTime.Kind != DateTimeKind.Utc)
            dateTime = TimeZoneInfo.ConvertTimeToUtc(dateTime);

        TimeZoneInfo destinationTz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        return TimeZoneInfo.ConvertTimeFromUtc(dateTime, destinationTz);
    }

    // method to show current datetime in given timezones
    // accept array of timezones ids
    // loop throw the array and convert the current datetime in each timezone
    // finally print the current datetime in utc, local and each timezone
    public static void ShowCurrentDateTimeInTimezones(params string[] timezonesIds)
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine("Showing Current Time In Different Timezones");
        Console.WriteLine("-----------------------");

        if(timezonesIds.Length == 0)
            timezonesIds = [..TimeZoneInfo.GetSystemTimeZones().Select(tz => tz.Id).Shuffle().Take(5)];

        DateTime nowUtc = DateTime.UtcNow;
        Console.WriteLine($"Current Time: {nowUtc:yyyy-MM-dd HH:mm} +00:00 - UTC");

        DateTime nowLocal = DateTime.Now;
        Console.WriteLine($"Current Time: {nowLocal:yyyy-MM-dd HH:mm zzz} - {TimeZoneInfo.Local.Id}");

        try
        {
            foreach (var timezoneId in timezonesIds)
            {
                DateTime nowInTimezone = ConvertToDestinationTime(timezoneId, nowUtc);
                (string hoursOffset, string name) = GetTimeZoneNameAndHoursOffset(timezoneId);
                Console.WriteLine($"Current Time: {nowInTimezone:yyyy-MM-dd HH:mm} {hoursOffset} - {timezoneId} - {name}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to calculate total cost of hotel booking
    // based on check-in and check-out dates and price per night
    // accept check-in and check-out dates and price per night
    // finally return the total cost as double
    private static double GetTotalCostOfHotelBooking(DateTime checkIn, DateTime checkOut, double pricePerNight)
    {
        if (checkOut <= checkIn)
            throw new ArgumentException("Checkout date must be after check-in.");

        return (checkOut - checkIn).Days * pricePerNight;
    }
    // method that demonstrate the use of the CalculateTotalCost method as
    // collect user name, check-in, check-out dates and price per night
    // calculate the total cost
    // finally print the user name, total days of stay and total cost
    public static void HotelBookingCalculator()
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine("Calculating Total Cost Of Hotel Booking");
        Console.WriteLine("-----------------------");
        try
        {
            Console.Write("Enter Customer Name: ");
            string username = Console.ReadLine()?.Trim() ?? string.Empty;
            if(string.IsNullOrEmpty(username))
                throw new ArgumentNullException("you must enter your name");

            Console.Write("Enter check-in Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine()?.Trim() ?? string.Empty, out DateTime checkIn))
                throw new ArgumentException("Invalid check-in date format. Please enter a valid date.");

            Console.Write("Enter check-out Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine()?.Trim() ?? string.Empty, out DateTime checkOut))
                throw new ArgumentException("Invalid check-in date format. Please enter a valid date.");

            Console.Write("Enter Price Per Night: ");
            if (!double.TryParse(Console.ReadLine()?.Trim() ?? string.Empty, out double pricePerNight))
                throw new ArgumentException("Invalid price format. Please enter a valid number.");

            double totalDays = (checkOut - checkIn).Days;
            double totalCost = GetTotalCostOfHotelBooking(checkIn, checkOut, pricePerNight);
            Console.WriteLine($"Hi {username}, your total cost for ({totalDays}) days of stay is: ({totalCost:C2})");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to calculate employee working hours as
    // given start and end times
    // and return the total working hours and overtime hours as tuple
    private static (double totalWorkingHours, double totalOvertimeHours) EstimateWorkingHours(DateTime startTime, DateTime endTime)
    {
        if(endTime < startTime)
            throw new ArgumentException("End time must be after start time.");

        double worked = (endTime - startTime).TotalHours;
        double regularHours = Math.Min(worked, 8);
        double overtimeHours = Math.Max(worked - 8, 0);
        return (regularHours, overtimeHours);
    }
    // method to calculate employee working and overtime hours as
    // collect user name, start and end local datetime
    // calculate the working and overtime hours
    // finally print the user name, start and end datetime
    // and total working hours and total overtime hours
    public static void CalculateEmployeeWorkingHours()
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine("Calculating Employee Working Hours");
        Console.WriteLine("-----------------------");
        try
        {
            Console.Write("Enter Employee Name: ");
            string username = Console.ReadLine()?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("you must enter your name");

            Console.Write("Enter Start Time (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine()?.Trim() ?? string.Empty, out DateTime startTime))
                throw new ArgumentException("Invalid start time format. Please enter a valid date and time.");

            Console.Write("Enter End Time (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine()?.Trim() ?? string.Empty, out DateTime endTime))
                throw new ArgumentException("Invalid end time format. Please enter a valid date and time.");

            (double totalWorkingHours, double totalOvertimeHours) = EstimateWorkingHours(startTime, endTime);
            Console.WriteLine($"Hi {username}, you signed in from ({startTime:yyyy-MM-dd HH:mm}) to ({endTime:yyyy-MM-dd HH:mm}).");
            Console.WriteLine($"you worked ({totalWorkingHours:F1}) hours and ({totalOvertimeHours:F1}) hours of overtime.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to get the next doses of a medicine as
    // given the doses per day and doses count
    // return array of all doses datetime strings
    private static List<string> GetDosesList(int dosesPerDay = 1, int dosesCount = 5)
    {
        if(dosesPerDay <= 0 || dosesCount <= 0)
            throw new ArgumentException("Doses per day and doses count must be greater than zero.");

        int[] validDosesPerDay = [1, 2, 3, 4, 6, 8, 12];
        if (!validDosesPerDay.Contains(dosesPerDay))
            throw new ArgumentException("Doses per day must be 1, 2, 3, 4, 6, 8 or 12.");

        int[] validDosesCount = [..Enumerable.Range(1, 30)];
        if (!validDosesCount.Contains(dosesCount))
            throw new ArgumentException("Doses count must be between 1 and 30.");

        DateTime now = DateTime.Now;
        List<string> doses = [$"dose#01: {now:yyyy-MM-dd hh:mm tt zzz} - {TimeZoneInfo.Local.Id}"];
        for (int i = 1; i < dosesCount; i++)
        {
            DateTime nextDose = now.AddHours(i * (24 / dosesPerDay));
            doses.Add($"dose#{i+1:00}: {nextDose:yyyy-MM-dd hh:mm tt zzz} - {TimeZoneInfo.Local.Id}");
        }
        return doses;
    }
    // method to print list of doses of a medicine as
    // collect username, doses per day and doses count
    // finally print the username and the list of doses datetime strings
    public static void PrintDosesList()
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine("Getting Doses List");
        Console.WriteLine("-----------------------");
        try
        {
            Console.Write("Enter Patient Name: ");
            string username = Console.ReadLine()?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("you must enter your name");

            Console.Write("Enter Doses Per Day: ");
            if (!int.TryParse(Console.ReadLine()?.Trim() ?? string.Empty, out int dosesPerDay))
                throw new ArgumentException("Invalid doses per day format. Please enter a valid number.");

            Console.Write("Enter Doses Count: ");
            if (!int.TryParse(Console.ReadLine()?.Trim() ?? string.Empty, out int dosesCount))
                throw new ArgumentException("Invalid doses count format. Please enter a valid number.");

            List<string> doses = GetDosesList(dosesPerDay, dosesCount);
            Console.WriteLine($"Hi {username}, your doses list is: ");
            Console.WriteLine("-----------------------");
            foreach (string dose in doses)
                Console.WriteLine(dose);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}
