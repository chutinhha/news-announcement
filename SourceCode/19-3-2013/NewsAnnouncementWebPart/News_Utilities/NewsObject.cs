using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace NewsAnnouncementWebPart.News_Utilities
{
    public static class NewsObject
    {
        public static SPSite spSite = new SPSite(NewsString.RootSiteUrl);
        public static SPWeb spWeb = spSite.RootWeb;
        public static SPList spList = spWeb.GetList(NewsString.NewsListURL);
    }
}
