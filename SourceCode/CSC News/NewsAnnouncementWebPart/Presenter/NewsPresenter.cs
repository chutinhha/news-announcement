using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsAnnouncementWebPart.View;
using NewsAnnouncementWebPart.Model;
using Domain;


namespace NewsAnnouncementWebPart.Presenter
{
    /// <summary>
    /// <createdBy>Created by : ThinhNP</createdBy>
    /// <createdDate>12/03/2013</createdDate>
    /// </summary>
    public class NewsPresenter
    {
        private INewsView _view;
        private INewsRepository _model;

        public NewsPresenter(INewsView view, INewsRepository model)
        {
            _view = view;
            _model = model;
        }

        public NewsPresenter()
        {
            // TODO: Complete member initialization
        }

        public void initNews()
        {
            _view.setListNew((List<News>)_model.Get());
        }
    }
}
