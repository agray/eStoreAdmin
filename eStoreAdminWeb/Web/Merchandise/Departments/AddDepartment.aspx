<%@ Page Title="Add Department" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="AddDepartment.aspx.cs" Inherits="eStoreAdminWeb.Web.Merchandise.Departments.AddDepartment" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) {
        FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Add Department</h1>
    <asp:FormView ID="AddDepartmentFormView" runat="server"
                  DataSourceID="DepartmentODS" 
                  DataKeyNames="ID"
                  OnItemInserted="AddDepartmentFormView_ItemInserted">
        <InsertItemTemplate>
            <table width="100%">
                <tr>
                    <td>Name:</td>
                    <td><asp:TextBox ID="NameAddTextBox" runat="server" Text='<%# Bind("Name")%>' />
                        <asp:RequiredFieldValidator ID="NameAddRFV" runat="server" 
                                                    ControlToValidate="NameAddTextBox" 
                                                    ErrorMessage="Required"
                                                    ValidationGroup="DepartmentGroup"
                                                    Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <th colspan="2">SEO SETTINGS</th>
                </tr>
                <tr>
                    <td>Title:</td>
                    <td><asp:TextBox ID="SEOTitleAddTextBox" runat="server" Text='<%# Bind("SEOTitle")%>' /></td>
                </tr>
                <tr>
                    <td>Keywords:</td>
                    <td><asp:TextBox ID="SEOKeywordsAddTextBox" runat="server" Text='<%# Bind("SEOKeywords")%>' /></td>
                </tr>
                <tr>
                    <td>Description:</td>
                    <td><asp:TextBox ID="SEODescAddTextBox" runat="server" Text='<%# Bind("SEODescription")%>' /></td>
                </tr>
                <tr>
                    <td>Friendly Name:</td>
                    <td><asp:TextBox ID="SEOFriendlyNameURLAddTextBox" runat="server" Text='<%# Bind("SEOFriendlyNameURL")%>' /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" CssClass="linkButton" Text="Save" CommandName="Insert" ValidationGroup="DepartmentGroup" CausesValidation="True" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="linkButton" Text="Cancel" CommandName="Cancel" OnClick="Cancel_Click" CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </InsertItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="DepartmentODS" runat="server" 
                          TypeName="eStoreAdminBLL.DepartmentsBLL"
                          OldValuesParameterFormatString="original_{0}"
                          InsertMethod="AddDepartment" >
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="SEOTitle" Type="String" />
            <asp:Parameter Name="SEOKeywords" Type="String" />
            <asp:Parameter Name="SEOFriendlyNameURL" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
</asp:Content>
