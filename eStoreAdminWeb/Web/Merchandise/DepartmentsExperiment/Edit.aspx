<%@ Page Title="Edit Department" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="eStoreAdminWeb.Web.Merchandise.Departments.EditDepartment" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Edit <%=Request["DepName"]%> Department</h1>
    <table>
        <tr>
            <td valign="top" align="right">
                <asp:FormView ID="DepartmentFormView" runat="server" 
                              DataSourceID="DepartmentODS"
                              DataKeyNames="ID" 
                              BackColor="White" 
                              BorderColor="#999999" 
                              BorderStyle="None" 
                              BorderWidth="1px" 
                              CellPadding="3" 
                              GridLines="Vertical"
                              DefaultMode="Edit">
                    <EditItemTemplate>
                        <table>
                            <tr>
                                <td>Name:</td>
                                <td><asp:TextBox ID="NameEditTextBox" runat="server" Text='<%# Bind("Name")%>' /></td>
                                <td><asp:RequiredFieldValidator ID="NameEditRFV" runat="server" 
                                                                ControlToValidate="NameEditTextBox" 
                                                                ErrorMessage="Required"
                                                                ValidationGroup="DepartmentGroup"
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="UpdateButton" runat="server" 
                                    CausesValidation="True" 
                                    CommandName="Update"
                                    ValidationGroup="DepartmentGroup"
                                    Text="Update" />&nbsp;
                        <asp:Button ID="UpdateCancelButton" runat="server" 
                                    CausesValidation="False" 
                                    CommandName="Cancel" 
                                    Text="Cancel" />
                    </EditItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="DepartmentODS" runat="server" 
                                      TypeName="eStoreAdminBLL.DepartmentsBLL"
                                      OldValuesParameterFormatString="original_{0}"
                                      SelectMethod="GetDepartmentById"
                                      UpdateMethod="UpdateDepartment">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="" Name="ID" QueryStringField="DepID" 
                            Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="original_ID" Type="Int32" />
                        <asp:Parameter Name="Name" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
