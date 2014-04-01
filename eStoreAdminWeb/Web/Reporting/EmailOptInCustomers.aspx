<%@ Page Title="Accounts Report" Language="C#" MasterPageFile="~/MasterPages/ReportMaster.Master" AutoEventWireup="true" CodeBehind="EmailOptInCustomers.aspx.cs" Inherits="eStoreAdminWeb.Web.Reporting.EmailOptInCustomers" %>
<%@ MasterType VirtualPath="~/MasterPages/ReportMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content2" ContentPlaceHolderID="uxMainContent" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>

      
    <h1>EMAIL OPT-IN CUSTOMERS</h1>
    <hr />
</asp:Content>