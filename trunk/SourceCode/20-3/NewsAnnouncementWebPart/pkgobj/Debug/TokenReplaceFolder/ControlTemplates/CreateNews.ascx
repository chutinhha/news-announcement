<%@ Assembly Name="CSCV.GROUP.NewsAnnouncement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=83dfd338c1bf76e8" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateNews.ascx.cs" Inherits="NewsAnnouncementWebPart.ControlTemplates.CSCV.GROUP1.NewsAnnouncement.CreateNewsControl" %>
<link href="../_layouts/CSC-Stylesheet/all-news.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    .style1
    {
        width: 122px;
    }
    
    .sub-color
    {
        color: #FF0000;
        }
</style>
<table style="width:100%;">
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            Title: <sup class="sub-color">*</sup></td>
        <td>
            <SharePoint:InputFormTextBox ID="txtTitle" runat="server" CssClass="textbox" Width="300"></SharePoint:InputFormTextBox>
            <SharePoint:InputFormRequiredFieldValidator ID="vadTitle" 
                runat="server" ControlToValidate="txtTitle" 
                ErrorMessage=" Please input news title" 
                ErrorImageUrl="/_layouts/CSC-Images/icon_error.png"><br /><img alt="" 
                src="/_layouts/CSC-Images/icon_error.png"><span role="alert"> Please input news title</span></img></SharePoint:InputFormRequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Image: </td>
        <td>
            <asp:FileUpload ID="txtImage" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="style1">
            Start from: <sup class="sub-color">*</sup></td>
        <td>
            <SharePoint:DateTimeControl ID="txtFrom" runat="server" DateOnly="True" 
                IsRequiredField="False" CssClassTextBox="textbox"/>
            <SharePoint:InputFormRequiredFieldValidator ID="vadFrom" runat="server" 
                BreakBefore="False" ControlToValidate="txtFrom$txtFromDate" 
                ErrorImageUrl="/_layouts/CSC-Images/icon_error.png" 
                ErrorMessage=" Please input news start date"><span role="alert"> Please input news start date</span></img></SharePoint:InputFormRequiredFieldValidator>
            <SharePoint:InputFormCompareValidator ID="vadFromValid" runat="server" 
                BreakBefore="False" ControlToValidate="txtFrom$txtFromDate" 
                ErrorImageUrl="/_layouts/CSC-Images/icon_error.png" 
                ErrorMessage=" Please enter a valid start date" Operator="DataTypeCheck" 
                Type="Date"><img alt="" src="/_layouts/CSC-Images/icon_error.png"><span 
                role="alert"> Please enter a valid start date</span></img></SharePoint:InputFormCompareValidator>
        </td>
    </tr>
    <tr>
        <td class="style1">
            End at: <sup class="sub-color">*</sup></td>
        <td>
            <SharePoint:DateTimeControl ID="txtTo" runat="server" DateOnly="True" 
                IsRequiredField="False" CssClassTextBox="textbox"
                ErrorMessage="Please specify date ending for this article" />
            <SharePoint:InputFormRequiredFieldValidator ID="vadTo" runat="server" 
                BreakBefore="False" ControlToValidate="txtTo$txtToDate" 
                ErrorImageUrl="/_layouts/CSC-Images/icon_error.png" 
                ErrorMessage=" Please input news end date"><span role="alert"> Please input news end date</span></img></SharePoint:InputFormRequiredFieldValidator>
            <SharePoint:InputFormCompareValidator ID="vadToValid" runat="server" 
                BreakBefore="False" ControlToValidate="txtTo$txtToDate" 
                ErrorImageUrl="/_layouts/CSC-Images/icon_error.png" 
                ErrorMessage=" Please enter a valid end date" Operator="DataTypeCheck" 
                Type="Date"><img alt="" src="/_layouts/CSC-Images/icon_error.png"><span 
                role="alert"> Please enter a valid end date</span></img></SharePoint:InputFormCompareValidator>
            <SharePoint:InputFormCompareValidator ID="vadToCompare" runat="server" 
                BreakBefore="False" ControlToCompare="txtFrom$txtFromDate" 
                ControlToValidate="txtTo$txtToDate" 
                ErrorImageUrl="/_layouts/CSC-Images/icon_error.png" 
                ErrorMessage=" Please ensure that end date must be after start date" 
                Operator="GreaterThan" Type="Date"><img alt="" 
                src="/_layouts/CSC-Images/icon_error.png"><span role="alert"> Please ensure that end date must be after start date</span></img></SharePoint:InputFormCompareValidator>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Short Description: <sup class="sub-color">*</sup></td>
        <td>&nbsp;<SharePoint:InputFormTextBox ID="txtContent" TextMode="MultiLine" Rows="10" CssClass="textbox"
    Columns="80" runat="server"
    EnableViewState="false">    </SharePoint:InputFormTextBox>
            <SharePoint:InputFormRequiredFieldValidator ID="vadContentRequire" 
                runat="server" BreakBefore="True" ControlToValidate="txtContent" 
                ErrorMessage=" Please input news content" 
                ErrorImageUrl="/_layouts/CSC-Images/icon_error.png"><br /><img alt="" 
                src="/_layouts/CSC-Images/icon_error.png"><span role="alert"> Please input news content</span></img></SharePoint:InputFormRequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnInsert" runat="server" Text="Add News" CssClass="myButton"
                onclick="btnInsert_Click" />
            &nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="myButton"
                onclick="btnCancel_Click" CausesValidation="False" />
        </td>
    </tr>
</table>

