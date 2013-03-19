using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using NewsAnnouncementWebPart.View;
using NewsAnnouncementWebPart.News_Utilities;

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
                ((NewsAnnouncementWebPartUserControl)control).webPart = this;
                NewsUtil.WebPart = this;
                this.PropertyValue = NewsString.GroupContribute;
            }
            Controls.Add(control); 
            this.Title = "CSC News";
        }

        [WebBrowsable(true),

        Category("Configuration"),

        Personalizable(PersonalizationScope.Shared),

        WebDisplayName("WebPart User Group"),

        WebDescription("Input webpart administrative group")]

        public string PropertyValue { get; set; }
    }
}
