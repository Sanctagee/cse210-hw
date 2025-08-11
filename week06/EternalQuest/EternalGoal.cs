public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        int bonus = CalculateStreakBonus();
        _lastRecordedDate = DateTime.Today;
        return _points + bonus;
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString() => 
        $"[ ] {_name} ({_description})";

    public override string GetStringRepresentation() => 
        $"EternalGoal:{_name},{_description},{_points},{_lastRecordedDate}";
}