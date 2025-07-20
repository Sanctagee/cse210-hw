using System.Text.Json; 

namespace ScriptureMemorizer;
class Program
{
    // EXCEEDS REQUIREMENTS: Scripture library and difficulty levels
    static void Main(string[] args)
    {
        // Load scriptures from JSON file
        var scriptures = LoadScriptures("scriptures.json");
        var random = new Random();
        var scripture = scriptures[random.Next(scriptures.Count)];

        // Difficulty selection
        Console.WriteLine("Select difficulty (1=Easy, 2=Medium, 3=Hard):");
        int difficulty = int.Parse(Console.ReadLine() ?? "2");
        int wordsToHide = difficulty switch { 1 => 1, 3 => 5, _ => 3 };

        // Main loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            // EXCEEDS: Show progress percentage
            double hiddenPercent = scripture.GetHiddenPercentage();
            Console.WriteLine($"\nHidden: {hiddenPercent:0%} | Press ENTER or type QUIT");

            string input = Console.ReadLine()?.Trim() ?? "";
            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase)) break;

            scripture.HideRandomWords(wordsToHide);
            if (scripture.IsCompletelyHidden()) break;
        }

        // Final display
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words hidden. Program ending.");
    }

    // EXCEEDS: Load from JSON file
    static List<Scripture> LoadScriptures(string filePath)
    {
        // JSON structure: [{ "book":"John","chapter":3,"verse":16,"endVerse":0,"text":"For God so loved..."}, ...]
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<ScriptureData>>(json)!
            .Select(data => new Scripture(
                data.endVerse > 0
                    ? new Reference(data.book, data.chapter, data.verse, data.endVerse)
                    : new Reference(data.book, data.chapter, data.verse),
                data.text))  // Closing parenthesis for new Scripture() was missing
            .ToList();
    }

    private record ScriptureData(string book, int chapter, int verse, int endVerse, string text);
}