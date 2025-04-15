public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int penalty)
        : base(name, description, -penalty) { }

    public override int RecordEvent() => Points;

    public override bool IsComplete() => false;

    public override string GetDetails()
    {
        return $"[!] {Name} ({Description}) -- Avoid this to keep points";
    }

    public override string GetSaveString()
    {
        return $"NegativeGoal:{Name},{Description},{-Points}";
    }
}
