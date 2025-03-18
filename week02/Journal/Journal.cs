using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private static readonly List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void WriteEntry()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        
        Console.WriteLine("\nPrompt: " + prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        
        _entries.Add(new Entry(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), prompt, response));
        Console.WriteLine("Entry saved!");
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.");
            return;
        }
        
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"\nEntry {i + 1}");
            Console.WriteLine(_entries[i].GetFormattedEntry());
        }
    }

    public void SearchEntries(string keyword)
    {
        var foundEntries = _entries.FindAll(e => e.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                                  e.Response.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        if (foundEntries.Count == 0)
        {
            Console.WriteLine("No entries found with that keyword.");
        }
        else
        {
            Console.WriteLine("\nSearch Results:");
            foreach (var entry in foundEntries)
            {
                Console.WriteLine(entry.GetFormattedEntry());
            }
        }
    }

    public void DeleteEntry(int index)
    {
        if (index > 0 && index <= _entries.Count)
        {
            _entries.RemoveAt(index - 1);
            Console.WriteLine("Entry deleted successfully.");
        }
        else
        {
            Console.WriteLine("Invalid entry number.");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                _entries.Add(new Entry(parts[0], parts[1], parts[2]));
            }
        }
        Console.WriteLine("Journal loaded successfully.");
    }
}
