public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int penalty) 
        : base(name, description, penalty) { }

    public override int RecordEvent()
    {
        _lastRecordedDate = DateTime.Today;
        return -_points; // For deducting points
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString() => 
        $"[!] {_name} ({_description}) - Penalty: {_points} points";

    public override string GetStringRepresentation() => 
        $"NegativeGoal:{_name},{_description},{_points},{_lastRecordedDate}";
}