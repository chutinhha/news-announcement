<%@ Assembly Name="CSC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=04150759a95d9bf3" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateNews.ascx.cs" Inherits="CSC.ControlTemplates.CSC.CreateNews" %>
<style type="text/css">
    .style1
    {
        width: 152px;
    }
</style>

<table style="width:100%;">
    <tr>
        <td class="style1">
            News Title:</td>
        <td>
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Short Description:</td>
        <td>
            <asp:TextBox ID="txtShort" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Full Article</td>
        <td>
            <asp:TextBox ID="txtFull" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style1">
            Date From:</td>
        <td>
            <SharePoint:DateTimeControl ID="txtFrom" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="style1">
            Date To:</td>
        <td>
            <SharePoint:DateTimeControl ID="txtTo" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="style1">
            Image:</td>
        <td>
            <asp:FileUpload ID="txtImage" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnAdd" runat="server" Text="Add New" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        </td>
    </tr>
</table>

