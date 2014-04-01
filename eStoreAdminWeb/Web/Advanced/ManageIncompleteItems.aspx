<%@ Page Title="Incomplete Items" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageIncompleteItems.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.ManageIncompleteItems" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~/StyleSheets/humanity/jquery-ui-1.10.0.custom.min.css") %>" />
    <script type="text/javascript" src="<%=ResolveUrl("~/js/jquery-1.9.0.min.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/js/jquery-ui-1.10.0.custom.min.js") %>"></script>
    <script type="text/javascript">
        $(function() {
            $("#tabbedContent").tabs();
        });
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Incomplete Items</h1>
    <p>
        Images are added to products in the first instance.<br/>
        Category images can be assigned to a category from the pool of images of all the products in that category.<br/>
        Department images can be assigned to a department from the pool of images of all the products in all the categories in that department.<br/><br/>
        The system will direct you as close to the product level as possible based on your defined catalogue.
    </p>
    <table>
	    <tr>
            <td colspan="2">
	            <div id="tabbedContent">
	                <ul>
                        <li><a href="#tab1">Departments Without an Image</a></li>
                        <li><a href="#tab2">Categories Without an Image</a></li>
                        <li><a href="#tab3">Products Without an Image</a></li>
                        <li><a href="#tab4">Product Images without a Name</a></li>
                    </ul>
                    <div id="tab1">
                        <asp:ListView ID="DepartmentItemList" runat="server" 
                                      DataSourceID="DepartmentMissingImageODS" 
                                      DataKeyNames="ID">
                            <LayoutTemplate>
                                <table border="1">
                                    <thead>
                                        <th>Department</th>
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
                                <div>Good work. No issues here.</div>
                            </EmptyDataTemplate>
                            <ItemTemplate>
                                <td style="text-align:left">
                                    <asp:HyperLink ID="DepartmentHyperLink" runat="server" 
                                                   Text='<%# Eval("Name")%>'
                                                   NavigateUrl='<%#GetDepNavigateURL(Eval("ProductCount"), Eval("CategoryCount"), Eval("ID").ToString(), Eval("Name").ToString())%>' />
                                </td>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                    <div id="tab2">
                        <asp:ListView ID="CategoryItemList" runat="server" 
                                      DataSourceID="CategoryMissingImageODS" 
                                      DataKeyNames="ID">
                            <LayoutTemplate>
                                <table border="1">
                                    <thead>
                                        <th>Department</th>
                                        <th>Category</th>
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
                                <div>Good work. No issues here.</div>
                            </EmptyDataTemplate>
                            <ItemTemplate>
                                <td style="text-align:left">
                                    <asp:Label ID="DepLabel" runat="server" Text='<%# Eval("DepName")%>' />
                                </td>
                                <td style="text-align:left">
                                    <asp:HyperLink ID="CategoryHyperLink" runat="server" 
                                                   Text='<%# Eval("Name")%>'
                                                   NavigateUrl='<%#GetCatNavigateURL(Eval("DepID").ToString(), Eval("DepName").ToString(), Eval("ID").ToString(), Eval("Name").ToString())%>' />
                                </td>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                    <div id="tab3">
                        <asp:ListView ID="ProductItemList" runat="server" 
                                      DataSourceID="ProductMissingImageODS" 
                                      DataKeyNames="ID">
                            <LayoutTemplate>
                                <table border="1">
                                    <thead>
                                        <th>Department</th>
                                        <th>Category</th>
                                        <th>Product</th>
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
                                <div>Good work. No issues here.</div>
                            </EmptyDataTemplate>
                            <ItemTemplate>
                                <td style="text-align:left">
                                    <asp:Label ID="DepLabel" runat="server" Text='<%# Eval("DepName")%>' />
                                </td>
                                <td style="text-align:left">
                                    <asp:Label ID="CatLabel" runat="server" Text='<%# Eval("CatName")%>' />
                                </td>
                                <td style="text-align:left">
                                        <asp:HyperLink ID="HyperLink1" runat="server" 
                                                       Text='<%# Eval("Name")%>'
                                                       NavigateUrl='<%#"~/Web/Merchandise/Product/ManageImage.aspx?DepID=" + Eval("DepID") + "&DepName=" + Eval("DepName") + "&CatID=" + Eval("CatID") + "&CatName=" + Eval("CatName") + "&ProdID=" + Eval("ID") + "&ProdName=" + Eval("Name")%>' />
                                </td>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                    <div id="tab4">
                        <asp:ListView ID="ImageNameListView" runat="server" 
                                      DataSourceID="ImageMissingNameODS" 
                                      DataKeyNames="ID">
                            <LayoutTemplate>
                                <table border="1">
                                    <thead>
                                        <th>Department</th>
                                        <th>Category</th>
                                        <th>Product</th>
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
                                <div>Good work. No issues here.</div>
                            </EmptyDataTemplate>
                            <ItemTemplate>
                                <td style="text-align:left">
                                    <asp:Label ID="DepLabel" runat="server" Text='<%# Eval("DepName")%>' />
                                </td>
                                <td style="text-align:left">
                                    <asp:Label ID="CatLabel" runat="server" Text='<%# Eval("CatName")%>' />
                                </td>
                                <td style="text-align:left">
                                        <asp:HyperLink ID="ImageNameHyperLink" runat="server" 
                                                       Text='<%# Eval("Name")%>'
                                                       NavigateUrl='<%#"~/Web/Merchandise/Product/ManageImage.aspx?DepID=" + Eval("DepID") + "&DepName=" + Eval("DepName") + "&CatID=" + Eval("CatID") + "&CatName=" + Eval("CatName") + "&ProdID=" + Eval("ID") + "&ProdName=" + Eval("Name")%>' />
                                </td>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="DepartmentMissingImageODS" runat="server" 
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetMissingImages" 
                          TypeName="eStoreAdminBLL.DepartmentsBLL" />
    
    <asp:ObjectDataSource ID="CategoryMissingImageODS" runat="server" 
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetMissingImages" 
                          TypeName="eStoreAdminBLL.CategoriesBLL" />
    
    <asp:ObjectDataSource ID="ProductMissingImageODS" runat="server" 
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetMissingImages" 
                          TypeName="eStoreAdminBLL.ProductsBLL" />
                          
    <asp:ObjectDataSource ID="ImageMissingNameODS" runat="server" 
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetMissingNames" 
                          TypeName="eStoreAdminBLL.ProductsBLL" />                          
</asp:Content>