public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void RecordGoal(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            int points = _goals[index].RecordEvent();
            _score += points;
            UpdateLevel();
        }
    }

    private void UpdateLevel()
    {
        _level = (_score / 1000) + 1;
    }
    

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].Name} ({_goals[i].Description})");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Score: {_score} pts | Level: {_level}");
    }
    public void ListGoals()
    {
        Console.WriteLine("Your Goals:");
        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetStatus()}");
            index++;
        }
    }
    
    


    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string type = parts[0];
            string[] details = parts[1].Split(',');

            switch (type)
            {
                case "Simple":
                    AddGoal(new SimpleGoal(details[0], details[1], int.Parse(details[2])) { /* restore _isComplete */ });
                    break;
                case "Eternal":
                    AddGoal(new EternalGoal(details[0], details[1], int.Parse(details[2])));
                    break;
                case "Checklist":
                    AddGoal(new ChecklistGoal(details[0], details[1], int.Parse(details[2]),
                                              int.Parse(details[5]), int.Parse(details[3])));
                    break;
                case "Negative":
                    AddGoal(new NegativeGoal(details[0], details[1], -int.Parse(details[2])));
                    break;
            }
        }
    }
}
