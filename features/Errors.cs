using System.Text;

public static class Errors
{
    private static void ThrowNullReferenceException()
    {
        // null reference exception
        string? messages = null;
        #pragma warning disable CS8602
        Console.WriteLine(messages.ToString());
        #pragma warning restore CS8602
    }
    private static void ThrowDivideByZeroException()
    {
        // divide by zero exception
        int number3 = 10;
        int number4 = 0;
        int quotient = number3 / number4;
        Console.WriteLine($"{number3} / {number4} = {quotient}");
    }
    private static void ThrowOutOfRangeException()
    {
        // index out of range exception
        string[] names = ["John", "Mary", "Bob"];
        Console.WriteLine(names[3]);
    }
    private static void ThrowOverflowException()
    {
        // overflow exception
        checked
        {
            int number1 = int.MaxValue ^ 2;
            Console.WriteLine($"{number1}");
        }
    }

    // method to demonstrate how to handle common exceptions
    // like: overflow, null reference, index out of range and divide by zero
    public static void HandleCommonExceptions()
    {
        try
        {
            try
            {
                ThrowOverflowException();
            }
            catch (OverflowException error)
            {
                Console.WriteLine($"An overflow exception occurred. {error.Message}");
            }
            try
            {
                ThrowDivideByZeroException();
            }
            catch (DivideByZeroException error)
            {
                Console.WriteLine($"A divide by zero exception occurred. {error.Message}");
            }
            try
            {
                ThrowNullReferenceException();
            }
            catch (NullReferenceException error)
            {
                Console.WriteLine($"A null reference exception occurred. {error.Message}");
            }
            try
            {
                ThrowOutOfRangeException();
            }
            catch (IndexOutOfRangeException error)
            {
                Console.WriteLine($"An index out of range exception occurred. {error.Message}");
            }
        }
        catch (Exception error)
        {
            Console.WriteLine($"An exception occurred. {error.Message}");
        }
        finally
        {
            Console.WriteLine("Finally block executed.");
        }

    }

    // method to calculate the sum and average of a range of numbers
    // given the start and end numbers and return them as a tuple
    private static (int sum, float average) SumAndAverageOfRang(int start, int end)
    {
        if(start > end)
            throw new ArgumentOutOfRangeException("The start number must be less than the end number.");

        if (start < 1 || end < 1)
            throw new ArgumentOutOfRangeException("The start and end numbers must be greater than 0.");

        if(start == end)
            throw new ArgumentException("The start and end numbers must be different.");

        int sum = 0, count = 0;
        float average;
        for (int number = start; number <= end; number++)
        {
            sum += number;
            count++;
        }
        average = (float)(sum / count);
        return (sum, average);
    }

    public static void CalculateSumAndAverageOfRange()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Calculate Sum And Average Of a given Range: ");
        Console.WriteLine("---------------------");

        int start, end, sum; float average;
        try
        {
            Console.Write("Enter the start number: ");
            start = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the end number: ");
            end = Convert.ToInt32(Console.ReadLine());
            (sum, average) = SumAndAverageOfRang(start, end);
            Console.WriteLine("---------------------");
            Console.WriteLine($"The sum of [{start} to {end}] is {sum}");
            Console.WriteLine($"The average of [{start} to {end}] is {average:F2}");
        }
        catch (FormatException error)
        {
            Console.WriteLine($"An format exception occurred. {error.Message}");
        }
        catch (ArgumentOutOfRangeException error)
        {
            Console.WriteLine($"An argument out of range exception occurred. {error.Message}");
        }
        catch (ArgumentException error)
        {
            Console.WriteLine($"An argument exception occurred. {error.Message}");
        }
        finally
        {
            Console.WriteLine("---------------------");
        }

    }

}
