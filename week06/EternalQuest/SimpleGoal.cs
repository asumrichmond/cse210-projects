public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _completed = false;
    }

    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return Points;
        }
        return 0;
    }

    public override bool IsComplete() => _completed;

    public override string GetDetails()
    {
        return $"[{(_completed ? "X" : " ")}] {Name} ({Description})";
    }

    public override string GetSaveString()
    {
        return $"SimpleGoal:{Name},{Description},{Points},{_completed}";
    }
}
