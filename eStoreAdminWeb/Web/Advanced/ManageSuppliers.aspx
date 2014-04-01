<%@ Page Title="Manage Suppliers" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageSuppliers.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.ManageSuppliers" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<%@ Register TagPrefix="country" TagName="CountryDDL" Src="~/Controls/CountryDDL.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Manage Suppliers</h1>
    <asp:ListView ID="SupplierList" runat="server" 
                  DataSourceID="SuppliersODS" 
                  DataKeyNames="ID"
                  OnItemUpdated="SupplierList_ItemUpdated"
                  OnItemDeleting="SupplierList_ItemDeleting">
        <LayoutTemplate>
            <table border="1" style="font-size:smaller">
                <thead>
                    <td>Company Name</td>
                    <td>Contact Name</td>
                    <td>Business Phone</td>
                    <td>Mobile Phone</td>
                    <td>Email Address</td>
                    <td>Address</td>
                    <td>Suburb</td>
                    <td>State</td>
                    <td>Postcode</td>
                    <td>Country</td>
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
                <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("CompanyName")%>'/>
            </td>
            <td style="text-align:left">
                <%#Eval("ContactName")%>
            </td>
            <td style="text-align:left">
                <%#Eval("BusinessPhone")%>
            </td>
            <td style="text-align:left">
                <%#Eval("MobilePhone")%>
            </td>
            <td style="text-align:left">
                <%#Eval("EmailAddress")%>
            </td>
            <td style="text-align:left">
                <%#Eval("Address")%>
            </td>
            <td style="text-align:left">
                <%#Eval("CitySuburb")%>
            </td>
            <td style="text-align:left">
                <%#Eval("StateProvinceRegion")%>
            </td>
            <td style="text-align:left">
                <%#Eval("ZipPostcode")%>
            </td>
            <td style="text-align:left">
                <%#Eval("Country")%>
            </td>
            <td style="text-align:right">
                <asp:Button ID="btnEdit" runat="server" CssClass="linkButton" Text="Edit" CommandName="Edit" />
                <asp:Button ID="btnDelete" runat="server" CssClass="linkButton" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this item?')" />
            </td>
        </ItemTemplate>
        <EditItemTemplate>
            <td style="text-align:left;width:75%">
                <asp:TextBox ID="NameEditTextBox" runat="server" Text='<%# Bind("CompanyName")%>' />
                <asp:RequiredFieldValidator ID="NameEditRFV" runat="server" 
                                                ControlToValidate="NameEditTextBox" 
                                                ErrorMessage="Required"
                                                ValidationGroup="DDLGroup"
                                                Display="Dynamic" />
            </td>
            <td style="text-align:left;width:75%">
                <asp:TextBox ID="ContactNameEditTextBox" runat="server" Text='<%# Bind("ContactName")%>' />
                <asp:RequiredFieldValidator ID="ContactNameEditRFV" runat="server" 
                                                ControlToValidate="ContactNameEditTextBox" 
                                                ErrorMessage="Required"
                                                ValidationGroup="DDLGroup"
                                                Display="Dynamic" />
            </td>
            <td style="text-align:left;width:75%">
                <asp:TextBox ID="BusinessPhoneEditTextBox" runat="server" Text='<%# Bind("BusinessPhone")%>' />
                <asp:RequiredFieldValidator ID="BusinessPhoneEditRFV" runat="server" 
                                                ControlToValidate="BusinessPhoneEditTextBox" 
                                                ErrorMessage="Required"
                                                ValidationGroup="DDLGroup"
                                                Display="Dynamic" />
            </td>
            <td style="text-align:left;width:75%">
                <asp:TextBox ID="MobileEditTextBox" runat="server" Text='<%# Bind("MobilePhone")%>' />
                <asp:RequiredFieldValidator ID="MobileEditRFV" runat="server" 
                                                ControlToValidate="MobileEditTextBox" 
                                                ErrorMessage="Required"
                                                ValidationGroup="DDLGroup"
                                                Display="Dynamic" />
            </td>
            <td style="text-align:left;width:75%">
                <asp:TextBox ID="EmailEditTextBox" runat="server" Text='<%# Bind("EmailAddress")%>' />
                <asp:RequiredFieldValidator ID="EmailEditRFV" runat="server" 
                                                ControlToValidate="EmailEditTextBox" 
                                                ErrorMessage="Required"
                                                ValidationGroup="DDLGroup"
                                                Display="Dynamic" />
            </td>
            <td style="text-align:left;width:75%">
                <asp:TextBox ID="AddressEditTextBox" runat="server" Text='<%# Bind("Address")%>' />
                <asp:RequiredFieldValidator ID="AddressEditRFV" runat="server" 
                                                ControlToValidate="AddressEditTextBox" 
                                                ErrorMessage="Required"
                                                ValidationGroup="DDLGroup"
                                                Display="Dynamic" />
            </td>
            <td style="text-align:left;width:75%">
                <asp:TextBox ID="SuburbEditTextBox" runat="server" Text='<%# Bind("Suburb")%>' />
                <asp:RequiredFieldValidator ID="SuburbEditRFV" runat="server" 
                                                ControlToValidate="SuburbEditTextBox" 
                                                ErrorMessage="Required"
                                                ValidationGroup="DDLGroup"
                                                Display="Dynamic" />
            </td>
            <td style="text-align:left;width:75%">
                <asp:TextBox ID="StateEditTextBox" runat="server" Text='<%# Bind("State")%>' />
                <asp:RequiredFieldValidator ID="StateEditRFV" runat="server" 
                                                ControlToValidate="StateEditTextBox" 
                                                ErrorMessage="Required"
                                                ValidationGroup="DDLGroup"
                                                Display="Dynamic" />
            </td>
            <td style="text-align:left;width:75%">
                <asp:TextBox ID="PostcodeEditTextBox" runat="server" Text='<%# Bind("Postcode")%>' />
                <asp:RequiredFieldValidator ID="PostcodeEditRFV" runat="server" 
                                                ControlToValidate="PostcodeEditTextBox" 
                                                ErrorMessage="Required"
                                                ValidationGroup="DDLGroup"
                                                Display="Dynamic" />
            </td>
            <td style="text-align:left;width:75%">
                <country:CountryDDL ID="CountryEditDropDownList" runat="server"
                                    SelectedValue='<%# Bind("ID") %>'/>
                <asp:RequiredFieldValidator ID="CountryEditRFV" runat="server" 
                                            ControlToValidate="CountryEditDropDownList:CountryDropDownList" 
                                            InitialValue=""
                                            ErrorMessage="Required"
                                            ValidationGroup="EditGroup"
                                            Display="Dynamic" />
            </td>
            <td style="text-align:right">
                <asp:Button ID="btnSave" runat="server" CssClass="linkButton" Text="Save" CommandName="Update" ValidationGroup="DDLGroup"/>
                <asp:Button ID="btnCancel" runat="server" CssClass="linkButton" Text="Cancel" CommandName="Cancel" />
            </td>
        </EditItemTemplate>
    </asp:ListView>
    <hr />
    <table style="font-size:xx-small">
        <tr>
            <td>
                <asp:TextBox runat="server" ID="AddCompanyTextBox"/>
                <asp:RequiredFieldValidator ID="CompanyAddRFV" runat="server" 
                                            ControlToValidate="AddCompanyTextBox" 
                                            ErrorMessage="Required"
                                            ValidationGroup="AddItemGroup"
                                            Display="Dynamic" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="AddContactTextBox"/>
                <asp:RequiredFieldValidator ID="ContactAddRFV" runat="server" 
                                            ControlToValidate="AddContactTextBox" 
                                            ErrorMessage="Required"
                                            ValidationGroup="AddItemGroup"
                                            Display="Dynamic" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="TextBox1"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="AddContactTextBox" 
                                            ErrorMessage="Required"
                                            ValidationGroup="AddItemGroup"
                                            Display="Dynamic" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="TextBox2"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="AddContactTextBox" 
                                            ErrorMessage="Required"
                                            ValidationGroup="AddItemGroup"
                                            Display="Dynamic" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="TextBox3"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="AddContactTextBox" 
                                            ErrorMessage="Required"
                                            ValidationGroup="AddItemGroup"
                                            Display="Dynamic" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="TextBox4"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                            ControlToValidate="AddContactTextBox" 
                                            ErrorMessage="Required"
                                            ValidationGroup="AddItemGroup"
                                            Display="Dynamic" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="TextBox5"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                            ControlToValidate="AddContactTextBox" 
                                            ErrorMessage="Required"
                                            ValidationGroup="AddItemGroup"
                                            Display="Dynamic" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="TextBox6"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                            ControlToValidate="AddContactTextBox" 
                                            ErrorMessage="Required"
                                            ValidationGroup="AddItemGroup"
                                            Display="Dynamic" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="TextBox7"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                            ControlToValidate="AddContactTextBox" 
                                            ErrorMessage="Required"
                                            ValidationGroup="AddItemGroup"
                                            Display="Dynamic" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="TextBox8"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                            ControlToValidate="AddContactTextBox" 
                                            ErrorMessage="Required"
                                            ValidationGroup="AddItemGroup"
                                            Display="Dynamic" />
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" 
                            CssClass="linkButton" 
                            Text="Add" 
                            OnClick="AddNewItem" 
                            ValidationGroup="AddItemGroup" />
            </td>                        
        </tr>
    </table>


    
    <asp:ObjectDataSource ID="SuppliersODS" runat="server" 
                                      TypeName="eStoreAdminBLL.SuppliersBLL"
                                      OldValuesParameterFormatString="original_{0}" 
                                      SelectMethod="GetSuppliers"
                                      UpdateMethod="UpdateSupplier"
                                      DeleteMethod="DeleteSupplier">
        <UpdateParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="name" Type="String" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
</asp:Content>
