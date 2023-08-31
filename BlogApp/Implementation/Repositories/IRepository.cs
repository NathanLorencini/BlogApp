using System.Collections.Generic;
using BlogApp.Sites;

namespace BlogApp.Implementation.Repositories
{
    public interface IRepository
    {
        Site GetById(int id);

        List<Site> GetAll();
        
        int Add(Site sites);
        
        Site Update(Site entity);
        
        void Delete(int id);
    }
}
