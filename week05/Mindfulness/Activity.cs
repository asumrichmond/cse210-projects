using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public virtual void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"\n--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public virtual void DisplayEndingMessage()
    {
        Console.WriteLine($"\nWell done! You completed {_duration} seconds of {_name}.");
        Logger.Log(_name, _duration);
        ShowQuote();
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        var symbols = new[] { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write($"\r{symbols[i++ % symbols.Length]}");
            Thread.Sleep(200);
        }
        Console.Write("\r ");
    }

    protected void ShowQuote()
    {
        string[] quotes = {
            "🌟 Peace comes from within. Do not seek it without.",
            "🧘‍♀️ Be where you are; otherwise you will miss your life.",
            "🌿 Every breath we take, every step we make, can be filled with peace.",
            "✨ You are enough just as you are."
        };
        var rand = new Random();
        Console.WriteLine($"\n{quotes[rand.Next(quotes.Length)]}\n");
    }

    public abstract void Run();
}
