using BlogApp.Domain;
using BlogApp.Repositories;

namespace BlogApp.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Post Create(string title, string content)
        {
            var createdPost = _postRepository.Add(title, content);

            return createdPost;
        }
    }
}
