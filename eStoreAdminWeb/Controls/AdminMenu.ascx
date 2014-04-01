<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminMenu.ascx.cs" Inherits="eStoreAdminWeb.Controls.AdminMenu" %>
<asp:Menu ID="NavBarMenu_SkipLink" runat="server" Enabled="True" Orientation="Horizontal">
    <StaticMenuItemStyle ItemSpacing="8px" />
    <Items>
        <asp:MenuItem NavigateUrl="~/Dashboards/AdminDashboard.aspx" Text="DASHBOARD" />
        <asp:MenuItem NavigateUrl="~/Web/Settings/SettingsAdminHome.aspx" Text="SETTINGS"/>
        <asp:MenuItem NavigateUrl="~/Web/Orders/OrderManagementHome.aspx" Text="ORDER MANAGEMENT"/>
        <asp:MenuItem NavigateUrl="~/Web/Advanced/AdvancedAdminHome.aspx" Text="ADVANCED"/>
        <asp:MenuItem NavigateUrl="~/Web/Email/EmailHome.aspx" Text="EMAIL"/>
        <asp:MenuItem NavigateUrl="~/Web/UISample/JQWithMaster.aspx" Text="SAMPLES"/>
        
    </Items>
</asp:Menu>