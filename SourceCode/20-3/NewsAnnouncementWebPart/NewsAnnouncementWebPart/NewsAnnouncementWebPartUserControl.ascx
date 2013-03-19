<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsAnnouncementWebPartUserControl.ascx.cs" Inherits="NewsAnnouncementWebPart.NewsAnnouncementWebPart.NewsAnnouncementWebPartUserControl" %>

<link href="~/_layouts/CSC-Stylesheet/all-news.css" rel="stylesheet" type="text/css" />
<div align="right" class="webpart-button">
<asp:HyperLink ID="btnAdd" runat="server" NavigateUrl="~/_layouts/CreateNews.aspx">
<asp:Image ImageUrl="~/_layouts/CSC-Images/add-news-icon.png" runat="server" ID="imgAdd" Width="20" Height="20"/> Add News
</asp:HyperLink>
&nbsp;
<asp:HyperLink ID="linkAllNews" runat="server" NavigateUrl="~/_layouts/AllNews.aspx">
<asp:Image ImageUrl="~/_layouts/CSC-Images/all-news-icon.png" runat="server" ID="imgAll" Width="20" Height="20"/> All News</asp:HyperLink>
</div>
<div id="noData" runat="server"></div>
<asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" 
    AutoGenerateColumns="False" 
    ShowHeader="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
    BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" 
    AllowPaging="True" PageSize="5">
    <Columns>
        <asp:TemplateField SortExpression="Image" ShowHeader="false" >
            <ItemTemplate>
                <asp:Image ID="Label4" runat="server" ImageUrl='<%# Eval("NewsImage") %>'  Width="150" Height="100"/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField SortExpression="Title" ShowHeader="false" ItemStyle-VerticalAlign="Top">
            <ItemTemplate>
                <div>
                    <div class="title">
                        <asp:HyperLink ID="Label2" runat="server" Text='<%# Eval("Title") %>' NavigateUrl='<%# Eval("ID", "~/_layouts/ViewNews.aspx?id={0}") %>'>
                        </asp:HyperLink>
                    </div>
                    <div>
                        <asp:Label ID="Label3" CssClass="content" runat="server" Text='<%# Eval("NewsShort") %>'></asp:Label>
                    </div>
                    <div class="button">
                        <asp:HyperLink ID="btnUpdate" runat="server" NavigateUrl='<%# Eval("ID", "~/_layouts/EditNews.aspx?id={0}") %>'>
                            <asp:Image CssClass="image-action" runat="server" ID="image" ImageUrl="~/_layouts/CSC-Images/edit-icon.png" />
                            Update
                        </asp:HyperLink>
                        <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return confirm ('Are you sure you want to delete this item?');" OnCommand="DeleteItem" CommandArgument='<%# Eval("ID") %>'>
                            <asp:Image CssClass="image-action" runat="server" ID="image1" ImageUrl="~/_layouts/CSC-Images/delete-icon.png" />
                            Delete
                        </asp:LinkButton>
                        </div>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
</asp:GridView>
<br />
<br />
<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Create Sample Data"/>
