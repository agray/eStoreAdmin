<%@ Page Title="Online Customers" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="OnlineCustomers.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.Customers.OnlineCustomers" %>
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
    <h1>Online Customers</h1>
    <table>
        <tr>
            <td valign="top">
                <br />
                <asp:GridView ID="OnlineCustomersGridView" runat="server" 
                              AutoGenerateColumns="false"
	                          CssClass="list" 
	                          AlternatingRowStyle-CssClass="odd" 
	                          GridLines="Vertical"
	                          AllowSorting="true"
	                          OnRowDataBound="OnlineCustomersGridView_RowDataBound">
                    <Columns>
	                    <asp:TemplateField>
		                    <HeaderTemplate>Full Name</HeaderTemplate>
		                    <ItemTemplate>
		                        <asp:HyperLink ID="OnlineCustomerHyperlink" runat="server" 
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
                        There are no online customers currently.
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>