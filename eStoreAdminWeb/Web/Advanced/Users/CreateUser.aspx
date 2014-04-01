<%@ Page Title="Administration - Create New User" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.Users.CreateUser" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Stylesheets/Users.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Create New User</h1>
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
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
                          SideBarStyle-BackColor="#FFFBFF" 
                          SideBarStyle-BorderColor="#CCCCCC"
                          SideBarStyle-BorderStyle="Solid"
                          SideBarStyle-BorderWidth="1px"
                          SideBarnStyle-Font-Names="Verdana"
                          SideBarStyle-ForeColor="#284775"
                          SideBarButtonStyle-BackColor="#FFFBFF" 
                          SideBarButtonStyle-BorderColor="#CCCCCC"
                          SideBarButtonStyle-BorderStyle="Solid"
                          SideBarButtonStyle-BorderWidth="1px"
                          SideBarButtonStyle-Font-Names="Verdana"
                          SideBarButtonStyle-ForeColor="#284775"
                          ContinueButtonStyle-BackColor="#FFFBFF" 
                          ContinueButtonStyle-BorderColor="#CCCCCC"
                          ContinueButtonStyle-BorderStyle="Solid"
                          ContinueButtonStyle-BorderWidth="1px"
                          ContinueButtonStyle-Font-Names="Verdana"
                          ContinueButtonStyle-ForeColor="#284775"
                          NavigationButtonStyle-BackColor="#FFFBFF" 
                          NavigationButtonStyle-BorderColor="#CCCCCC"
                          NavigationButtonStyle-BorderStyle="Solid"
                          NavigationButtonStyle-BorderWidth="1px"
                          NavigationButtonStyle-Font-Names="Verdana"
                          NavigationButtonStyle-ForeColor="#284775"
                          CreateUserButtonStyle-BackColor="#FFFBFF" 
                          CreateUserButtonStyle-BorderColor="#CCCCCC"
                          CreateUserButtonStyle-BorderStyle="Solid"
                          CreateUserButtonStyle-BorderWidth="1px"
                          CreateUserButtonStyle-Font-Names="Verdana"
                          CreateUserButtonStyle-ForeColor="#284775"
                          HeaderStyle-BackColor="#FFFBFF" 
                          HeaderStyle-BorderColor="#CCCCCC"
                          HeaderStyle-BorderStyle="Solid"
                          HeaderStyle-BorderWidth="1px"
                          HeaderStyle-Font-Names="Verdana"
                          HeaderStyle-ForeColor="#284775"
                          StepStyle-BackColor="#FFFBFF" 
                          StepStyle-BorderColor="#CCCCCC"
                          StepStyle-BorderStyle="Solid"
                          StepStyle-BorderWidth="1px"
                          StepStyle-Font-Names="Verdana"
                          StepStyle-ForeColor="#284775"
                          OnCreatedUser="CreateUserWizard1_CreatedUser"
                          OnCreateUserError="CreateUserWizard1_CreateUserError">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server"
                                    AllowReturn="true">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
    
</asp:Content>