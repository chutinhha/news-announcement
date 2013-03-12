using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.Web;
namespace CSC.CSCNews
{
    public partial class CSCNewsUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentURL = HttpContext.Current.Request.Url.AbsolutePath;
            linkAddNews.NavigateUrl = currentURL + "?action=Add";
            string property = Request.QueryString["action"];
            if (property == null)
            {
                SPQuery query = new SPQuery();
                using (SPWeb spWeb = SPContext.Current.Web)
                {
                    SPList newsList = spWeb.Lists["CSC List News"];
                    SPQuery spQuery = new SPQuery(newsList.DefaultView);
                    spQuery.ViewFields = "<FieldRef Name='NewsImage'/><FieldRef Name='NewsDateFrom'/><FieldRef Name='NewsDateTo'/><FieldRef Name='NewsTitle'/><FieldRef Name='NewsShort'/><FieldRef Name='NewsFull'/>";
                    SPListItemCollection allNews = newsList.GetItems(spQuery);
                    gridListNews.DataSource = allNews.GetDataTable();
                    gridListNews.DataBind();
                    /*spQuery.Query = "<Where><Eq><FieldRef Name='Title'/>"
                            + "<Value Type='Text'>"
                            + "MyTask"
                            + "</Value></Eq></Where>";
                    }      */
                }
            }
            else {
                this.Visible = false;
            }
        }

        private void Authentication()
        {

        }
    }
}
