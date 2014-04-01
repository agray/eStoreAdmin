<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StaffMenu.ascx.cs" Inherits="eStoreAdminWeb.Controls.StaffMenu" %>
<asp:Menu ID="NavBarTopMenu_SkipLink" runat="server" Enabled="True" Orientation="Horizontal">
    <StaticMenuItemStyle ItemSpacing="8px" />
    <Items>
        <asp:MenuItem NavigateUrl="~/Dashboards/StaffDashboard.aspx" Text="DASHBOARD" />
        <asp:MenuItem NavigateUrl="~/Web/Orders/ManageOrders.aspx" Text="ORDER MANAGEMENT"/>
        <asp:MenuItem NavigateUrl="~/Web/Email/ManageEmails.aspx" Text="EMAIL"/>
    </Items>
</asp:Menu>