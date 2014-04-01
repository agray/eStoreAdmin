<%@ Page Title="Manage Settings" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="SettingsAdminHome.aspx.cs" Inherits="eStoreAdminWeb.SettingsAdminHome" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <p>
        <asp:HyperLink ID="Hyperlink1" runat="server" 
                       CssClass="heading2Link"
                       Text="Links" 
                       NavigateUrl="ManageLinks.aspx" /><br/>
        Add, Edit and Delete Links to other sites for your customers.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink2" runat="server" 
                       CssClass="heading2Link"
                       Text="Testimonials" 
                       NavigateUrl="ManageTestimonials.aspx" /><br/>
        Add, Edit and Delete Testimonials from your customers.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink3" runat="server" 
                       CssClass="heading2Link"
                       Text="Social Networking by Department" 
                       NavigateUrl="ManageSocialByDep.aspx" /><br/>
        Configure Social Networking capabilities an entire department at a time.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink4" runat="server" 
                       CssClass="heading2Link"
                       Text="Social Networking by Category" 
                       NavigateUrl="ManageSocialByCat.aspx" /><br/>
        Configure Social Networking capabilities a category at a time.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink5" runat="server" 
                       CssClass="heading2Link"
                       Text="Social Networking by Product" 
                       NavigateUrl="ManageSocialByProd.aspx" /><br/>
        Configure Social Networking capabilities a product at a time.
    </p>
</asp:Content>
       
