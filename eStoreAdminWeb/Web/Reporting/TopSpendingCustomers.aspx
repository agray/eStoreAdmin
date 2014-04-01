<%@ Page Title="Top Spending Customers Report" Language="C#" MasterPageFile="~/MasterPages/ReportMaster.Master" AutoEventWireup="true" CodeBehind="TopSpendingCustomers.aspx.cs" Inherits="eStoreAdminWeb.Web.Reporting.TopSpendingCustomers" %>
<%@ MasterType VirtualPath="~/MasterPages/ReportMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
             Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content2" ContentPlaceHolderID="uxMainContent" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    
      
    <h1>TOP SPENDING CUSTOMERS</h1>
    <hr />
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                                ReportSourceID="TopSpendingCustomerReportSource" 
                                AutoDataBind="True" 
                                ToolPanelView="None"
                                Height="50px" 
                                Width="100%" />
    <CR:CrystalReportSource ID="TopSpendingCustomerReportSource" runat="server"/>
</asp:Content>