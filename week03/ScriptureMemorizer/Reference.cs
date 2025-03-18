using System;

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; }

    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        return EndVerse == null ? $"{Book} {Chapter}:{StartVerse}" : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }

    public static Reference Parse(string input)
    {
        string[] parts = input.Split(' ');
        string book = parts[0];
        string[] chapterVerse = parts[1].Split(':');
        int chapter = int.Parse(chapterVerse[0]);
        string[] verseParts = chapterVerse[1].Split('-');
        int startVerse = int.Parse(verseParts[0]);
        int? endVerse = verseParts.Length > 1 ? int.Parse(verseParts[1]) : (int?)null;
        return new Reference(book, chapter, startVerse, endVerse);
    }
}