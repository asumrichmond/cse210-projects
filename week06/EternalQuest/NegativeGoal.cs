public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int penaltyPoints)
        : base(name, description, -penaltyPoints) {}

    public override int RecordEvent() => Points;  // Negative value

    public override bool IsComplete() => false;

    public override string GetStatus() => "[⚠️ Bad Habit]";

    public override string GetStringRepresentation()
        => $"Negative:{Name},{Description},{Points}";
}
