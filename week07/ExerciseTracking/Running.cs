public class Running : Activity
{
    private double _distance; // in km

    public Running(string date, int length, double distance)
        : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / GetLength()) * 60;
    public override double GetPace() => GetLength() / _distance;
    public override string GetTypeName() => "Running";
    public override double GetCaloriesBurned() => _distance * 60; // 60 kcal per km

    public override string GetIcon() => "👟";
}
