using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.IO;
using Microsoft.SharePoint.Administration;

namespace CSC.ControlTemplates1.CSC
{
    public partial class NewsEditControl : UserControl
    {
        private string previousURL;
        private string fileName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer == null)
            {
                Response.Redirect("/_layouts/CSCNewsError.aspx");
            }
        }

        protected void InsertNews(object sender, EventArgs e)
        {
            SPQuery query = new SPQuery();
            using (SPWeb spWeb = SPContext.Current.Web)
            {
                SPList newsList = spWeb.Lists["CSC List News"];
                SPListItem itemToAdd = newsList.Items.Add();
                itemToAdd["Title"] = txtTitle.Text;
                itemToAdd["Date from"] = txtFrom.SelectedDate;
                itemToAdd["Date to"] = txtTo.SelectedDate;
                itemToAdd["News Short"] = txtShort.Text;

                SPList pictureLibrary = spWeb.Lists["CSC - News Picture"];
                string fileExtension = Path.GetExtension(txtImage.FileName);
                fileName = txtTitle.Text + fileExtension;
                /*
                SPQuery spQuery = new SPQuery(pictureLibrary.DefaultView);
                spQuery.ViewFields = "<Where><Eq><FieldRef Name='FileLeafRef' /><Value Type='File'>" + fileName + "</Value></Eq></Where>";
                SPListItemCollection items = pictureLibrary.GetItems(spQuery);
                string temp = fileName;
                int i = 1;
                while (items != null) {
                    fileName = temp + i;
                    i++;
                    items = pictureLibrary.GetItems(spQuery);
                }
                */
                pictureLibrary.RootFolder.Files.Add(fileName, txtImage.FileBytes);
                string image = "http://" + SPServer.Local.Address.ToString() + "/Lists/CSCNews-PictureLibrary/" + fileName;
                itemToAdd["News Image"] = image;
                pictureLibrary.Update();
                itemToAdd.Update();
            }

        }
    }
}
