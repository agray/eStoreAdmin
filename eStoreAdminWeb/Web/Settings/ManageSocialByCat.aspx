<%@ Page Title="Manage Social Networking" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageSocialByCat.aspx.cs" Inherits="eStoreAdminWeb.ManageSocialByCat" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Manage Social Networks - Categories</h1>
    <%if(Roles.IsUserInRole("Manager")) { %>
        <asp:HyperLink ID="ManagerHomeHyperlink" runat="server"
                       NavigateUrl="SettingsManagerHome.aspx"
                       Text="Back to Settings Home"/>
    <%} else { %>
        <asp:HyperLink ID="AdminHomeHyperlink" runat="server"
                       NavigateUrl="SettingsAdminHome.aspx"
                       Text="Back to Settings Home"/>
    <%} %>
    <table width="100%">
        <tr>
            <td valign="top">
                <asp:DropDownList ID="DepartmentsDropDownList" runat="server"
                                  DataTextField="Name" 
                                  DataValueField="ID"
                                  AppendDataBoundItems="True" 
                                  AutoPostBack="True" 
                                  DataSourceID="DepartmentsODS">
                    <asp:ListItem Selected="True" Value="-1">--Choose a Department--</asp:ListItem>
                </asp:DropDownList>
                                  
                <asp:ObjectDataSource ID="DepartmentsODS" runat="server" 
                                      OldValuesParameterFormatString="original_{0}" 
                                      SelectMethod="GetDepartments" 
                                      TypeName="eStoreAdminBLL.DepartmentsBLL">
                </asp:ObjectDataSource>
                                  
                <asp:GridView ID="SNsGridView" runat="server" 
                              AutoGenerateColumns="False" 
                              BackColor="White" 
                              BorderColor="#999999" 
                              BorderStyle="None" 
                              BorderWidth="1px" 
                              CellPadding="3" 
                              DataKeyNames="ID"  
                              GridLines="Vertical" 
                              AllowPaging="True" 
                              AllowSorting="True" 
                              DataSourceID="SNsODS">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                                        ReadOnly="True" SortExpression="ID" Visible="False" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Description" HeaderText="Description" 
                                        SortExpression="Description" Visible="False" />
                        <asp:BoundField DataField="DepID" HeaderText="DepID" 
                                        SortExpression="DepID" Visible="False" />
                        <asp:BoundField DataField="ImageID" HeaderText="ImageID" 
                                        SortExpression="ImageID" Visible="False" />
                        <asp:BoundField DataField="DepName" HeaderText="DepName" ReadOnly="True" 
                                        SortExpression="DepName" Visible="False" />
                        <asp:BoundField DataField="ImgPath" HeaderText="ImgPath" ReadOnly="True" 
                                        SortExpression="ImgPath" Visible="False" />
                        <asp:BoundField DataField="AllHaveSNWord" HeaderText="All Have SN" 
                                        SortExpression="AllHaveSN" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="SNsODS" runat="server" 
                                      OldValuesParameterFormatString="original_{0}" 
                                      SelectMethod="GetSocialByDepId" 
                                      TypeName="eStoreAdminBLL.CategoriesBLL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DepartmentsDropDownList" 
                                              Name="departmentID" 
                                              PropertyName="SelectedValue" 
                                              Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
            <td valign="top" align="right">
                <asp:FormView ID="SNFormView" runat="server"
                              DataSourceID="SNODS" 
                              DataKeyNames="ID"
                              BackColor="White" 
                              BorderColor="#999999" 
                              BorderStyle="None" 
                              BorderWidth="1px" 
                              CellPadding="3" 
                              GridLines="Vertical"
                              OnItemUpdated="SNFormView_ItemUpdated">
                    <EditItemTemplate>
                        <table>
                            <tr>
                                <td>Name:</td>
                                <td><asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' /></td>
                            </tr>
                            <tr>
                                <td>All Have SN:</td>
                                <td>
                                    <asp:DropDownList ID="SNEditDropDownList" runat="server" 
                                                      SelectedValue='<%# Bind("AllHaveSN") %>'>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="UpdateButton" runat="server" 
                                    CausesValidation="True" 
                                    CommandName="Update" 
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
                                <td><asp:Label ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' /></td>
                            </tr>
                            <tr>
                                <td>All Have SN:</td>
                                <td><asp:Label ID="AllHaveSNLabel" runat="server" Text='<%# Bind("AllHaveSNWord") %>' /></td>
                            </tr>
                        </table>
                        <asp:Button ID="EditButton" runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit" />
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="SNODS" runat="server" 
                                      TypeName="eStoreAdminBLL.CategoriesBLL" 
                                      OldValuesParameterFormatString="original_{0}" 
                                      SelectMethod="GetSocialById" 
                                      UpdateMethod="UpdateSocial">
                    <UpdateParameters>
                        <asp:Parameter Name="original_ID" Type="Int32" />
                        <asp:Parameter Name="AllHaveSN" Type="Int32" />
                        <asp:Parameter Name="name" Type="String" />
                        <asp:Parameter Name="hasSN" Type="Int32" />
                        <asp:Parameter Name="CatID" Type="Int32" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="SNsGridView" 
                                              DefaultValue="0" Name="ID"
                                              PropertyName="SelectedValue"
                                              Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>