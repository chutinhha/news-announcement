using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NewsAnnouncementWebPart.Model;
using NewsAnnouncementWebPart.News_Utilities;
using Domain;

namespace NewsAnnouncementWebPart.ControlTemplates
{
    public partial class ViewNews : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString[NewsString.paramID] != null)
            {
                NewsRepository news = new NewsRepository(NewsString.NewsListURL);
                int newsID = int.Parse(Request.QueryString[NewsString.paramID]);
                News entity = news.Get(newsID);
                newsTitle.InnerText = entity.Tittle;
                newsContent.InnerText = entity.Content.ToString();
                newsImage.Src = entity.ImageUrl;
            }
        }
    }
}
