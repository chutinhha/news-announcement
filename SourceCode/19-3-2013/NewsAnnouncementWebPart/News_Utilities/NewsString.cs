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
        public static string PiclibaryUrl = "http://" + SPServer.Local.Address.ToString() + "/Lists/NewsPicture/";
        public static string NewsListURL = "http://" + SPServer.Local.Address.ToString() + "/Lists/CSC-News-List";
        public static string RootSiteUrl = "http://" + SPServer.Local.Address.ToString();
        public static string GroupContribute = "HR";
        public static string paramID = "id";
    }
}
