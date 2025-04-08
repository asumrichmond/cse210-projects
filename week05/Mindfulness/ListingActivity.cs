public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "List things that make you smile.",
        "List people who inspire you.",
        "List goals you’re proud of achieving."
    };

    public ListingActivity() : base("Listing Activity",
        "List as many positive things as you can in a short time.") { }

    public override void Run()
    {
        DisplayStartingMessage();
        var rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine($"\n✏️ Prompt: {prompt}");
        Console.WriteLine("Start listing! Press Enter after each item:");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            if (!string.IsNullOrWhiteSpace(Console.ReadLine()))
                count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");
        DisplayEndingMessage();
    }
}
