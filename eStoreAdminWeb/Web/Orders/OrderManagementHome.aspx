<%@ Page Title="Order Management Home" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="OrderManagementHome.aspx.cs" Inherits="eStoreAdminWeb.Web.Orders.OrderManagementHome" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Order Management Home</h1>
    <p>Use the links in this section to manage orders.</p>
    <hr />
    <p>
        <asp:HyperLink ID="Hyperlink1" runat="server" 
                       CssClass="heading2Link"
                       Text="Search Orders" 
                       NavigateUrl="~/Web/Orders/ManageOrders.aspx" /><br/>
        Search orders placed by customers.
    </p>
    
    <p>
        <asp:HyperLink ID="OrderEmailHyperlink" runat="server" 
                       CssClass="heading2Link"
                       Text="Order Email Preferences" 
                       NavigateUrl="~/Web/Orders/ManageEmailPreferences.aspx" /><br/>
        Manage Departments.
    </p>
</asp:Content>
