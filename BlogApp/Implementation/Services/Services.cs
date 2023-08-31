using System.Collections.Generic;
using BlogApp.Implementation.Repositories;
using BlogApp.Sites;

namespace BlogApp.Implementation.Services
{
    public class Services
    {
        private readonly IRepository _repository;

        public Services(IRepository repository)
        {
            _repository = repository;
        }

        public int AddSite(Site site)
        {
            _repository.Add(site);

            return GetAll().Count;
        }

        public List<Site> GetAll()
        {
            return _repository.GetAll();
        }

        public Site GetBySiteId(int siteId)
        {
            return _repository.GetById(siteId);
        }

        public Site UpdateSite(Site site)
        {
            _repository.Update(site);
            return site;
        }

        public void DeleteSite(Site site)
        {
            _repository.Delete(site.SiteId);
        }
    }
}
