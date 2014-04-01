<%@ Page Title="Manage Social Networking" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageSocialByProd.aspx.cs" Inherits="eStoreAdminWeb.ManageSocialByProd" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Manage Social Networks - Products</h1>
    <%if(Roles.IsUserInRole("Manager")) { %>
        <asp:HyperLink ID="ManagerHomeHyperlink" runat="server"
                       NavigateUrl="SettingsManagerHome.aspx"
                       Text="Back to Settings Home"/>
    <%} else { %>
        <asp:HyperLink ID="AdminHomeHyperlink" runat="server"
                       NavigateUrl="SettingsAdminHome.aspx"
                       Text="Back to Settings Home"/>
    <%} %>
    <table>
        <tr>
            <td>Department:</td>
            <td valign="top">
                <asp:DropDownList ID="DepartmentsDropDownList" runat="server" 
                                  DataSourceID="DepartmentsODS" 
                                  DataTextField="Name" 
                                  DataValueField="ID"
                                  AppendDataBoundItems="True"
                                  AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="-1">--Choose a Department--</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Category:</td>
            <td>
                <asp:DropDownList ID="CategoriesDropDownList" runat="server" 
                                  DataSourceID="CategoriesODS" 
                                  DataTextField="Name" 
                                  DataValueField="ID"
                                  AutoPostBack="True"
                                  OnDataBound="CategoriesDropDownList_DataBound"
                                  OnSelectedIndexChanged="CategoriesDropDownList_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="DepartmentsODS" runat="server" 
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetDepartments" 
                          TypeName="eStoreAdminBLL.DepartmentsBLL">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="CategoriesODS" runat="server" 
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetCategoriesByDepartmentId" 
                          TypeName="eStoreAdminBLL.CategoriesBLL">
        <SelectParameters>
            <asp:ControlParameter ControlID="DepartmentsDropDownList" 
                                  Name="departmentID" 
                                  PropertyName="SelectedValue" 
                                  Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <table width="100%">
        <tr>
            <td>       
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
                              AllowSorting="True" DataSourceID="SNsODS">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                                        ReadOnly="True" SortExpression="ID" Visible="False" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Description" HeaderText="Description" 
                                        SortExpression="Description" Visible="False" />
                        <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" 
                                        SortExpression="SupplierID" Visible="False" />
                        <asp:BoundField DataField="CatID" HeaderText="CatID" 
                                        SortExpression="CatID" Visible="False" />
                        <asp:BoundField DataField="DepID" HeaderText="DepID" 
                                        SortExpression="DepID" Visible="False" />
                        <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" 
                                        SortExpression="QuantityPerUnit" Visible="False" />
                        <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" 
                                        SortExpression="UnitPrice" Visible="False" />
                        <asp:BoundField DataField="Weight" HeaderText="Weight" SortExpression="Weight" 
                                        Visible="False" />
                        <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" 
                                        SortExpression="UnitsInStock" Visible="False" />
                        <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" 
                                        SortExpression="UnitsOnOrder" Visible="False" />
                        <asp:BoundField DataField="ReOrderLevel" HeaderText="ReOrderLevel" 
                                        SortExpression="ReOrderLevel" Visible="False" />
                        <asp:BoundField DataField="Active" HeaderText="Active" SortExpression="Active" 
                                        Visible="False" />
                        <asp:BoundField DataField="IsOnSale" HeaderText="IsOnSale" 
                                        SortExpression="IsOnSale" Visible="False" />
                        <asp:BoundField DataField="IsLimitedOffer" HeaderText="IsLimitedOffer" 
                                        SortExpression="IsLimitedOffer" Visible="False" />
                        <asp:BoundField DataField="DiscountUnitPrice" HeaderText="DiscountUnitPrice" 
                                        SortExpression="DiscountUnitPrice" Visible="False" />
                        <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" 
                                        ReadOnly="True" SortExpression="CompanyName" Visible="False" />
                        <asp:BoundField DataField="ActiveWord" HeaderText="ActiveWord" ReadOnly="True" 
                                        SortExpression="ActiveWord" Visible="False" />
                        <asp:BoundField DataField="IsOnSaleWord" HeaderText="IsOnSaleWord" 
                                        ReadOnly="True" SortExpression="IsOnSaleWord" Visible="False" />
                        <asp:BoundField DataField="IsLimitedOfferWord" HeaderText="IsLimitedOfferWord" 
                                        ReadOnly="True" SortExpression="IsLimitedOfferWord" Visible="False" />
                        <asp:BoundField DataField="HasSNWord" HeaderText="Has SN" 
                                        SortExpression="HasSocialNetworking" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="SNsODS" runat="server" 
                                      OldValuesParameterFormatString="original_{0}" 
                                      SelectMethod="GetSocialByCatId" 
                                      TypeName="eStoreAdminBLL.ProductsBLL">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="CategoriesDropDownList" 
                                              Name="categoryID" 
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
                                <td>Has SN:</td>
                                <td>
                                    <asp:DropDownList ID="SNEditDropDownList" runat="server" 
                                                      SelectedValue='<%# Bind("HasSocialNetworking") %>'>
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
                                <td><asp:Label ID="HasSNLabel" runat="server" Text='<%# Bind("HasSNWord") %>' /></td>
                            </tr>
                        </table>
                        <asp:Button ID="EditButton" runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit" />
                    </ItemTemplate>
                </asp:FormView>
                <asp:ObjectDataSource ID="SNODS" runat="server" 
                                      TypeName="eStoreAdminBLL.ProductsBLL" 
                                      OldValuesParameterFormatString="original_{0}" 
                                      SelectMethod="GetSocialById" 
                                      UpdateMethod="UpdateSocial">
                    <UpdateParameters>
                        <asp:Parameter Name="original_ID" Type="Int32" />
                        <asp:Parameter Name="HaveSN" Type="Int32" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="SNsGridView" 
                                              DefaultValue="0" 
                                              Name="ID"
                                              PropertyName="SelectedValue"
                                              Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>