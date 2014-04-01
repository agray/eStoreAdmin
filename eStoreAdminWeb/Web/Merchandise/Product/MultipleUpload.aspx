<%@ Page Title="Upload Catalog Images" Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" CodeBehind="MultipleUpload.aspx.cs" Inherits="eStoreAdminWeb.MultipleUpload" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Upload Images to <%=Request["ProdName"]%> Product</h1>
    <asp:AjaxFileUpload ID="AjaxFileUpload1" runat="server"
                        AllowedFileTypes="gif,jpg,jpeg"
                        MaximumNumberOfFiles="10"
                        Width="400px" 
                        OnUploadComplete="AjaxFileUpload1_UploadComplete"/>
    <br/>
    <br/>
    <asp:Label ID="UploadStatusLabel" runat="server"/>
    <br />
    <br />
    <hr />
    <asp:HyperLink ID="BackToHyperlink" runat="server">
        < Back to <%=Request["ProdName"]%> Product Images
    </asp:HyperLink>
</asp:Content>