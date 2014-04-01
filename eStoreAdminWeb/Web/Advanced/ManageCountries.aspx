<%@ Page Title="Manage Countries" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageCountries.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.ManageCountries" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<%@ Register TagPrefix="zone" TagName="ZoneDDL" Src="~/Controls/ZoneDDL.ascx" %>
<%@ Register TagPrefix="currency" TagName="CurrencyDDL" Src="~/Controls/CurrencyDDL_NoSIC.ascx" %>
<%@ Register TagPrefix="country" TagName="CountryDDL" Src="~/Controls/CountryDDL.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Manage Countries</h1>
    <asp:EntityDataSource ID="CountriesEDS" runat="server"
                          ConnectionString="name=eStoreEntities"
                          DefaultContainerName="eStoreAdminEntities"
                          Include="Zone,Currency"
                          EnableFlattening="False"
                          EnableInsert="True"
                          EnableUpdate="True"
                          EnableDelete="True"
                          EntitySetName="ShipToCountries"/>
    <asp:ListView ID="CountryList" runat="server" 
                  DataSourceID="CountriesEDS" 
                  DataKeyNames="ID"
                  OnItemUpdated="CountryList_ItemUpdated"
                  OnItemDeleting="CountryList_ItemDeleting">
        <LayoutTemplate>
            <table width="75%" border="1">
                <thead>
                    <td>Zone</td>
                    <td>Country</td>
                    <td>Country Code</td>
                    <td>Currency</td>
                    <td>Actions</td>
                </thead>
                <div ID="groupPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <GroupTemplate>
            <tr>
                <div ID="itemPlaceholder" runat="server" />
            </tr>
        </GroupTemplate>
        <EmptyDataTemplate>
            <div>There are no items in this list yet. Add one.</div>
        </EmptyDataTemplate>
        <ItemTemplate>
            <td style="text-align:left">
                <asp:Label ID="ZoneLabel" runat="server" Text='<%#Eval("Zone.Name")%>'/>
            </td>
            <td style="text-align:left">
                <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name")%>'/>
            </td>
            <td style="text-align:left">
                <asp:Label ID="CountryLabel" runat="server" Text='<%#Eval("CountryCode")%>'/>
            </td>
            <td style="text-align:left">
                <asp:Label ID="CurrencyLabel" runat="server" Text='<%#Eval("Currency.Name")%>'/>
            </td>
            <td style="text-align:right">
                <asp:Button ID="btnEdit" runat="server" CssClass="linkButton" Text="Edit" CommandName="Edit" />
                <asp:Button ID="btnDelete" runat="server" CssClass="linkButton" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this item?')" />
            </td>
        </ItemTemplate>
        <EditItemTemplate>
            <td>
                <zone:ZoneDDL ID="ZoneEditDropDownList" runat="server"
                              SelectedValue='<%# Bind("ZoneID") %>' />
            </td>
            <td>
                <country:CountryDDL ID="CountryEditDropDownList" runat="server"
                                    SelectedValue='<%# Bind("ID") %>'/>
                <asp:RequiredFieldValidator ID="CountryEditRFV" runat="server" 
                                            ControlToValidate="CountryEditDropDownList:CountryDropDownList" 
                                            InitialValue=""
                                            ErrorMessage="Required"
                                            ValidationGroup="EditGroup"
                                            Display="Dynamic" />
            </td>
            <td>
                <asp:TextBox ID="CountryCodeEditTextBox" runat="server" MaxLength="3" Text='<%# Bind("CountryCode") %>' /></td>
                <asp:RequiredFieldValidator ID="CountryCodeEditRFV" runat="server" 
                                            ControlToValidate="CountryCodeEditTextBox" 
                                            ErrorMessage="Required"
                                            ValidationGroup="EditGroup"
                                            Display="Dynamic" />
                <asp:RegularExpressionValidator ID="CountryCodeEditREV" runat="server"
                                                ControlToValidate="CountryCodeEditTextBox"
                                                ValidationExpression="^[a-zA-Z]*$"
                                                ValidationGroup="EditGroup"
                                                ErrorMessage="Invalid Country Code"
                                                Display="Dynamic" />
            </td>
            <td>
                <currency:CurrencyDDL ID="CurrencyEditDropDownList" runat="server"
                                      SelectedValue='<%# Bind("CurrencyID") %>' />
            </td>
            
            <td style="text-align:right">
                <asp:Button ID="btnSave" runat="server" CssClass="linkButton" Text="Save" CommandName="Update" ValidationGroup="DDLGroup"/>
                <asp:Button ID="btnCancel" runat="server" CssClass="linkButton" Text="Cancel" CommandName="Cancel" />
            </td>
        </EditItemTemplate>
    </asp:ListView>
    <hr />
    <zone:ZoneDDL ID="ZoneAddDropDownList" runat="server"
                  AppendDataBoundItems="true" 
                  SelectedValue='<%# Bind("ZoneID") %>'>
        <Items>
            <asp:ListItem Text="" />
        </Items>
    </zone:ZoneDDL>
    <asp:RequiredFieldValidator ID="ZoneAddRFV" runat="server" 
                                ControlToValidate="ZoneAddDropDownList:ZoneDropDownList" 
                                ErrorMessage="Required"
                                ValidationGroup="AddGroup"
                                Display="Dynamic" />
                                
    <country:CountryDDL ID="CountryAddDropDownList" runat="server"
                        AppendDataBoundItems="true">
        <Items>
            <asp:ListItem Text="" />
        </Items>
    </country:CountryDDL>
    <asp:RequiredFieldValidator ID="CountryAddRFV" runat="server" 
                                ControlToValidate="CountryAddDropDownList:CountryDropDownList" 
                                InitialValue=""
                                ErrorMessage="Required"
                                ValidationGroup="AddGroup"
                                Display="Dynamic" />
    <asp:TextBox runat="server" ID="AddCountryCodeTextBox" MaxLength="3"/>
    <asp:RequiredFieldValidator ID="CountryCodeAddRFV" runat="server" 
                                ControlToValidate="AddCountryCodeTextBox" 
                                ErrorMessage="Required"
                                ValidationGroup="AddGroup"
                                Display="Dynamic" />
    <currency:CurrencyDDL ID="CurrencyAddDropDownList" runat="server"
                          AppendDataBoundItems="true" 
                          SelectedValue='<%# Bind("CurrencyID") %>'>
        <Items>
            <asp:ListItem Text="" />
        </Items>
    </currency:CurrencyDDL>
    <asp:RequiredFieldValidator ID="CurrencyAddRFV" runat="server" 
                                ControlToValidate="CurrencyAddDropDownList:CurrencyDropDownList_NoSIC" 
                                ErrorMessage="Required"
                                ValidationGroup="AddGroup"
                                Display="Dynamic" />
    <asp:Button ID="btnAdd" runat="server" 
                CssClass="linkButton" 
                Text="Add" 
                OnClick="AddNewItem" 
                ValidationGroup="AddGroup" />
    <%--<asp:ObjectDataSource ID="CountriesODS" runat="server" 
                          TypeName="eStoreAdminBLL.CountriesBLL"
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="getCountries"
                          UpdateMethod="updateCountry"
                          DeleteMethod="deleteCountry">
        <UpdateParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="name" Type="String"/>
            <asp:Parameter Name="zoneID" Type="Int32" />
            <asp:Parameter Name="countryCode" Type="String" />
            <asp:Parameter Name="currencyID" Type="Int32" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>--%>
</asp:Content>
