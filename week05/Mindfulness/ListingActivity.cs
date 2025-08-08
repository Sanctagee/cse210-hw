// Listing Activity (ListingActivity.cs)
public class ListingActivity : Activity
{
    private readonly List<string> _prompts = new() { /* prompts */ };
    private int _itemCount;

    public ListingActivity() : base(
        "Listing",
        "Reflect on good things in your life by listing items in a specific area."
    ) { }

    public override void Run()
    {
        DisplayStartMessage();
        Console.WriteLine($"\nPrompt: {GetRandomPrompt()}");
        Console.Write("\nStarting in: ");
        ShowCountdown(5);
        
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        _itemCount = 0;
        
        Console.WriteLine("\nStart listing:");
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _itemCount++;
        }
        
        Console.WriteLine($"\nYou listed {_itemCount} items!");
        DisplayEndMessage();
    }

    private string GetRandomPrompt() => _prompts[new Random().Next(_prompts.Count)];
}
