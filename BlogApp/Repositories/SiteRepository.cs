using BlogApp.Sites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;

namespace BlogApp.Repositories
{
    public class SiteRepository
    {
        //public Task<Site> GetSiteById(Site site,int siteId)
        //{
        //    return Task.FromResult<>(site.GetType().GetProperty(nameof(Site.SiteId))?.SetValue(site,siteId));
        //}

        //public Task<Site> GetByDescription(Site site, string description)
        //{
        //    return Task.FromResult<>(site.GetType().GetProperty(nameof(Site.Description))?.SetValue(site, description));
        //}
    }
}
