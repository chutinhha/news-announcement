using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.Administration;

namespace NewsAnnouncementWebPart.News_Utilities
{
    public static class NewsString
    {
        public const string projectName = "CSCV.News";
        public static string _picLibraryURL = "http://" + SPServer.Local.Address.ToString() + "/Lists/NewsPicture/";
        public static string _newsListURL = "http://" + SPServer.Local.Address.ToString() + "/Lists/CSC-News-List";
        public static string rootSiteURL = "http://" + SPServer.Local.Address.ToString();
    }
}
