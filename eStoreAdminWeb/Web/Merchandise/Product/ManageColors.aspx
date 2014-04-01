<%@ Page Title="Manage Colors" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageColors.aspx.cs" Inherits="eStoreAdminWeb.Web.Merchandise.Product.ManageColors" %>
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
        <h1>Manage <%=Request["ProdName"]%> Colors</h1>
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
    <h2>Colors</h2>
    <asp:ListView ID="ColorList" runat="server" 
                  DataSourceID="ColorsODS" 
                  DataKeyNames="ID"
                  OnItemUpdated="ColorList_ItemUpdated"
                  OnItemDeleting="ColorList_ItemDeleting">
        <LayoutTemplate>
            <table width="50%" border="1">
                <thead>
                    <td>Color</td>
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
            <td style="text-align:left;width:75%">
                <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name")%>'/>
            </td>
            <td style="text-align:right">
                <asp:Button ID="btnEdit" runat="server" CssClass="linkButton" Text="Edit" CommandName="Edit" />
                <asp:Button ID="btnDelete" runat="server" CssClass="linkButton" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this item?')" />
            </td>
        </ItemTemplate>
        <EditItemTemplate>
            <table width="50%" border="1">
                <tr>
                    <td style="text-align:left;width:75%">
                        <asp:TextBox ID="NameEditTextBox" runat="server" Text='<%# Bind("Name")%>' />
                        <asp:RequiredFieldValidator ID="NameEditRFV" runat="server" 
                                                        ControlToValidate="NameEditTextBox" 
                                                        ErrorMessage="Required"
                                                        ValidationGroup="DDLGroup"
                                                        Display="Dynamic" />
                    </td>
                    <td style="text-align:right">
                        <asp:Button ID="btnSave" runat="server" CssClass="linkButton" Text="Save" CommandName="Update" ValidationGroup="DDLGroup"/>
                        <asp:Button ID="btnCancel" runat="server" CssClass="linkButton" Text="Cancel" CommandName="Cancel" />
                    </td>
                </tr>
            </table>
        </EditItemTemplate>
    </asp:ListView>
    <hr />
    <asp:DetailsView ID="ColorsDetailsView" runat="server" 
                        DataSourceID="ColorsODS"
                        DataKeyNames="ID"
                        DefaultMode="Insert"
                        AutoGenerateRows="False"
                        OnItemInserted="ColorsDetailsView_Inserted">
        <Fields>
            <asp:BoundField DataField="Name"/>
            <asp:CommandField InsertText="Add" CancelText="" ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
    <asp:ObjectDataSource ID="ColorsODS" runat="server" 
                                      TypeName="eStoreAdminBLL.ColorsBLL"
                                      OldValuesParameterFormatString="original_{0}" 
                                      SelectMethod="GetColorsByProductId"
                                      UpdateMethod="UpdateColor"
                                      DeleteMethod="DeleteColor"
                                      InsertMethod="AddColor">
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
