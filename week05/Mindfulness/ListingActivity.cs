
using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base(
        "Listing Activity",
        "This activity helps you reflect on positive aspects by listing items."
    ) { }

    public override void Run()
    {
        DisplayStartMessage();
        
        Random rand = new();
        Console.WriteLine($"\nPrompt: {_prompts[rand.Next(_prompts.Count)]}");
        Console.Write("Starting in ");
        ShowCountdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int itemCount = 0;

        Console.WriteLine("\nBegin listing:");
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            itemCount++;
        }

        Console.WriteLine($"\nYou listed {itemCount} items!");
        DisplayEndMessage();
    }
}