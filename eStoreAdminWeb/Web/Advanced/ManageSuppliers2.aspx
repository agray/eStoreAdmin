<%@ Page Title="Manage Suppliers" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageSuppliers2.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.ManageSuppliers2" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage();  
      } %>
    <h1>Manage Suppliers</h1>
    
    <table width="100%">
        <tr>
            <td valign="top">
                <asp:GridView ID="SuppliersGridView" runat="server" 
                              DataSourceID="SuppliersODS"
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
                              GridLines="Vertical" ondatabound="SuppliersGridView_DataBound">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                                        ReadOnly="True" SortExpression="ID" Visible="False" />
                        <asp:BoundField DataField="CompanyName" HeaderText="Company Name" 
                                        SortExpression="CompanyName" />
                        <asp:BoundField DataField="ContactName" HeaderText="Contact Name" 
                                        SortExpression="ContactName" />
                        <asp:BoundField DataField="BusinessPhone" HeaderText="BusinessPhone" 
                                        SortExpression="BusinessPhone" Visible="False" />
                        <asp:BoundField DataField="MobilePhone" HeaderText="MobilePhone" 
                                        SortExpression="MobilePhone" Visible="False" />
                        <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" 
                                        SortExpression="EmailAddress" Visible="False" />
                        <asp:BoundField DataField="Address" HeaderText="Address" 
                                        SortExpression="Address" Visible="False" />
                        <asp:BoundField DataField="CitySuburb" HeaderText="CitySuburb" 
                                        SortExpression="CitySuburb" Visible="False" />
                        <asp:BoundField DataField="StateProvinceRegion" 
                                        HeaderText="StateProvinceRegion" 
                                        SortExpression="StateProvinceRegion" Visible="False" />
                        <asp:BoundField DataField="ZipPostcode" HeaderText="ZipPostcode" 
                                        SortExpression="ZipPostcode" Visible="False" />
                        <asp:BoundField DataField="Country" HeaderText="Country" 
                                        SortExpression="Country" Visible="False" />
                    </Columns>
                    <EmptyDataTemplate>
                        There are no Suppliers.
                    </EmptyDataTemplate>
                </asp:GridView>
                
                <asp:ObjectDataSource ID="SuppliersODS" runat="server" 
                                      TypeName="eStoreAdminBLL.SuppliersBLL"
                                      OldValuesParameterFormatString="original_{0}" 
                                      SelectMethod="GetSuppliers">
                </asp:ObjectDataSource>
            </td>
            <td valign="top" align="right">
                <asp:FormView ID="SupplierFormView" runat="server" 
                              DataSourceID="SupplierODS"
                              DataKeyNames="ID" 
                              BackColor="White" 
                              BorderColor="#999999" 
                              BorderStyle="None" 
                              BorderWidth="1px" 
                              CellPadding="3" 
                              GridLines="Vertical" 
                              OnItemDeleted="SupplierFormView_ItemDeleted" 
                              OnItemInserted="SupplierFormView_ItemInserted" 
                              OnItemUpdated="SupplierFormView_ItemUpdated">
                    <EditItemTemplate>
                        <table>
                            <tr>
                                <td>Company Name:</td>
                                <td><asp:TextBox ID="CompanyNameEditTextBox" runat="server" Text='<%# Bind("CompanyName") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="CompanyNameEditRFV" runat="server" 
                                                                ControlToValidate="CompanyNameEditTextBox" 
                                                                ErrorMessage="Required" 
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Contact Name:</td>
                                <td><asp:TextBox ID="ContactNameEditTextBox" runat="server" Text='<%# Bind("ContactName") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="ContactNameEditRFV" runat="server" 
                                                                ControlToValidate="ContactNameEditTextBox" 
                                                                ErrorMessage="Required" 
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="ContactNameEditREV" runat="server"
                                                                    ControlToValidate="ContactNameEditTextBox"
                                                                    ValidationExpression="^[a-zA-Z ]*$"
                                                                    ValidationGroup="SuppliersGroup"
                                                                    ErrorMessage="Invalid Contact Name"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Business Phone:</td>
                                <td><asp:TextBox ID="BusinessPhoneEditTextBox" runat="server" MaxLength="10" Text='<%# Bind("BusinessPhone") %>' /></td>
                                <td><asp:CompareValidator ID="BusinessPhoneEditCheckFormat" runat="server" 
                                                          ControlToValidate="BusinessPhoneEditTextBox" 
                                                          Operator="DataTypeCheck" 
                                                          Type="Integer"
                                                          ErrorMessage="Illegal format for numeric"
                                                          Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Mobile Phone:</td>
                                <td><asp:TextBox ID="MobilePhoneEditTextBox" runat="server" MaxLength="10" Text='<%# Bind("MobilePhone") %>' /></td>
                                <td><asp:CompareValidator ID="MobilePhoneEditCheckFormat" runat="server" 
                                                          ControlToValidate="MobilePhoneEditTextBox"
                                                          Operator="DataTypeCheck"
                                                          Type="Integer"
                                                          ErrorMessage="Illegal format for numeric"
                                                          Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Email Address:</td>
                                <td><asp:TextBox ID="EmailAddressEditTextBox" runat="server" Text='<%# Bind("EmailAddress") %>' /></td>
                            </tr>
                            <tr>
                                <td>Address:</td>
                                <td><asp:TextBox ID="AddressEditTextBox" runat="server" Text='<%# Bind("Address") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="AddressEditRFV" runat="server" 
                                                                ControlToValidate="AddressEditTextBox" 
                                                                ErrorMessage="Required" 
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>City / Suburb:</td>
                                <td><asp:TextBox ID="CitySuburbEditTextBox" runat="server" Text='<%# Bind("CitySuburb") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="CitySuburbEditRFV" runat="server" 
                                                                ControlToValidate="CitySuburbEditTextBox" 
                                                                ErrorMessage="Required" 
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="CitySuburbEditREV" runat="server"
                                                                    ControlToValidate="CitySuburbEditTextBox"
                                                                    ValidationExpression="^[a-zA-Z ]*$"
                                                                    ValidationGroup="SuppliersGroup"
                                                                    ErrorMessage="Invalid Suburb"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>State:</td>
                                <td><asp:TextBox ID="StateEditTextBox" runat="server" Text='<%# Bind("StateProvinceRegion") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="StateEditRFV" runat="server" 
                                                                ControlToValidate="StateEditTextBox" 
                                                                ErrorMessage="Required" 
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="StateEditREV" runat="server"
                                                                    ControlToValidate="StateEditTextBox"
                                                                    ValidationExpression="^[a-zA-Z ]*$"
                                                                    ValidationGroup="SuppliersGroup"
                                                                    ErrorMessage="Invalid State"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Postcode:</td>
                                <td><asp:TextBox ID="PostcodeEditTextBox" runat="server" Text='<%# Bind("ZipPostcode") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="PostcodeEditRFV" runat="server" 
                                                                ControlToValidate="PostcodeEditTextBox" 
                                                                ErrorMessage="Required" 
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="PostcodeEditREV" runat="server"
                                                                    ControlToValidate="PostcodeEditTextBox"
                                                                    ValidationExpression="^[0-9]*$"
                                                                    ValidationGroup="SuppliersGroup"
                                                                    ErrorMessage="Invalid Postcode"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Country:</td>
                                <td><asp:TextBox ID="CountryEditTextBox" runat="server" Text='<%# Bind("Country") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="CountryEditRFV" runat="server" 
                                                                ControlToValidate="CountryEditTextBox" 
                                                                ErrorMessage="Required" 
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="CountryEditREV" runat="server"
                                                                    ControlToValidate="CountryEditTextBox"
                                                                    ValidationExpression="^[a-zA-Z\-]*$"
                                                                    ValidationGroup="SuppliersGroup"
                                                                    ErrorMessage="Invalid Country"
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
                                <td>Company Name:</td>
                                <td><asp:TextBox ID="CompanyNameAddTextBox" runat="server" Text='<%# Bind("CompanyName") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="CompanyNameAddRFV" runat="server" 
                                                                ControlToValidate="CompanyNameAddTextBox" 
                                                                ErrorMessage="Required" 
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Contact Name:</td>
                                <td><asp:TextBox ID="ContactNameAddTextBox" runat="server" Text='<%# Bind("ContactName") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="ContactNameAddRFV" runat="server" 
                                                                ControlToValidate="ContactNameAddTextBox" 
                                                                ErrorMessage="Required"
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="ContactNameAddREV" runat="server"
                                                                    ControlToValidate="ContactNameAddTextBox"
                                                                    ValidationExpression="^[a-zA-Z ]*$"
                                                                    ValidationGroup="SuppliersGroup"
                                                                    ErrorMessage="Invalid Contact Name"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Business Phone:</td>
                                <td><asp:TextBox ID="BusinessPhoneAddTextBox" runat="server" MaxLength="10" Text='<%# Bind("BusinessPhone") %>' /></td>
                                <td><asp:CompareValidator ID="BusinessPhoneAddCheckFormat" runat="server" 
                                                          ControlToValidate="BusinessPhoneAddTextBox" 
                                                          Operator="DataTypeCheck" 
                                                          Type="Integer"
                                                          ErrorMessage="Illegal format for numeric"
                                                          Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Mobile Phone:</td>
                                <td><asp:TextBox ID="MobilePhoneAddTextBox" runat="server" MaxLength="10" Text='<%# Bind("MobilePhone") %>' /></td>
                                <td><asp:CompareValidator ID="MobilePhoneAddCheckFormat" runat="server" 
                                                          ControlToValidate="MobilePhoneAddTextBox" 
                                                          Operator="DataTypeCheck" 
                                                          Type="Integer"
                                                          ErrorMessage="Illegal format for numeric"
                                                          Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Email Address:</td>
                                <td><asp:TextBox ID="EmailAddressAddTextBox" runat="server" Text='<%# Bind("EmailAddress") %>' /></td>
                            </tr>
                            <tr>
                                <td>Address:</td>
                                <td><asp:TextBox ID="AddressAddTextBox" runat="server" Text='<%# Bind("Address") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="AddressAddRFV" runat="server" 
                                                                ControlToValidate="AddressAddTextBox" 
                                                                ErrorMessage="Required" 
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>City / Suburb:</td>
                                <td><asp:TextBox ID="CitySuburbAddTextBox" runat="server" Text='<%# Bind("CitySuburb") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="CitySuburbAddRFV" runat="server" 
                                                                ControlToValidate="CitySuburbAddTextBox" 
                                                                ErrorMessage="Required" 
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="CitySuburbAddREV" runat="server"
                                                                    ControlToValidate="CitySuburbAddTextBox"
                                                                    ValidationExpression="^[a-zA-Z ]*$"
                                                                    ValidationGroup="SuppliersGroup"
                                                                    ErrorMessage="Invalid Suburb"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>State:</td>
                                <td><asp:TextBox ID="StateAddTextBox" runat="server" Text='<%# Bind("StateProvinceRegion") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="StateAddRFV" runat="server" 
                                                                ControlToValidate="StateAddTextBox" 
                                                                ErrorMessage="Required" 
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="StateAddREV" runat="server"
                                                                    ControlToValidate="StateAddTextBox"
                                                                    ValidationExpression="^[a-zA-Z ]*$"
                                                                    ValidationGroup="SuppliersGroup"
                                                                    ErrorMessage="Invalid State"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Postcode:</td>
                                <td><asp:TextBox ID="PostcodeAddTextBox" runat="server" Text='<%# Bind("ZipPostcode") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="PostcodeAddRFV" runat="server" 
                                                                ControlToValidate="PostcodeAddTextBox" 
                                                                ErrorMessage="Required" 
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="PostcodeAddREV" runat="server"
                                                                    ControlToValidate="PostcodeAddTextBox"
                                                                    ValidationExpression="^[0-9]*$"
                                                                    ValidationGroup="SuppliersGroup"
                                                                    ErrorMessage="Invalid Postcode"
                                                                    Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Country:</td>
                                <td><asp:TextBox ID="CountryAddTextBox" runat="server" Text='<%# Bind("Country") %>' /></td>
                                <td><asp:RequiredFieldValidator ID="CountryAddRFV" runat="server" 
                                                                ControlToValidate="CountryAddTextBox" 
                                                                ErrorMessage="Required" 
                                                                Display="Dynamic" />
                                    <asp:RegularExpressionValidator ID="CountryAddREV" runat="server"
                                                                    ControlToValidate="CountryAddTextBox"
                                                                    ValidationExpression="^[a-zA-Z\-]*$"
                                                                    ValidationGroup="SuppliersGroup"
                                                                    ErrorMessage="Invalid Country"
                                                                    Display="Dynamic" />
                                </td>
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
                                <td>Company Name:</td>
                                <td><%# Eval("CompanyName")%></td>
                            </tr>
                            <tr>
                                <td>Contact Name:</td>
                                <td><%# Eval("ContactName")%></td>
                            </tr>
                            <tr>
                                <td>Business Phone:</td>
                                <td><%# Eval("BusinessPhone")%></td>
                            </tr>
                            <tr>
                                <td>Mobile Phone:</td>
                                <td><%# Eval("MobilePhone")%></td>
                            </tr>
                            <tr>
                                <td>Email Address:</td>
                                <td><%# Eval("EmailAddress")%></td>
                            </tr>
                            <tr>
                                <td>Address:</td>
                                <td><%# Eval("Address")%></td>
                            </tr>
                            <tr>
                                <td>City / Suburb:</td>
                                <td><%# Eval("CitySuburb")%></td>
                            </tr>
                            <tr>
                                <td>State:</td>
                                <td><%# Eval("StateProvinceRegion")%></td>
                            </tr>
                            <tr>
                                <td>Postcode:</td>
                                <td><%# Eval("ZipPostcode")%></td>
                            </tr>
                            <tr>
                                <td>Country:</td>
                                <td><%# Eval("Country")%></td>
                            </tr>
                        </table>
                        <asp:Button ID="EditButton" runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit" />&nbsp;
                        <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" 
                                    CommandName="Delete" Text="Delete"
                                    OnClientClick="return confirm('Are you sure you want to delete this supplier?')" />&nbsp;
                        <asp:Button ID="NewButton" runat="server" CausesValidation="False" 
                                    CommandName="New" Text="New" />
                    </ItemTemplate>
                </asp:FormView>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="SupplierODS" runat="server"
                          TypeName="eStoreAdminBLL.SuppliersBLL"
                          OldValuesParameterFormatString="original_{0}"
                          InsertMethod="AddSupplier"  
                          SelectMethod="GetSupplierById"
                          UpdateMethod="UpdateSupplier"
                          DeleteMethod="DeleteSupplier">
        <InsertParameters>
            <asp:Parameter Name="companyName" Type="String" />
            <asp:Parameter Name="contactName" Type="String" />
            <asp:Parameter Name="businessPhone" Type="String" />
            <asp:Parameter Name="mobilePhone" Type="String" />
            <asp:Parameter Name="emailAddress" Type="String" />
            <asp:Parameter Name="address" Type="String" />
            <asp:Parameter Name="citySuburb" Type="String" />
            <asp:Parameter Name="stateProvinceRegion" Type="String" />
            <asp:Parameter Name="zipPostcode" Type="String" />
            <asp:Parameter Name="country" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="SuppliersGridView" DefaultValue="" Name="ID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="companyName" Type="String" />
            <asp:Parameter Name="contactName" Type="String" />
            <asp:Parameter Name="businessPhone" Type="String" />
            <asp:Parameter Name="mobilePhone" Type="String" />
            <asp:Parameter Name="emailAddress" Type="String" />
            <asp:Parameter Name="address" Type="String" />
            <asp:Parameter Name="citySuburb" Type="String" />
            <asp:Parameter Name="stateProvinceRegion" Type="String" />
            <asp:Parameter Name="zipPostcode" Type="String" />
            <asp:Parameter Name="country" Type="String" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
</asp:Content>
