using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}

/* Creativity and Exceeding Requirements:
1. Added NegativeGoal class for tracking bad habits (loses points when recorded)
2. Implemented Level System: 
   - Player levels up every 1000 points
   - Displays current level with score
3. Added streak bonus:
   - Awards 10% bonus points for consecutive daily recordings
   - Tracks last recorded date per goal
*/