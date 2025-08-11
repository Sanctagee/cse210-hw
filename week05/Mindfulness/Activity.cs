// Base Activity Class (Activity.cs)
using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected static int _activityCount;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public static int GetActivityCount()
    {
        return _activityCount;
    }
    protected void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}!");
        Console.WriteLine($"\n{_description}");
        
        while (true)
        {
            Console.Write("\nHow long (in seconds) would you like your session? ");
            if (int.TryParse(Console.ReadLine(), out _duration) && _duration > 0)
                break;
            Console.WriteLine("Please enter a positive number.");
        }

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
    }

    protected void DisplayEndMessage()
    {
        Console.WriteLine("\nGreat job!");
        Console.WriteLine($"You've completed {_duration} seconds of the {_name}.");
        ShowSpinner(3);
        _activityCount++;
    }

    protected void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] spinner = { "|", "/", "-", "\\" };
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            index = (index + 1) % spinner.Length;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public abstract void Run();
}
