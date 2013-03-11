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
            AddSampleDataToList(5);
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

        private void AddSampleDataToList(int count) {
            SPWeb spWeb = SPContext.Current.Web;
            spWeb.AllowUnsafeUpdates = true;
            SPList newsList = spWeb.Lists["CSC List News"];
            for (int i = 1; i < count; i++)
            {
                SPListItem itemToAdd = newsList.Items.Add();
                itemToAdd["Date from"] = DateTime.Now;
                itemToAdd["Date to"] = DateTime.Now;
                itemToAdd["News Full"] = "Full " + i;
                itemToAdd["News Short"] = "Short " + i;
                itemToAdd["News Image"] = "http://image"+i+".jpg";
                itemToAdd.Update();
            }
        }
    }
}
