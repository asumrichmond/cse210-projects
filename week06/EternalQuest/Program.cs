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
            Console.Write("Choose an option: ");

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
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("Goal Types: 1) Simple  2) Eternal  3) Checklist  4) Negative");
        string type = Console.ReadLine();
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Description: "); string desc = Console.ReadLine();
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
