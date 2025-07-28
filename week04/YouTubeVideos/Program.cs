using System;
var videos = new List<Video>
{
    new Video("C# Tutorial", "StrongCode", 600),
    new Video("OOP Principles", "CodeMaster", 1200),
    new Video("JavaScript Data Types", "GabbyTech", 1950),
    new Video("Django Dashboard", "StrongCode", 1100),
    new Video("Web Development Tutorial", "GabbyTech", 900),
    new Video("UseStates in React", "GabbyTech", 1000)
};

// Add comments
videos[0].AddComment(new Comment("User1", "Great tutorial!"));


videos[1].AddComment(new Comment("User2", "Very helpful."));
videos[1].AddComment(new Comment("DevA", "Clear explanation of OOP!"));
videos[1].AddComment(new Comment("DevB", "Would love more examples."));

videos[2].AddComment(new Comment("User3", "Wow! This is easier than what I had!"));
videos[2].AddComment(new Comment("JSFan", "Perfect for beginners."));
videos[2].AddComment(new Comment("CoderX", "When will you cover ES6?"));

videos[3].AddComment(new Comment("User4", "Quite Interesting way to construct Dashboard"));
videos[3].AddComment(new Comment("PythonLover", "Django FTW!"));

videos[4].AddComment(new Comment("User5", "GabbyTech, thanks for a job well done!"));
videos[4].AddComment(new Comment("Designer", "Add CSS tips next time."));
videos[4].AddComment(new Comment("WebNewbie", "Short but insightful."));

videos[5].AddComment(new Comment("User6", "This is of utmost importance to me."));
videos[5].AddComment(new Comment("ReactDev", "useState is my favorite hook!"));

// Display
foreach (var video in videos)
{
    video.DisplayInfo();
    Console.WriteLine();
}
