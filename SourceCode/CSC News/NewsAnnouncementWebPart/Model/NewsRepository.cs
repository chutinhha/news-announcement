using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.IO;
using NewsAnnouncementWebPart.News_Utilities;
using Domain;

namespace NewsAnnouncementWebPart.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class NewsRepository : INewsRepository
    {
        private string _listName;
        private SPSite _spSite;
        private SPWeb _spWeb;
        private SPList _spList;

        public NewsRepository(string listName)
        {
            _listName = listName;
            _spSite = new SPSite(NewsString.RootSiteUrl);
            _spWeb = _spSite.RootWeb;
            _spList = _spWeb.GetList(_listName); 
        }

        public bool Add(Domain.News entity)
        {
//            SPSite site = new SPSite(NewsString.RootSiteUrl);
//#if DEBUG
//            Console.WriteLine("Site : " + NewsString.RootSiteUrl);   
//#endif
//            SPWeb spWeb = site.RootWeb;

            try
            {
                //SPList newsList = spWeb.GetList(NewsString.NewsListUrl);
                SPListItem itemToAdd = _spList.Items.Add();

                //-------------
                itemToAdd[NewsGuid.Title] = entity.Tittle;
                itemToAdd[NewsGuid.FromDate] = entity.FromDate;
                itemToAdd[NewsGuid.ToDate] = entity.ToDate;
                itemToAdd[NewsGuid.Content] = entity.Content;

                SPList pictureLibrary = _spWeb.GetList(NewsString.PiclibaryUrl);
                string picGuid = pictureLibrary.ID.ToString();

                string fileExtension = Path.GetExtension(entity.ImageUrl);
                string fileName = Guid.NewGuid().ToString() + fileExtension;

                //fileName = NewsUtil.GenerateValidImageName(fileName, pictureLibrary);

                pictureLibrary.RootFolder.Files.Add(fileName, entity.ImageByte);
                string image = NewsString.PiclibaryUrl + fileName;
                itemToAdd[NewsGuid.Image] = image;
                pictureLibrary.Update();
                itemToAdd.Update();
            }
            catch (Exception exception)
            {
                Logger.WriteLog(exception, "debug");
                return false;
                
            }

            
            return true;
        }

        public bool Delete(int id)
        {
            //SPSite site = new SPSite(NewsString.RootSiteUrl);
            //spWeb = site.RootWeb;
            //SPList newsList = spWeb.GetList(NewsString.NewsListUrl);
            SPQuery query = new SPQuery(_spList.DefaultView);
            query.ViewFields = "<Query><Where><Eq><FieldRef Name='ID' /><Value Type='Counter'>" + id + "</Value></Eq></Where></Query>";
            SPListItemCollection itemDeleteCollection = _spList.GetItems(query);
            if (itemDeleteCollection.Count > 0)
            {
                SPListItem itemDelete = itemDeleteCollection[0];
                SPList pictureLibrary = _spWeb.Lists[NewsString.PiclibaryUrl];
                //Delete relevant image
                SPFile existingImage = pictureLibrary.RootFolder.Files[NewsString.PiclibaryUrl + itemDelete[NewsGuid.Image]];
                existingImage.Delete();
                existingImage.Update();
                //Delete selected item
                itemDelete.Delete();
                itemDelete.Update();
            }
            return true;
        }

        public bool Update(Domain.News entity)
        {
            string fileName = "";
            int itemID = entity.Id;
            //SPSite site = new SPSite(NewsString.RootSiteUrl);
            //SPWeb spWeb = site.RootWeb;
            //-------------
            //SPList newsList = spWeb.GetList(NewsString.NewsListUrl);
                SPQuery query = new SPQuery(_spList.DefaultView);
                query.ViewFields = "<Query><Where><Eq><FieldRef Name='ID' /><Value Type='Counter'>" + itemID + "</Value></Eq></Where></Query>";
                SPListItemCollection itemUpdateCollection = _spList.GetItems(query);
                if (itemUpdateCollection.Count > 0)
                {
                    SPListItem itemUpdate = itemUpdateCollection[0];
                    itemUpdate[NewsGuid.Title] = entity.Tittle;
                    itemUpdate[NewsGuid.FromDate] = entity.FromDate;
                    itemUpdate[NewsGuid.ToDate] = entity.ToDate;
                    itemUpdate[NewsGuid.Content] = entity.Content;
                    if (entity.ImageUrl != null)
                    {
                        //Get picture library
                        SPList pictureLibrary = _spWeb.Lists[NewsString.PiclibaryUrl];
                        string fileExtension = Path.GetExtension(entity.ImageUrl);
                        fileName = Guid.NewGuid() + fileExtension;
                        //Delete existing image
                        SPFile existingImage = pictureLibrary.RootFolder.Files[NewsString.PiclibaryUrl + itemUpdate[NewsGuid.Image]];
                        existingImage.Delete();
                        existingImage.Update();

                        //Add new image
                        pictureLibrary.RootFolder.Files.Add(fileName, entity.ImageByte);
                        string image = NewsString.PiclibaryUrl + fileName;
                        itemUpdate[NewsGuid.Image] = image;
                        pictureLibrary.Update();
                    }
                    itemUpdate.Update();
                }
                return true;
            }

        public Domain.News Get(int id)
        {
            News entity = new News();

            SPQuery query = new SPQuery(_spList.DefaultView);
            StringBuilder queryString = new StringBuilder();
            queryString.Append("<Query><Where><Eq>");
            queryString.Append("<FieldRef Name='ID' />");
            queryString.Append("<Value Type='Counter'>");
            queryString.Append(id.ToString());
            queryString.Append("</Value>");
            queryString.Append("</Eq></Where></Query>");
            query.ViewFields = queryString.ToString();

            SPListItemCollection items = _spList.GetItems(query);

            if (items.Count > 0)
            {
#if DEBUG
                Console.WriteLine("Item is found");
                Console.WriteLine("Id: ", id);
#endif
                try
                {
                    SPListItem item = items[0];
                    entity.FromDate = (DateTime)item[NewsGuid.FromDate];
                    entity.ToDate = (DateTime)item[NewsGuid.ToDate];
                    entity.Tittle = (String)item[NewsGuid.Title];
                    StringBuilder content = new StringBuilder((String)item[NewsGuid.Content]);
                    entity.Content = content;
                    entity.ImageUrl = (String)item[NewsGuid.Image];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return entity;
        }

        public IEnumerable<News> Get()
        {
            SPQuery query = new SPQuery(_spList.DefaultView);
            StringBuilder queryString = new StringBuilder();
            List<News> listNews = new List<News>();
            News entity = new News();
            queryString.Append("<GetListItems><Query><OrderBy><FieldRef Name='NewsDateFrom' Ascending='True' />");
            queryString.Append("</OrderBy></Query><ViewFields>");
            queryString.Append("<FieldRef Name='ID' />");
            queryString.Append("<FieldRef Name='Title' />");
            queryString.Append("<FieldRef Name='NewsDateFrom' />");
            queryString.Append("<FieldRef Name='NewsDateTo' />");
            queryString.Append("<FieldRef Name='NewsImage' />");
            queryString.Append("<FieldRef Name='NewsShort' />");
            queryString.Append("</ViewFields><QueryOptions />");
            queryString.Append("</GetListItems>");

            query.ViewFields = queryString.ToString();

            SPListItemCollection items = _spList.GetItems(query);
#if DEBUG
            Console.WriteLine("Items count: {0}", items.Count);   
#endif
            foreach (SPListItem item in items)
            {
                try
                {                   
                    entity.FromDate = (DateTime)item[NewsGuid.FromDate];
                    entity.ToDate = (DateTime)item[NewsGuid.ToDate];
                    entity.Tittle = (String)item[NewsGuid.Title];
                    StringBuilder content = new StringBuilder((String)item[NewsGuid.Content]);
                    entity.Content = content;
                    entity.ImageUrl = (String)item[NewsGuid.Image];

                    listNews.Add(entity);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return listNews;
        }
    }
}
