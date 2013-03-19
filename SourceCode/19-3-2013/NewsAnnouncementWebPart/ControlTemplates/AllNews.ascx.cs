using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using NewsAnnouncementWebPart.News_Utilities;
using System.Data;
using System.Text;
using NewsAnnouncementWebPart.Model;

namespace NewsAnnouncementWebPart.ControlTemplates
{
    public partial class AllNews : UserControl
    {
        NewsRepository repo;
        protected void Page_Load(object sender, EventArgs e)
        {
            repo = new NewsRepository(NewsString.NewsListURL);
            if (repo.GetAllNews() != null)
            {
                GridView1.DataSource = repo.GetAllNews();
                GridView1.DataBind();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
    }
}
