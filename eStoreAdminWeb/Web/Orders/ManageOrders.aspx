<%--
/*
 * The MIT License
 *
 * Copyright (c) 2008-2013, Andrew Gray
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
 --%>
<%@ Page Title="Manage Orders" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master"
    AutoEventWireup="true" CodeBehind="ManageOrders.aspx.cs" Inherits="eStoreAdminWeb.ManageOrders" %>

<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>
<%@ Register TagPrefix="yesNoAll" TagName="YesNoAllDDL" Src="~/Controls/YesNoAllDDL.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~/StyleSheets/humanity/jquery-ui-1.10.0.custom.min.css") %>" />
    <script type="text/javascript" src="<%=ResolveUrl("~/js/jquery-1.9.0.min.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/js/jquery-ui-1.10.0.custom.min.js") %>"></script>
    <script type="text/javascript">
        $(function () {
            // Datepicker
            $("#<%=OrderDateDatePicker.ClientID%>").datepicker({ dateFormat: "dd-mm-yy" });
            $("#<%=ShipDateDatePicker.ClientID%>").datepicker({ dateFormat: "dd-mm-yy" });
            $("#<%=OrderDateFromDatePicker.ClientID%>").datepicker({ dateFormat: "dd-mm-yy" });
            $("#<%=OrderDateToDatePicker.ClientID%>").datepicker({ dateFormat: "dd-mm-yy" });
            $("#<%=ShipDateFromDatePicker.ClientID%>").datepicker({ dateFormat: "dd-mm-yy" });
            $("#<%=ShipDateToDatePicker.ClientID%>").datepicker({ dateFormat: "dd-mm-yy" });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if(SessionHandler.isSessionTimedOut(Context, Page)) { %>
    <%FormsAuthentication.RedirectToLoginPage();
      } %>
    <h1>Manage Orders</h1>
    <fieldset class="CheckOut">
        <legend>Search Criteria</legend>
        <table id="SearchParamsTable1" style="font-size: smaller">
            <tr>
                <td valign="top">
                    <table>
                        <tr>
                            <td>
                                <h2>Billing Details</h2>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="BillingFirstNameLabel" AssociatedControlID="BillingFirstNameTextBox"
                                    runat="server" Text="First Name" />
                            </td>
                            <td>
                                <asp:TextBox ID="BillingFirstNameTextBox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="BillingLastNameLabel" AssociatedControlID="BillingLastNameTextBox"
                                    runat="server" Text="Last Name" />
                            </td>
                            <td>
                                <asp:TextBox ID="BillingLastNameTextBox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="EmailLabel" AssociatedControlID="EmailTextBox" runat="server" Text="Email" />
                            </td>
                            <td>
                                <asp:TextBox ID="EmailTextBox" Columns="50" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="BillingAddressLabel" AssociatedControlID="BillingAddressTextBox" runat="server"
                                    Text="Address" />
                            </td>
                            <td>
                                <asp:TextBox ID="BillingAddressTextBox" Columns="50" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="BillingSuburbCityLabel" AssociatedControlID="BillingSuburbCityTextBox"
                                    runat="server" Text="Suburb/City" />
                            </td>
                            <td>
                                <asp:TextBox ID="BillingSuburbCityTextBox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="BillingZipPostcodeLabel" AssociatedControlID="BillingZipPostcodeTextBox"
                                    runat="server" Text="Zip/Postcode" />
                            </td>
                            <td>
                                <asp:TextBox ID="BillingZipPostcodeTextBox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="BillingStateProvinceRegionLabel" AssociatedControlID="BillingStateProvinceRegionTextBox"
                                    runat="server" Text="State/Region" />
                            </td>
                            <td>
                                <asp:TextBox ID="BillingStateProvinceRegionTextBox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="BillingCountryLabel" AssociatedControlID="BillingCountryDropDownList"
                                    runat="server" Text="Country" />
                            </td>
                            <td>
                                <asp:DropDownList ID="BillingCountryDropDownList" runat="server" 
                                                  DataSourceID="CountriesODS"
                                                  DataTextField="Name" 
                                                  DataValueField="ID" 
                                                  AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="CountriesODS" runat="server" 
                                                      TypeName="eStoreAdminBLL.CountriesBLL"
                                                      OldValuesParameterFormatString="original_{0}" 
                                                      SelectMethod="GetCountries">
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <table>
                        <tr>
                            <td>
                                <h2>Shipping Details</h2>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="ShippingFirstNameLabel" runat="server"
                                           AssociatedControlID="ShippingFirstNameTextBox"
                                           Text="First Name" />
                            </td>
                            <td>
                                <asp:TextBox ID="ShippingFirstNameTextBox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="ShippingLastNameLabel" runat="server"
                                           AssociatedControlID="ShippingLastNameTextBox"
                                           Text="Last Name" />
                            </td>
                            <td>
                                <asp:TextBox ID="ShippingLastNameTextBox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="ShippingAddressLabel" AssociatedControlID="ShippingAddressTextBox"
                                    runat="server" Text="Address" />
                            </td>
                            <td>
                                <asp:TextBox ID="ShippingAddressTextBox" Columns="50" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="ShippingSuburbCityLabel" AssociatedControlID="ShippingSuburbCityTextBox"
                                    runat="server" Text="Suburb/City" />
                            </td>
                            <td>
                                <asp:TextBox ID="ShippingSuburbCityTextBox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="ShippingZipPostcodeLabel" AssociatedControlID="ShippingZipPostcodeTextBox"
                                    runat="server" Text="Zip/Postcode" />
                            </td>
                            <td>
                                <asp:TextBox ID="ShippingZipPostcodeTextBox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="ShippingStateProvinceRegionLabel" AssociatedControlID="ShippingStateProvinceRegionTextBox"
                                    runat="server" Text="State/Region" />
                            </td>
                            <td>
                                <asp:TextBox ID="ShippingStateProvinceRegionTextBox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="ShippingCountryLabel" AssociatedControlID="ShippingCountryDropDownList"
                                    runat="server" Text="Country" />
                            </td>
                            <td>
                                <asp:DropDownList ID="ShippingCountryDropDownList" runat="server" 
                                                  DataSourceID="CountriesODS"
                                                  DataTextField="Name" 
                                                  DataValueField="ID" 
                                                  AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="ShippingModeLabel" AssociatedControlID="ShippingModeDropDownList"
                                    runat="server" Text="Shipping Mode" />
                            </td>
                            <td>
                                <asp:DropDownList ID="ShippingModeDropDownList" runat="server" 
                                                  DataTextField="Name"
                                                  DataValueField="ID" 
                                                  DataSourceID="ModesEDS" 
                                                  AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:EntityDataSource ID="ModesEDS" runat="server"
                                                      ConnectionString="name=eStoreEntities"
                                                      DefaultContainerName="eStoreAdminEntities"
                                                      EntitySetName="ShipToModes"
                                                      EnableFlattening="False" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="ShippingCostLabel" runat="server" 
                                           AssociatedControlID="ShippingCostTextBox"
                                           Text="Shipping Cost" />
                            </td>
                            <td>
                                <asp:TextBox ID="ShippingCostTextBox" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="ShippedLabel" runat="server" Text="Shipped?" />
                            </td>
                            <td colspan="6">
                                <yesNoAll:YesNoAllDDL ID="ShippedDDL" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <table>
                        <tr>
                            <td>
                                <h2>Other</h2>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="ApprovedLabel" runat="server" Text="Approved?" />
                            </td>
                            <td colspan="6">
                                <yesNoAll:YesNoAllDDL ID="ApprovedDDL" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="CommentLabel" runat="server" Text="Comment?" />
                            </td>
                            <td colspan="6">
                                <yesNoAll:YesNoAllDDL ID="CommentDDL" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="GiftTagLabel" runat="server" Text="Gift Tag?" />
                            </td>
                            <td colspan="6">
                                <yesNoAll:YesNoAllDDL ID="GiftTagDDL" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table id="SearchParamsTable2" style="font-size: smaller">
            <tr>
                <td>
                    <h2>Dates</h2>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="OrderDateLabel" runat="server" Text="Order Date" />
                </td>
                <td>
                    <asp:TextBox ID="OrderDateDatePicker" Width="60px" runat="server" />
                </td>
                <td>
                    <asp:Label ID="OrderDateRangeLabel" runat="server" Text="Order Date Range" />
                </td>
                <td><asp:TextBox ID="OrderDateFromDatePicker" Width="60px" runat="server" /></td>
                <td><asp:TextBox ID="OrderDateToDatePicker" Width="60px" runat="server" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ShipDateLabel" runat="server" Text="Ship Date" />
                </td>
                <td><asp:TextBox ID="ShipDateDatePicker" Width="60px" runat="server" /></td>
                <td>
                    <asp:Label ID="ShipDateRangeLabel" runat="server" Text="Ship Date Range" />
                </td>
                <td><asp:TextBox ID="ShipDateFromDatePicker" Width="60px" runat="server" /></td>
                <td><asp:TextBox ID="ShipDateToDatePicker" Width="60px" runat="server" /></td>
            </tr>
            
        </table>
    </fieldset>
    <asp:Button ID="SearchButton" Text="Search" OnClick="ProcessSearch" runat="server" />
    <asp:Button ID="ClearButton" Text="Clear" OnClick="ClearForm" runat="server" />
    <asp:UpdatePanel ID="SearchResultsUpdatePanel" runat="server">
        <ContentTemplate>
            <asp:GridView ID="SearchResultsGridView" runat="server" 
                          DataKeyNames="ID" 
                          AllowPaging="True"
                          PagerSettings-Mode="NumericFirstLast" 
                          PageSize="10" 
                          BackColor="White"
                          BorderColor="#999999" 
                          BorderStyle="None" 
                          BorderWidth="1px" 
                          CellPadding="3" 
                          Font-Size="Smaller"
                          GridLines="Vertical" 
                          HorizontalAlign="Center" 
                          OnRowCommand="SearchResultsGridView_RowCommand"
                          OnPageIndexChanging="SearchResultsGridView_PageIndexChanging">
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="ID" 
                                        DataNavigateUrlFormatString="AllDetails.aspx?ID={0}"
                                        Text="Customer" />
                    <asp:HyperLinkField DataNavigateUrlFields="ID" 
                                        DataNavigateUrlFormatString="OrderDetails.aspx?ID={0}"
                                        Text="Order Detail" />
                    <asp:HyperLinkField DataNavigateUrlFields="ID" 
                                        DataNavigateUrlFormatString="PaymentDetails.aspx?ID={0}"
                                        Text="Payment Details" />
                    <%--<asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="RefundButton" runat="server" 
                                        CausesValidation="false" 
                                        CommandName="RefundCustomer"
                                        Text="Refund" 
                                        Visible='<%# !IsRefunded(Eval("IsRefunded").ToString()) %>' 
                                        CommandArgument='<%# ((GridViewRow)Container).RowIndex %>'
                                        OnClientClick="return confirm('Are you sure you want to refund this order?')" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
            <asp:Label ID="NoResultsLabel" runat="server">No Results Found. Please change search criteria.</asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>