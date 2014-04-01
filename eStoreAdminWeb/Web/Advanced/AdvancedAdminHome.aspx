<%@ Page Title="Advanced Home" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="AdvancedAdminHome.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.AdvancedAdminHome" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage();
      }%>
    <h1>Advanced</h1>
    <p>Use the links in this section to perform general maintenance.</p>
    <hr />
    
    <p>
        <asp:HyperLink ID="Hyperlink2" runat="server" 
                       CssClass="heading2Link"
                       Text="Currencies" 
                       NavigateUrl="ManageCurrencies.aspx" /><br/>
        Manage currency exchange rates.
    </p>
  
    <p>
        <asp:HyperLink ID="Hyperlink3" runat="server" 
                       CssClass="heading2Link"
                       Text="Suppliers" 
                       NavigateUrl="ManageSuppliers.aspx" /><br/>
        Manage Suppliers.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink4" runat="server" 
                       CssClass="heading2Link"
                       Text="Credit Card Years" 
                       NavigateUrl="ManageCCYears.aspx" /><br/>
        Manage Credit Card Expiry Years.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink5" runat="server" 
                       CssClass="heading2Link"
                       Text="Words" 
                       NavigateUrl="ManageWords.aspx" /><br/>
        Manage Unacceptable Words.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink6" runat="server" 
                       CssClass="heading2Link"
                       Text="Incomplete Items" 
                       NavigateUrl="ManageIncompleteItems.aspx" /><br/>
        Manage Incomplete Items.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink7" runat="server" 
                       CssClass="heading2Link"
                       Text="Customer Site Authentication" 
                       NavigateUrl="~/Web/Advanced/Customers/ManageCustomers.aspx" /><br/>
        Manage Customer Authentication.
    </p>
</asp:Content>