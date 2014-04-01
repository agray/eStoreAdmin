<%@ Page Title="Most Frequent Customers Report" Language="C#" MasterPageFile="~/MasterPages/ReportMaster.Master" AutoEventWireup="true" CodeBehind="MostFrequentCustomers.aspx.cs" Inherits="eStoreAdminWeb.Web.Reporting.MostFrequentCustomers" %>
<%@ MasterType VirtualPath="~/MasterPages/ReportMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content2" ContentPlaceHolderID="uxMainContent" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>

      
    <h1>MOST FREQUENT CUSTOMERS</h1>
    <hr />
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                                ReportSourceID="MostFrequentCustomerReportSource" 
                                AutoDataBind="True" 
                                ToolPanelView="None"
                                Height="50px" 
                                Width="100%" />
    <CR:CrystalReportSource ID="MostFrequentCustomerReportSource" runat="server"/>
</asp:Content>