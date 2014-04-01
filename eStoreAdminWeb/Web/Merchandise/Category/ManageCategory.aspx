<%@ Page Title="Manage Category" Language="C#" MasterPageFile="~/MasterPages/MerchandiseMaster.Master" AutoEventWireup="true" CodeBehind="ManageCategory.aspx.cs" Inherits="eStoreAdminWeb.Web.Merchandise.Category.ManageCategory" %>
<%@ MasterType VirtualPath="~/MasterPages/MerchandiseMaster.Master" %>
<%@ Import Namespace="phoenixconsulting.culture" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
     <asp:UpdatePanel ID="CategoryUpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left">
                        <h1>Manage <%=Request["CatName"]%> Category</h1>
                        <h2>Products</h2>
                    </td>
                    <td align="right" valign="top">
                        <asp:HyperLink ID="BackToHyperlink1" runat="server">
                            < Back to <%=Request["DepName"]%> Department
                        </asp:HyperLink>
                    </td>
                </tr>
            </table>
            <hr />
            <asp:ListView ID="ProductList" runat="server" 
                            DataSourceID="ProductsODS" 
                            DataKeyNames="ID" 
                            GroupItemCount="4"
                            OnItemDataBound="ProductList_ItemDataBound"
                            OnItemCommand="ProductList_ItemCommand"
                            OnItemDeleting="ProductList_ItemDeleting"
                            OnDataBound="ProductListView_DataBound"
                            OnPagePropertiesChanging="ProductListView_PagePropertiesChanging">
                <ItemTemplate>
                    <div class="Category">
                        <asp:HyperLink ID="ProductHyperLink" runat="server"
                                        NavigateUrl='<%#constructNavigateURL(Eval("ID").ToString(), Eval("Name").ToString())%>'>
                            <asp:Image ID="ProductImage" runat="server"
                                        ImageUrl='<%#Eval("DefaultImage")%>'
                                        AlternateText='<%#Eval("Name")%>'
                                        BorderWidth="0px"
                                        Height="130px"
                                        Width="150px"/>
                            <asp:Label ID="ProductName" class="ProductName" runat="server" Text='<%# Eval("Name") %>' />
                        </asp:HyperLink>
                        <div>        
                            <asp:Label ID="ProductPriceLabel" class="Price" runat="server" Visible='<%#Int32.Parse(Eval("IsOnSale").ToString())==0%>'><%#SessionHandler.Instance.CurrencyValue + " " + CultureService.getConvertedPrice(Eval("UnitPrice").ToString(), SessionHandler.Instance.CurrencyXRate, SessionHandler.Instance.CurrencyValue)%></asp:Label>
                            <asp:Label ID="ProductDealLabel" class="PriceDeal" runat="server" Visible='<%#Int32.Parse(Eval("IsOnSale").ToString())==1%>'><%#SessionHandler.Instance.CurrencyValue + " " + CultureService.getConvertedPrice(Eval("DiscountUnitPrice").ToString(), SessionHandler.Instance.CurrencyXRate, SessionHandler.Instance.CurrencyValue)%></asp:Label>
                            <asp:Label ID="ProductDiscountPriceLabel" class="PriceNow" runat="server"></asp:Label>
                        </div>
                        <asp:Literal ID="ImageCount" runat="server" Text='<%# Eval("ImageCount") %>' Visible="false"/>
                        <asp:HyperLink ID="ManageLink" runat="server" Text="Manage" NavigateUrl='<%#constructNavigateURL(Eval("ID").ToString(), Eval("Name").ToString())%>' />
                        <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this category?')"/>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div>There are no products in this category yet. Add one.</div>
                </EmptyDataTemplate>
                <LayoutTemplate>
                    <table width="100%">
                        <tr>
                            <td style="text-align:left">
                                <b><asp:Label ID="TopTotalProductsReturnedLabel" runat="server" /></b>
                                <asp:Label ID="TopShowingLabel" runat="server" />
                            </td>
                            <td style="text-align:right">
                                <asp:DataPager ID="BeforeListDataPager" runat="server" 
                                                PagedControlID="ProductList"
                                                PageSize="12">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Link" 
                                                                    ShowFirstPageButton="False" 
                                                                    ShowNextPageButton="False" 
                                                                    ShowPreviousPageButton="True"
                                                                    PreviousPageText="< Previous" />
                                        <asp:NumericPagerField ButtonCount="6" />
                                        <asp:NextPreviousPagerField ButtonType="Link" 
                                                                    ShowLastPageButton="False" 
                                                                    ShowNextPageButton="True" 
                                                                    ShowPreviousPageButton="False"
                                                                    NextPageText="Next >" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                    <hr class="clear" />
                    <div ID="groupPlaceholder" runat="server"></div>
                    <hr class="clear" />
                    <table width="100%">
                        <tr>
                            <td style="text-align:left">
                                <b><asp:Label ID="BottomTotalProductsReturnedLabel" runat="server" /></b>
                                <asp:Label ID="BottomShowingLabel" runat="server" />
                            </td>
                            <td style="text-align:right">
                                <asp:DataPager ID="AfterListDataPager" runat="server" 
                                                PagedControlID="ProductList"
                                                PageSize="12">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Link" 
                                                                    ShowFirstPageButton="False" 
                                                                    ShowNextPageButton="False" 
                                                                    ShowPreviousPageButton="True"
                                                                    PreviousPageText="< Previous" />
                                        <asp:NumericPagerField ButtonCount="6" />
                                        <asp:NextPreviousPagerField ButtonType="Link" 
                                                                    ShowLastPageButton="False" 
                                                                    ShowNextPageButton="True" 
                                                                    ShowPreviousPageButton="False"
                                                                    NextPageText="Next >" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <GroupTemplate>
                    <div ID="itemPlaceholder" runat="server"></div>
                </GroupTemplate>
            </asp:ListView>
            <hr class="clear" />
            <p class="clear">
                <asp:LinkButton ID="AddButton" runat="server" Text="Add New" OnClick="GoToAdd" />
            </p>  
            <asp:ObjectDataSource ID="ProductsODS" runat="server" 
                                  TypeName="eStoreAdminBLL.ProductsBLL" 
                                  OldValuesParameterFormatString="original_{0}"
                                  SelectMethod="GetProductsByCategoryIdAndCurrId" 
                                  DeleteMethod="DeleteProduct">
                <SelectParameters>
                    <asp:QueryStringParameter Name="categoryID" 
                                              QueryStringField="CatID" 
                                              Type="Int32" />
                    <asp:SessionParameter Name="currencyID" 
                                          SessionField="Currency" 
                                          Type="Int32" 
                                          DefaultValue="1"  />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="original_ID" Type="Int32" />
                    <asp:Parameter Name="name" Type="String" />
                    <asp:Parameter Name="description" Type="String" />
                    <asp:Parameter Name="supplierID" Type="Int32" />
                    <asp:Parameter Name="quantityPerUnit" Type="Int32" />
                    <asp:Parameter Name="unitPrice" Type="Double" />
                    <asp:Parameter Name="weight" Type="Double" />
                    <asp:Parameter Name="unitsInStock" Type="Int32" />
                    <asp:Parameter Name="unitsOnOrder" Type="Int32" />
                    <asp:Parameter Name="reOrderLevel" Type="Int32" />
                    <asp:Parameter Name="active" Type="Int32" />
                    <asp:Parameter Name="isOnSale" Type="Int32" />
                    <asp:Parameter Name="discountUnitPrice" Type="Double" />
                    <asp:Parameter Name="wholesalePrice" Type="Double" />
                    <asp:Parameter Name="seoTitle" Type="String" />
                    <asp:Parameter Name="seoKeywords" Type="String" />
                    <asp:Parameter Name="seoDescription" Type="String" />
                    <asp:Parameter Name="seoFriendlyNameURL" Type="String" />
                </UpdateParameters>
                <DeleteParameters>
                    <asp:Parameter Name="original_ID" Type="Int32" />
                </DeleteParameters>
            </asp:ObjectDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
