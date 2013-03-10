using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.ComponentModel;
using System.Text;
using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;
namespace SampleVisualWebPart.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {
        public VisualWebPart1UserControl()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);          

        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGetList_Click(object sender, EventArgs e)
        {
            StringBuilder queryString = new StringBuilder();
            queryString.Append("<FieldRef Name='ID'/>");
            queryString.Append("<FieldRef Name='Title'/>");
            queryString.Append("<FieldRef Name='Content'/>");
            queryString.Append("<FieldRef Name='Created_x0020_Date0' />");
            queryString.Append("<FieldRef Name='Expired_x0020_Date' />");

            SPWeb web = SPContext.Current.Web;
            SPList newList = web.Lists.TryGetList("NewsAnnouncementList");
               
            SPQuery query = new SPQuery();
            query.ViewFields = queryString.ToString();
            SPListItemCollection item = newList.GetItems(query);
            GridView1.DataSource = item.GetDataTable();
            GridView1.DataBind();
            
        }
    }
}
