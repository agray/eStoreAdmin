<%@ Page Title="Advanced Home" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="AdvancedManagerHome.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.AdvancedManagerHome" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Advanced</h1>
    <p>Use the links in this section to perform general maintenance.</p>
    <hr />
    
    <p>
        <asp:HyperLink ID="Hyperlink2" runat="server" 
                       CssClass="heading2Link"
                       Text="Brands" 
                       NavigateUrl="ManageBrands.aspx" /><br/>
        Manage Brands.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink3" runat="server" 
                       CssClass="heading2Link"
                       Text="Currencies" 
                       NavigateUrl="ManageCurrencies.aspx" /><br/>
        Manage currency exchange rates.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink4" runat="server" 
                       CssClass="heading2Link"
                       Text="Zones" 
                       NavigateUrl="ManageZones.aspx" /><br/>
        Manage Shipping Zones.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink5" runat="server" 
                       CssClass="heading2Link"
                       Text="Modes" 
                       NavigateUrl="ManageModes.aspx" /><br/>
        Manage Shipping Modes.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink6" runat="server" 
                       CssClass="heading2Link"
                       Text="Countries" 
                       NavigateUrl="ManageCountries.aspx" /><br/>
        Manage Shipping Countries.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink7" runat="server" 
                       CssClass="heading2Link"
                       Text="Suppliers" 
                       NavigateUrl="ManageSuppliers.aspx" /><br/>
        Manage Suppliers.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink8" runat="server" 
                       CssClass="heading2Link"
                       Text="Costs" 
                       NavigateUrl="ManageCosts.aspx" /><br/>
        Manage Shipping Costs.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink9" runat="server" 
                       CssClass="heading2Link"
                       Text="Credit Card Years" 
                       NavigateUrl="ManageCCYears.aspx" /><br/>
        Manage Credit Card Expiry Years.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink10" runat="server" 
                       CssClass="heading2Link"
                       Text="Words" 
                       NavigateUrl="ManageWords.aspx" /><br/>
        Manage Unacceptable Words.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink11" runat="server" 
                       CssClass="heading2Link"
                       Text="Incomplete Items" 
                       NavigateUrl="ManageIncompleteItems.aspx" /><br/>
        Manage Incomplete Items.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink14" runat="server" 
                       CssClass="heading2Link"
                       Text="Themes" 
                       NavigateUrl="ManageThemes.aspx" /><br/>
        Manage Themes (for customer facing website).
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink12" runat="server" 
                       CssClass="heading2Link"
                       Text="Administration Authentication" 
                       NavigateUrl="~/Web/Advanced/Users/AuthenticationHome.aspx" /><br/>
        Manage eStore Administration Site Authentication (this Site).
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink13" runat="server" 
                       CssClass="heading2Link"
                       Text="Customer Site Authentication" 
                       NavigateUrl="~/Web/Advanced/Customers/ManageCustomers.aspx" /><br/>
        Manage Customer Authentication.
    </p>
</asp:Content>