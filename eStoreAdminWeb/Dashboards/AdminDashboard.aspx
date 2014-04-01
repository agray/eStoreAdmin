<%@ Page Language="C#" MasterPageFile="~/MasterPages/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="eStoreAdminWeb.AdminDashboard" %>
<%@ MasterType VirtualPath="~/MasterPages/DashboardMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../StyleSheets/humanity/jquery-ui-1.10.0.custom.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.9.0.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.10.0.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $("#tabbedContent").tabs();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <asp:Image ID="HeadingImage" runat="server"
               ImageUrl="~/Images/System/DashboardHeading.gif"
               AlternateText="Welcome to eStore 6.0"
               CssClass="DashboardHeading" />
    <table width="100%">
        <tr>
            <td align="center">
                <asp:HyperLink ID="SettingsHyperLink" NavigateUrl="~/Web/Settings/SettingsAdminHome.aspx" runat="server">
                    <asp:Image ID="SettingsImage" runat="server"
                               ImageUrl="~/Images/System/SettingsOrangeIcon.gif"
                               AlternateText="Settings"/>
                </asp:HyperLink>
            </td>
            <td>
                <asp:Image ID="Image4" runat="server"
                           ImageUrl="~/Images/System/spacer.gif"
                           AlternateText=""
                           Width="1px"
                           Height="200px"
                           BorderWidth="0px" />
            </td>
            <td align="center">
                <asp:HyperLink ID="OrderManagementHyperLink" NavigateUrl="~/Web/Orders/OrderManagementHome.aspx" runat="server">
                    <asp:Image ID="OrderManagementImage" runat="server"
                               ImageUrl="~/Images/System/OrderManagementOrangeIcon.gif"
                               AlternateText="Order Management"/>
                </asp:HyperLink>
            </td>
            <td>
                <asp:Image ID="Image2" runat="server"
                           ImageUrl="~/Images/System/spacer.gif"
                           AlternateText=""
                           Width="1px"
                           Height="200px"
                           BorderWidth="0px" />
            </td>
            <td align="center">
                <asp:HyperLink ID="AdvancedHyperLink" NavigateUrl="~/Web/Advanced/AdvancedAdminHome.aspx" runat="server">
                    <asp:Image ID="AdvancedImage" runat="server"
                               ImageUrl="~/Images/System/AdvancedOrangeIcon.gif"
                               AlternateText="Advanced"/>
                </asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:HyperLink ID="EmailHyperLink" NavigateUrl="~/Web/Email/EmailHome.aspx" runat="server">
                    <asp:Image ID="EmailImage" runat="server"
                               ImageUrl="~/Images/System/EmailOrangeIcon.gif"
                               AlternateText="Email"/>
                </asp:HyperLink>
            </td>
            <td>
                <asp:Image ID="Image5" runat="server"
                           ImageUrl="~/Images/System/spacer.gif"
                           AlternateText=""
                           Width="1px"
                           Height="200px"
                           BorderWidth="0px" />
            </td>
            <td align="center" valign="top">
                <table>
	                <tr>
                        <td valign="top">
	                        <div id="tabbedContent">
	                            <ul>
                                    <li><a href="#tab1">Alerts</a></li>
                                    <li><a href="#tab2">Metrics</a></li>
                                </ul>
                                <div id="tab1">
                                    <asp:Literal runat="server">» Low Inventory: </asp:Literal><asp:Label ID="LowInventoryLabel" runat="server" /><br/>
                                    <asp:Literal runat="server">» Declined Transactions: </asp:Literal><asp:Label ID="DeclinedTransactionsLabel" runat="server" /><br/>
                                    <asp:Literal runat="server">» # Locked Out Users: </asp:Literal><asp:Label ID="LockedOutUsersLabel" runat="server" />
                                </div>
                                <div id="tab2">
                                    <asp:Literal runat="server">» Net Sales YTD: $</asp:Literal><asp:Label ID="NetSalesYTDLabel" runat="server" /><br/>
                                    <asp:Literal runat="server">» Net Sales MTD: $</asp:Literal><asp:Label ID="NetSalesMTDLabel" runat="server" /><br/>
                                    <asp:Literal runat="server">» Net Sales Today: $</asp:Literal><asp:Label ID="NetSalesTodayLabel" runat="server" /><br/>
                                    <asp:Literal runat="server">» # Total Orders: $</asp:Literal><asp:Label ID="TotalOrdersLabel" runat="server" /><br/>
                                    <asp:Literal runat="server">» # Total Orders MTD: $</asp:Literal><asp:Label ID="TotalOrdersMTDLabel" runat="server" /><br/>
                                    <br/>
                                    <asp:HyperLink ID="HyperLink1" runat="server"
                                                   CssClass="normalLink"
                                                   NavigateUrl="~/Web/Reporting/ReportsHome.aspx" 
                                                   Text="See more reports >>"/>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>   
        </tr>
    </table>
</asp:Content>