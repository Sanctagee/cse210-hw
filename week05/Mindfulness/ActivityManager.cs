using System;
using System.Collections.Generic;

public class ActivityManager
{
    private readonly Dictionary<string, int> _activityLog = new();
    
    public void TrackActivity(string name) 
    {
        if (_activityLog.ContainsKey(name)) 
            _activityLog[name]++;
        else 
            _activityLog.Add(name, 1);
    }
    
    public void ShowLog()
    {
        Console.WriteLine("\nActivity Statistics:");
        foreach (KeyValuePair<string, int> entry in _activityLog)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} time(s)");
        }
        Console.WriteLine($"Total sessions: {Activity.GetActivityCount()}");
    }
}