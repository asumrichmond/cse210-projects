public abstract class Activity
{
    private string _date;
    private int _length; // in minutes

    public Activity(string date, int length)
    {
        _date = date;
        _length = length;
    }

    public string GetDate() => _date;
    public int GetLength() => _length;

    public abstract double GetDistance(); // km
    public abstract double GetSpeed(); // kph
    public abstract double GetPace(); // min/km
    public abstract string GetTypeName();
    public abstract double GetCaloriesBurned(); // Creative

    public virtual string GetSummary()
    {
        return $"{_date} {GetTypeName()} ({_length} min): " +
               $"Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, " +
               $"Pace {GetPace():0.00} min/km, Calories: {GetCaloriesBurned():0.0} kcal {GetIcon()}";
    }

    public virtual string GetIcon()
    {
        return ""; // override in child
    }
}
