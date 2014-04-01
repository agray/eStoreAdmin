<%@ Page Title="Customer Details" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="AllDetails.aspx.cs" Inherits="eStoreAdminWeb.Web.Orders.AllDetails" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Customer Details</h1>
    
    <asp:HyperLink ID="AllDetailsHyperlinkTop" runat="server">Order Details</asp:HyperLink>
    <asp:HyperLink ID="PaymentDetailsHyperLinkTop" runat="server">Payment Details</asp:HyperLink>
    <asp:HyperLink ID="SearchResultsHyperlinkTop" runat="server">Return to Search</asp:HyperLink>
    <asp:FormView ID="AllDetailsFormView" runat="server" 
                  DataSourceID="OrderODS" 
                  DataKeyNames="ID" 
                  BackColor="White" 
                  BorderColor="#999999" 
                  BorderStyle="None" 
                  BorderWidth="1px" 
                  CellPadding="3" 
                  GridLines="Vertical"
                  HorizontalAlign="Center">
        <ItemTemplate>
            <table border="1">
                <tr>
                    <td style="background-color:Gray;"><b><font color="white">Email Address:</font></b></td>
                    <td><asp:Label ID="EmailAddressLabel" runat="server" Text='<%# Bind("EmailAddress")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Billing First Name:</font></b></td>
                    <td><asp:Label ID="BillingFirstNameLabel" runat="server" Text='<%# Bind("BillingFirstName") %>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Billing Last Name:</font></b></td>
                    <td><asp:Label ID="BillingLastNameLabel" runat="server" Text='<%# Bind("BillingLastName")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Billing Address:</font></b></td>
                    <td><asp:Label ID="BillingAddressLabel" runat="server" Text='<%# Bind("BillingAddress") %>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Billing Suburb City:</font></b></td>
                    <td><asp:Label ID="BillingSuburbCityLabel" runat="server" Text='<%# Bind("BillingSuburbCity")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Billing State Province Region:</font></b></td>
                    <td><asp:Label ID="BillingStateProvinceRegionLabel" runat="server" Text='<%# Bind("BillingStateProvinceRegion")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Billing Zip Postcode:</font></b></td>
                    <td><asp:Label ID="BillingZipPostcodeLabel" runat="server" Text='<%# Bind("BillingZipPostcode")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Billing Country:</font></b></td>
                    <td><asp:Label ID="BillingCountryLabel" runat="server" Text='<%# Bind("BillingCountry")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Shipping First Name:</font></b></td>
                    <td><asp:Label ID="ShippingFirstNameLabel" runat="server" Text='<%# Bind("ShippingFirstName")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Shipping Last Name:</font></b></td>
                    <td><asp:Label ID="ShippingLastNameLabel" runat="server" Text='<%# Bind("ShippingLastName")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Shipping Address:</font></b></td>
                    <td><asp:Label ID="ShippingAddressLabel" runat="server" Text='<%# Bind("ShippingAddress")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Shipping Suburb City:</font></b></td>
                    <td><asp:Label ID="ShippingSuburbCityLabel" runat="server" Text='<%# Bind("ShippingSuburbCity")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Shipping State Province Region:</font></b></td>
                    <td><asp:Label ID="ShippingSPRLabel" runat="server" Text='<%# Bind("ShippingStateProvinceRegion")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Shipping Postcode:</font></b></td>
                    <td><asp:Label ID="ShippingZipPostcodeLabel" runat="server" Text='<%# Bind("ShippingZipPostcode")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Shipping Country:</font></b></td>
                    <td><asp:Label ID="ShippingCountryLabel" runat="server" Text='<%# Bind("ShippingCountry")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Shipping Mode:</font></b></td>
                    <td><asp:Label ID="ShippingModeLabel" runat="server" Text='<%# Bind("ShippingMode")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Shipping Cost:</font></b></td>
                    <td><asp:Label ID="ShippingCostLabel" runat="server" 
                            Text='<%# Bind("ShippingCost", "{0:C}") %>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">CC Approval Status:</font></b></td>
                    <%if(this.IsApproved(AllDetailsFormView)) { %>
                        <td style="background-color:green">
                            <b><font color="white">Approved</font></b>
                        </td>
                    <%} else {%>
                        <td style="background-color:red">
                            <b><font color="white">Declined</font></b>
                        </td>
                    <%} %>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Ship Date:</font></b></td>
                    <td><asp:Label ID="ShipDateLabel" runat="server" Text='<%# Bind("ShipDate")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Order Date:</font></b></td>
                    <%if(!this.IsShipped() && IsApproved(AllDetailsFormView) && IsOld()) { %>
                        <td style="background-color:red">
                            <b><font color="white"><asp:Label ID="OrderDateLabel" runat="server" Text='<%# Bind("OrderDate")%>'/></font></b>
                        </td>
                    <%} else {%>
                        <td><asp:Label ID="Label1" runat="server" Text='<%# Bind("OrderDate")%>'/></td>
                    <%} %>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Comments:</font></b></td>
                    <td><asp:Label ID="CommentsLabel" runat="server" Text='<%# Bind("Comments")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Gift Tag:</font></b></td>
                    <td><asp:Label ID="GiftTagLabel" runat="server" Text='<%# Bind("GiftTag")%>'/></td>
                </tr>
            </table>
            <asp:Label ID="CCApprovalStatusLabel" runat="server" Text='<%# Bind("CCApprovalStatus")%>' Visible="false"/>
        </ItemTemplate>
    </asp:FormView>
    
    <asp:ObjectDataSource ID="OrderODS" runat="server" 
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetOrdersById" 
                          TypeName="eStoreAdminBLL.OrdersBLL">
        <SelectParameters>
            <asp:QueryStringParameter Name="orderID" QueryStringField="ID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>