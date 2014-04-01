<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.Users.ManageUsers" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<%@ Register TagPrefix="dc" TagName="AlphaLinks" Src="~/Controls/AlphaLinks.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Stylesheets/Users.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Manage Users</h1>
    <table>
        <%--<tr>
	        <th>Users by Name</th>
        </tr>--%>
        <tr>
            <td valign="top">
                <%--User Name filter:&nbsp;&nbsp;&nbsp;--%>
                <asp:HyperLink ID="ActiveUsersHyperLink" runat="server" 
                               NavigateUrl="~/Web/Advanced/Users/ActiveUsers.aspx"
                               Text="Active" />
                <asp:HyperLink ID="LockedUsersHyperLink" runat="server" 
                               NavigateUrl="~/Web/Advanced/Users/LockedUsers.aspx"
                               Text="Locked" />
                <asp:HyperLink ID="OnlineUsersHyperLink" runat="server" 
                               NavigateUrl="~/Web/Advanced/Users/OnlineUsers.aspx"
                               Text="Online" />
                <dc:AlphaLinks runat="server" ID="AlphaLinks" />
                <br />
                <asp:HyperLink ID="NewUserHyperLink" runat="server" 
                               NavigateUrl="~/Web/Advanced/Users/CreateUser.aspx"
                               Text="Create New" />
                <br /><br />
                <asp:GridView runat="server" ID="Users" 
                              AutoGenerateColumns="False"
	                          GridLines="Vertical">
                    <Columns>
	                    <asp:TemplateField>
		                    <HeaderTemplate>User Name</HeaderTemplate>
		                    <ItemTemplate>
		                        <a href="EditUser.aspx?username=<%# Eval("UserName") %>"><%# Eval("UserName") %></a>
		                    </ItemTemplate>
	                    </asp:TemplateField>
	                    <asp:BoundField DataField="email" HeaderText="Email" />
	                    <asp:BoundField DataField="comment" HeaderText="Comments" />
	                    <asp:BoundField DataField="creationdate" HeaderText="Create Date" />
	                    <asp:BoundField DataField="lastlogindate" HeaderText="Last Login Date" />
	                    <asp:BoundField DataField="lastactivitydate" HeaderText="Last Activity Date" />
	                    <asp:BoundField DataField="isapproved" HeaderText="Active?" />
	                    <asp:BoundField DataField="isonline" HeaderText="Online?" />
	                    <asp:BoundField DataField="islockedout" HeaderText="Locked Out?" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>