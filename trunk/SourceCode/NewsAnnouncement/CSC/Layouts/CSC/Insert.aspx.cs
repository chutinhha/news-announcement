using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.IO;
using Microsoft.SharePoint.Administration;
using CSC.ControlTemplates1.CSC;
using System.Web.UI;

namespace CSC.Layouts.CSC
{
    public partial class Insert : LayoutsPageBase
    {
        private string previousURL;
        private string fileName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer == null)
            {
                Response.Redirect("/_layouts/CSCNewsError.aspx");
            }
        }

        protected void InsertNews(object sender, EventArgs e)
        {
    
        }
    }
}
