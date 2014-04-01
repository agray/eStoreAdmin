<%@ Page Title="Manage Departments 2" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageDepartments2.aspx.cs" Inherits="eStoreAdminWeb.Web.Merchandise.Departments.ManageDepartments2" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--
/*
 * The MIT License
 *
 * Copyright (c) 2008-2013, Andrew Gray
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
-->
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Manage Departments</h1>
    <table>
        <tr>
            <td width="70%"
                align="left">
                Use this page to manage your departments. Departments allow you to create hierarchical groupings of products so customers can easily find what they are looking for.
            </td>
            <td width="30%"
                align="right">
                <asp:HyperLink ID="AddDepartment" runat="server"
                               CssClass="AddButton"
                               Text="ADD NEW DEPARTMENT"
                               NavigateUrl="~/Web/Merchandise/Departments/Add.aspx" />
            </td>
        </tr>
    </table>
    <hr style="color:Silver" />
    <h3 class="SubTitle">SEARCH DEPARTMENTS</h3>
    <asp:Label ID="DepartmentLabel" runat="server"
               CssClass="LabelText" 
               Text="DEPARTMENT NAME" /><br />
    <asp:TextBox ID="DepartmentTextbox" runat="server" />
    <br/><br/>
    <asp:ImageButton ID="btnSearch" runat="server"
                     ImageUrl="~/Images/System/button_search.gif"
                     OnClick="btnSearch_Click" />
    <asp:ImageButton ID="btnClear" runat="server"
                     ImageUrl="~/Images/System/button_clear.gif"
                     OnClick="btnClear_Click" />
        
    <hr style="color:Silver" />
    <h3 class="SubTitle">DEPARTMENT LIST</h3>
    
    <table width="100%">
        <tr>
            <td valign="top">
                <asp:GridView ID="DepartmentsGridView" runat="server" 
                              DataSourceID="DepartmentsODS"
                              DataKeyNames="ID"
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
                              GridLines="Vertical">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                                        ReadOnly="True" SortExpression="ID" Visible="False" />
                        <asp:TemplateField HeaderText="Name" SortExpression="Name">
                            <ItemTemplate>
                                <asp:HyperLink ID="DepartmentHyperLink" runat="server"
                                               Text='<%# Bind("Name") %>'
                                               NavigateUrl='<%# "../ManageDepartment.aspx?DepID=" + Eval("ID") + "&DepName=" + Eval("Name") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:HyperLink ID="EditHyperlink" runat="server" 
                                               NavigateUrl='<%# "Edit.aspx?DepID=" + Eval("ID") + "&DepName=" + Eval("Name") %>' 
                                               Text="EDIT" />
                                <asp:LinkButton ID="btnDelete" runat="server" Text="DELETE"
                                                OnClick="btnDelete_Click"
                                                OnClientClick="return confirm('Are you sure you want to delete this department?')"
                                                CommandArgument='<%# Eval("ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    <EmptyDataTemplate>
                        There are no Departments.
                    </EmptyDataTemplate>
                </asp:GridView>
                
                <asp:ObjectDataSource ID="DepartmentsODS" runat="server" 
                                      TypeName="eStoreAdminBLL.DepartmentsBLL"
                                      OldValuesParameterFormatString="original_{0}"
                                      SelectMethod="GetDepartments">
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>