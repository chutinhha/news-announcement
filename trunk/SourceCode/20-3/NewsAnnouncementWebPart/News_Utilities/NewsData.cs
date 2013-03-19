using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace NewsAnnouncementWebPart.News_Utilities
{
    class NewsData
    {
        public static void InsertSampleData()
        {
            try
            {
                SPList spList = NewsObject.spList;
                SPListItem itemToAdd = spList.Items.Add();
                //-------------
                itemToAdd[NewsGuid.Title] = "Cận cảnh lính đặc công đổ bộ đường không";
                itemToAdd[NewsGuid.FromDate] = DateTime.Now;
                itemToAdd[NewsGuid.ToDate] = DateTime.Now.AddDays(2);
                itemToAdd[NewsGuid.Content] = "Không chỉ điêu luyện võ công, thuần thục các loại vũ khí trang bị, thông thạo tin học và ngoại ngữ, lính đặc công còn phải giỏi cơ động trên không để tiếp cận mục tiêu trên mọi địa hình, thời tiết phức tạp.";
                itemToAdd[NewsGuid.Image] = NewsString.RootSiteUrl + "/_layouts/CSC-Images/no-image-available.jpg";
                itemToAdd.Update();

                itemToAdd = spList.Items.Add();
                //-------------
                itemToAdd[NewsGuid.Title] = "Ngày cuối tuần của đại gia đình hiếm có nhất Việt Nam";
                itemToAdd[NewsGuid.FromDate] = DateTime.Now;
                itemToAdd[NewsGuid.ToDate] = DateTime.Now.AddDays(2);
                itemToAdd[NewsGuid.Content] = "Bốn thế hệ cùng sống trong 5 căn biệt thự đồ sộ, chung một chiếc sân không có vách ngăn, cùng làm chung, tiêu chung một túi, ăn chung một nồi – đó là câu chuyện khó tin về gia đình ông Nguyễn Văn Giáo ở Từ Hồ - Yên Phú - Yên Mỹ (Hưng Yên).";
                itemToAdd[NewsGuid.Image] = NewsString.RootSiteUrl + "/_layouts/CSC-Images/no-image-available.jpg";
                itemToAdd.Update();

                itemToAdd = spList.Items.Add();
                //-------------
                itemToAdd[NewsGuid.Title] = "Nỗ lực tránh gây tai nạn, xe tải lật chắn ngang đường";
                itemToAdd[NewsGuid.FromDate] = DateTime.Now;
                itemToAdd[NewsGuid.ToDate] = DateTime.Now.AddDays(2);
                itemToAdd[NewsGuid.Content] = " Chiếc xe ben chở đá dăm đang lưu thông với tốc độ cao thì bị mất phanh. Để tránh tông vào dòng xe đang mua vé qua trạm thu phí, tài xế cho xe lao thẳng vào dải phân cách.";
                itemToAdd[NewsGuid.Image] = NewsString.RootSiteUrl + "/_layouts/CSC-Images/no-image-available.jpg";
                itemToAdd.Update();

                itemToAdd = spList.Items.Add();
                //-------------
                itemToAdd[NewsGuid.Title] = "Galaxy S 4 trình làng là sự kiện công nghệ nổi bật nhất tuần qua";
                itemToAdd[NewsGuid.FromDate] = DateTime.Now;
                itemToAdd[NewsGuid.ToDate] = DateTime.Now.AddDays(2);
                itemToAdd[NewsGuid.Content] = "Galaxy S 4 được Samsung chính thức trình làng là sự kiện công nghệ nổi bật và được quan tâm nhất trong tuần qua. Ngoài ra còn những sự kiện nổi bật khác như Internet Triều Tiên bị hacker tấn công hay Sony công bố giá bán Xperia Z chính hãng tại Việt Nam";
                itemToAdd[NewsGuid.Image] = NewsString.RootSiteUrl + "/_layouts/CSC-Images/no-image-available.jpg";
                itemToAdd.Update();

                itemToAdd = spList.Items.Add();
                //-------------
                itemToAdd[NewsGuid.Title] = "Galaxy S 4, Galaxy Note II chuẩn bị lên đời Android 5.0";
                itemToAdd[NewsGuid.FromDate] = DateTime.Now;
                itemToAdd[NewsGuid.ToDate] = DateTime.Now.AddDays(2);
                itemToAdd[NewsGuid.Content] = "Mặc dù chưa có thông tin nào về thời điểm xuất hiện của phiên bản Android 5.0 mới nhất của Google, nhưng danh sách những sản phẩm của Samsung sẽ sớm được nâng cấp lên phiên bản mới này đã bị rò rỉ trên Internet.";
                itemToAdd[NewsGuid.Image] = NewsString.RootSiteUrl + "/_layouts/CSC-Images/no-image-available.jpg";
                itemToAdd.Update();

                itemToAdd = spList.Items.Add();
                //-------------
                itemToAdd[NewsGuid.Title] = "CEO BlackBerry chê iPhone… lỗi thời";
                itemToAdd[NewsGuid.FromDate] = DateTime.Now;
                itemToAdd[NewsGuid.ToDate] = DateTime.Now.AddDays(2);
                itemToAdd[NewsGuid.Content] = "Thorsten Heins, CEO của BlackBerry vừa có một tuyên bố gây sốc khi cho rằng iPhone của Apple đã trở nên lỗi thời. Tuy nhiên, Heins hoàn toàn có cơ sở khi tuyên bố điều này.";
                itemToAdd[NewsGuid.Image] = NewsString.RootSiteUrl + "/_layouts/CSC-Images/no-image-available.jpg";
                itemToAdd.Update();

                itemToAdd = spList.Items.Add();
                //-------------
                itemToAdd[NewsGuid.Title] = "Zalo: Từ giấc mơ lãng mạn đến ngôi vị số 1";
                itemToAdd[NewsGuid.FromDate] = DateTime.Now;
                itemToAdd[NewsGuid.ToDate] = DateTime.Now.AddDays(2);
                itemToAdd[NewsGuid.Content] = "Khởi đầu chậm chạp và có những lúc sai lầm nhưng Zalo (ứng dụng nhắn tin miễn phí thuần Việt trên di động) đã có cuộc lội ngược dòng ngoạn mục để vươn lên vị trí số 1 Việt Nam.";
                itemToAdd[NewsGuid.Image] = NewsString.RootSiteUrl + "/_layouts/CSC-Images/no-image-available.jpg";
                itemToAdd.Update();

                itemToAdd = spList.Items.Add();
                //-------------
                itemToAdd[NewsGuid.Title] = "Windows Phone 7.8 và Windows Phone 8 sẽ “hết đời” từ năm 2014";
                itemToAdd[NewsGuid.FromDate] = DateTime.Now;
                itemToAdd[NewsGuid.ToDate] = DateTime.Now.AddDays(2);
                itemToAdd[NewsGuid.Content] = "Gã khổng lồ phần mềm xứ Redmond cho hay hãng sẽ ngưng hỗ trợ cho nền tảng di động Windows Phone 8 từ tháng 7/2014, trong khi đó thời gian của Windows Phone 7.8 sẽ được kéo dài đến tháng 9.";
                itemToAdd[NewsGuid.Image] = NewsString.RootSiteUrl + "/_layouts/CSC-Images/no-image-available.jpg";
                itemToAdd.Update();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
