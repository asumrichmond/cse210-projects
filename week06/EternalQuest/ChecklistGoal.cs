public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        return (_currentCount == _targetCount) ? Points + _bonusPoints : Points;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus()
        => IsComplete() ? "[X]" : $"[ ] Completed {_currentCount}/{_targetCount}";

    public override string GetStringRepresentation()
        => $"Checklist:{Name},{Description},{Points},{_bonusPoints},{_currentCount},{_targetCount}";
}
