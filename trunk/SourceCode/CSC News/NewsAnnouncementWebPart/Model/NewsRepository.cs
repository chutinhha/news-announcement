using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.IO;
using NewsAnnouncementWebPart.News_Utilities;

namespace NewsAnnouncementWebPart.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class NewsRepository : INewsRepository
    {
        private string _listName;
        private SPWeb spWeb;

        public NewsRepository(string listName)
        {
            _listName = listName;
        }

        public bool Add(Domain.News entity)
        {
            SPSite site = new SPSite(NewsString.rootSiteURL);
            SPWeb spWeb = site.RootWeb;
            SPList newsList = spWeb.GetList(NewsString._newsListURL);
            SPListItem itemToAdd = newsList.Items.Add();

            //-------------
            itemToAdd[NewsGuid.Title] = entity.Tittle;
            itemToAdd[NewsGuid.FromDate] = entity.FromDate;
            itemToAdd[NewsGuid.ToDate] = entity.ToDate;
            itemToAdd[NewsGuid.Content] = entity.Content;

            SPList pictureLibrary = spWeb.GetList(NewsString._picLibraryURL);
            string picGuid = pictureLibrary.ID.ToString();

            string fileExtension = Path.GetExtension(entity.ImageUrl);
            string fileName = Guid.NewGuid().ToString() + fileExtension;
            
            //fileName = NewsUtil.GenerateValidImageName(fileName, pictureLibrary);

            pictureLibrary.RootFolder.Files.Add(fileName, entity.ImageByte);
            string image = NewsString._picLibraryURL + fileName;
            itemToAdd[NewsGuid.Image] = image;
            pictureLibrary.Update();
            itemToAdd.Update();
            return true;
        }

        public bool Delete(int id)
        {
            SPSite site = new SPSite(NewsString.rootSiteURL);
            spWeb = site.RootWeb;
            SPList newsList = spWeb.GetList(NewsString._newsListURL);
            SPQuery query = new SPQuery(newsList.DefaultView);
            query.ViewFields = "<Query><Where><Eq><FieldRef Name='ID' /><Value Type='Counter'>" + id + "</Value></Eq></Where></Query>";
            SPListItemCollection itemDeleteCollection = newsList.GetItems(query);
            if (itemDeleteCollection.Count > 0)
            {
                SPListItem itemDelete = itemDeleteCollection[0];
                SPList pictureLibrary = spWeb.Lists[NewsString._picLibraryURL];
                //Delete relevant image
                SPFile existingImage = pictureLibrary.RootFolder.Files[NewsString._picLibraryURL + itemDelete[NewsGuid.Image]];
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
            SPSite site = new SPSite(NewsString.rootSiteURL);
            SPWeb spWeb = site.RootWeb;
            //-------------
            SPList newsList = spWeb.GetList(NewsString._newsListURL);
                SPQuery query = new SPQuery(newsList.DefaultView);
                query.ViewFields = "<Query><Where><Eq><FieldRef Name='ID' /><Value Type='Counter'>" + itemID + "</Value></Eq></Where></Query>";
                SPListItemCollection itemUpdateCollection = newsList.GetItems(query);
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
                        SPList pictureLibrary = spWeb.Lists[NewsString._picLibraryURL];
                        string fileExtension = Path.GetExtension(entity.ImageUrl);
                        fileName = Guid.NewGuid() + fileExtension;
                        //Delete existing image
                        SPFile existingImage = pictureLibrary.RootFolder.Files[NewsString._picLibraryURL + itemUpdate[NewsGuid.Image]];
                        existingImage.Delete();
                        existingImage.Update();

                        //Add new image
                        pictureLibrary.RootFolder.Files.Add(fileName, entity.ImageByte);
                        string image = NewsString._picLibraryURL + fileName;
                        itemUpdate[NewsGuid.Image] = image;
                        pictureLibrary.Update();
                    }
                    itemUpdate.Update();
                }
                return true;
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
