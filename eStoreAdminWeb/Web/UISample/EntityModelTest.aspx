<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="EntityModelTest.aspx.cs" Inherits="eStoreAdminWeb.Web.UISample.EntityModelTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mode List</h2>
    <asp:EntityDataSource ID="ModesEDS" runat="server"
                          ConnectionString="name=eStoreEntities"
                          DefaultContainerName="eStoreAdminEntities"
                          EnableFlattening="False"
                          EnableInsert="True"
                          EnableUpdate="True"
                          EnableDelete="True"
                          EntitySetName="ShipToModes"/>
        <asp:ListView ID="ModeList" runat="server" 
                      DataSourceID="ModesEDS" 
                      DataKeyNames="ID">
            <LayoutTemplate>
                <table border="1">
                    <thead>
                        <td>Actions</td>
                        <td>Mode</td>
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
                    <%#Eval("Name")%>
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
        <asp:DetailsView ID="ModesDetailsView" runat="server" 
                         DataSourceID="ModesEDS"
                         DataKeyNames="ID"
                         DefaultMode="Insert"
                         AutoGenerateRows="False"
                         OnItemInserted="ModesDetailsView_Inserted">
            <Fields>
                <asp:BoundField DataField="Name"/>
                <asp:CommandField InsertText="Add" CancelText="" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
</asp:Content>