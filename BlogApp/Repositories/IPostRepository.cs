using BlogApp.Domain;

namespace BlogApp.Repositories
{
    public interface IPostRepository
    {
        Post Add(string title, string content);
    }
}
