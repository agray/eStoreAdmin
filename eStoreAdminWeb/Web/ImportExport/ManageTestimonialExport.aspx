<%@ Page Title="Manage Testimonial Export" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageTestimonialExport.aspx.cs" Inherits="eStoreAdminWeb.Web.ImportExport.ManageTestimonialExport" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Download Testimonials</h1>
    <%--<asp:Button ID="ExportButton" runat="server" 
                Text="Export Testimonials"
                OnClick="exportData" />
    <asp:Button ID="CancelButton" runat="server" 
                Text="Cancel"
                OnClick="ReturnToHomePage" />--%>
</asp:Content>