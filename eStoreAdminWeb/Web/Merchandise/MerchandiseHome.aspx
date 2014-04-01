<%@ Page Title="Merchandise Home" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="MerchandiseHome.aspx.cs" Inherits="eStoreAdminWeb.Web.Merchandise.MerchandiseHome" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Catalogue</h1>
    <p>Use the links in this section to perform maintenance of the Catalogue.</p>
    <hr />

    <p>
        <asp:HyperLink ID="Hyperlink1" runat="server" 
                       CssClass="heading2Link"
                       Text="Store Menu" 
                       NavigateUrl="~/Web/Merchandise/ManageStoreMenu.aspx" /><br/>
        View the current state of the menu as it will appear in the customer facing site.
    </p>
    
    <p>
        <asp:HyperLink ID="DepartmentsHyperlink" runat="server" 
                       CssClass="heading2Link"
                       Text="Departments" 
                       NavigateUrl="~/Web/Merchandise/Departments/ManageDepartments.aspx" /><br/>
        Manage Departments.
    </p>
</asp:Content>