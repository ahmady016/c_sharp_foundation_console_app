public static class Numbers
{
    public static void GetRandomNumber()
    {
        Random random = new();
        int randomNumber = random.Next(1, 101);
        Console.WriteLine($"Random number between 1 and 100: {randomNumber}");
    }

    public static void GetThreeRandomNumbers()
    {
        Random random = new();
        int firstNumber = random.Next(1, 101);
        int secondNumber = random.Next(1, 101);
        int thirdNumber = random.Next(1, 101);
        Console.WriteLine($"Three random numbers: {firstNumber}, {secondNumber}, {thirdNumber}");
    }

    public static void MathOperations()
    {
        Random random = new();
        int firstNumber = random.Next(1, 101);
        int secondNumber = random.Next(1, 101);
        int thirdNumber = random.Next(1, 101);
        int sum = firstNumber + secondNumber + thirdNumber;
        float average = (float)sum / 3;
        Console.WriteLine($"The sum of ({firstNumber}, {secondNumber}, {thirdNumber}) = {sum}");
        Console.WriteLine($"The average of ({firstNumber}, {secondNumber}, {thirdNumber}) = {average:F2}");

        int max = Math.Max(firstNumber, Math.Max(secondNumber, thirdNumber));
        int min = Math.Min(firstNumber, Math.Min(secondNumber, thirdNumber));
        Console.WriteLine($"The maximum number is: {max}");
        Console.WriteLine($"The minimum number is: {min}");
    }

    public static void AnotherMathOperations()
    {
        Random random = new();
        int firstNumber = random.Next(1, 101);
        int secondNumber = random.Next(1, 101);
        int thirdNumber = random.Next(1, 101);

        int product = firstNumber * secondNumber * thirdNumber;
        float quotient = (float)firstNumber / (float)secondNumber / (float)thirdNumber;
        int remainder = firstNumber % secondNumber % thirdNumber;
        Console.WriteLine($"The product of ({firstNumber}, {secondNumber}, {thirdNumber}) = {product}");
        Console.WriteLine($"The quotient of ({firstNumber}, {secondNumber}, {thirdNumber}) = {quotient:F2}");
        Console.WriteLine($"The remainder of ({firstNumber}, {secondNumber}, {thirdNumber}) = {remainder}");
    }
}
