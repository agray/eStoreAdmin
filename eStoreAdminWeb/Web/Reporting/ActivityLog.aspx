<%@ Page Title="Accounts Report" Language="C#" MasterPageFile="~/MasterPages/ReportMaster.Master" AutoEventWireup="true" CodeBehind="ActivityLog.aspx.cs" Inherits="eStoreAdminWeb.Web.Reporting.ActivityLog" %>
<%@ MasterType VirtualPath="~/MasterPages/ReportMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
<asp:Content ID="Content2" ContentPlaceHolderID="uxMainContent" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>

      
    <h1>ACTIVITY LOG</h1>
    <hr />
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                                ReportSourceID="ActivityLogReportSource" 
                                AutoDataBind="True" 
                                ToolPanelView="None"
                                Height="50px" 
                                Width="100%" />
        
    <CR:CrystalReportSource ID="ActivityLogReportSource" runat="server"/>
</asp:Content>