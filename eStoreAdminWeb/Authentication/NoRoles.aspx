<%@ Page Title="No Roles" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="NoRoles.aspx.cs" Inherits="eStoreAdminWeb.Authentication.NoRoles" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>No Roles!</h1>
To try again with another user, please return to the <asp:HyperLink ID="loginHyperlink" runat="server" 
                                                            Text="Login Page"
                                                            NavigateUrl="Login.aspx" />
</asp:Content>
