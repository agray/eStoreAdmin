<%@ Page Title="Manage Department" Language="C#" MasterPageFile="~/MasterPages/MerchandiseMaster.Master" AutoEventWireup="true" CodeBehind="ManageDepartment.aspx.cs" Inherits="eStoreAdminWeb.Web.Merchandise.Department.ManageDepartment" %>
<%@ MasterType VirtualPath="~/MasterPages/MerchandiseMaster.Master" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>
<%@ Import Namespace="phoenixconsulting.culture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <asp:UpdatePanel ID="DepartmentUpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left">
                        <h1>Manage <%=Request["DepName"]%> Department</h1>
                        <h2>Categories</h2>
                    </td>
                    <td align="right" valign="top">
                        <asp:HyperLink ID="BackToHyperlink1" runat="server">
                            < Back to All Departments
                        </asp:HyperLink>
                    </td>
                </tr>
            </table>
            <hr />
            <asp:ListView ID="CategoryList" runat="server" 
                            DataSourceID="CategoriesODS" 
                            DataKeyNames="ID" 
                            GroupItemCount="4"
                            OnItemDataBound="CategoryList_ItemDataBound"
                            OnItemCommand="CategoryList_ItemCommand"
                            OnItemDeleting="CategoryList_ItemDeleting"
                            OnItemUpdating="CategoryList_ItemUpdating">
                <ItemTemplate>
                    <div class="Category">
                        <asp:HyperLink ID="CategoryHyperLink"
                                        NavigateUrl='<%#constructNavigateURL(Eval("ID").ToString(), 
                                                                            Eval("Name").ToString())%>' runat="server">
                            <asp:Image ID="CategoryImage" runat="server"
                                        ImageUrl='<%#Eval("ImgPath")%>'
                                        AlternateText='<%#Eval("Name")%>'
                                        BorderWidth="0px"
                                        Height="130px"
                                        Width="150px"/>
                            <asp:Label ID="CategoryName" class="CategoryName" runat="server" Text='<%# Eval("Name") %>' />
                            <asp:Label ID="CategoryPrice" class="CategoryPrice" runat="server">from <%#SessionHandler.Instance.CurrencyValue + " " + CultureService.getConvertedPrice(Eval("MinPrice").ToString(), SessionHandler.Instance.CurrencyXRate, SessionHandler.Instance.CurrencyValue)%></asp:Label>
                        </asp:HyperLink>
                        <asp:Literal ID="ImageCount" runat="server" Text='<%# Eval("ImageCount") %>' Visible="false"/>
                        <asp:LinkButton ID="EditButton" runat="server" Text="Edit" CommandName="Edit" />
                        <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this category?')"/>
                        <asp:LinkButton ID="PickImageButton" runat="server" CommandName="ManageImage" CommandArgument='<%#Eval("ID") + "|" + Eval("Name")%>' Text="Pick Image" />
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <div class="Category Edit">
                        <table width="100%">
                            <tr>
                                <td class="label">Name:</td>
                                <td><asp:TextBox ID="NameEditTextBox" runat="server" Text='<%# Bind("Name")%>' /></td>
                                <td><asp:RequiredFieldValidator ID="NameEditRFV" runat="server" 
                                                                ControlToValidate="NameEditTextBox" 
                                                                ErrorMessage="Required"
                                                                ValidationGroup="CategoryGroup"
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td class="label">Description:</td>
                                <td><asp:TextBox ID="DescriptionEditTextBox" runat="server" Text='<%# Bind("Description")%>' /></td>
                                <td><asp:RequiredFieldValidator ID="DescriptionEditRFV" runat="server" 
                                                                ControlToValidate="DescriptionEditTextBox" 
                                                                ErrorMessage="Required"
                                                                ValidationGroup="CategoryGroup"
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
                        <asp:Button ID="btnSave" runat="server" CssClass="linkButton" Text="Save" CommandName="Update" ValidationGroup="CategoryGroup"/>
                        <asp:Button ID="btnCancel" runat="server" CssClass="linkButton" Text="Cancel" CommandName="Cancel" />
                    </div>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <div>There are no categories in this department yet. Add one.</div>
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
            <asp:ObjectDataSource ID="CategoriesODS" runat="server" 
                                  TypeName="eStoreAdminBLL.CategoriesBLL" 
                                  OldValuesParameterFormatString="original_{0}" 
                                  SelectMethod="GetCategoriesByDepartmentIdAndCurrencyId" 
                                  UpdateMethod="UpdateCategory" 
                                  DeleteMethod="DeleteCategory">
                <DeleteParameters>
                    <asp:Parameter Name="original_ID" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="original_ID" Type="Int32" />
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="description" Type="String" />
                </UpdateParameters>
                <SelectParameters>
                    <asp:QueryStringParameter Name="departmentID" 
                                              QueryStringField="DepID" 
                                              Type="Int32" />
                    <asp:SessionParameter Name="currencyID" 
                                          SessionField="Currency" 
                                          Type="Int32" 
                                          DefaultValue="1"  />
                </SelectParameters>
            </asp:ObjectDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>