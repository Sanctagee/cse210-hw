public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        if (_isComplete) return 0;
        
        int bonus = CalculateStreakBonus();
        _lastRecordedDate = DateTime.Today;
        _isComplete = true;
        return _points + bonus;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetailsString() => 
        $"[{(_isComplete ? "X" : " ")}] {_name} ({_description})";

    public override string GetStringRepresentation() => 
        $"SimpleGoal:{_name},{_description},{_points},{_isComplete},{_lastRecordedDate}";
}