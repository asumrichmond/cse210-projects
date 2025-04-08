using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("🧘‍♂️ Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            // Removed Gratitude Activity option
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return; // Quit the program
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    continue; // Continue the loop without breaking
            }

            if (activity != null)
            {
                activity.Run();
            }
        }

        Console.WriteLine("\n👋 Thanks for using the Mindfulness Program!");
    }
}
