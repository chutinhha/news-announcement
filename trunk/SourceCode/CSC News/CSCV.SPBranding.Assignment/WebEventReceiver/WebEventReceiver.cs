using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace CSCV.SPBranding.Assignment
{
    /// <summary>
    /// Web Events
    /// </summary>
    public class WebEventReceiver : SPWebEventReceiver
    {
        /// <summary>
        /// A site was provisioned.
        /// </summary>
        public override void WebProvisioned(SPWebEventProperties properties)
        {
            base.WebProvisioned(properties);

            SPWeb site = properties.Web;
            SPWeb rootSite = site.Site.RootWeb;
            site.MasterUrl = rootSite.MasterUrl;
            site.CustomMasterUrl = rootSite.CustomMasterUrl;
            site.Update();
        }


    }
}
