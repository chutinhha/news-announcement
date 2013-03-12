using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace NewsAnnouncementWebPart.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class NewsRepository : INewsRepository
    {
        private string _listName;
        private SPWeb _web;

        public NewsRepository(string listName)
        {
            _listName = listName;
        }

        public bool Add(Domain.News entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Domain.News entity)
        {
            throw new NotImplementedException();
        }

        public Domain.News Get(int id)
        {
            throw new NotImplementedException();
        }

        public Microsoft.SharePoint.SPList Get()
        {
            throw new NotImplementedException();
        }
    }
}
