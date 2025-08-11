public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int bonus, int target) 
        : base(name, description, points)
    {
        _bonus = bonus;
        _target = target;
    }

    public override int RecordEvent()
    {
        int bonus = CalculateStreakBonus();
        _lastRecordedDate = DateTime.Today;
        _amountCompleted++;
        
        if (_amountCompleted >= _target)
        {
            return _points + _bonus + bonus;
        }
        return _points + bonus;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString() => 
        $"[{(_amountCompleted >= _target ? "X" : " ")}] {_name} ({_description}) " +
        $"- Completed {_amountCompleted}/{_target} times";

    public override string GetStringRepresentation() => 
        $"ChecklistGoal:{_name},{_description},{_points},{_bonus},{_target},{_amountCompleted},{_lastRecordedDate}";
}