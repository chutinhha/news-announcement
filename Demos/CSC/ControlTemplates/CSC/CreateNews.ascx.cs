using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web;

namespace CSC.ControlTemplates.CSC
{
    public partial class CreateNews : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentURL = HttpContext.Current.Request.Url.AbsolutePath;
            string property = Request.QueryString["action"];
            if (property == null)
            {
                this.Visible = false;
            }
            else if(!property.Equals("Add")){
                this.Visible = false;
            }
        }
    }
}
