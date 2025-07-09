using System;

class Program
{
    static void Main(string[] args)
    {
        //  Declaring variables that will enhance the loop
        string playAgain = "yes";

        while (playAgain == "yes")

        {
            // Generate random magic number (1–100)
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            int guess;
            int guessCount = 0; // Track guesses for stretch challenge

            Console.WriteLine("\nGuess the magic number (1-100)!");

            do
            {
                // Get user guess
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

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

            // Ask to play again
            Console.Write("\nPlay again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();
        }

        Console.WriteLine("Thanks for playing!");
            

    }
}