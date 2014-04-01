<%@ Page Title="Manage Roles" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageRoles.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.Users.ManageRoles" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Stylesheets/Users.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Roles</h1>
    <table>
        <tr>
            <td valign="top" style="width: 450px;">
                <asp:GridView ID="UserRoles" runat="server" 
                              AutoGenerateColumns="false"
	                          CssClass="list" 
	                          AlternatingRowStyle-CssClass="odd" 
	                          GridLines="none">
	                <Columns>
		                <asp:TemplateField>
			                <HeaderTemplate>Role Name</HeaderTemplate>
			                <ItemTemplate>
				                <%# Eval("Role Name") %>
			                </ItemTemplate>
		                </asp:TemplateField>
		                <asp:TemplateField>
			                <HeaderTemplate>User Count</HeaderTemplate>
			                <ItemTemplate>
				                <%# Eval("User Count") %>
			                </ItemTemplate>
		                </asp:TemplateField>
		                <asp:TemplateField>
			                <HeaderTemplate>Delete Role</HeaderTemplate>
			                <ItemTemplate>
				                <asp:Button ID="DeleteButton" runat="server" OnCommand="DeleteRole" CommandName="DeleteRole" CommandArgument='<%# Eval("Role Name") %>' Text="Delete" OnClientClick="return confirm('Are you sure?')" />
			                </ItemTemplate>
		                </asp:TemplateField>
	                </Columns>
	                <EmptyDataTemplate>
	                    There are no roles defined currently.
	                </EmptyDataTemplate>
                </asp:GridView>
                <p>
                    New Role:
                    <asp:TextBox runat="server" ID="NewRole" />
                    <asp:Button ID="Button2" runat="server" 
                                OnClick="AddRole" 
                                Text="Add Role" />
                </p>

                <div id="ConfirmationMessage" runat="server">
                </div>
            </td>
        </tr>
    </table>
</asp:Content>