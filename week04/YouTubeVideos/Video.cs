// Video.cs
public class Video
{
    private string _title;
    private string _author;
    private int _length; // in seconds
    private List<Comment> _comments = new();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(Comment comment) => _comments.Add(comment);
    public int GetCommentCount() => _comments.Count;
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {_title}\nAuthor: {_author}\nLength: {_length}s\nComments: {GetCommentCount()}");
        foreach (var comment in _comments)
            Console.WriteLine($"- {comment.GetCommentDetails()}");
    }
}

// Comment.cs
public class Comment
{
    private string _commenterName;
    private string _text;

    public Comment(string name, string text)
    {
        _commenterName = name;
        _text = text;
    }

    public string GetCommentDetails() => $"{_commenterName}: {_text}";
}