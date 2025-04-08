using System;

public static class Logger
{
    public static void Log(string activityName, int duration)
    {
        // Log the activity name and duration
        Console.WriteLine($"Activity: {activityName}, Duration: {duration} seconds");
    }
}
