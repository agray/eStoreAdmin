<%@ Page Title="Set Theme" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="SetTheme.aspx.cs" Inherits="eStoreAdminWeb.SetTheme" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<%@ Register TagPrefix="theme" TagName="ThemeDDL" Src="~/Controls/ThemeDDL.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
     } %>
    <h1>Set Theme</h1>
    <%if(Roles.IsUserInRole("Manager")) { %>
        <asp:HyperLink ID="ManagerHomeHyperlink" runat="server"
                       NavigateUrl="SettingsManagerHome.aspx"
                       Text="Back to Settings Home"/>
    <%} else { %>
        <asp:HyperLink ID="AdminHomeHyperLink" runat="server"
                       NavigateUrl="SettingsAdminHome.aspx"
                       Text="Back to Settings Home"/>
    <%} %>
    <br />
    <asp:Literal runat="server" Text="Theme: "/><theme:ThemeDDL ID="themeDDL" runat="server" OnDataBinding="ThemeDDL_DataBinding" />
    <asp:Button runat="server" Text="Set Theme" OnClick="storeTheme" />
    <br /><br />
    <asp:Literal runat="server" Text="Changing this setting will require restarting the Customer Facing website" />
    
</asp:Content>