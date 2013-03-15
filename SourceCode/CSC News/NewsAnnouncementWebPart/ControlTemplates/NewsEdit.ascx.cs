using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NewsAnnouncementWebPart.Model;
using Domain;
using System.Text;

namespace NewsAnnouncementWebPart.ControlTemplates
{
    public partial class NewsEdit : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            News news = new News();
            news.Id = int.Parse(Request.QueryString["itemID"]);
            news.ImageByte = txtImage.FileBytes;
            news.FromDate = txtFrom.SelectedDate;
            news.ToDate = txtTo.SelectedDate;
            news.Tittle = txtTitle.Text;
            news.ImageUrl = txtImage.FileName;
            StringBuilder builder = new StringBuilder(txtShort.Text);
            news.Content =builder;
            NewsRepository model = new NewsRepository("list");
            model.Update(news);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            NewsRepository model = new NewsRepository("list");
            int id = int.Parse(Request.QueryString["itemID"]);
            model.Delete(id);
        }
    }
}
