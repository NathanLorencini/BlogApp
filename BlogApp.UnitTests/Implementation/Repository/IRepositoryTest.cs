//using System.Collections.Generic;
//using BlogApp.Implementation.Repositories;
//using BlogApp.Sites;
//using NSubstitute;
//using Xunit;

//namespace BlogApp.UnitTests.Implementation.Repository
//{
//    public class IRepositoryTest
//    {
//        #region Consts

//        private const int Id = 1;

//        private const string Description = "description";


//        private const int Id2 = 2;

//        private const string Description2 = "description2";


//        private const int Id3 = 3;

//        private const string Description3 = "description3";

//        #endregion

//        [Fact(DisplayName = "Ensure that the Add method add a site")]
//        private void Ensure_that_the_Add_method_add_a_site()
//        {
//            //Arrange
//            var iRepository = Substitute.For<IRepository>();

//            var site = new Site(1, "site1");
//            //var site2 = new Site(2, "site2"); 
//            //var site3 = new Site(3, "site3");


//            ////Act
//            //iRepository.Add(Arg.Any<Site>()).Returns(x =>
//            //{
//            //    var newSite = x.Arg<Site>();

//            //    var add = new Site(newSite.SiteId, newSite.Description);

//            //    return add;
//            //});

//            var result = iRepository.Add(site);
//            //var result2 = iRepository.Add(site2);
//            //var result3= iRepository.Add(site3);

//            //iRepository.GetAllSites().Returns(new List<Site>
//            //{
//            //    result,
//            //    result2,
//            //    result3,
//            //});


//            //var count = iRepository.GetAllSites().Count;

//            //Assert
//            iRepository.Received(1).Add(Arg.Any<Site>());

//            //var value = iRepository.Received(1).Add(Arg.Is<Site>(s => s.SiteId == site.SiteId));
//        }


//        [Fact(DisplayName = "Ensure that the GetById method get by id")]
//        private void Ensure_that_GetById_method_get_by_id()
//        {
//            //Arrange
//            Site site = new Site(Id, Description);

//            var iRepository = Substitute.For<IRepository>();

//            iRepository.Add(site);


//            //Act
//            var result = iRepository.GetById(Id);

//            //Assert
//            Assert.Equal(Id, result.SiteId);
//            Assert.Equal(Description, result.Description);

//        }


//        [Fact]
//        private void TestGetAll()
//        {

//            //Arrange
//            var iRepository = Substitute.For<IRepository>();

//            iRepository.GetAllSites().Returns(new List<Site>
//                {
//                    new(1, "site1"),
//                    new(2, "site2"),
//                    new(3, "site3")
//                });


//            //Act
//            var result = iRepository.GetAllSites();


//            //Assert
//            iRepository.Received(1).GetAllSites();
//            Assert.Equal(3, result.Count);
//            Assert.Equal(1, result[0].SiteId);
//            Assert.Equal(2, result[1].SiteId);
//            Assert.Equal(3, result[2].SiteId);

//        }

//        //ChatGPT
//        [Fact]
//        public void Test_UpdateGPT()
//        {
//            // Arrange
//            var iRepository = Substitute.For<IRepository>();

//            var sites = new List<Site>
//            {
//                new(1, "site1"),
//                new(2, "site2"),
//                new(3, "site3")
//            };


//            var update = new Site(2, "testUpdate");

//            iRepository.Update(Arg.Any<Site>()).Returns(x =>
//            {
//                var updateSite = x.Arg<Site>();

//                var siteToUpdate = sites.Find(site => site.SiteId == updateSite.SiteId);
//                if (siteToUpdate != null)
//                {
//                    siteToUpdate.UpdateSite(updateSite);
//                }

//                return updateSite;
//            });


//            // Act
//            var result = iRepository.Update(update);


//            // Assert
//            iRepository.Received(1).Update(Arg.Any<Site>());

//            Assert.Equal(update.SiteId, result.SiteId);
//            Assert.Equal(update.Description, sites[1].Description);

//        }


//        [Fact(DisplayName = "Ensure tha the Delete method delete a site")]
//        public void Ensure_tha_the_Delete_method_delete_a_site()
//        {
//            // Arrange
//            var site = new Site(1, "site1");

//            var iRepository = Substitute.For<IRepository>();

//            //Configuring Add method
//            iRepository.Add(Arg.Any<Site>()).Returns(x =>
//            {
//                var newSite = x.Arg<Site>();

//                var add = new Site(newSite.SiteId, newSite.Description);

//                return add;
//            });

//            iRepository.Add(site);

//            var getSite = iRepository.GetById(Arg.Any<int>()).Returns(site);

//            // Act
//            iRepository.Delete(1);

//            var getSiteDeleted = iRepository.GetById(Arg.Any<int>()).Returns(site);

//            // Assert
//            iRepository.Received(1).Delete(site.SiteId);
//            iRepository.DidNotReceive().Delete(2);
//        }
//    }
//}
