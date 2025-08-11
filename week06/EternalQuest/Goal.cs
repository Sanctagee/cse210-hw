public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected DateTime _lastRecordedDate;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _lastRecordedDate = DateTime.MinValue;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();

    public virtual string GetName() => _name;
    
    protected int CalculateStreakBonus()
    {
        if (_lastRecordedDate.Date == DateTime.Today.AddDays(-1))
        {
            return (int)(_points * 0.1); // Bear in mind that this 0.1 implies 10% bonus
        }
        return 0;
    }
}