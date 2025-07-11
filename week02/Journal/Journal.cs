using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person you interacted with today?",
        "What was the best part of your day?",
        "How did you see the hand of the Lord in your life today?",
        "What was the strongest emotion you felt today?",
        "If you had one thing you could do over today, what would it be?",
        // Additional prompts to exceed requirements
        "What made you laugh today?",
        "What are you grateful for today?",
        "What challenge did you overcome today?"
    };

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal yet.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.FormatForSave());
            }
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Journal saved to {filename} successfully!");
        Console.ResetColor();
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        if (!File.Exists(filename))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("File not found. Please try again.");
            Console.ResetColor();
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            Entry newEntry = new Entry();
            newEntry.LoadFromString(line);
            _entries.Add(newEntry);
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Journal loaded from {filename} successfully!");
        Console.ResetColor();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}