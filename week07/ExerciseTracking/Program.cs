using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("15 Apr 2025", 30, 5.0),
            new Cycling("15 Apr 2025", 45, 20.0),
            new Swimming("15 Apr 2025", 40, 30)
            
        };

        Console.WriteLine("\n***********************************************************************************************************");
        Console.WriteLine("📊 Exercise Summary:\n");   
        Console.WriteLine("\n---------------------");
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
        
        Console.WriteLine("\n***********************************************************************************************************");
    }
}
