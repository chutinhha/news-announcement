<%@ Assembly Name="CSCV.GROUP.NewsAnnouncement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=83dfd338c1bf76e8" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsAnnouncementWebPartUserControl.ascx.cs" Inherits="NewsAnnouncementWebPart.NewsAnnouncementWebPart.NewsAnnouncementWebPartUserControl" %>
<asp:HyperLink ID="linkAddNews" runat="server" NavigateUrl="~/_layouts/CSCV.GROUP1.NewsAnnouncement/CreateNews.aspx">Add News</asp:HyperLink>
