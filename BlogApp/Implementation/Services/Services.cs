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

        public void AddSite(Site site)
        {
            _repository.Add(site);
        }

        public Site GetBySiteId(int siteId)
        {
            return _repository.GetById(siteId);
        }

        public void UpdateSite(Site site)
        {
            _repository.Update(site);
        }

        public void DeleteSite(Site site)
        {
            _repository.Delete(site.SiteId);
        }
    }
}
