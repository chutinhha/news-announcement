using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using NewsAnnouncementWebPart.News_Utilities;

namespace NewsAnnouncementWebPart.NewsAnnouncementWebPart
{
    public partial class NewsAnnouncementWebPartUserControl : UserControl
    {
        public NewsAnnouncementWebPart webPart { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (NewsUtil.IsContribute() == false) {
                linkAddNews.Visible = false;
                linkAddNews.Dispose();
            }
        }
    }
}
