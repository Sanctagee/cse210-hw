using System;

public class Entry
{
    public string _prompt;
    public string _response;
    public string _date;
    public string _mood; // Extra field to exceed requirements

    public Entry()
    {
        _date = DateTime.Now.ToShortDateString();
    }

    public void Display()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Date: {_date}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Mood: {_mood}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Prompt: {_prompt}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
        Console.ResetColor();
    }

    public string FormatForSave()
    {
        return $"{_date}|{_mood}|{_prompt}|{_response}";
    }

    public void LoadFromString(string entryString)
    {
        string[] parts = entryString.Split('|');
        _date = parts[0];
        _mood = parts[1];
        _prompt = parts[2];
        _response = parts[3];
    }
}