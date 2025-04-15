/*
 * Creative Additions:
 * - Leveling system: Gain a new level every 1000 points.
 * - NegativeGoal: Lose points for bad habits like missing prayer or gossiping.
 */

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Eternal Quest ===");
            manager.ShowScore();
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.WriteLine("\n=== Choose an option ===");
            /*Console.Write("Choose an option: ");*/


            switch (Console.ReadLine())
            {
                
                case "1": CreateGoal(manager); break;
                case "2": manager.DisplayGoals(); break;
                case "3":
                    manager.DisplayGoals();
                    Console.Write("Enter goal number: ");
                    manager.RecordGoal(int.Parse(Console.ReadLine()) - 1);
                    break;
                case "4":
                    Console.Write("Filename to save: ");
                    manager.SaveGoals(Console.ReadLine());
                    break;
                case "5":
                    Console.Write("Filename to load: ");
                    manager.LoadGoals(Console.ReadLine());
                    break;
                case "6": running = false; break;
                case "7":
                     manager.ListGoals();break;

            }
        }
    }
    

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\n=== what type of Goal you wish to creat ===");
        Console.WriteLine("1) Simple ");
        Console.WriteLine("2) Eternal ");
        Console.WriteLine("3) Checklist ");
        Console.WriteLine("4) Negative ");
        Console.WriteLine("Choose an option: ");
        string type = Console.ReadLine();
        Console.Write("What is the Name of your Goal: "); string name = Console.ReadLine();
        Console.Write("What is the short Description of it: "); string desc = Console.ReadLine();
        Console.Write("Points: "); int pts = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, desc, pts));
                break;
            case "2":
                manager.AddGoal(new EternalGoal(name, desc, pts));
                break;
            case "3":
                Console.Write("Times to complete: ");
                int count = int.Parse(Console.ReadLine());
                Console.Write("Bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                manager.AddGoal(new ChecklistGoal(name, desc, pts, count, bonus));
                break;
            case "4":
                manager.AddGoal(new NegativeGoal(name, desc, pts));
                break;
        }
    }
}
