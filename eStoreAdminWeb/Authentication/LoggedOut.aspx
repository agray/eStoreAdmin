<%@ Page Language="C#" MasterPageFile="~/MasterPages/eStoreAdminLoginMaster.Master" AutoEventWireup="true" CodeBehind="LoggedOut.aspx.cs" Inherits="eStoreAdminWeb.Authentication.LoggedOut" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Logged Out</h1>
    <p>
        You are now logged out of eStore Administration.<br />
        To log back in, please return to the <asp:HyperLink ID="logoutHyperlink" runat="server" 
                                                            Text="Login Page"
                                                            NavigateUrl="Login.aspx" />.
    </p>
</asp:Content>