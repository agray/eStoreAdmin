<%@ Page Title="Manage Product Image" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageImage.aspx.cs" Inherits="eStoreAdminWeb.Web.Merchandise.Product.ManageImage" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="left">
                <h1>Manage <%=Request["ProdName"] %> Product</h1>
                <h2>Images</h2>
            </td>
            <td align="right" valign="top">
                <asp:HyperLink ID="BackToHyperlink" runat="server">
                    < Back to <%=Request["ProdName"] %> Product
                </asp:HyperLink>
            </td>
        </tr>
    </table>
    <hr />  
    <asp:ListView ID="ProductImageListView" runat="server" 
                    DataKeyNames="ID" 
                    DataSourceID="ImagesODS" 
                    GroupItemCount="4"
                    OnItemUpdated="ProductImageListView_ItemUpdated"
                    OnItemCommand="ProductImageListView_ItemCommand">
        <ItemTemplate>
            <div class="<%#getDivClass("Product", Eval("IsDefault").ToString(), false)%>">
                <asp:Image ID="ProductImage" runat="server"
                            ImageUrl='<%#Eval("imgPath")%>'
                            BorderWidth="0px"
                            Height="130px"
                            Width="150px"/>
                <p class="clear">
                    <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" 
                                    CommandName="Edit" 
                                    CommandArgument='<%#Eval("ID")%>' />
                    <asp:LinkButton ID="btnMakeDefault" runat="server" 
                                    Text="Make Image Default" 
                                    CommandName="MakeDefault"
                                    CommandArgument='<%#Eval("ID")%>'
                                    Visible='<%#setEditVisibility(Eval("IsDefault").ToString())%>' />
                    <asp:LinkButton ID="btnDelete" runat="server" 
                                    Text="Delete" 
                                    CommandName="Delete"
                                    CommandArgument='<%#Eval("ID")%>'
                                    Visible='<%#setEditVisibility(Eval("IsDefault").ToString())%>' />
                </p>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="<%#getDivClass("Category", Eval("IsDefault").ToString(), true)%>">
                <table>
                    <tr>
                        <td class="label">Name:</td>
                        <td><asp:TextBox ID="NameEditTextBox" runat="server" Text='<%# Bind("imgName")%>' /></td>
                        <td><asp:RequiredFieldValidator ID="NameEditRFV" runat="server" 
                                                        ControlToValidate="NameEditTextBox" 
                                                        ErrorMessage="Required"
                                                        ValidationGroup="ProductImageGroup"
                                                        Display="Dynamic" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Button ID="btnSave" runat="server" 
                                        CssClass="linkButton" 
                                        Text="Save" 
                                        CommandName="Update"
                                        CommandArgument='<%#Eval("ID")%>'
                                        ValidationGroup="ProductionImageGroup"
                                        CausesValidation="True"/>
                            <asp:Button ID="btnCancel" runat="server" 
                                        CssClass="linkButton" 
                                        Text="Cancel" 
                                        CommandName="Cancel"
                                        CausesValidation="False"/>
                        </td>
                    </tr>
                </table>
            </div>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <div>There are no images for this product. Add one.</div>
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
        <asp:HyperLink ID="AddImages" runat="server">Add Images</asp:HyperLink>
    </p>

    <asp:ObjectDataSource ID="ImagesODS" runat="server" 
                          TypeName="eStoreAdminBLL.ImagesBLL"
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetImagesByProductId"
                          UpdateMethod="UpdateImageName">
        <SelectParameters>
            <asp:QueryStringParameter Name="productID" 
                                      QueryStringField="ProdID" 
                                      Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>