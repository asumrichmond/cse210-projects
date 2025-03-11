using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userNumber;
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
     do
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());
            
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        } while (userNumber != 0);

        // Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Compute the average
        float average = (float)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Find the maximum number
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge: Find the smallest positive number
        int? smallestPositive = null;
        foreach (int number in numbers)
        {
            if (number > 0 && (smallestPositive == null || number < smallestPositive))
            {
                smallestPositive = number;
            }
        }
        if (smallestPositive != null)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // Stretch Challenge: Sort the list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}