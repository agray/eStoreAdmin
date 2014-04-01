<%@ Page Title="Administration - Login" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminLoginMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="eStoreAdminWeb.Authentication.LoginPage" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Login ID="Login" runat="server"
               TitleText="Please Login"
               BackColor="#F7F6F3" 
               BorderColor="#E6E2D8" 
               BorderPadding="4" 
               BorderStyle="Solid" 
               BorderWidth="1px" 
               Font-Names="Verdana" 
               ForeColor="#333333"
               TitleTextStyle-Font-Size="Medium"
               TitleTextStyle-BackColor="#5D7B9D"
               TitleTextStyle-Font-Bold="True" 
               TitleTextStyle-ForeColor="White"
               InstructionTextStyle-Font-Italic="true"
               InstructionTextStyle-ForeColor="Black"
               FailureTextStyle-Font-Bold="true"
               FailureTextStyle-ForeColor="Red"
               LoginButtonStyle-BackColor="#FFFBFF" 
               LoginButtonStyle-BorderColor="#CCCCCC"
               LoginButtonStyle-BorderStyle="Solid"
               LoginButtonStyle-BorderWidth="1px"
               LoginButtonStyle-Font-Names="Verdana"
               LoginButtonStyle-ForeColor="#284775"
               PasswordRecoveryText="Forgot your password?" 
               PasswordRecoveryUrl="~/Authentication/ForgottenPassword.aspx"
               OnAuthenticate="Login_Authenticate">
        <LoginButtonStyle BackColor="#FFFBFF" 
                          BorderColor="#CCCCCC" 
                          BorderWidth="1px" 
                          BorderStyle="Solid" 
                          Font-Names="Verdana" 
                          ForeColor="#284775" />
        <LayoutTemplate>
            <table border="0" 
                   cellpadding="4" 
                   cellspacing="0" 
                   style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table border="0" 
                               cellpadding="0">
                            <tr>
                                <td align="center" 
                                    colspan="2" 
                                    style="color:White;background-color:#5D7B9D;font-size:Medium;font-weight:bold;">
                                    Please Login</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server"
                                               Text="User Name:" 
                                               AssociatedControlID="UserName"/>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"/>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                                Text="*"
                                                                ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                                                ToolTip="User Name is required." ValidationGroup="Login"/>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" 
                                               Text="Password:"
                                               AssociatedControlID="Password"/>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"/>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server"
                                                                Text="*"
                                                                ControlToValidate="Password" 
                                                                ErrorMessage="Password is required." 
                                                                ToolTip="Password is required." 
                                                                ValidationGroup="Login"/>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;font-weight:bold;">
                                    <asp:Literal ID="FailureText" runat="server" 
                                                 EnableViewState="False"/>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="LoginButton" runat="server" BackColor="#FFFBFF" 
                                                BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" 
                                                Font-Names="Verdana" ForeColor="#284775" Text="Log In" 
                                                ValidationGroup="Login" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:HyperLink ID="PasswordRecoveryLink" runat="server" 
                                                   Text="Forgot your password?"
                                                   NavigateUrl="~/Authentication/ForgottenPassword.aspx"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <InstructionTextStyle Font-Italic="True" ForeColor="Black"/>
        <FailureTextStyle Font-Bold="True"/>
        <TitleTextStyle BackColor="#5D7B9D" 
                        Font-Size="Medium" 
                        Font-Bold="True" 
                        ForeColor="White"/>
    </asp:Login>
</asp:Content>