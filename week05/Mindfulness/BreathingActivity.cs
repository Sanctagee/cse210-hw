// Breathing Activity (BreathingActivity.cs)

/* ENHANCEMENT: Dynamic breathing animation
   - Text size grows during inhale
   - Shrinks during exhale
   - Provides visual pacing cue */

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax through paced breathing. Focus on your breath."
    )
    { }

    public override void Run()
    {
        DisplayStartMessage();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);

            Console.Write("\nBreathe out... ");
            ShowCountdown(6);
            Console.WriteLine();
        }

        DisplayEndMessage();
    }
}
