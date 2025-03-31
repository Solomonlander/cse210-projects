using System;
using System.Collections.Generic;

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    public override string ToString()
    {
        return $"{Name}: {Text}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumComments()
    {
        return Comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"  - {comment}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // create Video objects
        var video1 = new Video("How to Cook Soup", "Chef Lander", 300);
        var video2 = new Video("Learn How To Install Smart Locks", "Hiphen Solutions", 600);
        var video3 = new Video("Amazing Nature Documentary", "Nature Channel", 1800);

        // comments to video1
        video1.AddComment(new Comment("Patinces", "Great recipe! I tried it last night and loved it."));
        video1.AddComment(new Comment("Lander", "I love this channel! You make cooking so easy."));
        video1.AddComment(new Comment("Emediong", "Nice video, but you missed an ingredient."));
        video1.AddComment(new Comment("Esther", "This is a must-try recipe!"));

        // comments to video2
        video2.AddComment(new Comment("Solomon", "Amazing tutorial! I learned so much."));
        video2.AddComment(new Comment("Joshua", "I had no idea Python could be so easy to learn."));
        video2.AddComment(new Comment("Chineyen", "Thanks for the tips! Going to start coding today."));
        video2.AddComment(new Comment("Judith", "This is the best Python tutorial I've found so far."));
            
        //  comments to video3
        video3.AddComment(new Comment("Ime-Obong", "The footage is stunning! Nature is truly amazing."));
        video3.AddComment(new Comment("Emmanuel", "This is the best nature documentary I've ever seen."));
        video3.AddComment(new Comment("Sunday", "I wish the video was longer, it's so interesting!"));
        video3.AddComment(new Comment("Peter", "The way you show the animals' behavior is so captivating."));

        // list of videos
        var videos = new List<Video> { video1, video2, video3 };

        // display information for each video
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine(new string('-', 50) + "\n");
        }
    }
}
