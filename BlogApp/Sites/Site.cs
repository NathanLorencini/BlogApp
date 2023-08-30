using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Sites
{
    public class Site
    {
        public Site(int siteId, string description)
        {
            SiteId = siteId;
            Description = description;
        }

        public void UpdateSite(Site sites)
        {
            SiteId = sites.SiteId;
            Description = sites.Description;
        }

        public int SiteId{ get; private set; }
        public string Description { get; private set; }
    }
}
