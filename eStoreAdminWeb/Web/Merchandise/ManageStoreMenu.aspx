<%@ Page Title="Store Menu" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageStoreMenu.aspx.cs" Inherits="eStoreAdminWeb.Web.Merchandise.ManageStoreMenu" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>
<%@ Register Src="~/Controls/StoreMenu.ascx" TagPrefix="store" TagName="Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage();
      }%>
    <div class="DivSideBar">
        <h1>Store Menu</h1>
        <p>What the menu looks like in the customer facing store</p>
        <hr />
        <asp:HyperLink ID="BackToHyperlink" runat="server" NavigateUrl="~/Web/Merchandise/MerchandiseHome.aspx" Text="Back To Merchandise Home"/>
        <store:Menu ID="StoreMenu" runat="server" />
    </div>
</asp:Content>