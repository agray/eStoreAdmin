<%@ Page Title="Manage Departments" Language="C#" MasterPageFile="~/MasterPages/MerchandiseMaster.Master" AutoEventWireup="true" CodeBehind="ManageDepartments.aspx.cs" Inherits="eStoreAdminWeb.Web.Merchandise.Departments.ManageDepartments" %>
<%@ MasterType VirtualPath="~/MasterPages/MerchandiseMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>
<%@ Import Namespace="System.Configuration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <asp:UpdatePanel ID="DepartmentsUpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <% if(DepartmentsList.Items.Count != 0) {%>
                <h1>Manage Departments</h1>
                <hr />
                <asp:ListView ID="DepartmentsList" runat="server" 
                              DataKeyNames="ID" 
                              DataSourceID="DepartmentsODS" 
                              GroupItemCount="4"
                              OnItemDataBound="DepartmentsList_ItemDataBound"
                              OnItemCommand="DepartmentsList_ItemCommand"
                              OnItemDeleting="DepartmentsList_ItemDeleting"
                              OnItemUpdated="DepartmentsList_ItemUpdated">
                    <ItemTemplate>
                        <div class="Department">
                            <asp:HyperLink ID="DepartmentHyperLink" runat="server"
                                           NavigateUrl='<%#"~/Web/Merchandise/Department/ManageDepartment.aspx?DepID=" + Eval("ID") + "&DepName=" + Eval("Name")%>'>
                                <asp:Image ID="DepartmentImage" runat="server"
                                           ImageUrl='<%#Eval("ImgPath")%>'
                                           AlternateText='<%#Eval("Name")%>'
                                           BorderWidth="0px"
                                           Height="130px"
                                           Width="150px"/>
                                <asp:Label ID="DepartmentName" class="DepartmentName" runat="server" Text='<%# Eval("Name") %>' />
                            </asp:HyperLink>
                            <asp:Literal ID="ImageCount" runat="server" Text='<%# Eval("ImageCount") %>' Visible="false"/>
                            <asp:LinkButton ID="EditButton" runat="server" Text="Edit" CommandName="Edit" />
                            <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this department?')"/>
                            <asp:LinkButton ID="PickImageButton" runat="server" CommandName="ManageImage" CommandArgument='<%#Eval("ID") + "|" + Eval("Name")%>' Text="Pick Image" />
                        </div>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <div class="Department Edit">
                            <table width="100%">
                                <tr>
                                    <td class="label">Name:</td>
                                    <td><asp:TextBox ID="NameEditTextBox" runat="server" Text='<%# Bind("Name")%>' /></td>
                                    <td><asp:RequiredFieldValidator ID="NameEditRFV" runat="server" 
                                                                    ControlToValidate="NameEditTextBox" 
                                                                    ErrorMessage="Required"
                                                                    ValidationGroup="DepartmentGroup"
                                                                    Display="Dynamic" />
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="2">SEO</th>
                                </tr>
                                <tr>
                                    <td class="label">Title:</td>
                                    <td><asp:TextBox ID="SEOTitleEditTextBox" runat="server" Text='<%# Bind("SEOTitle")%>' /></td>
                                </tr>
                                <tr>
                                    <td class="label">Keywords:</td>
                                    <td><asp:TextBox ID="SEOKeywordsEditTextBox" runat="server" Text='<%# Bind("SEOKeywords")%>' /></td>
                                </tr>
                                <tr>
                                    <td class="label">Description:</td>
                                    <td><asp:TextBox ID="SEODescEditTextBox" runat="server" Text='<%# Bind("SEODescription")%>' /></td>
                                </tr>
                                <tr>
                                    <td class="label">Friendly Name:</td>
                                    <td><asp:TextBox ID="SEOFriendlyNameURLEditTextBox" runat="server" Text='<%# Bind("SEOFriendlyNameURL")%>' /></td>
                                </tr>
                            </table>
                            <asp:Button ID="btnSave" runat="server" CssClass="linkButton" Text="Save" CommandName="Update"/>
                            <asp:Button ID="btnCancel" runat="server" CssClass="linkButton" Text="Cancel" CommandName="Cancel" />
                        </div>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <div>There are no departments. Add one.</div>
                    </EmptyDataTemplate>
                    <LayoutTemplate>
                        <div ID="groupPlaceholder" runat="server"></div>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <div ID="itemPlaceholder" runat="server"></div>
                    </GroupTemplate>
                </asp:ListView>
                <hr class="clear" />
                <p class="clear">
                    <asp:LinkButton ID="AddButton" runat="server" Text="Add New" OnClick="GoToAdd" />
                </p>
            <%} else { %>
                <h1>No Departments found. Add one.</h1>
            <%} %>
            <asp:ObjectDataSource ID="DepartmentsODS" runat="server" 
                                  TypeName="eStoreAdminBLL.DepartmentsBLL"
                                  OldValuesParameterFormatString="original_{0}"
                                  SelectMethod="GetDepartments"
                                  UpdateMethod="UpdateDepartment"
                                  DeleteMethod="DeleteDepartment"
                                  EnableCaching="False">
                <UpdateParameters>
                    <asp:Parameter Name="original_ID" Type="Int32" />
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="seoTitle" Type="String" />
                    <asp:Parameter Name="seoKeywords" Type="String" />
                    <asp:Parameter Name="seoDescription" Type="String" />
                    <asp:Parameter Name="seoFriendlyNameURL" Type="String" />
                </UpdateParameters>
                <DeleteParameters>
                    <asp:Parameter Name="original_ID" Type="Int32" />
                </DeleteParameters>
            </asp:ObjectDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>