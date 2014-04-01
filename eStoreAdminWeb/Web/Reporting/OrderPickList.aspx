<%@ Page Title="Order Pick List Report" Language="C#" MasterPageFile="~/MasterPages/ReportMaster.Master" AutoEventWireup="true" CodeBehind="OrderPickList.aspx.cs" Inherits="eStoreAdminWeb.Web.Reporting.OrderPickList" %>
<%@ MasterType VirtualPath="~/MasterPages/ReportMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content2" ContentPlaceHolderID="uxMainContent" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>

    <h1>ORDER PICK LIST</h1>
    <hr />
    
</asp:Content>