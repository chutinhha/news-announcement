using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace CSC.CSCNews
{
    [ToolboxItemAttribute(false)]
    public class CSCNews : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string homePath = @"~/_CONTROLTEMPLATES/CSC/CSCNews/CSCNewsUserControl.ascx";
        private const string addPath = @"~/_CONTROLTEMPLATES/CSC/CreateNews.ascx";
        protected override void CreateChildControls()
        {          
            Control controlHome = Page.LoadControl(homePath);
            Control controlAdd = Page.LoadControl(addPath);
            Controls.Add(controlHome);
            Controls.Add(controlAdd);
        }
    }
}
