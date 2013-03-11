<%@ Assembly Name="SampleVisualWebPart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=033d7206800dc20b" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1UserControl.ascx.cs" Inherits="SampleVisualWebPart.VisualWebPart1.VisualWebPart1UserControl" %>
<SharePoint:ScriptLink ID="popuo" runat="server" Name="/_layouts/SampleVisualWebPart/OpenPopup.js"></SharePoint:ScriptLink>
<div>    
    <button id="btnAdd" onclick="OpenPopup();return false;" value="Add" 
        runat="server" name="Add" />
    <table style="font-family:Verdana; text-align:center;">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblList" runat="server" Text="Select List Data Using CAML"
                  Font-Bold="true" ForeColor="Maroon" Font-Size="Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnGetList" runat="server" Text="Retrive List Data" ForeColor="Orange"
                Font-Bold="true" BackColor="Black" OnClick="btnGetList_Click" Width="261px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:label id="Label4" runat="server" font-bold="true"></asp:label>

            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <br />
                <asp:gridview id="GridView1" runat="server" backcolor="LightGoldenrodYellow" bordercolor="Tan"
                    borderwidth="1px" cellpadding="2" enablemodelvalidation="True" forecolor="Black"
                    gridlines="None" autogeneratecolumns="False"><AlternatingRowStyle BackColor="PaleGoldenrod" /><FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" /><Columns>
                    <asp:BoundField DataField="ID" HeaderText="Id" ReadOnly="true" SortExpression="ID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" ReadOnly="true" />
                    <asp:BoundField DataField="Content" HeaderText="Content" ReadOnly="true" />
                    <asp:BoundField DataField="Created_x0020_Date0" HeaderText="Created Date" ReadOnly="true" />
                    <asp:BoundField DataField="Expired_x0020_Date" HeaderText="Due Date" ReadOnly="true" />
                    </Columns></asp:gridview>
            </td>
        </tr>
    </table>
</div>
