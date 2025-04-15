public class Cycling : Activity
{
    private double _speed; // in kph

    public Cycling(string date, int length, double speed)
        : base(date, length)
    {
        _speed = speed;
    }

    public override double GetSpeed() => _speed;
    public override double GetDistance() => (_speed * GetLength()) / 60;
    public override double GetPace() => 60 / _speed;
    public override string GetTypeName() => "Cycling";
    public override double GetCaloriesBurned() => GetDistance() * 30; // ~30 kcal per km

    public override string GetIcon() => "🚴";
}
