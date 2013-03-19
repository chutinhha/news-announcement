using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using NewsAnnouncementWebPart.News_Utilities;
using NewsAnnouncementWebPart.Model;

namespace NewsAnnouncementWebPart.NewsAnnouncementWebPart
{
    public partial class NewsAnnouncementWebPartUserControl : UserControl
    {
        public NewsAnnouncementWebPart webPart { get; set; }
        NewsRepository repo;
        protected void Page_Load(object sender, EventArgs e)
        {
            repo = new NewsRepository(NewsString.NewsListURL);
            if (repo.GetNewsForWebpart() != null) {
                GridView1.DataSource = repo.GetNewsForWebpart();
            GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            NewsUtil.InsertSampleData();
        }
    }
}
