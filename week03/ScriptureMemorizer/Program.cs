using System;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found in file. Using default scripture.");
            scriptures.Add(new Scripture(new Reference("John", 3, 16), 
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."));
        }

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (!scripture.IsFullyHidden())
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // Hides 3 words at a time
        }

        Console.Clear();
        scripture.Display();
        Console.WriteLine("\nAll words are hidden! Program ending...");
    }

    static List<Scripture> LoadScripturesFromFile(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    Reference reference = Reference.Parse(parts[0]);
                    scriptures.Add(new Scripture(reference, parts[1]));
                }
            }
        }
        return scriptures;
    }
}