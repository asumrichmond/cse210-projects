public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
        "Relax and focus on your breathing with guided prompts.") { }

    public override void Run()
    {
        DisplayStartingMessage();
        for (int i = 0; i < _duration / 6; i++)
        {
            AnimateText("Breathe in...", true);
            AnimateText("Breathe out...", false);
        }
        DisplayEndingMessage();
    }

    private void AnimateText(string message, bool expanding)
    {
        Console.Write("\r");
        for (int i = 1; i <= message.Length; i++)
        {
            Console.Write("\r" + message.Substring(0, expanding ? i : message.Length - i));
            Thread.Sleep(100);
        }
        Thread.Sleep(1000);
        Console.Write("\r" + new string(' ', message.Length));
    }
}
