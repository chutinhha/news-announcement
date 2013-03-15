using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.IO;

namespace NewsAnnouncementWebPart.News_Utilities
{
    public static class NewsUtil
    {
        public static string GenerateValidImageName(string fileName, SPList pictureLibrary)
        {
            //Check if new image name validates
            int i = 0;
            string temp = fileName;
            string extention = Path.GetExtension(fileName);
            SPQuery query = new SPQuery(pictureLibrary.DefaultView);
            SPListItemCollection imageCollection;
            do
            {
                i++;
                query.ViewFields = "<Where><Eq><FieldRef Name='LinkFilename' /><Value Type='Computed'>" + fileName + "</Value></Eq></Where>";
                imageCollection = pictureLibrary.GetItems(query);
                if (imageCollection.Count > 0)
                {
                    fileName = temp;
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName) + " " + i;
                    fileName = fileNameWithoutExtension + extention;
                }
                else {
                    break;
                }
            } while (imageCollection.Count > 0);
            return fileName;
        }

        public static NewsAnnouncementWebPart.NewsAnnouncementWebPart WebPart { get; set; }
        
        public static bool IsContribute() { 
        SPSite spSite = new SPSite(NewsString.RootSiteUrl);
            SPWeb spWeb = spSite.RootWeb;
            SPUser currentUser = spWeb.CurrentUser;
            SPGroup group = spWeb.SiteGroups[NewsUtil.WebPart.PropertyValue];
            bool flag = false;
            foreach (SPGroup loop in currentUser.Groups) {
                if (loop.Name.Equals(group.Name)) {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
}
