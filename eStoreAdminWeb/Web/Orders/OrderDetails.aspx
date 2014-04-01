<%@ Page Title="Manage Orders" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="eStoreAdminWeb.OrderDetails" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Order Details</h1>
    <asp:HyperLink ID="OrderDetailsHyperlinkTop" runat="server">Customer Details</asp:HyperLink>
    <asp:HyperLink ID="PaymentDetailsHyperLinkTop" runat="server">Payment Details</asp:HyperLink>
    <asp:HyperLink ID="SearchResultsHyperlinkTop" runat="server">Return to Search</asp:HyperLink>
    <asp:GridView ID="OrderDetailsGridView" runat="server" 
                  DataSourceID="OrderDetailsODS" 
                  DataKeyNames="ID" 
                  AllowPaging="True" 
                  AllowSorting="True" 
                  AutoGenerateColumns="False" 
                  BackColor="White" 
                  BorderColor="#999999" 
                  BorderStyle="None" 
                  BorderWidth="1px" 
                  CellPadding="3" 
                  GridLines="Vertical"
                  Font-Size="Small"
                  HorizontalAlign="Center" 
                  ShowFooter="True"
                  OnRowDataBound="OrderDetailsGridView_RowDataBound">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                            ReadOnly="True" SortExpression="ID" Visible="False"/>
            <asp:BoundField DataField="OrderID" HeaderText="OrderID" 
                            SortExpression="OrderID" Visible="False" />
            <asp:ImageField DataImageUrlField="DefaultImage" HeaderText="Picture">
            </asp:ImageField>
            <asp:BoundField DataField="Product" HeaderText="Product Name" 
                            SortExpression="Product" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                            SortExpression="Quantity" ItemStyle-HorizontalAlign="Center" >
            </asp:BoundField>
            <asp:BoundField DataField="UnitPrice" HeaderText="Price" 
                            SortExpression="UnitPrice" DataFormatString="{0:c}" />                                        
            <asp:BoundField DataField="TotalWeight" HeaderText="Weight (kg)" 
                            SortExpression="TotalWeight" />
        </Columns>
        <EmptyDataTemplate>
            There are no items in this Order. <!--Should never get this-->
        </EmptyDataTemplate>
    </asp:GridView>
    
    <%--<%if(!Roles.IsUserInRole("Staff")) { %>
        <asp:Button ID="RefundButton" runat="server" 
                    Text="Refund"
                    OnClick="RefundButton_Click"
                    OnClientClick="return confirm('Are you sure you want to refund this order?')" />
    <%} %>--%>
    
    
    <asp:ObjectDataSource ID="OrderDetailsODS" runat="server" 
                          TypeName="eStoreAdminBLL.OrdersBLL"
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetOrderDetailsByOrderId">
        <SelectParameters>
            <asp:QueryStringParameter Name="orderID" QueryStringField="ID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br/><br/>
    <%--<asp:Label Visible="false" ID="OrderID" runat="server" />--%>
    <asp:HyperLink ID="OrderDetailsHyperlinkBottom" runat="server">Customer Details</asp:HyperLink>
    <asp:HyperLink ID="PaymentDetailsHyperLinkBottom" runat="server">Payment Details</asp:HyperLink>
    <asp:HyperLink ID="SearchResultsHyperlinkBottom" runat="server">Return to Search</asp:HyperLink>
</asp:Content>