// Reflection Activity (ReflectionActivity.cs)
public class ReflectionActivity : Activity
{
    private readonly List<string> _prompts = new() { /* prompts */ };
    private readonly List<string> _questions = new() { /* questions */ };
    private List<string> _unusedQuestions = new();

    public ReflectionActivity() : base(
        "Reflection",
        "Reflect on times you've shown strength. Recognize your personal power."
    ) 
    {
        ResetQuestions();
    }

    public override void Run()
    {
        DisplayStartMessage();
        Console.WriteLine($"\nPrompt: {GetRandomPrompt()}");
        Console.WriteLine("\nPress Enter when ready");
        Console.ReadLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        Console.WriteLine("Begin reflection...\n");
        
        while (DateTime.Now < endTime)
        {
            Console.WriteLine(GetUniqueQuestion());
            ShowSpinner(5);
        }
        
        DisplayEndMessage();
    }

    private string GetRandomPrompt() => _prompts[new Random().Next(_prompts.Count)];
    
    private string GetUniqueQuestion()
    {
        if (_unusedQuestions.Count == 0) ResetQuestions();
        string question = _unusedQuestions[0];
        _unusedQuestions.RemoveAt(0);
        return question;
    }
    
    private void ResetQuestions() => _unusedQuestions = new List<string>(_questions);
}
