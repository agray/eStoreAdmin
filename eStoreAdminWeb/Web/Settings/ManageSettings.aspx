<%@ Page Title="Manage Basic Settings" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageSettings.aspx.cs" Inherits="eStoreAdminWeb.ManageSettings" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.basepages" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<%@ Register TagPrefix="theme" TagName="ThemeDDL" Src="~/Controls/ThemeDDL.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Manage Basic Settings</h1>
        <asp:HyperLink ID="HomeHyperlink" runat="server"
                       NavigateUrl="SettingsManagerHome.aspx"
                       Text="Back to Settings Home"/>
        <table width="100%">
            <tr>
                <td valign="top">
                    <asp:GridView ID="SettingsGridView" runat="server" 
                                  DataSourceID="SettingsODS"
                                  DataKeyNames="ID"
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
                                  OnDataBound="SettingsGridView_DataBound">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                                            ReadOnly="True" SortExpression="ID" Visible="False" />
                            <asp:BoundField DataField="Name" HeaderText="Name" 
                                            SortExpression="Name" />
                            <asp:BoundField DataField="Value" HeaderText="Value" 
                                            SortExpression="Value" />
                        </Columns>
                        <EmptyDataTemplate>
                            There are no Settings.
                        </EmptyDataTemplate>
                    </asp:GridView>                    
                    <asp:ObjectDataSource ID="SettingsODS" runat="server"
                                          SelectMethod="GetSettings" 
                                          OldValuesParameterFormatString="original_{0}"  
                                          TypeName="eStoreAdminBLL.SettingsBLL" >
                    </asp:ObjectDataSource>
                </td>
                <td valign="top" align="right">
                    <asp:FormView ID="SettingFormView" runat="server" 
                                  DataSourceID="SettingODS"
                                  DataKeyNames="ID" 
                                  BackColor="White" 
                                  BorderColor="#999999" 
                                  BorderStyle="None" 
                                  BorderWidth="1px" 
                                  CellPadding="3" 
                                  GridLines="Vertical" 
                                  OnItemUpdated="SettingFormView_ItemUpdated">
                        <EditItemTemplate>
                            <table>
                                <tr>
                                    <td>Name:</td>
                                    <td><asp:Label ID="NameEditLabel" runat="server" 
                                                    Text='<%# Bind("Name") %>' />
                                    </td>
                                </tr>
                                <%--<%if(Eval("Type").Equals("mpage")) { %>
                                    <tr>
                                        <td>Value:</td>
                                        <td>
                                            <theme:ThemeDDL ID="ThemeEditDropDownList" runat="server"
                                                            SelectedValue='<%# Bind("ID") %>' />
                                        </td>
                                    </tr>
                                <%} else { %>--%>
                                    <tr>
                                        <td>Value:</td>
                                        <td><asp:TextBox ID="ValueEditTextBox" runat="server"
                                                         MaxLength="100"
                                                         TextMode="MultiLine" 
                                                         Rows="10" 
                                                         Columns="100" 
                                                         Font-Size="X-Small"
                                                         Text='<%# Bind("Value") %>' />
                                        </td>
                                        <td><asp:RequiredFieldValidator ID="ValueEditRFV" runat="server" 
                                                                        ControlToValidate="ValueEditTextBox" 
                                                                        ErrorMessage="Required"
                                                                        ValidationGroup="SettingGroup"
                                                                        Display="Dynamic" />
                                            <asp:CustomValidator ID="ValueCV" runat="server" 
                                                                 ControlToValidate="ValueEditTextBox" 
                                                                 OnServerValidate="ValueTextBox_CustomServerValidate"
                                                                 ErrorMessage="Invalid Value"
                                                                 ValidationGroup="SettingGroup"
                                                                 Enabled="true" />
                                            <asp:RegularExpressionValidator ID="LengthREV" runat="server"
                                                                            Display="dynamic" 
                                                                            ControlToValidate="ValueEditTextBox" 
                                                                            ValidationExpression="^([\S\s]{0,100})$" 
                                                                            ErrorMessage="Only 100 characters are permitted" />
                                        </td>
                                    </tr>
                                <%--<%} %>--%>
                                <tr>
                                    <td>Type:</td>
                                    <td><asp:Label ID="TypeEditLabel" runat="server" 
                                                    Text='<%# Bind("Type") %>' />
                                    </td>
                                </tr>
                            </table>
                            <asp:Button ID="UpdateButton" runat="server" 
                                        CausesValidation="True" 
                                        CommandName="Update"
                                        ValidationGroup="SettingGroup" 
                                        Text="Update" />&nbsp;
                            <asp:Button ID="UpdateCancelButton" runat="server" 
                                        CausesValidation="False" 
                                        CommandName="Cancel" 
                                        Text="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>Name:</td>
                                    <td><asp:Label ID="NameLabel" runat="server" 
                                                   Text='<%# Bind("Name") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Value:</td>
                                    <td><asp:Label ID="ValueLabel" runat="server" 
                                                   Text='<%# Bind("Value") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Type:</td>
                                    <td><asp:Label ID="TypeLabel" runat="server" 
                                                   Text='<%# Bind("Type") %>' />
                                    </td>
                                </tr>
                            </table>
                            <asp:Button ID="EditButton" runat="server" CausesValidation="False" 
                                        CommandName="Edit" Text="Edit" />&nbsp;
                        </ItemTemplate>
                    </asp:FormView>
                    <asp:ObjectDataSource ID="SettingODS" runat="server" 
                                          OldValuesParameterFormatString="original_{0}" 
                                          SelectMethod="GetSettingById" 
                                          TypeName="eStoreAdminBLL.SettingsBLL" 
                                          UpdateMethod="UpdateSetting">
                        <UpdateParameters>
                            <asp:Parameter Name="original_ID" Type="Int32" />
                            <asp:Parameter Name="Name" Type="String" />
                            <asp:Parameter Name="Value" Type="String" />
                        </UpdateParameters>
                        <SelectParameters>
                            <asp:ControlParameter ControlID="SettingsGridView" 
                                                  DefaultValue="0" 
                                                  Name="ID" 
                                                  PropertyName="SelectedValue" 
                                                  Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr><td>An Application Restart is required for changes to take effect.</td></tr>
        </table>
</asp:Content>