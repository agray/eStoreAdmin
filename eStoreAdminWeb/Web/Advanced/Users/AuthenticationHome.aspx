<%@ Page Title="Authentication Home" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="AuthenticationHome.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.Users.AuthenticationHome" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>eStore Administration Authentication</h1>
    <p>Use the links in this perform the same functions as the Web Site Administration Tool.</p>
    <hr />
    <p>
        <asp:HyperLink ID="Hyperlink10" runat="server" 
                       CssClass="heading2Link"
                       Text="Users" 
                       NavigateUrl="~/Web/Advanced/Users/ManageUsers.aspx" /><br/>
        Manage User Accounts.
    </p>
    <p>
        <asp:HyperLink ID="Hyperlink11" runat="server" 
                       CssClass="heading2Link"
                       Text="Roles" 
                       NavigateUrl="~/Web/Advanced/Users/ManageRoles.aspx" /><br/>
        Manage Roles.
    </p>
    <p>
        <asp:HyperLink ID="Hyperlink12" runat="server" 
                       CssClass="heading2Link"
                       Text="Users By Role" 
                       NavigateUrl="~/Web/Advanced/Users/UsersByRole.aspx" /><br/>
        Users By Role.
    </p>
    <p>
        <asp:HyperLink ID="Hyperlink13" runat="server" 
                       CssClass="heading2Link"
                       Text="Access Rules" 
                       NavigateUrl="~/Web/Advanced/Users/ManageAccessRules.aspx" /><br/>
        Manage Access Rules.
    </p>
    <p>
        <asp:HyperLink ID="Hyperlink14" runat="server" 
                       CssClass="heading2Link"
                       Text="Access Rule Summary" 
                       NavigateUrl="~/Web/Advanced/Users/AccessRuleSummary.aspx" /><br/>
        Access Rule Summary.
    </p>
</asp:Content>