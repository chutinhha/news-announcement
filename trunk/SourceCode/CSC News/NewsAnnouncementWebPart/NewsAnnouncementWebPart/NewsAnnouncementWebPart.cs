using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using NewsAnnouncementWebPart.View;

namespace NewsAnnouncementWebPart.NewsAnnouncementWebPart
{
    [ToolboxItemAttribute(false)]
    public class NewsAnnouncementWebPart : WebPart, INewsView
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/NewsAnnouncementWebPart/NewsAnnouncementWebPart/NewsAnnouncementWebPartUserControl.ascx";

        protected override void CreateChildControls()
        {
            Control control = Page.LoadControl(_ascxPath);
            if (control != null) {
                ((NewsAnnouncementWebPartUserControl)control).WebPart = this;
            }
            Controls.Add(control);
        }

        [WebBrowsable(true),

        Category("Configuration"),

        Personalizable(PersonalizationScope.Shared),

        WebDisplayName("Friendly Display Name"),

        WebDescription("Values: Whatever value you need")]

        public string PropertyValue { get; set; }
    }
}
