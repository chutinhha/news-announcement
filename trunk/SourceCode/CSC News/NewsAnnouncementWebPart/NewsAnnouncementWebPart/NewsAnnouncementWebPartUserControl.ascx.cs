using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using NewsAnnouncementWebPart.News_Utilities;
using NewsAnnouncementWebPart.Presenter;
using System.Web.UI.HtmlControls;

namespace NewsAnnouncementWebPart.NewsAnnouncementWebPart
{
    public partial class NewsAnnouncementWebPartUserControl : UserControl
    {
        public NewsAnnouncementWebPart webPart { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);            

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (NewsUtil.IsContribute() == false) {
                linkAddNews.Visible = false;
                linkAddNews.Dispose();
            }            
        }
    }
}
