public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time you showed courage.",
        "Reflect on a moment of peace.",
        "When did you overcome a challenge?",
        "What is a lesson you learned recently?"
    };
    private List<string> _usedPrompts = new List<string>();

    public ReflectingActivity() : base("Reflecting Activity",
        "Reflect on meaningful moments to deepen your mindfulness.") { }

    public override void Run()
    {
        DisplayStartingMessage();
        string prompt = GetUniquePrompt();
        Console.WriteLine($"\n🧠 Reflect on this: {prompt}");
        ShowSpinner(3);
        Console.WriteLine("\nThink about it...");
        ShowSpinner(_duration);
        DisplayEndingMessage();
    }

    private string GetUniquePrompt()
    {
        if (_usedPrompts.Count == _prompts.Count) _usedPrompts.Clear();
        var remaining = _prompts.Except(_usedPrompts).ToList();
        var rand = new Random();
        var prompt = remaining[rand.Next(remaining.Count)];
        _usedPrompts.Add(prompt);
        return prompt;
    }
}
