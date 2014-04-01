<%@ Page Title="Manage Access Rules" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageAccessRules.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.Users.ManageAccessRules" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="eStoreAdminWeb.Controls" %>
<%@ Import Namespace="System.Web.Configuration" %>
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
    <h1>Access Rules</h1>
    <table>
        <tr>
	        <td valign="top">
		        <p>
		        Use this page to manage access rules for your Web site. Rules are applied to folders, thus providing robust folder-level security enforced by the ASP.NET infrastructure. Rules are persisted as XML in each folder's Web.config file. <i>Page-level security and inner-page security are not handled using this tool &mdash; they are handled using specialized code that is available to the Web Developers.</i>
		        </p>
		        <table>
		        <tr>
			        <td valign="top" style="padding-right: 30px;">
				        <div class="treeview">
				        <asp:TreeView ID="FolderTree" runat="server" 
            					      OnSelectedNodeChanged="FolderTree_SelectedNodeChanged">
					        <RootNodeStyle ImageUrl="~/Images/System/folder.gif" />
					        <ParentNodeStyle ImageUrl="~/Images/System/folder.gif" />
					        <LeafNodeStyle ImageUrl="~/Images/System/folder.gif" />
					        <SelectedNodeStyle Font-Underline="true" 
					                           ForeColor="#A21818" />
				        </asp:TreeView>
				        </div> 
			        </td>

			        <td valign="top" style="padding-left: 30px; border-left: 1px solid #999;">
			        <asp:Panel ID="SecurityInfoSection" runat="server" 
			                   Visible="false">
				        <h2 id="TitleOne" runat="server"
				            class="alert" ></h2>
				        <p>
				        Rules are applied in order. The first rule that matches applies, and the permission in each rule overrides the permissions in all following rules. Use the Move Up and Move Down buttons to change the order of the selected rule. Rules that appear dimmed are inherited from the parent and cannot be changed at this level. 
				        </p>
        				
				        <asp:GridView ID="RulesGrid" runat="server" 
				                      AutoGenerateColumns="false"
				                      CssClass="list" 
				                      GridLines="none"
				                      OnRowDataBound="RowDataBound">
					        <Columns>
						        <asp:TemplateField HeaderText="Action">
							        <ItemTemplate>
								        <%# GetAction((AuthorizationRule)Container.DataItem) %>
							        </ItemTemplate>
						        </asp:TemplateField>
						        <asp:TemplateField HeaderText="Roles">
							        <ItemTemplate>
								        <%# GetRole((AuthorizationRule)Container.DataItem) %>
							        </ItemTemplate>
						        </asp:TemplateField>
						        <asp:TemplateField HeaderText="User">
							        <ItemTemplate>
								        <%# GetUser((AuthorizationRule)Container.DataItem) %>
							        </ItemTemplate>
						        </asp:TemplateField>
						        <asp:TemplateField HeaderText="Delete Rule">
							        <ItemTemplate>
								        <asp:Button ID="Button1" runat="server" Text="Delete Rule" CommandArgument="<%# (AuthorizationRule)Container.DataItem %>" OnClick="DeleteRule" OnClientClick="return confirm('Click OK to delete this rule.')" />
							        </ItemTemplate>
						        </asp:TemplateField>
						        <asp:TemplateField HeaderText="Move Rule">
							        <ItemTemplate>
								        <asp:Button ID="Button2" runat="server" Text="  Up  " CommandArgument="<%# (AuthorizationRule)Container.DataItem %>" OnClick="MoveUp" />
								        <asp:Button ID="Button3" runat="server" Text="Down" CommandArgument="<%# (AuthorizationRule)Container.DataItem %>" OnClick="MoveDown" />
							        </ItemTemplate>
						        </asp:TemplateField>
					        </Columns>
				        </asp:GridView>

				        <br />
				        <hr />
				        <h2 runat="server" id="TitleTwo" class="alert"></h2>
				        <b>Action:</b>
				        <asp:RadioButton ID="ActionDeny" runat="server" 
				                         GroupName="action" 
					                     Text="Deny" 
					                     Checked="true" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				        <asp:RadioButton ID="ActionAllow" runat="server" 
				                         GroupName="action" 
					                     Text="Allow" />
        				
				        <br /><br />
				        <b>Rule applies to:</b>
				        <br />
				        <asp:RadioButton ID="ApplyRole" runat="server"
				                         GroupName="applyto"
					                     Text="This Role:" 
					                     Checked="true" />
					    <userrole:UserRoleDDL ID="UserRolesDDL" runat="server"
                                              AppendDataBoundItems="true">
                            <Items>
                                <asp:ListItem>Select Role</asp:ListItem>
                            </Items>
                        </userrole:UserRoleDDL>
				        <br />
        					
				        <asp:RadioButton ID="ApplyUser" runat="server" 
				                         GroupName="applyto"
					                     Text="This User:" />
					    <user:UserDDL ID="UsersDDL" runat="server"
                                          AppendDataBoundItems="true">
                            <Items>
                                <asp:ListItem>Select User</asp:ListItem>
                            </Items>
                        </user:UserDDL>
				        <br />
        				
        				
				        <asp:RadioButton ID="ApplyAllUsers" runat="server" 
				                         GroupName="applyto"
					                     Text="All Users (*)"  />
				        <br />
        				
        				
				        <asp:RadioButton ID="ApplyAnonUser" runat="server" 
				                         GroupName="applyto"
					                     Text="Anonymous Users (?)"  />
				        <br /><br />
        				
				        <asp:Button ID="Button4" runat="server" 
				                    Text="Create Rule" 
				                    OnClick="CreateRule"
					                OnClientClick="return confirm('Click OK to create this rule.');" />
        					
				        <asp:Literal runat="server" ID="RuleCreationError"></asp:Literal>
			        </asp:Panel>
			        </td>
		        </tr>
		        </table>
	        </td>
        </tr>
    </table>
</asp:Content>