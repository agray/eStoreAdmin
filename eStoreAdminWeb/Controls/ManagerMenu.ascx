<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerMenu.ascx.cs" Inherits="eStoreAdminWeb.Controls.ManagerMenu" %>
<asp:Menu ID="NavBarTopMenu_SkipLink" runat="server" Enabled="True" Orientation="Horizontal">
    <StaticMenuItemStyle ItemSpacing="8px" />
    <Items>
        <asp:MenuItem NavigateUrl="~/Dashboards/ManagerDashboard.aspx" Text="DASHBOARD" />
        <asp:MenuItem NavigateUrl="~/Web/Settings/SettingsManagerHome.aspx" Text="SETTINGS" />
        <asp:MenuItem NavigateUrl="~/Web/Merchandise/MerchandiseHome.aspx" Text="MERCHANDISE"/>
        <asp:MenuItem NavigateUrl="~/Web/Orders/OrderManagementHome.aspx" Text="ORDER MANAGEMENT"/>
        <asp:MenuItem NavigateUrl="~/Web/Email/EmailHome.aspx" Text="EMAIL"/>
        <asp:MenuItem NavigateUrl="~/Web/ImportExport/ImportExportHome.aspx" Text="IMPORT/EXPORT"/>
        <asp:MenuItem NavigateUrl="~/Web/Advanced/AdvancedManagerHome.aspx" Text="ADVANCED" />
        <asp:MenuItem NavigateUrl="~/Web/Reporting/ReportsHome.aspx" Text="REPORTS"/>
        <asp:MenuItem NavigateUrl="~/Web/UISample/SampleHome.aspx" Text="SAMPLES"/>
    </Items>
</asp:Menu>
