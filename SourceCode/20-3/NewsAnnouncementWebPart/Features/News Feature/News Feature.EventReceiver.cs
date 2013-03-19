using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using NewsAnnouncementWebPart.News_Utilities;

namespace NewsAnnouncementWebPart.Features.News_Feature
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("7fb246f0-c09e-4818-8740-8421e3a8dd90")]
    public class News_FeatureEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite site = new SPSite(NewsString.RootSiteUrl);
            SPWeb web = site.RootWeb;
            SPList list = web.GetList(NewsString.NewsListURL);
            list.BreakRoleInheritance(true);
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised after a feature has been installed.

        public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        {
            SPSite site = new SPSite(NewsString.RootSiteUrl);
            SPWeb spWeb = site.RootWeb;
            spWeb.AllowUnsafeUpdates = true;
            SPGroupCollection groupCollection = spWeb.Groups;
            string[] arr = new string[2];
            arr[0] = "HR";
            arr[1] = "Admin";

            foreach (string loop in arr)
            {
                if (NewsUtil.IsGroupAlreadyExist(spWeb, loop) == false)
                {
                    spWeb.SiteGroups.Add(loop, spWeb.CurrentUser, spWeb.CurrentUser, string.Empty);
                    SPGroup group = spWeb.SiteGroups[loop];
                    SPRoleDefinition roleDefinition = spWeb.RoleDefinitions.GetByType(SPRoleType.Contributor);
                    SPRoleAssignment roleAssigment = new SPRoleAssignment(group);
                    roleAssigment.RoleDefinitionBindings.Add(roleDefinition);
                    spWeb.RoleAssignments.Add(roleAssigment);
                    spWeb.Update();
                }
            }
        }

        
        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
