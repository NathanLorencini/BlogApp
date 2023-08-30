using System;

namespace BlogApp.Domain
{
    public class Post
    {
        public Post(string title, string content)
        {
            Title = title;
            Content = content;
            CreatedAt = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
