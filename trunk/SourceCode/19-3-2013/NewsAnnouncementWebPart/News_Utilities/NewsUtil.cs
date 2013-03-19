using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.IO;

namespace NewsAnnouncementWebPart.News_Utilities
{
    public static class NewsUtil
    {
        public static string GenerateValidImageName(string fileName, SPList pictureLibrary)
        {
            //Check if new image name validates
            int i = 0;
            string temp = fileName;
            string extention = Path.GetExtension(fileName);
            SPQuery query = new SPQuery(pictureLibrary.DefaultView);
            SPListItemCollection imageCollection;
            do
            {
                i++;
                query.ViewFields = "<Where><Eq><FieldRef Name='LinkFilename' /><Value Type='Computed'>" + fileName + "</Value></Eq></Where>";
                imageCollection = pictureLibrary.GetItems(query);
                if (imageCollection.Count > 0)
                {
                    fileName = temp;
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName) + " " + i;
                    fileName = fileNameWithoutExtension + extention;
                }
                else {
                    break;
                }
            } while (imageCollection.Count > 0);
            return fileName;
        }

        public static NewsAnnouncementWebPart.NewsAnnouncementWebPart WebPart { get; set; }
        
        public static bool IsContribute() { 
        SPSite spSite = new SPSite(NewsString.RootSiteUrl);
            SPWeb spWeb = spSite.RootWeb;
            SPUser currentUser = spWeb.CurrentUser;
            SPGroup group = spWeb.SiteGroups[NewsUtil.WebPart.PropertyValue];
            bool flag = false;
            foreach (SPGroup loop in currentUser.Groups) {
                if (loop.Name.Equals(group.Name)) {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public static void InsertSampleData()
        {
            try
            {
                SPSite site = new SPSite(NewsString.RootSiteUrl);
                SPWeb spWeb = site.RootWeb;
                SPList _spList = spWeb.GetList(NewsString.NewsListURL);
                SPListItem itemToAdd = _spList.Items.Add();
                //-------------
                itemToAdd[NewsGuid.Title] = "Cận cảnh lính đặc công đổ bộ đường không";
                itemToAdd[NewsGuid.FromDate] = DateTime.Now;
                itemToAdd[NewsGuid.ToDate] = DateTime.Now.AddDays(2);
                itemToAdd[NewsGuid.Content] = "Không chỉ điêu luyện võ công, thuần thục các loại vũ khí trang bị, thông thạo tin học và ngoại ngữ, lính đặc công còn phải giỏi cơ động trên không để tiếp cận mục tiêu trên mọi địa hình, thời tiết phức tạp.";
                itemToAdd[NewsGuid.Image] = NewsString.RootSiteUrl + "/_layouts/CSC-Images/no-image-available.jpg";
                itemToAdd.Update();

                itemToAdd = _spList.Items.Add();
                //-------------
                itemToAdd[NewsGuid.Title] = "Ngày cuối tuần của đại gia đình hiếm có nhất Việt Nam";
                itemToAdd[NewsGuid.FromDate] = DateTime.Now;
                itemToAdd[NewsGuid.ToDate] = DateTime.Now.AddDays(2);
                itemToAdd[NewsGuid.Content] = "Bốn thế hệ cùng sống trong 5 căn biệt thự đồ sộ, chung một chiếc sân không có vách ngăn, cùng làm chung, tiêu chung một túi, ăn chung một nồi – đó là câu chuyện khó tin về gia đình ông Nguyễn Văn Giáo ở Từ Hồ - Yên Phú - Yên Mỹ (Hưng Yên).";
                itemToAdd[NewsGuid.Image] = NewsString.RootSiteUrl + "/_layouts/CSC-Images/no-image-available.jpg";
                itemToAdd.Update();

                itemToAdd = _spList.Items.Add();
                //-------------
                itemToAdd[NewsGuid.Title] = "Nỗ lực tránh gây tai nạn, xe tải lật chắn ngang đường";
                itemToAdd[NewsGuid.FromDate] = DateTime.Now;
                itemToAdd[NewsGuid.ToDate] = DateTime.Now.AddDays(2);
                itemToAdd[NewsGuid.Content] = " Chiếc xe ben chở đá dăm đang lưu thông với tốc độ cao thì bị mất phanh. Để tránh tông vào dòng xe đang mua vé qua trạm thu phí, tài xế cho xe lao thẳng vào dải phân cách.";
                itemToAdd[NewsGuid.Image] = NewsString.RootSiteUrl + "/_layouts/CSC-Images/no-image-available.jpg";
                itemToAdd.Update();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static bool IsGroupAlreadyExist(SPWeb web, string groupName)
        {
            bool isExist = false;

            try
            {
                SPGroup group = web.SiteGroups[groupName];
                isExist = true;
            }
            catch (SPException)
            {
                isExist = false;
            }
            catch (Exception)
            {
                isExist = false;
            }
            return isExist;        
        }
    }
}
