public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int length, int laps)
        : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000.0;
    public override double GetSpeed() => (GetDistance() / GetLength()) * 60;
    public override double GetPace() => GetLength() / GetDistance();
    public override string GetTypeName() => "Swimming";
    public override double GetCaloriesBurned() => GetDistance() * 40; // ~40 kcal per km

    public override string GetIcon() => "🏊";
}
