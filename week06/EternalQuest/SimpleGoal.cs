public class SimpleGoal : Goal
{
    private bool _isComplete = false;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) {}

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return Points;
        }
        return 0;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStatus() => _isComplete ? "[X]" : "[ ]";

    public override string GetStringRepresentation()
        => $"Simple:{Name},{Description},{Points},{_isComplete}";
}
