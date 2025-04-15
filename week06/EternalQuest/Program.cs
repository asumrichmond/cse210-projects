using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Score: {score} | Level: {score / 1000 + 1} - {GetTitle()}");
            Console.WriteLine("1. Create Goal\n2. List Goals\n3. Record Event\n4. Save\n5. Load\n6. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": return;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("Goal Types: 1. Simple 2. Eternal 3. Checklist 4. Negative");
        Console.Write("Type: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1": goals.Add(new SimpleGoal(name, desc, points)); break;
            case "2": goals.Add(new EternalGoal(name, desc, points)); break;
            case "3":
                Console.Write("Target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            case "4":
                goals.Add(new NegativeGoal(name, desc, points)); break;
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetails()}");
        }
        Console.ReadLine();
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Enter number of goal to record: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        int gained = goals[index].RecordEvent();
        score += gained;
        Console.WriteLine($"Points earned: {gained}");
        Console.ReadLine();
    }

    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(score);
            foreach (Goal g in goals)
                writer.WriteLine(g.GetSaveString());
        }
    }

    static void LoadGoals()
    {
        goals.Clear();
        string[] lines = File.ReadAllLines("goals.txt");
        score = int.Parse(lines[0]);

        foreach (string line in lines[1..])
        {
            string[] parts = line.Split(':');
            string[] data = parts[1].Split(',');

            switch (parts[0])
            {
                case "SimpleGoal":
                    goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2])) { });
                    break;
                case "EternalGoal":
                    goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                    break;
                case "ChecklistGoal":
                    var cg = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]));
                    for (int i = 0; i < int.Parse(data[5]); i++) cg.RecordEvent();
                    goals.Add(cg);
                    break;
                case "NegativeGoal":
                    goals.Add(new NegativeGoal(data[0], data[1], int.Parse(data[2])));
                    break;
            }
        }
    }

    static string GetTitle()
    {
        if (score >= 3000) return "Master";
        if (score >= 2000) return "Seeker";
        if (score >= 1000) return "Disciple";
        return "Beginner";
    }
}
