<%@ Page Title="Reports" Language="C#" MasterPageFile="~/MasterPages/ReportMaster.Master" AutoEventWireup="true" CodeBehind="ReportsHome.aspx.cs" Inherits="eStoreAdminWeb.Web.Reporting.ReportsHome" %>
<%@ MasterType VirtualPath="~/MasterPages/ReportMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content2" ContentPlaceHolderID="uxMainContent" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
</asp:Content>