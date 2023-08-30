using BlogApp.Domain;

namespace BlogApp.Services
{
    public interface IPostService
    {
        Post Create(string title, string content);
    }
}
