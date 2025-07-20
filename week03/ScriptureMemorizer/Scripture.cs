public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count)
    {
        var visibleIndices = _words
            .Select((word, index) => new { word, index })
            .Where(x => !x.word.IsHidden())
            .Select(x => x.index)
            .ToList();

        var random = new Random();
        count = Math.Min(count, visibleIndices.Count);
        
        for (int i = 0; i < count; i++)
        {
            int randomIndex = random.Next(visibleIndices.Count);
            _words[visibleIndices[randomIndex]].Hide();
            visibleIndices.RemoveAt(randomIndex);
        }
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        string wordsText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{referenceText}\n\n{wordsText}";
    }


    public double GetHiddenPercentage()
    {
        int hiddenCount = _words.Count(word => word.IsHidden());
        return (double)hiddenCount / _words.Count;
    }
    
    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}