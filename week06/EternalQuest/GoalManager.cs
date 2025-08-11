using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public void Start()
    {
        LoadGoals(); // Auto-load on start
        bool quit = false;
        
        while (!quit)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");

            switch (Console.ReadLine())
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": quit = true; break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        int level = _score / 1000 + 1;
        Console.WriteLine($"\nYou have {_score} points");
        Console.WriteLine($"Level: {level}");
    }

    private void CreateGoal()
    {
        Console.WriteLine("Goal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal (Penalty)");
        Console.Write("Select goal type: ");

        string type = Console.ReadLine();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Target completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, points, bonus, target));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, desc, points));
                break;
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i+1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        ListGoals();
        Console.Write("Select goal: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int earned = _goals[index].RecordEvent();
            _score += earned;
            Console.WriteLine($"Event recorded! Earned: {earned} points");
        }
    }

    private void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter("goals.txt"))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    private void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            string[] lines = File.ReadAllLines("goals.txt");
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string[] data = parts[1].Split(',');

                switch (parts[0])
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), 
                            int.Parse(data[3]), int.Parse(data[4])));
                        break;
                    case "NegativeGoal":
                        _goals.Add(new NegativeGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                }
            }
        }
    }
}