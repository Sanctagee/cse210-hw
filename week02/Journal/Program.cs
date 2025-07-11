/*
Journal Program - CSE210 Week 02 Assignment
By: Gabriel Chikwendu Nwofoke

This program helps users keep a journal by:
- Providing random writing prompts
- Storing entries with dates
- Saving/loading to files

Exceeds requirements by:
1. Adding mood tracking for each entry
2. Including 3 additional journal prompts
3. Implementing robust file handling
4. Adding color to the console output
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("This program includes these extra features:");
        Console.WriteLine("- Tracks your mood with each entry");
        Console.WriteLine("- Additional journal prompts");
        Console.WriteLine("- Colorful console output");
        Console.ResetColor();
        Console.WriteLine();

        while (running)
        {
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("> ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ResetColor();
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Journal Program!");
    }

    static void WriteNewEntry(Journal journal)
    {
        Entry entry = new Entry();
        entry._prompt = journal.GetRandomPrompt();
        
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Prompt: {entry._prompt}");
        Console.ResetColor();
        Console.Write("Your response: ");
        entry._response = Console.ReadLine();
        
        Console.Write("How are you feeling today? (mood): ");
        entry._mood = Console.ReadLine();
        
        journal.AddEntry(entry);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Entry added successfully!\n");
        Console.ResetColor();
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save to: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load from: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }
}