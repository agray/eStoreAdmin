<%@ Page Title="Manage Currencies" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageCurrencies.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.ManageCurrencies" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Manage Currencies</h1>
    
    <table width="100%">
        <tr>
            <td valign="top">
                <%--<%if (this.IsUpToDate())
                  { %>--%>
                    <font color="green"><b>Currencies up to date</b></font>
                <%--<%}
                  else
                  { %>--%>
                    <%--<font color="red"><b>Currencies Behind</b></font>--%>
                    <%--<asp:Button ID="CurrencyRateUpdate" runat="server"
                                Text="Update"
                                OnClick="UpdateCurrencies" />--%>
                <%--<%} %>--%>
                <asp:GridView ID="CurrenciesGridView" runat="server" 
                              DataSourceID="CurrenciesODS"
                              DataKeyNames="ID"
                              EnableViewState="False"
                              AutoGenerateColumns="False"
                              AllowPaging="True" 
                              AllowSorting="True"
                              PagerSettings-Mode="Numeric"
                              PageSize="20"
                              BackColor="White" 
                              BorderColor="#999999" 
                              BorderStyle="None" 
                              BorderWidth="1px" 
                              CellPadding="3" 
                              GridLines="Vertical" 
                              OnDataBound="CurrenciesGridView_DataBound">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                                        ReadOnly="True" SortExpression="ID" Visible="False" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Value" HeaderText="Value" SortExpression="Value" />
                        <asp:BoundField DataField="ExchangeRate" HeaderText="Exchange Rate" 
                                        SortExpression="ExchangeRate" />
                    </Columns>
                    <EmptyDataTemplate>
                        There are no Currencies.
                    </EmptyDataTemplate>
                </asp:GridView>
                     
                <asp:ObjectDataSource ID="CurrenciesODS" runat="server" 
                                      TypeName="eStoreAdminBLL.CurrenciesBLL"
                                      OldValuesParameterFormatString="original_{0}"
                                      SelectMethod="GetCurrencies">
                </asp:ObjectDataSource>
            </td>
            <td valign="top" align="right">
                <asp:FormView ID="CurrencyDetails" runat="server" 
                              DataSourceID="CurrencyODS"
                              DataKeyNames="ID" 
                              BackColor="White" 
                              BorderColor="#999999" 
                              BorderStyle="None" 
                              BorderWidth="1px" 
                              CellPadding="3" 
                              GridLines="Vertical" 
                              OnItemDeleted="CurrencyDetails_ItemDeleted" 
                              OnItemInserted="CurrencyDetails_ItemInserted" 
                              OnItemUpdated="CurrencyDetails_ItemUpdated">
                    <EditItemTemplate>
                        <table>
                            <tr>
                                <td>Name:</td>
                                <td><asp:TextBox ID="NameEditTextBox" runat="server" Text='<%# Bind("Name")%>' /></td>
                            </tr>
                            <tr>
                                <td>Value:</td>
                                <td><asp:TextBox ID="ValueEditTextBox" runat="server" Text='<%# Bind("Value")%>' /></td>
                            </tr>
                            <tr>
                                <td>Exchange Rate:</td>
                                <td><asp:TextBox ID="ExchangeRateEditTextBox" runat="server" Text='<%# Bind("ExchangeRate") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="ExchangeRFV" runat="server" 
                                                                ControlToValidate="ExchangeRateEditTextBox" 
                                                                ErrorMessage="Required" 
                                                                Display="Dynamic" />
                                    <asp:CompareValidator ID="ExchangeCheckFormat" runat="server" 
                                                          ControlToValidate="ExchangeRateEditTextBox" 
                                                          Operator="DataTypeCheck" 
                                                          Type="Double"
                                                          ErrorMessage="Illegal format for numeric"
                                                          Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="ExchangeREVNN" runat="server"
                                                                    ErrorMessage="Must be positive"
                                                                    ControlToValidate="ExchangeRateEditTextBox"
                                                                    ValidationExpression="[+]?([0-9]*\.)?[0-9]+"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" 
                                    CommandName="Update" Text="Update" />&nbsp;
                        <asp:Button ID="UpdateCancelButton" runat="server" 
                                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table>
                            <tr>
                                <td>Name:</td>
                                <td><asp:TextBox ID="NameAddTextBox" runat="server" Text='<%# Bind("Name")%>' /></td>
                            </tr>
                            <tr>
                                <td>Value:</td>
                                <td><asp:TextBox ID="ValueAddTextBox" runat="server" Text='<%# Bind("Value")%>' /></td>
                            </tr>
                            <tr>
                                <td>Exchange Rate:</td>
                                <td><asp:TextBox ID="ExchangeRateAddTextBox" runat="server" Text='<%# Bind("ExchangeRate") %>' /></td>
                            </tr>
                        </table>
                        <asp:Button ID="InsertButton" runat="server" CausesValidation="True" 
                                    CommandName="Insert" Text="Insert" />&nbsp;
                        <asp:Button ID="InsertCancelButton" runat="server" 
                                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>Name:</td>
                                <td><asp:Label ID="NameItemLabel" runat="server" Text='<%# Bind("Name") %>' /></td>
                            </tr>
                            <tr>
                                <td>Value:</td>
                                <td><asp:Label ID="ValueItemLabel" runat="server" Text='<%# Bind("Value") %>' />
                            </tr>
                            <tr>
                                <td>Exchange Rate:</td>
                                <td><asp:Label ID="ExchangeRateItemLabel" runat="server" 
                                        Text='<%# Bind("ExchangeRate") %>' /></td>
                            </tr>
                        </table>
                        <asp:Button ID="EditButton" runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit" />&nbsp;
                        <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" 
                                    CommandName="Delete" Text="Delete"
                                    OnClientClick="return confirm('Are you sure you want to delete this currency?')" />&nbsp;
                        <asp:Button ID="NewButton" runat="server" CausesValidation="False" 
                                    CommandName="New" Text="New" />
                    </ItemTemplate>
                </asp:FormView>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="CurrencyODS" runat="server" 
                          TypeName="eStoreAdminBLL.CurrenciesBLL" 
                          OldValuesParameterFormatString="original_{0}" 
                          InsertMethod="AddCurrency" 
                          SelectMethod="GetCurrencyById" 
                          UpdateMethod="UpdateCurrency"
                          DeleteMethod="DeleteCurrency">
        <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="value" Type="String" />
            <asp:Parameter Name="exchangeRate" Type="Double" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="CurrenciesGridView" DefaultValue="" Name="ID" 
                                  PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>      
        <UpdateParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="value" Type="String" />
            <asp:Parameter Name="exchangeRate" Type="Double" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
</asp:Content>