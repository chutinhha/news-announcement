using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NewsAnnouncementWebPart.Model;
using Domain;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.IO;
using NewsAnnouncementWebPart.News_Utilities;

namespace NewsAnnouncementWebPart.ControlTemplates.CSCV.GROUP1.NewsAnnouncement
{
    public partial class CreateNewsControl : UserControl
    {
        News entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Rediect to home page if the current user doesn't have contribute permission
            if (NewsUtil.IsContribute() == false) {
                Response.Redirect(NewsString.RootSiteUrl);
            }
        }
        
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            NewsRepository repo = new NewsRepository(NewsString.NewsListURL);
            InitNews();
            repo.Add(entity);
        }

        protected void InitNews()
        {
            entity = new News();
            entity.Tittle = txtTitle.Text;
            entity.FromDate = txtFrom.SelectedDate;
            entity.ToDate = txtTo.SelectedDate;
            entity.Content = new StringBuilder(txtContent.Text);
            entity.ImageByte = txtImage.FileBytes;
            entity.ImageUrl = txtImage.FileName;
        }
    }
}
