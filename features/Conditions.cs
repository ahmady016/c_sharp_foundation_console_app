public static class Conditions
{
    public static void BooleanEvaluations()
    {
        string message = "The quick brown fox jumps over the lazy dog.";
        bool containsQuick = message.Contains("quick");
        bool containsLazy = message.Contains("lazy");
        Console.WriteLine($"Does the message contain 'quick'? {containsQuick}");
        Console.WriteLine($"Does the message contain 'lazy'? {containsLazy}");
    }

    public static void ShowOddOrEven()
    {
        Random random = new();
        int randNumber = random.Next(1, 101);
        bool isEven = randNumber % 2 == 0;
        if (isEven)
            Console.WriteLine($"The Random number: {randNumber} is even.");
        else
            Console.WriteLine($"The Random number: {randNumber} is odd.");
    }

    public static void DiceRollingGame()
    {
        Random dice = new();
        int firstDice = dice.Next(1, 7);
        int secondDice = dice.Next(1, 7);
        int thirdDice = dice.Next(1, 7);
        int total = firstDice + secondDice + thirdDice;

        Console.WriteLine($"You rolled: {firstDice}, {secondDice}, {thirdDice} (Total: {total})");

        if((firstDice == secondDice) || (secondDice == thirdDice) || (firstDice == thirdDice))
        {
            if ((firstDice == secondDice) && (secondDice == thirdDice))
            {
                Console.WriteLine("Congratulations! You rolled a triple!");
                total += 10;
            }
            else
            {
                Console.WriteLine("Congratulations! You rolled a double!");
                total += 5;
            }
        }

        if(total >= 15)
            Console.WriteLine($"Congratulations! You win! Your total score is: {total}");
        else
            Console.WriteLine($"Sorry, you lose. Your total score is: {total}. Try again!");
    }

    public static void CheckSubscriptionStatus()
    {
        Random randomDays = new();
        int remainingDays = randomDays.Next(0, 15);
        int discountPercentage = 0;
        string discountMessage = "renew now.";
        string resultMessage = "";

        if (remainingDays == 0)
            resultMessage = "Your subscription has expired.";
        else if (remainingDays == 1)
        {
            discountPercentage = 20;
            resultMessage = $"Your subscription will expire within a day.";
        }
        else if (remainingDays <= 5)
        {
            discountPercentage = 10;
            resultMessage = $"Your subscription will expire within {remainingDays} days.";
        }
        else if (remainingDays <= 14)
            resultMessage = $"Your subscription will expire soon";

        if(discountPercentage > 0)
            discountMessage += $" and save {discountPercentage}%!";

        Console.WriteLine($"Remaining days: {remainingDays}");
        Console.WriteLine($"{resultMessage} {discountMessage}");
    }

    // method to calculate the total price after discount
    // first collect user name
    // collect the price of each 3 products
    // check if the product01 is the most expensive then give him 66% discount
    // check if the product02 price is the most expensive then give him 50% discount
    // check if the product03 price is the most expensive then give him 33% discount
    // finally print the total const before and after discount
    public static void TotalPriceCalculator()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Total Price Calculator");
        Console.WriteLine("---------------------");
        try
        {
            Console.Write("Enter your name: ");
            string username = Console.ReadLine()?.Trim() ?? string.Empty;
            if(string.IsNullOrEmpty(username))
                throw new ArgumentNullException("you must enter your name");

            bool isProduct01PriceValid, isProduct02PriceValid,isProduct03PriceValid;
            Console.Write("Enter the price of product#1: ");
            isProduct01PriceValid = double.TryParse(Console.ReadLine()?.Trim() ?? string.Empty, out double product01Price);
            Console.Write("Enter the price of product#2: ");
            isProduct02PriceValid = double.TryParse(Console.ReadLine()?.Trim() ?? string.Empty, out double product02Price);
            Console.Write("Enter the price of product#3: ");
            isProduct03PriceValid = double.TryParse(Console.ReadLine()?.Trim() ?? string.Empty, out double product03Price);
            if(!isProduct01PriceValid || !isProduct02PriceValid || !isProduct03PriceValid)
                throw new ArgumentException("you must enter #3 product prices");

            double total_before_discount = product01Price + product02Price + product03Price;
            double total_after_discount, discountRate;
            if(product01Price > product02Price && product01Price > product03Price)
            {
                Console.WriteLine("product#1 is the most expensive and you will get 66% discount");
                discountRate = 0.33;
            }
            else if(product02Price > product01Price && product02Price > product03Price)
            {
                Console.WriteLine("product#2 is the most expensive and you will get 50% discount");
                discountRate = 0.5;
            }
            else if(product03Price > product01Price && product03Price > product02Price)
            {
                Console.WriteLine("product#3 is the most expensive and you will get 66% discount");
                discountRate = 0.66;
            }
            else
            {
                Console.WriteLine("all 3 products have the same price and there is no discount");
                discountRate = 0.0;
            }
            total_after_discount = total_before_discount - (total_before_discount * discountRate);

            Console.WriteLine("------------------");
            Console.WriteLine($"Total Before Discount: {total_before_discount:F2}");
            Console.WriteLine($"Total After Discount: {total_after_discount:F2}");
            Console.WriteLine("------------------");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to give the customer a feedback based on his rate as
    // collect the user name and a rate from 1 to 10
    // if the rate is 8 or more then print "thank you very much"
    // and if the rate is between 5 and 7 print "we will work hard to improve"
    // finally if the rate is less than 5 print "we are sorry to hear that"
    public static void CustomerFeedback()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Customer Feedback on His Review Rate");
        Console.WriteLine("---------------------");
        try
        {

            Console.Write("Enter your name: ");
            string username = Console.ReadLine()?.Trim() ?? string.Empty;
            if(string.IsNullOrEmpty(username))
                throw new ArgumentNullException("you must enter your name");

            Console.Write("Enter your review rate from 1 to 10: ");
            bool isValidRate = byte.TryParse(Console.ReadLine()?.Trim() ?? string.Empty, out byte customerRate);
            if(!isValidRate)
                throw new ArgumentException("your review rate must be a number between 1 and 10");

            string feedbackMessage = customerRate switch
            {
                >=8 => "Thank you very much",
                >=5 and <=7 => "We will work hard to improve",
                _ => "We are sorry to hear that"
            };

            Console.WriteLine("---------------------");
            Console.WriteLine($"{feedbackMessage} {username}");
            Console.WriteLine("---------------------");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to give the user learning recommendation of C# programming language
    // collect the user name and ask him if he want to read a book [yes, no]
    // if the user wants to read a book ask him his current level [beginner, intermediate, advanced]
    // if the current level is beginner recommend [C# Foundation] book
    // if the current level is intermediate recommend [Head First C#] book
    // if the current level is advanced recommend [Domain Driven Design Distilled] book
    // if the user does not want to read a book recommend [C# Crash Course] video
    public static void CSharpLearningRecommendation()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Customer Feedback on His Review Rate");
        Console.WriteLine("---------------------");
        try
        {
            Console.Write("Enter your name: ");
            string username = Console.ReadLine()?.Trim() ?? string.Empty;
            if(string.IsNullOrEmpty(username))
                throw new ArgumentNullException("you must enter your name");

            Console.Write("Do you want to read a book? [yes/no]: ");
            string isReadingBook = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
            if(string.IsNullOrEmpty(isReadingBook) || (isReadingBook != "yes" && isReadingBook != "no"))
                throw new ArgumentException("only [yes or no] are allowed");

            string message;
            if(isReadingBook == "yes")
            {
                Console.Write("Enter your current level [beginner, intermediate, advanced]: ");
                string userLevel = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
                if(
                    string.IsNullOrEmpty(userLevel) ||
                    (userLevel != "beginner" && userLevel != "intermediate" && userLevel != "advanced")
                )
                    throw new ArgumentException("only [beginner, intermediate, advanced] are allowed");

                message = userLevel switch
                {
                    "beginner" => "you should read the (C# Foundation) book",
                    "intermediate" => "you should read the (Head First C#) book",
                    "advanced" => "you should read the (Domain Driven Design Distilled) book",
                    _ => ""
                };
            }
            else
            {
                message = "you should watch (C# Crash Course) youtube video";
            }
            Console.WriteLine("------------------------");
            Console.WriteLine($"Hi {username}, {message}");
            Console.WriteLine("------------------------");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // method to get http status message from http status code as
    // collect the http status code and return the http status message
    public static string GetHttpStatusMessage(int httpStatusCode)
    {
        return httpStatusCode switch
        {
            200 => "OK",
            201 => "Created",
            202 => "Accepted",
            203 => "Non-Authoritative Information",
            204 => "No Content",
            205 => "Reset Content",
            206 => "Partial Content",
            300 => "Multiple Choices",
            301 => "Moved Permanently",
            302 => "Found",
            303 => "See Other",
            304 => "Not Modified",
            305 => "Use Proxy",
            307 => "Temporary Redirect",
            308 => "Permanent Redirect",
            400 => "Bad Request",
            401 => "Unauthorized",
            402 => "Payment Required",
            403 => "Forbidden",
            404 => "Not Found",
            405 => "Method Not Allowed",
            406 => "Not Acceptable",
            407 => "Proxy Authentication Required",
            408 => "Request Timeout",
            409 => "Conflict",
            410 => "Gone",
            411 => "Length Required",
            412 => "Precondition Failed",
            413 => "Request Entity Too Large",
            414 => "Request-URI Too Long",
            415 => "Unsupported Media Type",
            416 => "Requested Range Not Satisfiable",
            422 => "Unprocessable Entity",
            500 => "Internal Server Error",
            501 => "Not Implemented",
            502 => "Bad Gateway",
            503 => "Service Unavailable",
            504 => "Gateway Timeout",
            505 => "HTTP Version Not Supported",
            506 => "Variant Also Negotiates",
            507 => "Insufficient Storage",
            508 => "Loop Detected",
            509 => "Bandwidth Limit Exceeded",
            510 => "Not Extended",
            511 => "Network Authentication Required",
            599 => "Network Connect Timeout Error",
            _ => "Unknown Status Code"
        };
    }
    // method to demonstrate Get HTTP Status Message method
    public static void ShowHttpStatusMessage()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Show HTTP Status Message");
        Console.WriteLine("---------------------");

        string userResponse = string.Empty;
        do
        {
            try
            {
                Console.Write("Enter HTTP Status Code: ");
                if(!int.TryParse(Console.ReadLine()?.Trim() ?? string.Empty, out int httpStatusCode))
                    throw new ArgumentException("HTTP Status Code must be a number");

                Console.WriteLine($"HTTP Status Message: {GetHttpStatusMessage(httpStatusCode)}");

                Console.Write("Do you want to continue? [y/n]: ");
                userResponse = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        } while(userResponse == "y");
    }

}
