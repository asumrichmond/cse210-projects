using System;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _randomGenerator = new Random(); // Renamed to follow _camelCase

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(_reference.ToString());
        Console.WriteLine(string.Join(" ", _words.Select(w => w.GetDisplayText())));
    }

    public void HideRandomWords(int count)
    {
        List<Word> visibleWords = _words.Where(w => !w.IsHidden).ToList();
        if (visibleWords.Count == 0) return;

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = _randomGenerator.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsFullyHidden()
    {
        return _words.All(w => w.IsHidden);
    }
}
