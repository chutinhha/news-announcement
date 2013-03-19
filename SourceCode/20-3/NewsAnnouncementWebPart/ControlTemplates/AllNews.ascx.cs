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
            else
            {
                noData.InnerText = "Oops! There is no data to display!!!";
            }

            if (NewsUtil.IsContribute() == false)
            {
                btnAdd.Visible = false;
                HideControls();
            }
        }

        protected void DeleteItem(Object sender, CommandEventArgs e)
        {
            NewsRepository repo = new NewsRepository(NewsString.NewsListURL);
            repo.Delete(int.Parse(e.CommandArgument.ToString()));
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
            if (btnAdd.Visible == false)
            {
                HideControls();
            }
        }

        private void HideControls()
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRowCollection gridRowCol = GridView1.Rows;
                HyperLink update = (HyperLink)gridRowCol[i].FindControl("btnUpdate");
                LinkButton delete = (LinkButton)gridRowCol[i].FindControl("btnDelete");
                update.Visible = false;
                delete.Visible = false;
            }
        }
    }
}
