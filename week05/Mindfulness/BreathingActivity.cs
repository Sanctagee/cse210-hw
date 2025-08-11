// Breathing Activity (BreathingActivity.cs)

/* ENHANCEMENT: Dynamic breathing animation
   - Text size grows during inhale
   - Shrinks during exhale
   - Provides visual pacing cue */

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by guiding you through slow breathing."
    ) { }

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
        }

        DisplayEndMessage();
    }
}
