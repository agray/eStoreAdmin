<%@ Page Title="Manage Zones" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageZones.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.ManageZones" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Manage Zones</h1>
    <asp:EntityDataSource ID="ZonesEDS" runat="server"
                          ConnectionString="name=eStoreEntities"
                          DefaultContainerName="eStoreAdminEntities"
                          EnableFlattening="False"
                          EnableInsert="True"
                          EnableUpdate="True"
                          EnableDelete="True"
                          EntitySetName="Zones"/>
    <asp:ListView ID="ZoneList" runat="server" 
                    DataSourceID="ZonesEDS" 
                    DataKeyNames="ID"
                    OnItemUpdated="ZoneList_ItemUpdated"
                    OnItemDeleting="ZoneList_ItemDeleting">
        <LayoutTemplate>
            <table border="1">
                <thead>
                    <th>Actions</th>
                    <th>Zone</th>
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
                <asp:Button ID="btnEdit" runat="server" CssClass="linkButton" Text="Edit" CommandName="Edit" />
                <asp:Button ID="btnDelete" runat="server" CssClass="linkButton" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this item?')" />
            </td>
            <td style="text-align:left">
                <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name")%>'/>
            </td>
        </ItemTemplate>
        <EditItemTemplate>
            <td style="text-align:left">
                <asp:Button ID="btnSave" runat="server" CssClass="linkButton" Text="Save" CommandName="Update" ValidationGroup="DDLGroup"/>
                <asp:Button ID="btnCancel" runat="server" CssClass="linkButton" Text="Cancel" CommandName="Cancel" />
            </td>
            <td style="text-align:left">
                <asp:TextBox ID="NameEditTextBox" runat="server" Text='<%# Bind("Name")%>' />
                <asp:RequiredFieldValidator ID="NameEditRFV" runat="server" 
                                            ControlToValidate="NameEditTextBox" 
                                            ErrorMessage="Required"
                                            ValidationGroup="DDLGroup"
                                            Display="Dynamic" />
            </td>
        </EditItemTemplate>
    </asp:ListView>
    <hr />
    <asp:DetailsView ID="ZonesDetailsView" runat="server" 
                        DataSourceID="ZonesEDS"
                        DataKeyNames="ID"
                        DefaultMode="Insert"
                        AutoGenerateRows="False"
                        OnItemInserted="ZonesDetailsView_Inserted">
        <Fields>
            <asp:BoundField DataField="Name"/>
            <asp:CommandField InsertText="Add" CancelText="" ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
</asp:Content>
