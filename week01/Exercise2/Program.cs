using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.WriteLine("Enter your grade percentage:");

    string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);
        
        // Determine the letter grade
        string letter;
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        
        // Determine the grade sign (+ or -)
        string sign = "";
        int lastDigit = grade % 10;
        if (grade >= 60 && grade < 90) // No sign needed for A or F
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        
        // Handle A+ case (does not exist)
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }
        
        // Handle F+ and F- cases (do not exist)
        if (letter == "F")
        {
            sign = "";
        }
        
        // Print the final grade
        Console.WriteLine($"Your grade is: {letter}{sign}");
        
        // Check if the student passed
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep working hard, you'll do better next time!");
        }
    }
}