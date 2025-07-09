using System;

class Program
{
    static void Main(string[] args)
    {
        // Generate random magic number (1–100)
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess;
        int guessCount = 0; // Track guesses for stretch challenge

        Console.WriteLine("Guess the magic number (1-100)!");

        do
        {
            // Get user guess
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            guessCount++;

            // Provide feedback
            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine($"You guessed it in {guessCount} tries!");
            }
        } while (guess != magicNumber);
    }
}