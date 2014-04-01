<%@ Page Language="C#" MasterPageFile="~/MasterPages/DashboardMaster.Master" AutoEventWireup="true" CodeBehind="StaffDashboard.aspx.cs" Inherits="eStoreAdminWeb.StaffDashboard" %>
<%@ MasterType VirtualPath="~/MasterPages/DashboardMaster.Master" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>
<%@ Import Namespace="eStoreAdminWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <asp:Image ID="HeadingImage" runat="server"
               ImageUrl="~/Images/System/DashboardHeading.gif"
               AlternateText="Welcome to eStore 6.0"
               CssClass="DashboardHeading" />
    
    <table width="100%">
        <tr>
            <td align="center">
                <asp:HyperLink ID="OrderManagementHyperLink" NavigateUrl="~/Web/Orders/ManageOrders.aspx" runat="server">
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
                <asp:HyperLink ID="EmailHyperLink" NavigateUrl="~/Web/Email/ManageEmails.aspx" runat="server">
                    <asp:Image ID="EmailImage" runat="server"
                               ImageUrl="~/Images/System/EmailOrangeIcon.gif"
                               AlternateText="Email"/>
                </asp:HyperLink>
            </td>
        </tr>        
    </table>
</asp:Content>