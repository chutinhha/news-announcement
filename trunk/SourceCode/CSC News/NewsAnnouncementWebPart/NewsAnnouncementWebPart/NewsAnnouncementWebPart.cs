using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using NewsAnnouncementWebPart.View;
using NewsAnnouncementWebPart.News_Utilities;
using Domain;
using System.Collections.Generic;
using NewsAnnouncementWebPart.Presenter;
using NewsAnnouncementWebPart.Model;

namespace NewsAnnouncementWebPart.NewsAnnouncementWebPart
{
    [ToolboxItemAttribute(false)]
    public class NewsAnnouncementWebPart : WebPart, INewsView
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/NewsAnnouncementWebPart/NewsAnnouncementWebPart/NewsAnnouncementWebPartUserControl.ascx";
        private NewsPresenter _presenter;
        private INewsRepository _model;
        private List<News> _listNews;
        public NewsAnnouncementWebPart()
        {
            
        }
        protected override void CreateChildControls()
        {
            _model = new NewsRepository(NewsString.NewsListURL);
            _presenter = new NewsPresenter(this, _model);
            _presenter.initNews();

            CssRegistration.Register("/_layouts/Css/news.css");

            Control control = Page.LoadControl(_ascxPath);
            if (control != null) {
                ((NewsAnnouncementWebPartUserControl)control).webPart = this;
                //DataGrid gridView = (DataGrid)control.FindControl("newsDataGrid");
                //gridView.DataSource = _listNews;
                //gridView.DataBind();
                NewsUtil.WebPart = this;
                this.PropertyValue = NewsString.GroupContribute;

                //Find repeater
                object oRepeater = control.FindControl("repeater");
                if (oRepeater != null)
                {
                    Repeater repeater = (Repeater)oRepeater;
                    setDataSourceToRepeater(repeater);
                }
            }
            Controls.Add(control);
        }

        [WebBrowsable(true),

        Category("Configuration"),

        Personalizable(PersonalizationScope.Shared),

        WebDisplayName("WebPart User Group"),

        WebDescription("Input webpart administrative group")]

        public string PropertyValue { get; set; }

        public List<News> listNews { get; set; }

        public void setListNew(List<News> newsList)
        {
            _listNews = newsList;
        }

        private void setDataSourceToRepeater(Repeater repeater)
        {
            repeater.DataSource = _listNews;
            repeater.DataBind();
        }

    }
}
