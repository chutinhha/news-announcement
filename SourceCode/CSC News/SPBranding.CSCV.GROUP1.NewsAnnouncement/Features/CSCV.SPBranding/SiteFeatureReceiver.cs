using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;

namespace SPBranding.CSCV.GROUP1.NewsAnnouncement
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("54c0f8f8-d3fd-4998-8963-245781964974")]
    public class SiteFeatureReceiver : SPFeatureReceiver
    {
        private const string NAME_DEPLOYED_MASTER_PAGE = "cscv.starter.master";
        private const string NAME_V4_MASTER_PAGE = "v4.master";


        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite siteCollection = properties.Feature.Parent as SPSite;
            SetMasterPage(siteCollection, NAME_DEPLOYED_MASTER_PAGE);
        }


        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPSite siteCollection = properties.Feature.Parent as SPSite;
            SetMasterPage(siteCollection, NAME_V4_MASTER_PAGE);
        }

        private void SetMasterPage(SPSite siteCollection, string masterPageName)
        {
            SPList masterPage = siteCollection.GetCatalog(SPListTemplateType.MasterPageCatalog);
            string masterUrl = SPUrlUtility.CombineUrl(masterPage.RootFolder.ServerRelativeUrl, masterPageName);

            foreach (SPWeb site in siteCollection.AllWebs)
            {
                site.MasterUrl = masterUrl;
                site.CustomMasterUrl = masterUrl;
                site.Update();
            }
        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


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
