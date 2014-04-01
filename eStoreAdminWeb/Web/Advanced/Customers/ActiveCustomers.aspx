﻿<%@ Page Title="Active Users" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ActiveCustomers.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.Customers.ActiveCustomers" %>
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
    <h1>Active / Inactive Customers</h1>
    <table>
        <tr>
            <td valign="top">
                <asp:DropDownList runat="server" ID="active" AutoPostBack="true">
                    <asp:ListItem>Active</asp:ListItem>
                    <asp:ListItem>Inactive</asp:ListItem>
                </asp:DropDownList>
                <br /><br />
                <asp:GridView ID="CustomersGridView" runat="server" 
                              AutoGenerateColumns="false"
	                          CssClass="list" 
	                          AlternatingRowStyle-CssClass="odd" 
	                          GridLines="Vertical"
	                          AllowSorting="true"
	                          OnRowDataBound="CustomersGridView_RowDataBound">
                    <Columns>
	                    <asp:TemplateField>
		                    <HeaderTemplate>User Name</HeaderTemplate>
		                    <ItemTemplate>
		                        <asp:HyperLink ID="CustomerHyperlink" runat="server" 
                                               NavigateUrl='EditCustomer.aspx?username='/>
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
                        There are no customers with that status currently.
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>