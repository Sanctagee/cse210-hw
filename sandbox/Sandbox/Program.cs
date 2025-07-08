using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for first name
        Console.WriteLine("What is your first name?");
        string firstName = Console.ReadLine();

        // Ask for last name
        Console.WriteLine("What is your last name?");
        string lastName = Console.ReadLine();

        // Display formatted output
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}");
    }
}