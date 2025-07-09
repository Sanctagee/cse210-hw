using System;

class Program
{
    // Main method
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

    // Displays welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Prompts and returns user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Prompts and returns user's favorite number
    // Additional enhancement for number validation
    static int PromptUserNumber()
    {
        int number;
        while (true)
        {
            Console.Write("Please enter your favorite number: ");
            if (int.TryParse(Console.ReadLine(), out number))
                return number;
            Console.WriteLine("Invalid input. Please enter an integer.");
        }
    }

    // Squares a given number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Displays the result
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }

    
}