using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace CSC.CSCNewsAnouncement
{
    public partial class CSCNewsAnouncementUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SPQuery query = new SPQuery();
            // Use this to prevent SPSite can not get current URL when being redirected from insert page
                using (SPWeb spWeb = SPContext.Current.Web)
                {
                    SPList newsList = spWeb.Lists["CSC List News"];
                    SPQuery spQuery = new SPQuery(newsList.DefaultView);
                    spQuery.ViewFields = "<FieldRef Name='NewsImage'/><FieldRef Name='NewsDateFrom'/><FieldRef Name='NewsDateTo'/><FieldRef Name='NewsTitle'/><FieldRef Name='NewsShort'/>";
                    SPListItemCollection allNews = newsList.GetItems(spQuery);
                    gridListNews.DataSource = allNews.GetDataTable();
                    gridListNews.DataBind();
                }
        }

        protected void linkAddNews_Click(object sender, EventArgs e)
        {
            //SPWeb web = SPContext.GetContext(;
            //web.Properties["CurrentWeb"] = web.Url;
            //linkAddNews.PostBackUrl = "~/_layouts/CSC/Insert.aspx";
            Response.Redirect("~/_layouts/CSC/Insert.aspx");
        }
    }
}
