<%@ Page Title="Locked Users" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="LockedUsers.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.Users.LockedUsers" %>
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
    <h1>Locked Out Users</h1>
    <table>
        <tr>
            <td valign="top">
                <br />
                <asp:GridView ID="Users" runat="server" 
                              AutoGenerateColumns="false"
	                          CssClass="list" 
	                          AlternatingRowStyle-CssClass="odd" 
	                          GridLines="Vertical"
	                          AllowSorting="true">
                    <Columns>
	                    <asp:TemplateField>
		                    <HeaderTemplate>User Name</HeaderTemplate>
		                    <ItemTemplate>
		                        <a href="EditUser.aspx?username=<%# Eval("UserName") %>"><%# Eval("UserName") %></a>
		                    </ItemTemplate>
	                    </asp:TemplateField>
	                    <asp:BoundField DataField="email" HeaderText="Email" />
	                    <asp:BoundField DataField="comment" HeaderText="Comments" />
	                    <asp:BoundField DataField="creationdate" HeaderText="Creation Date" />
	                    <asp:BoundField DataField="lastlogindate" HeaderText="Last Login Date" />
	                    <asp:BoundField DataField="lastactivitydate" HeaderText="Last Activity Date" />
	                    <asp:BoundField DataField="isapproved" HeaderText="Is Active" />
	                    <asp:BoundField DataField="isonline" HeaderText="Is Online" />
	                    <asp:BoundField DataField="islockedout" HeaderText="Is Locked Out" />
                    </Columns>
                    <EmptyDataTemplate>
                        There are no locked users currently.
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>