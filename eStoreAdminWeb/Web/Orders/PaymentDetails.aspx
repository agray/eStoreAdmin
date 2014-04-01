<%@ Page Title="Payment Details" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="PaymentDetails.aspx.cs" Inherits="eStoreAdminWeb.Web.Orders.PaymentDetails" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Payment Details</h1>
    <asp:HyperLink ID="AllDetailsHyperlinkTop" runat="server">Order Details</asp:HyperLink>
    <asp:HyperLink ID="CustomerDetailsHyperLinkTop" runat="server">Customer Details</asp:HyperLink>
    <asp:HyperLink ID="SearchResultsHyperlinkTop" runat="server">Return to Search</asp:HyperLink>
    <asp:FormView ID="PaymentDetailsFormView" runat="server" 
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
            <asp:Label ID="CCApprovalStatusLabel" runat="server" Text='<%# Bind("CCApprovalStatus")%>' Visible="false"/>
            <table border="1">
                <tr>
                    <td style="background-color:Gray"><b><font color="white">CC Approval Status:</font></b></td>
                    <%if(this.IsApproved(PaymentDetailsFormView)) { %>
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
                    <td style="background-color:Gray;"><b><font color="white">Transaction ID:</font></b></td>
                    <td><asp:Label ID="TxnIDLabel" runat="server" Text='<%# Bind("TxnID")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Settlement Date:</font></b></td>
                    <td><asp:Label ID="SettlementDateLabel" runat="server" Text='<%# Bind("SettlementDate") %>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">Refund PO #:</font></b></td>
                    <td><asp:Label ID="RefundPONumLabel" runat="server" Text='<%# Bind("RefundPONum")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">PayPal Ack:</font></b></td>
                    <td><asp:Label ID="PayPalAckLabel" runat="server" Text='<%# Bind("PayPal_Ack") %>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">PayPal Correlation ID:</font></b></td>
                    <td><asp:Label ID="PayPalCorrelationIDLabel" runat="server" Text='<%# Bind("PayPal_CorrelationID")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">PayPal TimeStamp:</font></b></td>
                    <td><asp:Label ID="PayPalTimeStampLabel" runat="server" Text='<%# Bind("PayPal_TimeStamp")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">PayPal Fee Amount:</font></b></td>
                    <td><asp:Label ID="PayPalFeeAmountLabel" runat="server" Text='<%# Bind("PayPal_FeeAmount")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">PayPal Payment Status:</font></b></td>
                    <td><asp:Label ID="PayPalPaymentStatusLabel" runat="server" Text='<%# Bind("PayPal_PaymentStatus")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">PayPal Reason Code:</font></b></td>
                    <td><asp:Label ID="PayPalReasonCodeLabel" runat="server" Text='<%# Bind("PayPal_ReasonCode")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">PayPal Payment Date:</font></b></td>
                    <td><asp:Label ID="PayPalPaymentDateLabel" runat="server" Text='<%# Bind("PayPal_PaymentDate")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">PayPal Net Of Fee:</font></b></td>
                    <td><asp:Label ID="PayPalNetOfFeeLabel" runat="server" Text='<%# Bind("PayPal_NetOfFee")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">PayPal Refund Transaction ID:</font></b></td>
                    <td><asp:Label ID="PayPalRefundTransactionIDLabel" runat="server" Text='<%# Bind("PayPal_RefundTransactionID")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">PayPal Fee Refund Amount:</font></b></td>
                    <td><asp:Label ID="PayPalFeeRefundAmountLabel" runat="server" Text='<%# Bind("PayPal_FeeRefundAmount")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">PayPal Gross Refund Amount:</font></b></td>
                    <td><asp:Label ID="PayPalGrossRefundAmountLabel" runat="server" Text='<%# Bind("PayPal_GrossRefundAmount")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">PayPal Net Refund Amount:</font></b></td>
                    <td><asp:Label ID="PayPalNetRefundAmountLabel" runat="server" Text='<%# Bind("PayPal_NetRefundAmount")%>'/></td>
                </tr>
                <tr>
                    <td style="background-color:Gray"><b><font color="white">PayPal Total Refunded Amount:</font></b></td>
                    <td><asp:Label ID="PayPalTotalRefundedAmountLabel" runat="server" Text='<%# Bind("PayPal_TotalRefundedAmount")%>'/></td>
                </tr>
            </table>
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