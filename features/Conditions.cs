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
}
