using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();
        
        Video video1 = new Video("C# Tutorial", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Well explained!"));
        videos.Add(video1);
        
        Video video2 = new Video("Intro to OOP", "Jane Smith", 900);
        video2.AddComment(new Comment("David", "This was amazing!"));
        video2.AddComment(new Comment("Emma", "Really enjoyed this!"));
        video2.AddComment(new Comment("Frank", "Best OOP explanation."));
        videos.Add(video2);
        
        Video video3 = new Video("Advanced C#", "Robert Brown", 1200);
        video3.AddComment(new Comment("Grace", "I learned a lot!"));
        video3.AddComment(new Comment("Hank", "Super helpful, thanks!"));
        video3.AddComment(new Comment("Ivy", "More content like this, please!"));
        videos.Add(video3);
        
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
