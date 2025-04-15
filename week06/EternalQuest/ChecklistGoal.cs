public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        return _currentCount == _targetCount ? Points + _bonus : Points;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetDetails()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {Name} ({Description}) -- Completed {_currentCount}/{_targetCount}";
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal:{Name},{Description},{Points},{_targetCount},{_bonus},{_currentCount}";
    }
}
