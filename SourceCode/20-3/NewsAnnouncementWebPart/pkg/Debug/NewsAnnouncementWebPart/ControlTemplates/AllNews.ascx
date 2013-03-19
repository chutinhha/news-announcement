<%@ Assembly Name="CSCV.GROUP.NewsAnnouncement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=83dfd338c1bf76e8" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AllNews.ascx.cs" Inherits="NewsAnnouncementWebPart.ControlTemplates.AllNews" %>
<link href="../_layouts/CSC-Stylesheet/all-news.css" rel="stylesheet" type="text/css" />
<script src="../_layouts/CSC-Javascript/jquery-1.9.1.min.js" type="text/javascript"></script>
<div class="wrapper">
    <div align="right" class="allnews-padding">
        <asp:HyperLink ID="btnAdd" runat="server" 
            NavigateUrl="~/_layouts/CreateNews.aspx">
            <asp:Image ImageUrl="~/_layouts/CSC-Images/add-news-icon.png" runat="server" ID="imgAdd" Width="20" Height="20"/> 
            Add News</asp:HyperLink>
    </div>
    <div id="noData" runat="server"></div>
    <div>
        <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" AutoGenerateColumns="False"
            ShowHeader="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None"
            BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AllowPaging="True"
            PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField SortExpression="Image" ShowHeader="false" ControlStyle-CssClass="news-left">
                    <ItemTemplate>
                        <asp:Image ID="Label4" runat="server" ImageUrl='<%# Eval("NewsImage") %>' Width="150"
                            Height="100" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField SortExpression="Title" ShowHeader="false" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <div class="wrapper-content">
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
                                <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return confirm ('Are you sure you want to delete this item?');"
                                    OnCommand="DeleteItem" CommandArgument='<%# Eval("ID") %>'>
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
    </div>
</div>
