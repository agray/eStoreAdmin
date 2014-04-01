<%@ Page Title="Accounts Report" Language="C#" MasterPageFile="~/MasterPages/ReportMaster.Master" AutoEventWireup="true" CodeBehind="InventoryReOrder.aspx.cs" Inherits="eStoreAdminWeb.Web.Reporting.InventoryReOrder" %>
<%@ MasterType VirtualPath="~/MasterPages/ReportMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content2" ContentPlaceHolderID="uxMainContent" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>

      
    <h1>INVENTORY RE-ORDER</h1>
    <hr />
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                                ReportSourceID="InvReorderReportSource" 
                                AutoDataBind="True" 
                                ToolPanelView="None"
                                Height="50px" 
                                Width="100%" />
        
    <CR:CrystalReportSource ID="InvReorderReportSource" runat="server"/>
</asp:Content>