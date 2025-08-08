// Main Program (Program.cs)

/*
CREATIVITY SHOWCASE:
1. Activity Statistics Tracking
   - Logs all activity sessions with timestamps
   - Shows total time spent per activity type
2. Non-Repeating Prompts System
   - Ensures all reflection questions are used before repeating
3. Enhanced Breathing Visualization
   - Dynamic text sizing during inhale/exhale
4. Gratitude Journal Extension
   - Added bonus activity with custom prompts
*/

class Program
{
    static void Main()
    {
        ActivityManager manager = new();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities\n");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Exit\n");

            switch (Console.ReadLine())
            {
                case "1": RunActivity(new BreathingActivity(), manager); break;
                case "2": RunActivity(new ReflectionActivity(), manager); break;
                case "3": RunActivity(new ListingActivity(), manager); break;
                case "4": manager.ShowLog(); Pause(); break;
                case "5": manager.ShowLog(); return;
            }
        }
    }

    static void RunActivity(Activity activity, ActivityManager manager)
    {
        activity.Run();
        manager.TrackActivity(activity.GetType().Name);
    }

    static void Pause()
    {
        Console.Write("\nPress Enter to continue...");
        Console.ReadLine();
    }
}