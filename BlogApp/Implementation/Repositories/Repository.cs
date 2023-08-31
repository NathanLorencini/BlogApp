using System;
using System.Collections.Generic;
using System.Linq;
using BlogApp.Sites;

namespace BlogApp.Implementation.Repositories
{
    public class Repository : IRepository
    {
        public List<Site> _sites = new();

        public Site GetById(int id)
        {
            return _sites.FirstOrDefault(x => x.SiteId == id);
        }

        public List<Site> GetAll()
        {
            return _sites.ToList();
        }

        public Site Add(Site sites)
        {
            _sites.Add(sites);

            return sites;
        }

        public Site Update(Site sites)
        {
            var updateSite = GetById(sites.SiteId);

            if (updateSite != null)
            {
                updateSite.UpdateSite(sites);
            }

            return updateSite;
            //updateSite != null ? updateSite.UpdateSite(sites) : throw new Exception("Site not found.");

        }

        public void Delete(int id)
        {
            var removedSite = GetById(id);

            if (removedSite != null)
            {
                _sites.Remove(removedSite);
            }
        }
    }
}
