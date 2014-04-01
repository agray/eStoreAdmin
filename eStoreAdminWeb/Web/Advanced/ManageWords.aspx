<%@ Page Title="Manage Words" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageWords.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.ManageWords" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Manage Words</h1>
    <asp:EntityDataSource ID="WordsEDS" runat="server"
                          ConnectionString="name=eStoreEntities" 
                          DefaultContainerName="eStoreAdminEntities"
                          EnableFlattening="False"
                          EnableInsert="True"
                          EnableUpdate="True"
                          EnableDelete="True"
                          EntitySetName="BadWords"/>
    <asp:ListView ID="WordList" runat="server" 
                  DataSourceID="WordsEDS" 
                  DataKeyNames="ID">
        <LayoutTemplate>
            <table width="50%" border="1">
                <thead>
                    <td>Word</td>
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
                <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("BadWord1")%>'/>
            </td>
            <td style="text-align:right">
                <asp:Button ID="btnEdit" runat="server" CssClass="linkButton" Text="Edit" CommandName="Edit" />
                <asp:Button ID="btnDelete" runat="server" CssClass="linkButton" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this item?')" />
            </td>
        </ItemTemplate>
        <EditItemTemplate>
            <td style="text-align:left;width:75%">
                <asp:TextBox ID="NameEditTextBox" runat="server" Text='<%# Bind("BadWord1")%>' />
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
        </EditItemTemplate>
    </asp:ListView>
    <hr />
    <asp:DetailsView ID="WordssDetailsView" runat="server" 
                     DataSourceID="WordsEDS"
                     DataKeyNames="ID"
                     DefaultMode="Insert"
                     AutoGenerateRows="False"
                     OnItemInserted="WordsDetailsView_Inserted">
        <Fields>
            <asp:BoundField DataField="BadWord"/>
            <asp:CommandField InsertText="Add" CancelText="" ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
</asp:Content>
