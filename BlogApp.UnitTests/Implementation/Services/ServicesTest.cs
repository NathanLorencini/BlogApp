using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Implementation.Repositories;
using BlogApp.Sites;
using NSubstitute;
using Xunit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BlogApp.UnitTests.Implementation.Services
{
    public class ServicesTest
    {
        private static readonly IRepository Repository = Substitute.For<IRepository>();

        private static readonly BlogApp.Implementation.Services.Services SiteService = new(Repository);

        private static readonly Site Site = new(1, "Description");


        [Fact(DisplayName = "Ensure that the DeleteSite method delete a site")]
        public void Ensure_that_the_DeleteSite_method_delete_a_site()
        {
            // Arrange
            var repository = Repository;
            var siteService = SiteService;
            var site = Site;

            repository.GetById(site.SiteId).Returns(site);


            // Act
            siteService.DeleteSite(site);

            // Assert
            repository.Received(1).Delete(Arg.Is<int>(id => id == site.SiteId));

            var deletedSiteId = Arg.Is<int>(id => id == site.SiteId);

            repository.Received(1).Delete(deletedSiteId);


            Assert.Equal(deletedSiteId, site.SiteId);
        }


        [Fact(DisplayName = "Ensure that the AddSite method add a site")]
        public void Ensure_that_the_AddSite_method_add_a_site()
        {
            // Arrange
            var repository = Repository;
            var siteService = SiteService;
            Site site = Site;


            // Act
            siteService.AddSite(site);

            // Assert
            repository.Received(1).Add(Arg.Any<Site>());
        }



        [Fact(DisplayName = "Ensure that the UpdateSite method updates a site")]
        public void Ensure_that_the_UpdateSite_method_updates_a_site()
        {
            // Arrange
            var repository = Repository;
            var siteService = SiteService;

            var site = Site;
            var updateSite = new Site(1, "UpdateSite");


            repository.Add(Arg.Any<Site>()).Returns(x =>
            {
                var newSite = x.Arg<Site>();

                var add = new Site(newSite.SiteId, newSite.Description);

                return add;
            });


            siteService.AddSite(site);


            // Act
            siteService.UpdateSite(updateSite);

            // Assert
            repository.Received(1).Add(Arg.Any<Site>());

            repository.Received(1).Update(Arg.Any<Site>());

            //Assert.Equal(updateSite.Description, site.Description);
        }


        [Fact(DisplayName = "Ensure that the GetBySiteId method get by site id")]
        public void Ensure_that_the_GetBySiteId_method_get_by_site_id()
        {
            // Arrange
            var repository = Repository;
            var siteService = SiteService;
            var site = Site;

            repository.GetById(Arg.Any<int>()).Returns(site);

            // Act
            siteService.GetBySiteId(site.SiteId);

            // Assert
            repository.Received().GetById(Arg.Any<int>());
        }


        [Fact(DisplayName = "Ensure that the GetAll method get all")]
        public void Ensure_that_the_GetAll_method_get_all_sites()
        {
            // Arrange
            var repository = Repository;
            var siteService = SiteService;
            var site = Site;


            var configGetAll = repository.GetAll().Returns(new List<Site>
            {
                new(1, "site"),
                new(2, "site2"),
                new(3, "site3")
            });


            // Act
            var getSites = siteService.GetAll();

            // Assert
            repository.Received().GetAll();

            Assert.Equal(expected: 3, getSites.Count);

            Assert.Equal(1, getSites[0].SiteId);
            Assert.Equal("site", getSites[0].Description);

            Assert.Equal(2, getSites[1].SiteId);
            Assert.Equal("site2", getSites[1].Description);

            Assert.Equal(3, getSites[2].SiteId);
            Assert.Equal("site3", getSites[2].Description);
        }

    }
}
