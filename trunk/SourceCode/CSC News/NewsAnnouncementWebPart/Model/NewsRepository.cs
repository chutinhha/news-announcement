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
        private string _listNewsUrl;
        private SPSite _spSite;
        private SPWeb _spWeb;
        private SPList _spList;
        private SPList _spPicture;

        public NewsRepository(string listNewsUrl)
        {
            _listNewsUrl = listNewsUrl;
            _spSite = new SPSite(NewsString.RootSiteUrl);
            _spWeb = _spSite.RootWeb;
            _spList = _spWeb.GetList(_listNewsUrl);
            _spPicture = _spWeb.GetList(NewsString.PiclibaryUrl);
        }

        public bool Add(Domain.News entity)
        {
            try
            {
                SPListItem itemToAdd = _spList.Items.Add();
                //-------------
                itemToAdd[NewsGuid.Title] = entity.Tittle;
                itemToAdd[NewsGuid.FromDate] = entity.FromDate;
                itemToAdd[NewsGuid.ToDate] = entity.ToDate;
                itemToAdd[NewsGuid.Content] = entity.Content;

                string picGuid = _spPicture.ID.ToString();
                string fileExtension = Path.GetExtension(entity.ImageUrl);
                string fileName = Guid.NewGuid().ToString() + fileExtension;

                _spPicture.RootFolder.Files.Add(fileName, entity.ImageByte);
                string image = NewsString.PiclibaryUrl + fileName;
                itemToAdd[NewsGuid.Image] = image;
                _spPicture.Update();
                itemToAdd.Update();
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
                /*
                Logger.WriteLog(exception, "debug");
                return false;*/
                LogEnginee.LogError("Add_News", exception.Message);
            }

            
            return true;
        }

        public bool Delete(int id)
        {
            SPQuery query = new SPQuery(_spList.DefaultView);
            query.ViewFields = "<Query><Where><Eq><FieldRef Name='ID' /><Value Type='Counter'>" + id + "</Value></Eq></Where></Query>";
            SPListItemCollection itemDeleteCollection = _spList.GetItems(query);
            if (itemDeleteCollection.Count > 0)
            {
                SPListItem itemDelete = itemDeleteCollection[0];
                //Delete relevant image
                SPFile existingImage = _spPicture.RootFolder.Files[NewsString.PiclibaryUrl + itemDelete[NewsGuid.Image]];
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
                        string fileExtension = Path.GetExtension(entity.ImageUrl);
                        fileName = Guid.NewGuid() + fileExtension;
                        //Delete existing image
                        SPFile existingImage = _spPicture.RootFolder.Files[NewsString.PiclibaryUrl + itemUpdate[NewsGuid.Image]];
                        existingImage.Delete();
                        existingImage.Update();

                        //Add new image
                        _spPicture.RootFolder.Files.Add(fileName, entity.ImageByte);
                        string image = NewsString.PiclibaryUrl + fileName;
                        itemUpdate[NewsGuid.Image] = image;
                        _spPicture.Update();
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
                    entity.Content = content.ToString();
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
            List<News> listNews;
            try
            {
                SPQuery query = new SPQuery();
                StringBuilder queryString = new StringBuilder();
                StringBuilder queryViewField = new StringBuilder();
                listNews = new List<News>();
               
                queryString.Append("<OrderBy><FieldRef Name='NewsDateFrom' Ascending='False' />");
                queryString.Append("</OrderBy>");

                query.Query = queryString.ToString();

                queryViewField.Append("<FieldRef Name='ID' Ascending='True'/>");
                queryViewField.Append("<FieldRef Name='Title' Ascending='True'/>");
                queryViewField.Append("<FieldRef Name='NewsDateFrom' Ascending='True'/>");
                queryViewField.Append("<FieldRef Name='NewsDateTo' Ascending='True'/>");
                queryViewField.Append("<FieldRef Name='NewsImage' Ascending='True'/>");
                queryViewField.Append("<FieldRef Name='NewsShort' Ascending='True'/>");

                query.ViewFields = queryViewField.ToString();
                query.RowLimit = 4;              
                SPListItemCollection items = _spList.GetItems(query);

#if DEBUG
                Console.WriteLine("Items count: {0}", items.Count);
#endif
                foreach (SPListItem item in items)
                {
                        News entity = new News();
                        //entity.FromDate = (DateTime)item[NewsGuid.FromDate];
                        entity.FromDate = (DateTime)item[NewsGuid.FromDate];
                        entity.ToDate = (DateTime)item[NewsGuid.ToDate];
                        entity.Tittle = (String)item[NewsGuid.Title];
                        StringBuilder content = new StringBuilder((String)item[NewsGuid.Content]);
                        entity.Content = content.ToString();
                        String temp = (String)item[NewsGuid.Image];
                        String[] url = temp.Trim().Split(',');

                        if (url.Count() > 0)
                        {
                            entity.ImageUrl = url[0]; 
                        }

                        listNews.Add(entity);
                  
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }


            return listNews;
        }
    }
}
