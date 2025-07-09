using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for grade percentage
        Console.Write("Enter your grade percentage: ");
        string answer = Console.ReadLine();
        int gradePercentage = int.Parse(answer);

        string letter = ""; // Variable to hold the letter grade;
        string sign = ""; // Variable for + or -     

        // Determine letter grade
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }


        // Determine sign (+, -, or none)
        int lastDigit = gradePercentage % 10; // Get the last digit
        if (letter != "F") // No + or - for F
        {
            if (lastDigit >= 7 && letter != "A") // No A+
            {
                sign = "+";
            }
            else if (lastDigit < 3 && letter != "F") // No F-
            {
                sign = "-";
            }
        }

        // Print final grade
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Pass/fail message
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep working hard for next time!");
        }

    }
}