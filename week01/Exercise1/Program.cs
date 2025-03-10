using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for their first name
        Console.WriteLine("What is your first name?");
        string firstName = Console.ReadLine();

        // Prompt the user for their last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Display the name in the required format
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}