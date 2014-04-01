<%@ Page Title="Manage Customers" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageCustomers.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.Customers.ManageCustomers" %>
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
    <h1>Manage Customers</h1>
    <table>
        <tr>
            <td valign="top">
                <%--User Name filter:&nbsp;&nbsp;&nbsp;--%>
                <asp:HyperLink ID="ActiveCustomersHyperLink" runat="server" 
                               NavigateUrl="~/Web/Advanced/Customers/ActiveCustomers.aspx"
                               Text="Active" />
                <asp:HyperLink ID="LockedCustomersHyperLink" runat="server" 
                               NavigateUrl="~/Web/Advanced/Customers/LockedCustomers.aspx"
                               Text="Locked" />
                <asp:HyperLink ID="OnlineCustomersHyperLink" runat="server" 
                               NavigateUrl="~/Web/Advanced/Customers/OnlineCustomers.aspx"
                               Text="Online" />
                <dc:AlphaLinks runat="server" ID="AlphaLinks" />
                <br />
                <asp:GridView runat="server" ID="CustomersGridView" 
                              AutoGenerateColumns="False"
	                          GridLines="Vertical"
	                          CssClass="list"
	                          OnRowDataBound="CustomersGridView_RowDataBound">
                    <Columns>
	                    <asp:TemplateField>
		                    <HeaderTemplate>Full Name</HeaderTemplate>
		                    <ItemTemplate>
                                <asp:HyperLink ID="EditCustomerHyperlink" runat="server" 
                                               NavigateUrl='EditCustomer.aspx?username='/>
		                    </ItemTemplate>
	                    </asp:TemplateField>
	                    <asp:BoundField DataField="email" HeaderText="Email" />
	                    <asp:BoundField DataField="comment" HeaderText="Comments" />
	                    <asp:BoundField DataField="creationdate" HeaderText="Member Since" />
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
