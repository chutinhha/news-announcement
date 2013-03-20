using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace NewsAnnouncementWebPart.View
{
    public interface INewsView
    {
        void setListNew(List<News> newsList);
    }
}
