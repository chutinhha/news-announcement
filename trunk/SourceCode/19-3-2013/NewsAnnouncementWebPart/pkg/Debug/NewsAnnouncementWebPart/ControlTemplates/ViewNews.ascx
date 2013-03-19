<%@ Assembly Name="CSCV.GROUP.NewsAnnouncement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=83dfd338c1bf76e8" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewNews.ascx.cs" Inherits="NewsAnnouncementWebPart.ControlTemplates.ViewNews" %>

<link href="/_layouts/CSC-Stylesheet/holy-graill.css" rel="stylesheet" type="text/css" />

<div id="maincontainer">
    <div id="topsection">
        <div class="innertube" id="newsTitle" runat="server"></div>
    </div>
    <div id="contentwrapper">
        <div id="contentcolumn">
            <div class="innertube" id="newsContent" runat="server"></div>
        </div>
    </div>
    <div id="rightcolumn">
        <img id="newsImage" width="250" height="150" alt="News Image" runat="server"/>
    </div>
    <div id="footer"></div>
</div>
