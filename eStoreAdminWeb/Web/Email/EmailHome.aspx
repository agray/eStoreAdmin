<%@ Page Title="Email Home" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="EmailHome.aspx.cs" Inherits="eStoreAdminWeb.Web.Email.EmailHome" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>

    <h1>Email</h1>

    <p>
        <asp:HyperLink ID="CustomerEmailsHyperlink" runat="server" 
                       CssClass="heading2Link"
                       Text="Customer Contact" 
                       NavigateUrl="~/Web/Email/ManageEmails.aspx" /><br/>
        Manage Customer Emails.
    </p>
    <p>
        <asp:HyperLink ID="EmailMarketingHyperlink" runat="server" 
                       CssClass="heading2Link"
                       Text="Email Marketing" 
                       NavigateUrl="~/Web/Email/EmailMarketing.aspx" /><br/>
        Manage Customer Emails.
    </p>



</asp:Content>