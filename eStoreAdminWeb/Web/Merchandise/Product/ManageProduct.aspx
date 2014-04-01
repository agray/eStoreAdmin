<%@ Page Title="Manage Product" Language="C#" MasterPageFile="~/MasterPages/MerchandiseMaster.Master" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="eStoreAdminWeb.Web.Merchandise.Product.ManageProduct" %>
<%@ MasterType VirtualPath="~/MasterPages/MerchandiseMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>
<%@ Import Namespace="phoenixconsulting.culture" %>

<%@ Register TagPrefix="productSize" TagName="ProductSizeDDL" Src="~/Controls/ProductSizeDDL.ascx" %>
<%@ Register TagPrefix="productColor" TagName="ProductColorDDL" Src="~/Controls/ProductColorDDL.ascx" %>
<%@ Register TagPrefix="productQuantity" TagName="ProductQuantityDDL" Src="~/Controls/ProductQuantityDDL.ascx" %>
<%@ Register TagPrefix="currency" TagName="CurrencyDDL" Src="~/Controls/CurrencyDDL.ascx" %>
<%@ Register TagPrefix="supplier" TagName="SupplierDDL" Src="~/Controls/SupplierDDL.ascx" %>
<%@ Register TagPrefix="brand" TagName="BrandDDL" Src="~/Controls/BrandDDL.ascx" %>
<%@ Register TagPrefix="yesNo" TagName="YesNoDDL" Src="~/Controls/YesNoDDL.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%if(SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <asp:UpdatePanel ID="ProductUpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="left">
                        <h1>Manage <%=RequestHandler.Instance.ProductName%> Product</h1>
                    </td>
                    <td align="right" valign="top">
                        <asp:HyperLink ID="BackToHyperlink1" runat="server">
                            < Back to <%=RequestHandler.Instance.CategoryName%> Category
                        </asp:HyperLink>
                    </td>
                </tr>
            </table>
            <hr/>
            <% if(ProductFormView.DataItemCount != 0) {%>
                <%--bulk of content goes here--%>
                <asp:FormView ID="ProductFormView" runat="server" 
                              DataKeyNames="ID" 
                              DataSourceID="ProductODS"
                              OnItemUpdated="ProductFormView_ItemUpdated"
                              OnDataBound="ProductFormView_DataBound">
                    <ItemTemplate>
                        <div>
                            <asp:Label ID="Home_Breadcrumb" CssClass="HyperLinkLook" runat="server"
                                       Text="Home" />&nbsp;&gt;&nbsp
                            <asp:Label ID="DepartmentName_Breadcrumb" CssClass="HyperLinkLook" runat="server"
                                       Text='<%#Eval("DepartmentName")%>' />&nbsp;&gt;&nbsp
                            <asp:Label ID="CatName_Breadcrumb" CssClass="HyperLinkLook" runat="server"
                                       Text='<%#Eval("CategoryName")%>' />
                        </div>
                        <hr />
                        <table width="100%" cellpadding="0" cellspacing="2">
                            <tr>
                                <td valign="top">
                                    <h1>
                                        <asp:Label ID="HeaderNameLabel" runat="server" Text='<%#Eval("Name")%>' />
                                    </h1>
                                    <div class="ProductDescription">
                                        <asp:Label ID="ProductDescriptionLabel" runat="server" Text='<%#Eval("Description")%>' />
                                    </div>
                                    
                                    <%if(HasProductSizes()) {%>
                                        <div class="ProductOptions" style="text-align:right">
                                            <%--Hide this dropdown if there are no sizes--%>
                                            <asp:HyperLink ID="ManageSizeHyperLink" runat="server"
                                                           Text="Manage"
                                                           NavigateURL='<%#"~/Web/Merchandise/Product/ManageSizes.aspx?DepID=" + Request["DepID"] + "&DepName=" + Request["DepName"] + "&CatID=" + Request["CatID"] + "&CatName=" + Request["CatName"] + "&ProdID=" + Eval("ID") + "&ProdName=" + Eval("Name")%>'/>
                                            <asp:Label ID="SizeDDLLabel" class="ProductOptions" runat="server" Text="Size" />
                                            <productSize:ProductSizeDDL ID="productSizeDDL" runat="server" />
                                            
                                        </div>
                                    <%} else {%>
                                        <asp:HyperLink ID="AddSizeHyperLink2" runat="server"
                                                       Text="Add New Size"
                                                       NavigateURL='<%#"~/Web/Merchandise/Product/AddSize.aspx?DepID=" + Request["DepID"] + "&DepName=" + Request["DepName"] + "&CatID=" + Request["CatID"] + "&CatName=" + Request["CatName"] + "&ProdID=" + Eval("ID") + "&ProdName=" + Eval("Name")%>'/>
                                    <%}%>
                                    
                                    <%if(HasProductColors()) {%>
                                        <div class="ProductOptions" style="text-align:right">
                                            <%--Hide this dropdown if there are no colors--%>
                                            <asp:HyperLink ID="ManageColorHyperLink" runat="server"
                                                           Text="Manage"
                                                           NavigateURL='<%#"~/Web/Merchandise/Product/ManageColors.aspx?DepID=" + Request["DepID"] + "&DepName=" + Request["DepName"] + "&CatID=" + Request["CatID"] + "&CatName=" + Request["CatName"] + "&ProdID=" + Eval("ID") + "&ProdName=" + Eval("Name")%>'/>
                                            <asp:Label ID="ColorDDLLabel" class="ProductOptions" runat="server" Text="Color" />
                                            <productColor:ProductColorDDL ID="productColorDDL" runat="server" />
                                        </div>
                                    <%} else {%>
                                        <asp:HyperLink ID="AddColorHyperLink2" runat="server"
                                                   Text="Add New Color"
                                                   NavigateURL='<%#"~/Web/Merchandise/Product/AddColor.aspx?DepID=" + Request["DepID"] + "&DepName=" + Request["DepName"] + "&CatID=" + Request["CatID"] + "&CatName=" + Request["CatName"] + "&ProdID=" + Eval("ID") + "&ProdName=" + Request["Name"]%>'/>
                                    <%}%>
                                    <div class="ProductOptions" style="text-align:right">
                                        <span class="ProductOptions">Quantity</span>
                                        <productQuantity:ProductQuantityDDL ID="productQuantityDDL" runat="server" />
                                    </div>
                                    <div class="ProductFields" style="text-align:right">
                                        <asp:TextBox ID="ProductIDHiddenField" runat="server"
                                                     Visible="false" 
                                                     Text='<%#Request["ProdID"]%>' />
                                        <asp:ImageButton ID="AddToCartImageButton" runat="server"
                                                         AlternateText='Add <%#Eval("Name")%> From <%#Eval("CompanyName")%> to cart'
                                                         ImageUrl="~/Images/System/AddToCart.gif" />
                                    </div>
                                    <asp:Label Visible="false" ID="HasSN" runat="server" Text='<%#Eval("HasSN")%>' />
                                    <%if(HasSN()) {%>
                                        <div class="ProductBookmarks">
                                            <h2>Bookmark this page</h2>
                                            <p>
                                                <asp:Image ID="DiggImage" runat="server" ImageUrl="~/Images/System/icon_digg.gif" />
                                                <asp:Label ID="DiggLabel" CssClass="HyperLinkLook" runat="server" Text="Digg"/>
                                                <asp:Image ID="DelImage" runat="server" ImageUrl="~/Images/System/icon_del.gif" />
                                                <asp:Label ID="DeliciousLabel" CssClass="HyperLinkLook" runat="server" Text="del.icio.us"/>
                                                <asp:Image ID="RedditImage" runat="server" ImageUrl="~/Images/System/icon_reddit.gif" />
                                                <asp:Label ID="RedditLabel1" CssClass="HyperLinkLook" runat="server" Text="Reddit"/>
                                                <asp:Image ID="GoogleImage" runat="server" ImageUrl="~/Images/System/icon_google.gif" />
                                                <asp:Label ID="GoogleLabel" CssClass="HyperLinkLook" runat="server" Text="Google"/>
                                                <asp:Image ID="EmailImage" runat="server" ImageUrl="~/Images/System/icon_email.gif" />
                                                <asp:Label ID="EmailLabel" CssClass="HyperLinkLook" runat="server" Text="Email"/>
                                            </p>
                                        </div>
                                    <%} %>
                                    <div>
                                        <h2>Exchange and Returns Policy</h2>
                                        <p>
                                            PetsPlayground will exchange your product for a different size or refund your money if it is return within 30 days of receipt. Please see the
                                            <asp:Label ID="PoliciesLabel" CssClass="HyperLinkLook" runat="server" Text="Policies"/>
                                            page for more information.
                                        </p>
                                        <h2>Taxes and import duties</h2>
                                        <p>
                                            All import duties, taxes or VAT are the sole responsibility of the customer and are not 
                                            included in the shipping charges. If you are unsure if your parcel will be subject to such fees 
                                            you should contact your local customs or postal authority.
                                        </p>
                                        <h2>Payment Methods</h2>
                                        <p> We accept payment via Visa, MasterCard, American Express and Paypal.</p>
                                        <div class="DivSideBar" style="text-align:center">
                                            <asp:Image ID="VisaImage" runat="server" ImageUrl="~/Images/System/VisaCard.gif" />
                                            <asp:Image ID="MasterCardImage" runat="server" ImageUrl="~/Images/System/MasterCard.gif" />
                                            <asp:Image ID="AmexCardImage" runat="server" ImageUrl="~/Images/System/AmexCard.gif" />
                                            <asp:Image ID="PayPalImage" runat="server" ImageUrl="~/Images/System/PayPal.gif" />
                                        </div>
                                    </div>
                                </td>
                                <td style="text-align:center" valign="top">
                                    <%--images go here--%>
                                    <%--<span class="PriceDeal"/>--%>
                                    <span class="Price">
                                        <asp:Label ID="Label1" runat="server" Visible='<%#Int32.Parse(Eval("IsOnSale").ToString())==0%>'>Price <%#SessionHandler.Instance.CurrencyValue%>&nbsp;<%#CultureService.getConvertedPrice(Eval("UnitPrice").ToString(), SessionHandler.Instance.CurrencyXRate, SessionHandler.Instance.CurrencyValue)%></asp:Label>
                                        <asp:Label ID="Label2" class="PriceDeal" runat="server" Visible='<%#Int32.Parse(Eval("IsOnSale").ToString())==1%>'><%#SessionHandler.Instance.CurrencyValue + " " + CultureService.getConvertedPrice(Eval("DiscountUnitPrice").ToString(), SessionHandler.Instance.CurrencyXRate, SessionHandler.Instance.CurrencyValue)%></asp:Label>
                                        <asp:Label Visible="false" ID="HiddenUnitPriceLabel" runat="server" Text='<%#Eval("UnitPrice")%>' />
                                        <asp:Label Visible="false" ID="ProductNameLabel" runat="server" Text='<%#Eval("Name")%>' />
                                        <asp:Label Visible="false" ID="CompanyNameLabel" runat="server" Text='<%#Eval("CompanyName")%>' />
                                        <asp:Label Visible="false" ID="DiscountUnitPriceLabel" runat="server" Text='<%#Eval("DiscountUnitPrice")%>' />
                                        <asp:Label Visible="false" ID="ProductWeightLabel" runat="server" Text='<%#Eval("Weight")%>' />
                                        <asp:Label Visible="false" ID="OnSaleLabel" runat="server" Text='<%#Eval("IsOnSale")%>' />
                                        <asp:Label Visible="false" ID="ImagePathLabel" runat="server" Text='<%#Eval("DefaultImage")%>' />
                                        <asp:Label Visible="false" ID="NumProductSizes" runat="server" Text='<%#Eval("NumProductSizes")%>' />
                                        <asp:Label Visible="false" ID="NumProductColors" runat="server" Text='<%#Eval("NumProductColors")%>' />
                                    </span>
                                    <br>
                                    <asp:Image ID="MainImage" runat="server" 
                                               Height="300px" 
                                               Width="260px" 
                                               ImageUrl='<%#Eval("DefaultImage")%>' /><br>
                                    <asp:Label ID="ProductImageName" runat="server" Text='<%#Eval("imgName")%>' />
                                    <asp:Panel ID="MiniImagePanel" runat="server">
                                        <hr/>
                                        <ul class="MiniProduct">
                                            <%--LIST VIEW HERE--%>
                                            <asp:ListView ID="MiniImageListView" runat="server" 
                                                          DataSourceID="ImagesODS"
                                                          DataKeyNames="ID"
                                                          OnItemDataBound="MiniImageListView_ItemDataBound">
                                                <EmptyItemTemplate>
                                                      <li/>
                                                </EmptyItemTemplate>
                                                <LayoutTemplate>
                                                    <li ID="itemPlaceholder" runat="server"
                                                            class="MiniProduct">
                                                    </li>
                                                </LayoutTemplate>
                                                <ItemTemplate>
                                                    <li id="MiniProductImage" runat="server"
                                                        class="MiniProduct">
                                                        <asp:Image ID="MiniImage" runat="server" 
                                                                   Height="45px" 
                                                                   Width="39px" 
                                                                   ImageUrl='<%#Eval("imgPath")%>'
                                                                   AlternateText='<%#Eval("imgName")%>'/>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:ListView>
                                        </ul>
                                    </asp:Panel>
                                </td>
                            </tr>
                                <td>&nbsp;</td>
                                <td align="left">    
                                    <asp:HyperLink ID="ManageHyperLink" runat="server"
                                                   Text="Manage"
                                                   NavigateURL='<%#"~/Web/Merchandise/Product/ManageImage.aspx?DepID=" + Request["DepID"] + "&DepName=" + Request["DepName"] + "&CatID=" + Request["CatID"] + "&CatName=" + Request["CatName"] + "&ProdID=" + Eval("ID") + "&ProdName=" + Eval("Name")%>'/>
                                </td>
                            </tr>
                        </table>
                        <hr />
                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"/>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <div>
                            <table width="100%">
                                <tr>
                                    <td class="label">Name:</td>
                                    <td><asp:TextBox ID="NameEditTextBox" runat="server" Text='<%# Bind("Name")%>' CssClass="TextEntry" /></td>
                                    <td><asp:RequiredFieldValidator ID="NameEditRFV" runat="server" 
                                                                    ControlToValidate="NameEditTextBox" 
                                                                    ErrorMessage="Required"
                                                                    ValidationGroup="ProductGroup"
                                                                    Display="Dynamic" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">Description:</td>
                                    <td><asp:TextBox ID="DescriptionEditTextBox" runat="server" Text='<%# Bind("Description")%>' CssClass="TextEntry" /></td>
                                    <td><asp:RequiredFieldValidator ID="DescriptionEditRFV" runat="server" 
                                                                    ControlToValidate="DescriptionEditTextBox" 
                                                                    ErrorMessage="Required"
                                                                    ValidationGroup="ProductGroup"
                                                                    Display="Dynamic" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Brand:</td>
                                    <td>
                                        <brand:BrandDDL ID="BrandEditDropDownList" runat="server"
                                                        SelectedValue='<%# Bind("BrandID") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Supplier:</td>
                                    <td>
                                        <supplier:SupplierDDL ID="SupplierEditDropDownList" runat="server"
                                                              SelectedValue='<%# Bind("SupplierID") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Quantity Per Unit:</td>
                                    <td><asp:TextBox ID="QuantityPerUnitEditTextBox" runat="server" 
                                                     Text='<%# Bind("QuantityPerUnit") %>' CssClass="NumericEntry" /></td>
                                    <td><asp:RequiredFieldValidator ID="QuantityRFV" runat="server" 
                                                                    ControlToValidate="QuantityPerUnitEditTextBox" 
                                                                    ErrorMessage="Required" 
                                                                    Display="Dynamic" />
                                        <asp:CompareValidator ID="QuantityCheckFormat" runat="server" 
                                                              ControlToValidate="QuantityPerUnitEditTextBox" 
                                                              Operator="DataTypeCheck" 
                                                              Type="Integer"
                                                              ErrorMessage="Illegal format for numeric"
                                                              Display="Dynamic" />
                                        <asp:RegularExpressionValidator ID="QuantityREVNN" runat="server"
                                                                        ErrorMessage="Must be positive"
                                                                        ControlToValidate="QuantityPerUnitEditTextBox"
                                                                        ValidationExpression="[+]?([0-9]*\.)?[0-9]+"
                                                                        Display="Dynamic" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Retail Price ($):</td>
                                    <td><asp:TextBox ID="UnitPriceEditTextBox" runat="server"
                                                     CssClass="CurrencyEntry" 
                                                     Text='<%# Bind("UnitPrice", "{0:N}") %>'
                                                     OnTextChanged="UnitPriceEditTextBox_TextChanged" /></td>
                                    <td><asp:RequiredFieldValidator ID="UnitPriceRFV" runat="server" 
                                                                    ControlToValidate="UnitPriceEditTextBox" 
                                                                    ErrorMessage="Required" 
                                                                    Display="Dynamic" />
                                        <asp:CompareValidator ID="UnitPriceCheckFormat" runat="server" 
                                                              ControlToValidate="UnitPriceEditTextBox" 
                                                              Operator="DataTypeCheck" 
                                                              Type="Double"
                                                              ErrorMessage="Illegal format for numeric"
                                                              Display="Dynamic" />
                                        <asp:CompareValidator ID="UnitPriceEditNotZero" runat="server" 
                                                              ControlToValidate="UnitPriceEditTextBox" 
                                                              Operator="NotEqual"
                                                              ValueToCompare="0"
                                                              Type="Double"
                                                              ErrorMessage="Retail Price should not be 0"
                                                              Display="Dynamic" />
                                        <asp:RegularExpressionValidator ID="UnitPriceREVNN" runat="server"
                                                                        ErrorMessage="Must be positive"
                                                                        ControlToValidate="UnitPriceEditTextBox"
                                                                        ValidationExpression="[+]?([0-9]*\.)?[0-9]+"
                                                                        Display="Dynamic" />
                                    </td>  
                                </tr>
                                <tr>
                                    <td>Wholesale Price ($):</td>
                                    <td><asp:TextBox ID="WholesalePriceEditTextBox" runat="server" 
                                                     Text='<%# Bind("WholesalePrice", "{0:N}") %>'
                                                     CssClass="CurrencyEntry" /></td>
                                    <td><asp:RequiredFieldValidator ID="WholesalePriceRFV" runat="server" 
                                                                    ControlToValidate="WholesalePriceEditTextBox" 
                                                                    ErrorMessage="Required" 
                                                                    Display="Dynamic" />
                                        <asp:CompareValidator ID="WholesalePriceCheckFormat" runat="server" 
                                                              ControlToValidate="WholesalePriceEditTextBox" 
                                                              Operator="DataTypeCheck" 
                                                              Type="Double"
                                                              ErrorMessage="Illegal format for numeric"
                                                              Display="Dynamic" />
                                        <asp:CompareValidator ID="WholesalePriceLessThanUnitPrice" runat="server" 
                                                              ControlToValidate="WholesalePriceEditTextBox" 
                                                              Operator="LessThan"
                                                              Type="Double"
                                                              ControlToCompare="UnitPriceEditTextBox"
                                                              ErrorMessage="Wholesale Price is not less than Sale Price"
                                                              Display="Dynamic" />
                                        <asp:RegularExpressionValidator ID="WholesalePriceREVNN" runat="server"
                                                                        ErrorMessage="Must be positive"
                                                                        ControlToValidate="WholesalePriceEditTextBox"
                                                                        ValidationExpression="[+]?([0-9]*\.)?[0-9]+"
                                                                        Display="Dynamic" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Weight:</td>
                                    <td><asp:TextBox ID="WeightEditTextBox" runat="server" 
                                                     Text='<%# Bind("Weight") %>' CssClass="NumericEntry" /></td>
                                    <td><asp:RequiredFieldValidator ID="WeightRFV" runat="server" 
                                                                    ControlToValidate="WeightEditTextBox" 
                                                                    ErrorMessage="Required" 
                                                                    Display="Dynamic" />
                                        <asp:CompareValidator ID="WeightCheckFormat" runat="server" 
                                                              ControlToValidate="WeightEditTextBox" 
                                                              Operator="DataTypeCheck" 
                                                              Type="Double"
                                                              ErrorMessage="Illegal format for numeric"
                                                              Display="Dynamic" />
                                        <asp:RegularExpressionValidator ID="WeightREVNN" runat="server"
                                                                        ErrorMessage="Must be positive"
                                                                        ControlToValidate="WeightEditTextBox"
                                                                        ValidationExpression="[+]?([0-9]*\.)?[0-9]+"
                                                                        Display="Dynamic" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Units In Stock:</td>
                                    <td><asp:TextBox ID="UnitsInStockEditTextBox" runat="server" 
                                                     Text='<%# Bind("UnitsInStock") %>' CssClass="NumericEntry" /></td>
                                    <td><asp:RequiredFieldValidator ID="UnitsInStockRFV" runat="server" 
                                                                    ControlToValidate="UnitsInStockEditTextBox" 
                                                                    ErrorMessage="Required" 
                                                                    Display="Dynamic" />
                                        <asp:CompareValidator ID="UnitsInStockCheckFormat" runat="server" 
                                                              ControlToValidate="UnitsInStockEditTextBox" 
                                                              Operator="DataTypeCheck" 
                                                              Type="Integer"
                                                              ErrorMessage="Illegal format for numeric"
                                                              Display="Dynamic" />
                                        <asp:RegularExpressionValidator ID="UnitsInStockREVNN" runat="server"
                                                                        ErrorMessage="Must be positive"
                                                                        ControlToValidate="UnitsInStockEditTextBox"
                                                                        ValidationExpression="[+]?([0-9]*\.)?[0-9]+"
                                                                        Display="Dynamic" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Units On Order:</td>
                                    <td><asp:TextBox ID="UnitsOnOrderEditTextBox" runat="server" 
                                                     Text='<%# Bind("UnitsOnOrder") %>' CssClass="NumericEntry" /></td>
                                    <td><asp:RequiredFieldValidator ID="UnitsOnOrderRFV" runat="server" 
                                                                    ControlToValidate="UnitsOnOrderEditTextBox" 
                                                                    ErrorMessage="Required" 
                                                                    Display="Dynamic" />
                                        <asp:CompareValidator ID="UnitsOnOrderCheckFormat" runat="server" 
                                                              ControlToValidate="UnitsOnOrderEditTextBox" 
                                                              Operator="DataTypeCheck" 
                                                              Type="Integer"
                                                              ErrorMessage="Illegal format for numeric"
                                                              Display="Dynamic" />
                                        <asp:RegularExpressionValidator ID="UnitsOnOrderREVNN" runat="server"
                                                                        ErrorMessage="Must be positive"
                                                                        ControlToValidate="UnitsOnOrderEditTextBox"
                                                                        ValidationExpression="[+]?([0-9]*\.)?[0-9]+"
                                                                        Display="Dynamic" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>ReOrder Level:</td>
                                    <td><asp:TextBox ID="ReOrderLevelEditTextBox" runat="server" 
                                                     Text='<%# Bind("ReOrderLevel") %>' CssClass="NumericEntry" /></td>
                                    <td><asp:RequiredFieldValidator ID="ReOrderRFV" runat="server" 
                                                                    ControlToValidate="ReOrderLevelEditTextBox" 
                                                                    ErrorMessage="Required" 
                                                                    Display="Dynamic" />
                                        <asp:CompareValidator ID="ReOrderCheckFormat" runat="server" 
                                                              ControlToValidate="ReOrderLevelEditTextBox" 
                                                              Operator="DataTypeCheck" 
                                                              Type="Integer"
                                                              ErrorMessage="Illegal format for numeric"
                                                              Display="Dynamic" />
                                        <asp:RegularExpressionValidator ID="ReOrderREVNN" runat="server"
                                                                        ErrorMessage="Must be positive"
                                                                        ControlToValidate="ReOrderLevelEditTextBox"
                                                                        ValidationExpression="[+]?([0-9]*\.)?[0-9]+"
                                                                        Display="Dynamic" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td>Active:</td>
                                    <td>
                                        <yesNo:YesNoDDL ID="ActiveEditDropDownList" runat="server"
                                                        SelectedValue='<%# Bind("Active") %>' />
                                     </td>
                                </tr>
                                 <tr>
                                    <td>Is On Sale:</td>
                                    <td>
                                        <yesNo:YesNoDDL ID="OnSaleEditDDL" runat="server"
                                                        SelectedValue='<%# Bind("IsOnSale") %>'
                                                        AutoPostBack="True"
                                                        OnSelectedIndexChanged="OnSaleEditDropDownList_SelectedIndexChanged" />
                                        <%--<asp:DropDownList ID="OnSaleEditDropDownList" runat="server" 
                                                          SelectedValue='<%# Bind("IsOnSale") %>' 
                                                          AutoPostBack="True"
                                                          OnSelectedIndexChanged="OnSaleEditDropDownList_SelectedIndexChanged">
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:DropDownList>--%>
                                     </td>
                                </tr>
                                 <tr>
                                    <td>Sale Price ($):</td>
                                    <td><asp:TextBox ID="DiscountUnitPriceEditTextBox" runat="server" 
                                                     Text='<%# Bind("DiscountUnitPrice", "{0:N}") %>'
                                                     CssClass="CurrencyEntry" /></td>
                                    <td><asp:RequiredFieldValidator ID="DiscountUnitPriceEditRFV" runat="server" 
                                                                    ControlToValidate="DiscountUnitPriceEditTextBox" 
                                                                    ErrorMessage="Required" 
                                                                    Display="Dynamic"
                                                                    ValidationGroup="ProductGroup" />
                                        <asp:CompareValidator ID="DiscountUnitPriceEditCheckFormat" runat="server" 
                                                              ControlToValidate="DiscountUnitPriceEditTextBox" 
                                                              Operator="DataTypeCheck" 
                                                              Type="Double"
                                                              ErrorMessage="Illegal format for numeric"
                                                              Display="Dynamic"
                                                              ValidationGroup="ProductGroup" />
                                        <asp:CompareValidator ID="DiscountUnitPriceEditCheckQuantum" runat="server" 
                                                              ControlToValidate="DiscountUnitPriceEditTextBox" 
                                                              Operator="GreaterThan"
                                                              ControlToCompare="WholesalePriceEditTextBox"
                                                              ErrorMessage="Sale Price must be greater than wholesale price"
                                                              Display="Dynamic"
                                                              ValidationGroup="ProductGroup" />
                                    </td>
                                </tr>
                                <tr>
                                    <br/>
                                    <th colspan="2" align="center"><b>SEO</b></th>
                                </tr>
                                <tr>
                                    <td class="label">Title:</td>
                                    <td><asp:TextBox ID="SEOTitleEditTextBox" runat="server" Text='<%# Bind("SEOTitle")%>' CssClass="TextEntry" /></td>
                                </tr>
                                <tr>
                                    <td class="label">Keywords:</td>
                                    <td><asp:TextBox ID="SEOKeywordsEditTextBox" runat="server" Text='<%# Bind("SEOKeywords")%>' CssClass="TextEntry" /></td>
                                </tr>
                                <tr>
                                    <td class="label">Description:</td>
                                    <td><asp:TextBox ID="SEODescEditTextBox" runat="server" Text='<%# Bind("SEODescription")%>' CssClass="TextEntry" /></td>
                                </tr>
                                <tr>
                                    <td class="label">Friendly Name:</td>
                                    <td><asp:TextBox ID="SEOFriendlyNameURLEditTextBox" runat="server" Text='<%# Bind("SEOFriendlyNameURL")%>' CssClass="TextEntry" /></td>
                                </tr>
                            </table>
                            <asp:Button ID="btnSave" runat="server" CssClass="linkButton" Text="Save" CommandName="Update" ValidationGroup="ProductGroup"/>
                            <asp:Button ID="btnCancel" runat="server" CssClass="linkButton" Text="Cancel" CommandName="Cancel" />
                        </div>
                    </EditItemTemplate>
                </asp:FormView>
            <%} else { %>
                <div>
                    <asp:Label ID="HomeLiteral" CssClass="HyperLinkLook" runat="server"
                               Text="Home" />
                    <hr />
                </div>
                <h1>Product not found.</h1>
            <%} %>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="currencyDDL:CurrencyDropDownList" 
                                      EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>    
    <asp:ObjectDataSource ID="ImagesODS" runat="server" 
                          TypeName="eStoreAdminBLL.ImagesBLL"
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetImagesByProductId">
        <SelectParameters>
            <asp:QueryStringParameter Name="productID" 
                                      QueryStringField="ProdID" 
                                      Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ProductODS" runat="server"
                          TypeName="eStoreAdminBLL.ProductsBLL" 
                          OldValuesParameterFormatString="original_{0}" 
                          SelectMethod="GetProductByIdAndCurrencyId"
                          UpdateMethod="UpdateProduct">
        <SelectParameters>
            <asp:QueryStringParameter Name="ID" 
                                      QueryStringField="ProdID" 
                                      Type="Int32" />
            <%--<asp:SessionParameter Name="currencyID" DefaultValue="1" Type="Int32" />--%>
            <asp:SessionParameter Name="currencyID" SessionField="Currency" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>