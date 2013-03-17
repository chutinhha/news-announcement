<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsAnnouncementWebPartUserControl.ascx.cs"
    Inherits="NewsAnnouncementWebPart.NewsAnnouncementWebPart.NewsAnnouncementWebPartUserControl" %>
<div id="news">
    <ul>
        <asp:Repeater ID="repeater" runat="server">
            <HeaderTemplate>
                <div id="news-container">
            </HeaderTemplate>
            <ItemTemplate>
                <img src='<%# DataBinder.Eval(Container.DataItem, "ImageUrl")%>' alt="" />
                <div class="title">
                    <%# DataBinder.Eval(Container.DataItem, "Tittle")%>
                </div>
                <div class="content">
                    <%# DataBinder.Eval(Container.DataItem, "Content")%>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </ul>
</div>
<asp:HyperLink ID="linkAddNews" runat="server" NavigateUrl="~/_layouts/CreateNews.aspx">Add News</asp:HyperLink>