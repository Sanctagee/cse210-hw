
using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind?"
    };

    public ReflectionActivity() : base(
        "Reflection Activity",
        "This activity helps you reflect on meaningful life experiences."
    ) { }

    public override void Run()
    {
        DisplayStartMessage();
        
        Random rand = new();
        Console.WriteLine($"\nPrompt: {_prompts[rand.Next(_prompts.Count)]}");
        Console.WriteLine("\nWhen you have something in mind, press Enter.");
        Console.ReadLine();

        Console.WriteLine("Now ponder these questions:");
        Console.Write("Starting in ");
        ShowCountdown(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"\n{_questions[rand.Next(_questions.Count)]}");
            ShowSpinner(5);
        }

        DisplayEndMessage();
    }
}