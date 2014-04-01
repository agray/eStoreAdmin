<%@ Page Title="Manage Links" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageLinks.aspx.cs" Inherits="eStoreAdminWeb.ManageLinks" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
     } %>
    <h1>Manage Links</h1>
    <%if(Roles.IsUserInRole("Manager")) { %>
        <asp:HyperLink ID="ManagerHomeHyperlink" runat="server"
                       NavigateUrl="SettingsManagerHome.aspx"
                       Text="Back to Settings Home"/>
    <%} else { %>
        <asp:HyperLink ID="AdminHomeHyperLink" runat="server"
                       NavigateUrl="SettingsAdminHome.aspx"
                       Text="Back to Settings Home"/>
    <%} %>
    <table width="100%">
        <tr>
            <td valign="top">
                <asp:GridView ID="LinksGridView" runat="server" 
                              DataKeyNames="ID" 
                              DataSourceID="LinksODS" 
                              EnableViewState="False"
                              AutoGenerateColumns="False" 
                              AllowPaging="True" 
                              AllowSorting="True"
                              PagerSettings-Mode="Numeric"
                              PageSize="20"
                              BackColor="White" 
                              BorderColor="#999999" 
                              BorderStyle="None" 
                              BorderWidth="1px" 
                              CellPadding="3" 
                              GridLines="Vertical"
                              OnDataBound="LinksGridView_DataBound">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                                        ReadOnly="True" SortExpression="ID" Visible="False" />
                        <asp:BoundField DataField="LinkURL" HeaderText="Link URL" 
                                        SortExpression="LinkURL" />
                        <asp:BoundField DataField="LinkText" HeaderText="Link Text" 
                                        SortExpression="LinkText" />
                        <asp:BoundField DataField="LinkDescription" HeaderText="Link Description" 
                                        SortExpression="LinkDescription" />
                        <asp:BoundField DataField="LinkType" HeaderText="Link Type" 
                                        SortExpression="LinkType" />
                    </Columns>
                    <EmptyDataTemplate>
                        There are no Links.
                    </EmptyDataTemplate>
                </asp:GridView>                    
                <asp:ObjectDataSource ID="LinksODS" runat="server"
                                      SelectMethod="GetLinks" 
                                      OldValuesParameterFormatString="original_{0}"  
                                      TypeName="eStoreAdminBLL.LinkBLL" >
                </asp:ObjectDataSource>
            </td>
            <td valign="top" align="right">
                <asp:FormView ID="LinkFormView" runat="server" 
                              DataSourceID="LinkODS"
                              DataKeyNames="ID" 
                              BackColor="White" 
                              BorderColor="#999999" 
                              BorderStyle="None" 
                              BorderWidth="1px" 
                              CellPadding="3" 
                              GridLines="Vertical" 
                              OnItemDeleted="LinkFormView_ItemDeleted" 
                              OnItemInserted="LinkFormView_ItemInserted" 
                              OnItemUpdated="LinkFormView_ItemUpdated">
                    <EditItemTemplate>
                        <table>
                            <tr>
                                <td>Link URL:</td>
                                <td><asp:TextBox ID="LinkURLEditTextBox" runat="server"
                                                 MaxLength="100"
                                                 TextMode="MultiLine" 
                                                 Rows="10" 
                                                 Columns="50" 
                                                 Font-Size="X-Small"
                                                 Text='<%# Bind("LinkURL") %>' />
                                </td>
                                <td><asp:RequiredFieldValidator ID="LinkURLEditRFV" runat="server" 
                                                                ControlToValidate="LinkURLEditTextBox" 
                                                                ErrorMessage="Required"
                                                                ValidationGroup="LinkGroup"
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Link Text:</td>
                                <td><asp:TextBox ID="LinkTextEditTextBox" runat="server" 
                                                 Text='<%# Bind("LinkText") %>' />
                                </td>
                                <td><asp:RequiredFieldValidator ID="LinkTextEditRFV" runat="server" 
                                                                ControlToValidate="LinkTextEditTextBox" 
                                                                ErrorMessage="Required"
                                                                ValidationGroup="LinkGroup"
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Link Description:</td>
                                <td><asp:TextBox ID="LinkDescriptionEditTextBox" runat="server" 
                                                 Text='<%# Bind("LinkDescription") %>' />
                                </td>
                                <td><asp:RequiredFieldValidator ID="LinkDescriptionEditRFV" runat="server" 
                                                                ControlToValidate="LinkDescriptionEditTextBox" 
                                                                ErrorMessage="Required"
                                                                ValidationGroup="LinkGroup"
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Link Type:</td>
                                <td><asp:DropDownList ID="LinkTypeEditDropDownList" runat="server" 
                                                      SelectedValue='<%# Bind("LinkType") %>'>
                                        <asp:ListItem Value="Resources">Resources</asp:ListItem>
                                        <asp:ListItem Value="Shopping">Shopping</asp:ListItem>
                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td><asp:RequiredFieldValidator ID="LinkTypeEditRFV" runat="server" 
                                                                ControlToValidate="LinkTypeEditDropDownList" 
                                                                ErrorMessage="Required"
                                                                ValidationGroup="LinkGroup"
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="UpdateButton" runat="server" 
                                    CausesValidation="True"
                                    ValidationGroup="LinkGroup"  
                                    CommandName="Update" 
                                    Text="Update" />&nbsp;
                        <asp:Button ID="UpdateCancelButton" runat="server" 
                                    CausesValidation="False" 
                                    CommandName="Cancel" 
                                    Text="Cancel" />
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <table>
                            <tr>
                                <td>Link URL:</td>
                                <td><asp:TextBox ID="LinkURLAddTextBox" runat="server"
                                                 MaxLength="100"
                                                 TextMode="MultiLine" 
                                                 Rows="10" 
                                                 Columns="50" 
                                                 Font-Size="X-Small"
                                                 Text='<%# Bind("LinkURL") %>' />
                                </td>
                                <td><asp:RequiredFieldValidator ID="LinkURLAddRFV" runat="server" 
                                                                ControlToValidate="LinkURLAddTextBox" 
                                                                ErrorMessage="Required"
                                                                ValidationGroup="LinkGroup"
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Link Text:</td>
                                <td><asp:TextBox ID="LinkTextAddTextBox" runat="server" 
                                                 Text='<%# Bind("LinkText") %>' />
                                </td>
                                <td><asp:RequiredFieldValidator ID="LinkTextAddRFV" runat="server" 
                                                                ControlToValidate="LinkTextAddTextBox" 
                                                                ErrorMessage="Required"
                                                                ValidationGroup="LinkGroup"
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Link Description:</td>
                                <td><asp:TextBox ID="LinkDescriptionAddTextBox" runat="server" 
                                                 Text='<%# Bind("LinkDescription") %>' />
                                </td>
                                <td><asp:RequiredFieldValidator ID="LinkDescriptionAddRFV" runat="server" 
                                                                ControlToValidate="LinkDescriptionAddTextBox" 
                                                                ErrorMessage="Required"
                                                                ValidationGroup="LinkGroup"
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                            <tr>
                                <td>Link Type:</td>
                                <td><asp:TextBox ID="LinkTypeAddTextBox" runat="server" 
                                                 Text='<%# Bind("LinkType") %>' />
                                </td>
                                <td><asp:RequiredFieldValidator ID="LinkTypeAddRFV" runat="server" 
                                                                ControlToValidate="LinkTypeAddTextBox" 
                                                                ErrorMessage="Required"
                                                                ValidationGroup="LinkGroup"
                                                                Display="Dynamic" />
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="InsertButton" runat="server" 
                                    CausesValidation="True"
                                    ValidationGroup="LinkGroup" 
                                    CommandName="Insert" 
                                    Text="Insert" />&nbsp;
                        <asp:Button ID="InsertCancelButton" runat="server" 
                                    CausesValidation="False" 
                                    CommandName="Cancel" 
                                    Text="Cancel" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>Link URL:</td>
                                <td><asp:Label ID="LinkURLLabel" runat="server" 
                                               Text='<%# Bind("LinkURL") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>Link Text:</td>
                                <td><asp:Label ID="LinkTextLabel" runat="server" 
                                               Text='<%# Bind("LinkText") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>Link Description:</td>
                                <td><asp:Label ID="LinkDescriptionLabel" runat="server" 
                                               Text='<%# Bind("LinkDescription") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>Link Type:</td>
                                <td><asp:Label ID="LinkTypeLabel" runat="server" 
                                               Text='<%# Bind("LinkType") %>' />
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="EditButton" runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit" />&nbsp;
                        <asp:Button ID="DeleteButton" runat="server" CausesValidation="False" 
                                    CommandName="Delete" Text="Delete"
                                    OnClientClick="return confirm('Are you sure you want to delete this link?')" />&nbsp;
                        <asp:Button ID="NewButton" runat="server" CausesValidation="False" 
                                    CommandName="New" Text="New" />
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="LinkODS" runat="server" 
                                      OldValuesParameterFormatString="original_{0}" 
                                      SelectMethod="GetLinkById" 
                                      TypeName="eStoreAdminBLL.LinkBLL" 
                                      DeleteMethod="DeleteLink" 
                                      InsertMethod="AddLink" 
                                      UpdateMethod="UpdateLink">
                    <DeleteParameters>
                        <asp:Parameter Name="original_ID" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="linkURL" Type="String" />
                        <asp:Parameter Name="linkText" Type="String" />
                        <asp:Parameter Name="linkDescription" Type="String" />
                        <asp:Parameter Name="linkType" Type="String" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="LinksGridView" 
                                              DefaultValue="0" 
                                              Name="ID" 
                                              PropertyName="SelectedValue" 
                                              Type="Int32" />
                    </SelectParameters>
                    <InsertParameters>
                        <asp:Parameter Name="linkURL" Type="String" />
                        <asp:Parameter Name="linkText" Type="String" />
                        <asp:Parameter Name="linkDescription" Type="String" />
                        <asp:Parameter Name="linkType" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>