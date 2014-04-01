<%@ Page Title="Manage Countries" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageCountries2.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.ManageCountries2" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="eStoreAdminWeb.Controls" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<%@ Register TagPrefix="zone" TagName="ZoneDDL" Src="~/Controls/ZoneDDL.ascx" %>
<%@ Register TagPrefix="currency" TagName="CurrencyDDL" Src="~/Controls/CurrencyDDL.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage();  
      } %>
    <h1>Manage Countries</h1>
    <table width="100%">
        <tr>
            <td valign="top">
                <asp:GridView ID="CountriesGridView" runat="server" 
                              DataKeyNames="ID" 
                              DataSourceID="CountriesODS" 
                              AutoGenerateColumns="False" 
                              BackColor="White" 
                              BorderColor="#999999" 
                              BorderStyle="None" 
                              BorderWidth="1px" 
                              CellPadding="3" 
                              GridLines="Vertical" 
                              OnDataBound="CountriesGridView_DataBound" 
                              AllowPaging="True" 
                              AllowSorting="True"
                              PageSize="20">
                    <EmptyDataTemplate>
                        There are no Countries.
                    </EmptyDataTemplate>
                    
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                                        ReadOnly="True" SortExpression="ID" Visible="False" />
                        <asp:BoundField DataField="CurrencyID" HeaderText="CurrencyID" 
                                        SortExpression="CurrencyID" Visible="False" />
                        <asp:BoundField DataField="ZoneID" HeaderText="ZoneID" SortExpression="ZoneID" 
                                        Visible="False" />
                        <asp:BoundField DataField="Zone" HeaderText="Zone" ReadOnly="True" 
                                        SortExpression="Zone" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="CountryCode" HeaderText="Country Code" 
                                        SortExpression="CountryCode" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="CountriesODS" runat="server" 
                                      TypeName="eStoreAdminBLL.CountriesBLL"
                                      OldValuesParameterFormatString="original_{0}" 
                                      SelectMethod="GetCountries">
                </asp:ObjectDataSource>
            </td>
            <td valign="top" align="right">
                <asp:FormView ID="CountryFormView" runat="server" 
                              DataSourceID="CountryODS" 
                              DataKeyNames="ID" 
                              BackColor="White" 
                              BorderColor="#999999" 
                              BorderStyle="None" 
                              BorderWidth="1px" 
                              CellPadding="3" 
                              GridLines="Vertical" 
                              OnItemDeleted="CountryFormView_ItemDeleted" 
                              OnItemInserted="CountryFormView_ItemInserted" 
                              OnItemUpdated="CountryFormView_ItemUpdated">
                    <EditItemTemplate>
                        <table>
                            <tr>
                                <td>Name:</td>
                                <td><asp:TextBox ID="ValueEditTextBox" runat="server" Text='<%# Bind("Name")%>' /></td>
                                <td><asp:RequiredFieldValidator ID="ValueEditRFV" runat="server" 
                                                                ControlToValidate="ValueEditTextBox" 
                                                                ErrorMessage="Required"
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="ValueEditREV" runat="server"
                                                                    ControlToValidate="ValueEditTextBox"
                                                                    ValidationExpression="^[a-zA-Z]*$"
                                                                    ValidationGroup="CountriesGroup"
                                                                    ErrorMessage="Invalid Country"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Country Code:</td>
                                <td><asp:TextBox ID="CountryCodeEditTextBox" runat="server" MaxLength="3" Text='<%# Bind("CountryCode") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="CountryCodeEditRFV" runat="server" 
                                                                ControlToValidate="CountryCodeEditTextBox" 
                                                                ErrorMessage="Required"
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="CountryCodeEditREV" runat="server"
                                                                    ControlToValidate="CountryCodeEditTextBox"
                                                                    ValidationExpression="^[a-zA-Z]*$"
                                                                    ValidationGroup="CountriesGroup"
                                                                    ErrorMessage="Invalid Country Code"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Currency:</td>
                                <td>
                                    <currency:CurrencyDDL ID="CurrencyEditDropDownList" runat="server"
                                                          SelectedValue='<%# Bind("CurrencyID") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>Zone:</td>
                                <td>
                                    <zone:ZoneDDL ID="ZoneEditDropDownList" runat="server"
                                                  SelectedValue='<%# Bind("ZoneID") %>' />
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" 
                                    CommandName="Update" Text="Update" />&nbsp;
                        <asp:Button ID="UpdateCancelButton" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table>
                            <tr>
                                <td>Name:</td>
                                <td><asp:TextBox ID="ValueAddTextBox" runat="server" Text='<%# Bind("Name")%>' /></td>
                                <td><asp:RequiredFieldValidator ID="ValueAddRFV" runat="server" 
                                                                ControlToValidate="ValueAddTextBox" 
                                                                ErrorMessage="Required"
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="ValueAddEditREV" runat="server"
                                                                    ControlToValidate="ValueAddTextBox"
                                                                    ValidationExpression="^[a-zA-Z]*$"
                                                                    ValidationGroup="CountriesGroup"
                                                                    ErrorMessage="Invalid Country"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Country Code:</td>
                                <td><asp:TextBox ID="CountryCodeAddTextBox" runat="server" Text='<%# Bind("CountryCode") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="CountryCodeAddRFV" runat="server" 
                                                                ControlToValidate="CountryCodeAddTextBox" 
                                                                ErrorMessage="Required"
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="CountryCodeAddREV" runat="server"
                                                                    ControlToValidate="CountryCodeAddTextBox"
                                                                    ValidationExpression="^[a-zA-Z]*$"
                                                                    ValidationGroup="CountriesGroup"
                                                                    ErrorMessage="Invalid Country Code"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Currency:</td>
                                <td>
                                    <currency:CurrencyDDL ID="CurrencyAddDropDownList" runat="server"
                                                          AppendDataBoundItems="true" 
                                                          SelectedValue='<%# Bind("CurrencyID") %>'>
                                        <Items>
                                            <asp:ListItem Text="" />
                                        </Items>
                                    </currency:CurrencyDDL>
                                </td>
                                <td><asp:RequiredFieldValidator ID="CurrencyAddRFV" runat="server" 
                                                                ControlToValidate="CurrencyAddDropDownList:CurrencyDropDownList" 
                                                                ErrorMessage="Required"
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Zone:</td>
                                <td>
                                    <zone:ZoneDDL ID="ZoneAddDropDownList" runat="server"
                                                  AppendDataBoundItems="true" 
                                                  SelectedValue='<%# Bind("ZoneID") %>'>
                                        <Items>
                                            <asp:ListItem Text="" />
                                        </Items>
                                    </zone:ZoneDDL>
                                                  
                                </td>
                                <td><asp:RequiredFieldValidator ID="ZoneAddRFV" runat="server" 
                                                                ControlToValidate="ZoneAddDropDownList:ZoneDropDownList" 
                                                                ErrorMessage="Required"
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="InsertButton" runat="server" CausesValidation="True" 
                                    CommandName="Insert" Text="Insert" />&nbsp;
                        <asp:Button ID="InsertCancelButton" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" Text="Cancel" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>Name:</td>
                                <td><asp:Label ID="NameItemLabel" runat="server" Text='<%# Bind("Name")%>' /></td>
                            </tr>
                            <tr>
                                <td>Country Code:</td>
                                <td><asp:Label ID="CountryCodeLabel" runat="server" 
                                               Text='<%# Bind("CountryCode") %>' /></td>
                            </tr>
                            <tr>
                                <td>Currency:</td>
                                <td><asp:Label ID="CurrencyLabel" runat="server" 
                                               Text='<%# Bind("Currency") %>' /></td>
                            </tr>
                            <tr>
                                <td>Zone:</td>
                                <td><asp:Label ID="ZoneItemLabel" runat="server" Text='<%# Bind("Zone")%>' /></td>
                            </tr>
                        </table>
                        <asp:Button ID="EditButton" runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit" />&nbsp;
                        <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" 
                                    CommandName="Delete" Text="Delete"
                                    OnClientClick="return confirm('Are you sure you want to delete this country?')" />&nbsp;
                        <asp:Button ID="NewButton" runat="server" CausesValidation="False" 
                                    CommandName="New" Text="New" />
                    </ItemTemplate>
                </asp:FormView>
            </td>
        </tr>
    </table>
    
    <asp:ObjectDataSource ID="CountryODS" runat="server" 
                          TypeName="eStoreAdminBLL.CountriesBLL" 
                          OldValuesParameterFormatString="original_{0}" 
                          InsertMethod="AddCountry" 
                          SelectMethod="GetCountryById" 
                          UpdateMethod="UpdateCountry"
                          DeleteMethod="DeleteCountry"
                          OnInserting="CountryODS_Inserting"
                          OnUpdating="CountryODS_Updating">
        <SelectParameters>
            <asp:ControlParameter ControlID="CountriesGridView" DefaultValue="" Name="ID" 
                                  PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
</asp:Content>