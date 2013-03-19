using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.IO;
using NewsAnnouncementWebPart.News_Utilities;
using Domain;
using System.Web.UI;
using System.Data;
using Microsoft.SharePoint.Utilities;

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
                
                if (entity.ImageByte.Length == 0)
                {
                    itemToAdd[NewsGuid.Image] = NewsString.RootSiteUrl + "/_layouts/CSC-Images/no-image-available.jpg";
                }
                else
                {
                    string picGuid = _spPicture.ID.ToString();
                    string fileExtension = Path.GetExtension(entity.ImageUrl);
                    string fileName = Guid.NewGuid().ToString() + fileExtension;
                    _spPicture.RootFolder.Files.Add(fileName, entity.ImageByte);
                    string image = NewsString.PiclibaryUrl + fileName;
                    itemToAdd[NewsGuid.Image] = image;
                    _spPicture.Update();
                }           
                itemToAdd.Update();
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
                /*
                Logger.WriteLog(exception, "debug");
                return false;               
            */}          
            return true;
        }

        public bool Delete(int id)
        {
            SPQuery query = new SPQuery(_spList.DefaultView);
            query.Query = "<FieldRef Name='NewsImage' /><Where><Eq><FieldRef Name='ID' /><Value Type='Counter'>" + id + "</Value></Eq></Where>";
            SPListItemCollection itemDeleteCollection = _spList.GetItems(query);
            if (itemDeleteCollection.Count > 0)
            {
                SPListItem itemDelete = itemDeleteCollection[0];
                //Delete relevant image
                SPFieldUrlValue imageUrl = new SPFieldUrlValue(itemDelete[NewsGuid.Image].ToString());
                string image = Path.GetFileName(imageUrl.Url.ToString());
                SPFile file = _spWeb.GetFile(string.Format("{0}/{1}", _spPicture.RootFolder.Url, image));
                if (file.Exists)
                {
                    SPFile existingImage = _spPicture.RootFolder.Files[NewsString.PiclibaryUrl + image];
                    existingImage.Delete();
                }
                //Delete selected item
                itemDelete.Delete();
            }
            return true;
        }

        public bool Update(Domain.News entity)
        {
            string fileName = "";
            int itemID = entity.Id;
                SPQuery query = new SPQuery(_spList.DefaultView);
                query.ViewFields = "<Where><Eq><FieldRef Name='ID' /><Value Type='Counter'>" + itemID + "</Value></Eq></Where>";
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

        public string title;

        public string GetTitle(int id) {
            News entity = new News();
            SPQuery query = new SPQuery(_spList.DefaultView);
            query.ViewFields = "<Where><Eq><FieldRef Name='ID' /><Value Type='Counter'>" + id + "</Value></Eq></Where>";
            SPListItemCollection itemUpdateCollection = _spList.GetItems(query);
            SPListItem itemUpdate = itemUpdateCollection[0];
            return itemUpdate.Title;
        }

        public News Get(int id)
        {
            News entity = new News();
            SPQuery query = new SPQuery(_spList.DefaultView);
            query.Query = @"<FieldRef Name='ID' /><FieldRef Name='Title' /><FieldRef Name='NewsDateFrom' /><FieldRef Name='NewsDateTo' /><FieldRef Name='NewsImage' /><FieldRef Name='NewsShort' /><OrderBy><FieldRef Name='Title' /></OrderBy><Where><Eq><FieldRef Name='ID' /><Value Type='Counter'>" + id + "</Value></Eq></Where>";
            SPListItemCollection itemCollection = _spList.GetItems(query);
            SPListItem item = itemCollection[0];
            try
            {
                entity.FromDate = (DateTime)item[NewsGuid.FromDate];
                entity.ToDate = (DateTime)item[NewsGuid.ToDate];
                entity.Tittle = (String)item[NewsGuid.Title];
                StringBuilder content = new StringBuilder((String)item[NewsGuid.Content]);
                entity.Content = content;
                SPFieldUrlValue imageUrl = new SPFieldUrlValue(item[NewsGuid.Image].ToString());
                entity.ImageUrl = imageUrl.Url;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
            return entity;
        }

        public DataTable GetNewsForWebpart()
        {
            try
            {
                SPQuery query = new SPQuery(_spList.DefaultView);
                query.Query = "<FieldRef Name='ID' /><FieldRef Name='Title' /><FieldRef Name='NewsDateFrom' /><FieldRef Name='NewsDateTo' /><FieldRef Name='NewsImage' /><FieldRef Name='NewsShort' /><OrderBy><FieldRef Name='NewsDateFrom' Ascending='False' /></OrderBy>";
                query.RowLimit = 4;
                SPListItemCollection itemCollection = _spList.GetItems(query);
                if (itemCollection.Count > 0)
                {
                    DataTable table = itemCollection.GetDataTable();
                    DataColumn colID = new DataColumn();
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        SPFieldUrlValue imageUrl = new SPFieldUrlValue(table.Rows[i]["NewsImage"].ToString());
                        table.Rows[i]["NewsImage"] = imageUrl.Url;
                    }
                    return table;
                }
                else
                {
                    return null;
                }
            }
            catch { return null; }
        }

        public DataTable GetAllNews() {
            SPQuery query = new SPQuery(_spList.DefaultView);
            string currentDate = (SPUtility.CreateISO8601DateTimeFromSystemDateTime(DateTime.Now));
            query.Query = "<FieldRef Name='ID' /><FieldRef Name='Title' /><FieldRef Name='NewsImage' /><FieldRef Name='NewsShort' /><Where><And><Leq><FieldRef Name='NewsDateFrom' /><Value IncludeTimeValue='TRUE' Type='DateTime'>" + currentDate + "</Value></Leq><Geq><FieldRef Name='NewsDateTo' /><Value IncludeTimeValue='TRUE' Type='DateTime'>" + currentDate + "</Value></Geq></And></Where><OrderBy><FieldRef Name='NewsDateFrom' Ascending='False' /></OrderBy>";
            SPListItemCollection itemCollection = _spList.GetItems(query);
            if (itemCollection.Count > 0)
            {
                DataTable table = itemCollection.GetDataTable();
                DataColumn colID = new DataColumn();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    SPFieldUrlValue imageUrl = new SPFieldUrlValue(table.Rows[i]["NewsImage"].ToString());
                    table.Rows[i]["NewsImage"] = imageUrl.Url;
                }
                return table;
            }
            else {
                return null;
            }
        }
    }
}
