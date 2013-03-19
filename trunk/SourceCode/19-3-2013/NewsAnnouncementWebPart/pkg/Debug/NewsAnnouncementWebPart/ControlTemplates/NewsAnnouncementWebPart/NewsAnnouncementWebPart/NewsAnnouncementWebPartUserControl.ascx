<%@ Assembly Name="CSCV.GROUP.NewsAnnouncement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=83dfd338c1bf76e8" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsAnnouncementWebPartUserControl.ascx.cs" Inherits="NewsAnnouncementWebPart.NewsAnnouncementWebPart.NewsAnnouncementWebPartUserControl" %>
<asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" 
    AutoGenerateColumns="False" 
    ShowHeader="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
    BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" 
    AllowPaging="True" PageSize="5">
    <Columns>
        <asp:TemplateField SortExpression="Image" ShowHeader="false" >
            <ItemTemplate>
                <asp:Image ID="Label4" runat="server" ImageUrl='<%# Bind("NewsImage") %>'  Width="150" Height="100"/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField SortExpression="Title" ShowHeader="false" ItemStyle-VerticalAlign="Top">
            <ItemTemplate>
                <asp:HyperLink CssClass="title"  ID="Label2" runat="server" Text='<%# Eval("Title") %>' NavigateUrl='<%# Eval("ID", "../_layouts/ViewNews.aspx?id={0}") %>'></asp:HyperLink>
                <br />
                <br />
                <asp:Label ID="Label3" CssClass="content" runat="server" Text='<%# Bind("NewsShort") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
</asp:GridView>
<asp:HyperLink ID="linkAddNews" runat="server" NavigateUrl="~/_layouts/CreateNews.aspx">Add News</asp:HyperLink>
&nbsp;
<asp:HyperLink ID="linkAllNews" runat="server" 
    NavigateUrl="~/_layouts/AllNews.aspx">All News</asp:HyperLink>
<br />
<br />
<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Create Sample Data" />
