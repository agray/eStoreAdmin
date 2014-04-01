<%@ Page Title="Manage Sizes" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageSizes.aspx.cs" Inherits="eStoreAdminWeb.Web.Merchandise.Product.ManageSizes" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <div style="float:left">
        <h1>Manage <%=Request["ProdName"]%> Sizes</h1>
    </div>
    <div style="float:right">
        <p>
            <asp:HyperLink ID="BackToHyperlink1" runat="server">
                < Back to <%=Request["ProdName"]%> Product
            </asp:HyperLink>
        </p>
    </div>
    <div style="clear:both" />
    <hr />
    <h2>Sizes</h2>
    <asp:ListView ID="SizeList" runat="server" 
                  DataSourceID="SizesODS" 
                  DataKeyNames="ID"
                  OnItemUpdated="SizeList_ItemUpdated"
                  OnItemDeleting="SizeList_ItemDeleting">
        <LayoutTemplate>
            <table width="50%" border="1">
                <thead>
                    <td>Brand</td>
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
            <td style="text-align:right">
                <asp:Button ID="btnEdit" runat="server" CssClass="linkButton" Text="Edit" CommandName="Edit" />
                <asp:Button ID="btnDelete" runat="server" CssClass="linkButton" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this item?')" />
            </td>
            <td style="text-align:left;width:75%">
                <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name")%>'/>
            </td>
        </ItemTemplate>
        <EditItemTemplate>
            <table width="50%" border="1">
                <tr>
                    <td style="text-align:right">
                        <asp:Button ID="btnSave" runat="server" CssClass="linkButton" Text="Save" CommandName="Update" ValidationGroup="DDLGroup"/>
                        <asp:Button ID="btnCancel" runat="server" CssClass="linkButton" Text="Cancel" CommandName="Cancel" />
                    </td>
                    <td style="text-align:left;width:75%">
                        <asp:TextBox ID="NameEditTextBox" runat="server" Text='<%# Bind("Name")%>' />
                        <asp:RequiredFieldValidator ID="NameEditRFV" runat="server" 
                                                        ControlToValidate="NameEditTextBox" 
                                                        ErrorMessage="Required"
                                                        ValidationGroup="DDLGroup"
                                                        Display="Dynamic" />
                    </td>
                </tr>
            </table>
        </EditItemTemplate>
    </asp:ListView>
    <hr />
    <asp:DetailsView ID="SizesDetailsView" runat="server" 
                        DataSourceID="SizesODS"
                        DataKeyNames="ID"
                        DefaultMode="Insert"
                        AutoGenerateRows="False"
                        OnItemInserted="SizesDetailsView_Inserted">
        <Fields>
            <asp:BoundField DataField="Name"/>
            <asp:CommandField InsertText="Add" CancelText="" ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
    <%--<asp:TextBox runat="server" ID="AddItemTextBox"/>
    <asp:RequiredFieldValidator ID="NameAddRFV" runat="server" 
                                    ControlToValidate="AddItemTextBox" 
                                    ErrorMessage="Required"
                                    ValidationGroup="AddItemGroup"
                                    Display="Dynamic" />
    <asp:Button ID="btnAdd" runat="server" 
                CssClass="linkButton" 
                Text="Add" 
                OnClick="AddNewItem" 
                ValidationGroup="AddItemGroup" />--%>
    <asp:ObjectDataSource ID="SizesODS" runat="server" 
                                      TypeName="eStoreAdminBLL.SizesBLL"
                                      OldValuesParameterFormatString="original_{0}" 
                                      SelectMethod="GetSizesByProductId"
                                      UpdateMethod="UpdateSize"
                                      DeleteMethod="DeleteSize"
                                      InsertMethod="AddSize">
        <SelectParameters>
            <asp:QueryStringParameter Name="productID" 
                                      QueryStringField="ProdID" Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:QueryStringParameter Name="productID" 
                                      QueryStringField="ProdID" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="name" Type="String" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
</asp:Content>
