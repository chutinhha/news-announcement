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
        public static NewsAnnouncementWebPart.NewsAnnouncementWebPart WebPart { get; set; }
        
        public static bool IsContribute() {
            bool flag = false;
            SPSite spSite = new SPSite(NewsString.RootSiteUrl);
            SPWeb spWeb = SPContext.Current.Web;

            SPList spList = spSite.RootWeb.GetList(NewsString.NewsListURL);
            SPRoleDefinitionBindingCollection roleDC = spList.AllRolesForCurrentUser;
            SPRoleDefinition roleCon = spWeb.RoleDefinitions.GetByType(SPRoleType.Contributor);
            SPRoleDefinition roleAdmin = spWeb.RoleDefinitions.GetByType(SPRoleType.Administrator);
            if(roleDC.Contains(roleCon)){
                flag = true;
            }else if(roleDC.Contains(roleAdmin)){
                flag = true;
            }
            return flag;
        }

        

        public static bool IsGroupAlreadyExist(SPWeb web, string groupName)
        {
            bool isExist = false;

            try
            {
                SPGroup group = web.SiteGroups[groupName];
                isExist = true;
            }
            catch (SPException)
            {
                isExist = false;
            }
            catch (Exception)
            {
                isExist = false;
            }
            return isExist;        
        }
    }
}
