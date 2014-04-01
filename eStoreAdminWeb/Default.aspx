<%@ Page Title="Administration - Welcome" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="eStoreAdminWeb.Default" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>eStore Administration</h1>
    <asp:LoginView ID="LoginView1" runat="server">
        <%--<LoggedInTemplate>
            Welcome back
            <asp:LoginName ID="LoginName1" runat="server" />
            &nbsp;&nbsp;
            <br />
            <br />
            <a href="Authentication/ChangeMyPassword.aspx">Change my password</a>
        </LoggedInTemplate>--%>
        <AnonymousTemplate>
            You are not Logged in<br />
            <%--<br />
            <a href="Authentication/Login.aspx">Login</a><br />--%>
        </AnonymousTemplate>
    </asp:LoginView>
</asp:Content>