using BlogApp.Domain;
using BlogApp.Repositories;
using BlogApp.Services;
using NSubstitute;
using Xunit;

namespace BlogApp.UnitTests.Services
{
    public class PostServiceTests
    {
        #region Consts

        private const string Title = "title";

        private const string Content = "content";

        #endregion

        private static PostService CreateNewPostService(IPostRepository iPostRepository)
        {
            var postService = new PostService(iPostRepository);
            return postService;
        }


        [Fact]
        public void TitleAndContentAreValid_Called_ReturnCreatedPost()
        {
            // Arrange
            const string title = "Testes unitários com NSubstitute e .NET Core";
            const string content = "Lorem ipsum dolor sit amet, consectetur adipiscing.";
            var post = new Post(title, content);


            IPostRepository postRepositorySubstitute = Substitute.For<IPostRepository>(); // Criando um substituto

            postRepositorySubstitute.Add(title, content).Returns(post); // Definindo o comportamento do método Add

            var postService = new PostService(postRepositorySubstitute);

            // Act
            var createdPost = postService.Create(title, content);

            // Assert
            Assert.NotNull(createdPost);
            postRepositorySubstitute.Received().Add(title, content); // verificando se o método Add foi chamada com os parâmetros passados
            //testIPostRepository.Received(1).Add(myTitle, myContent);//My - Aqui eu estou verificando se o metodo Add foi chamado uma unica vez com estes parametros

            Assert.Equal(title, createdPost.Title);

            Assert.Equal(content, createdPost.Content);
        }


        [Fact(DisplayName = "Ensure that the PostService constructor can be instantiate")]
        private void Ensure_that_the_PostService_constructor_can_be_instantiate()
        {
            //Arrange

            var iPostRepository = Substitute.For<IPostRepository>();

            var postService = CreateNewPostService(iPostRepository);

            //Act

            //Assert
            Assert.NotNull(postService);


        }


        [Fact(DisplayName = "Ensure that the Create method returns a Post")]
        private void Ensure_that_the_create_method_returns_a_Post()
        {
            //Arrange
            var post = new Post(Title, Content);


            var iPostRepository = Substitute.For<IPostRepository>();
            iPostRepository.Add(Title, Content).Returns(post);

            var iPostService = Substitute.For<IPostService>();

            var postService = CreateNewPostService(iPostRepository);


            //Act
            iPostService.Create(Title, Content);

            //Assert
            Assert.NotNull(postService);

            //iPostRepository.Received().Add(Title, Content);
            iPostRepository.Received(1).Add(Title, Content);

            Assert.Equal(Title, post.Title);

            Assert.Equal(Content, post.Content);


        }
    }
}
