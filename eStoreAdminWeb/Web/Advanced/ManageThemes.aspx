<%@ Page Title="Manage Themes" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageThemes.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.ManageThemes" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Manage Themes</h1>
    <asp:EntityDataSource ID="ThemesEDS" runat="server"
                          ConnectionString="name=eStoreEntities" 
                          DefaultContainerName="eStoreAdminEntities"
                          EnableFlattening="False"
                          EnableInsert="True"
                          EnableUpdate="True"
                          EnableDelete="True"
                          EntitySetName="Themes"/>
    <asp:ListView ID="ThemeList" runat="server" 
                  DataSourceID="ThemesEDS" 
                  DataKeyNames="ID"
                  OnItemUpdated="ThemeList_ItemUpdated"
                  OnItemDeleting="ThemeList_ItemDeleting">
        <LayoutTemplate>
            <table width="75%" border="1">
                <thead>
                    <td>Name</td>
                    <td>MasterPage</td>
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
            <div id="EmptyListDiv" runat="server">There are no items in this list yet. Add one.</div>
        </EmptyDataTemplate>
        <ItemTemplate>
            <td style="text-align:left">
                <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name")%>'/>
            </td>
            <td style="text-align:left">
                <%#Eval("MasterPage")%>
            </td>
            <td style="text-align:right">
                <asp:Button ID="btnEdit" runat="server" CssClass="linkButton" Text="Edit" CommandName="Edit" />
                <asp:Button ID="btnDelete" runat="server" CssClass="linkButton" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this item?')" />
            </td>
        </ItemTemplate>
        <EditItemTemplate>
            <td style="text-align:left">
                <asp:TextBox ID="NameEditTextBox" runat="server" Text='<%# Bind("Name")%>' />
                <asp:RequiredFieldValidator ID="NameEditRFV" runat="server" 
                                            ControlToValidate="NameEditTextBox" 
                                            ErrorMessage="Required"
                                            ValidationGroup="EditGroup"
                                            Display="Dynamic" />
            </td>
            <td style="text-align:left">
                <asp:TextBox ID="MasterPageEditTextBox" runat="server" Text='<%# Bind("MasterPage")%>' />
                <asp:RequiredFieldValidator ID="MasterPageEditRFV" runat="server" 
                                            ControlToValidate="MasterPageEditTextBox" 
                                            ErrorMessage="Required"
                                            ValidationGroup="EditGroup"
                                            Display="Dynamic" />
            </td>
            <td style="text-align:right">
                <asp:Button ID="btnSave" runat="server" CssClass="linkButton" Text="Save" CommandName="Update" ValidationGroup="EditGroup"/>
                <asp:Button ID="btnCancel" runat="server" CssClass="linkButton" Text="Cancel" CommandName="Cancel" />
            </td>
        </EditItemTemplate>
    </asp:ListView>
    <hr />
    <asp:DetailsView ID="ThemesDetailsView" runat="server" 
                        DataSourceID="ThemesEDS"
                        DataKeyNames="ID"
                        DefaultMode="Insert"
                        AutoGenerateRows="False"
                        OnItemInserted="ThemesDetailsView_Inserted">
        <Fields>
            <asp:BoundField DataField="Name"/>
            <asp:BoundField DataField="MasterPage"/>
            <asp:CommandField InsertText="Add" CancelText="" ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
</asp:Content>
