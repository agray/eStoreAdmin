<%@ Page Title="Access Rule Summary" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="AccessRuleSummary.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.Users.AccessRuleSummary" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<%@ Register TagPrefix="userrole" TagName="UserRoleDDL" Src="~/Controls/RoleDDL.ascx" %>
<%@ Reference Control="~/Controls/RoleDDL.ascx" %>
<%@ Register TagPrefix="user" TagName="UserDDL" Src="~/Controls/UserDDL.ascx" %>
<%@ Reference Control="~/Controls/UserDDL.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Stylesheets/Users.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Website Access Security Summary</h1>
    <table>
        <tr>
            <td class="details" valign="top">
		        <table>
		            <tr>
			            <td valign="top" style="padding-right: 30px;">
				             <userrole:UserRoleDDL ID="UserRolesDDL" runat="server"
                                                   AppendDataBoundItems="true"
                                                   AutoPostBack="true" 
					                               OnSelectedIndexChanged="DisplayRoleSummary">
                                <Items>
                                    <asp:ListItem>Select Role</asp:ListItem>
                                </Items>
                            </userrole:UserRoleDDL>
       				
				            &nbsp;&nbsp;&nbsp;&nbsp;<b>&mdash;&nbsp;&nbsp;OR&nbsp;&nbsp;&mdash;</b>
				            &nbsp;&nbsp;&nbsp;				
        				
        				    <user:UserDDL ID="UserDDL" runat="server"
                                          AppendDataBoundItems="true"
                                          AutoPostBack="true" 
		                                  OnSelectedIndexChanged="DisplayUserSummary">
                                <Items>
                                    <asp:ListItem>Select User</asp:ListItem>
				                    <asp:ListItem Text="Anonymous users (?)" Value="?"></asp:ListItem>
				                    <asp:ListItem Text="Authenticated users not in a role (*)" Value="*"></asp:ListItem>
                                </Items>
                            </user:UserDDL>
        				
				            <br />
        				
				            <div class="treeview">
				            <asp:TreeView runat="server" ID="FolderTree"
					                      OnSelectedNodeChanged="FolderTree_SelectedNodeChanged">
                                <RootNodeStyle ImageUrl="~/Images/System/folder.gif" />
					            <ParentNodeStyle ImageUrl="~/Images/System/folder.gif" />
					            <LeafNodeStyle ImageUrl="~/Images/System/folder.gif" />
					            <SelectedNodeStyle Font-Underline="true" ForeColor="#A21818" />
				            </asp:TreeView>
				            </div>
			            </td>
		            </tr>
		        </table>
	        </td>
        </tr>
    </table>
</asp:Content>