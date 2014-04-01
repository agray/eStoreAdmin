<%@ Page Title="Add Product" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="eStoreAdminWeb.Web.Merchandise.Category.AddProduct" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<%@ Register tagprefix="supplier" tagname="SupplierDDL" src="~/Controls/SupplierDDL.ascx" %>
<%@ Register tagprefix="brand" tagname="BrandDDL" src="~/Controls/BrandDDL.ascx" %>
<%@ Register tagprefix="yesNo" tagname="YesNoDDL" src="~/Controls/YesNoDDL.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) {
        FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Add Product</h1>
    <asp:FormView ID="AddProductFormView" runat="server"
                  DataSourceID="ProductODS" 
                  DataKeyNames="ID"
                  OnItemInserted="AddProductFormView_ItemInserted"
                  OnItemCommand="AddProductFormView_ItemCommand">
        <InsertItemTemplate>
            <table width="100%">
                <tr>
                    <td>Name:</td>
                    <td><asp:TextBox ID="NameAddTextBox" runat="server" Text='<%# Bind("Name")%>' />
                        <asp:RequiredFieldValidator ID="NameAddRFV" runat="server" 
                                                    ControlToValidate="NameAddTextBox" 
                                                    ErrorMessage="Required"
                                                    ValidationGroup="ProductGroup"
                                                    Display="Dynamic" />
                    </td>
                </tr>
		        <tr>
                    <td>Description:</td>
                    <td><asp:TextBox ID="DescriptionAddTextBox" runat="server" Text='<%# Bind("Description")%>' />
                        <asp:RequiredFieldValidator ID="DescriptionAddRFV" runat="server" 
                                                    ControlToValidate="DescriptionAddTextBox" 
                                                    ErrorMessage="Required"
                                                    ValidationGroup="ProductGroup"
                                                    Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>Brand:</td>
                    <td>
                        <brand:BrandDDL ID="BrandAddDDL" runat="server"
                                        AppendDataBoundItems="true"
                                        SelectedValue='<%# Bind("BrandID") %>'>
                            <Items>
                                <asp:ListItem Text=""/>
                            </Items>
                        </brand:BrandDDL>
                        <asp:RequiredFieldValidator ID="BrandRFV" runat="server" 
                                                    ControlToValidate="BrandAddDDL:BrandDropDownList" 
                                                    ErrorMessage="Required" 
                                                    Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>Supplier:</td>
                    <td>
                        <supplier:SupplierDDL ID="SupplierAddDDL" runat="server"
                                              AppendDataBoundItems="true"
                                              SelectedValue='<%# Bind("SupplierID") %>'>
                            <Items>
                                <asp:ListItem Text=""/>
                            </Items>
                        </supplier:SupplierDDL>
                        <asp:RequiredFieldValidator ID="SupplierRFV" runat="server" 
                                                    ControlToValidate="SupplierAddDDL:SupplierDropDownList" 
                                                    ErrorMessage="Required" 
                                                    Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>Quantity Per Unit:</td>
                    <td><asp:TextBox ID="QuantityPerUnitAddTextBox" runat="server" 
                                     Text='<%# Bind("QuantityPerUnit") %>' /></td>
                    <td><asp:RequiredFieldValidator ID="QuantityRFV" runat="server" 
                                                    ControlToValidate="QuantityPerUnitAddTextBox" 
                                                    ErrorMessage="Required" 
                                                    Display="Dynamic" />
                        <asp:CompareValidator ID="QuantityAddCheckFormat" runat="server" 
                                              ControlToValidate="QuantityPerUnitAddTextBox" 
                                              Operator="DataTypeCheck" 
                                              Type="Integer"
                                              ErrorMessage="Illegal format for numeric"
                                              Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="QuantityAddREVNN" runat="server"
                                                        ErrorMessage="Must be positive"
                                                        ControlToValidate="QuantityPerUnitAddTextBox"
                                                        ValidationExpression="[+]?([0-9]*\.)?[0-9]+"
                                                        Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>Retail Price:</td>
                    <td><asp:TextBox ID="UnitPriceAddTextBox" runat="server" 
                                     Text='<%# Bind("UnitPrice") %>' /></td>
                    <td><asp:RequiredFieldValidator ID="UnitPriceAddRFV" runat="server" 
                                                    ControlToValidate="UnitPriceAddTextBox" 
                                                    ErrorMessage="Required" 
                                                    Display="Dynamic" />
                        <asp:CompareValidator ID="UnitPriceAddCheckFormat" runat="server" 
                                              ControlToValidate="UnitPriceAddTextBox" 
                                              Operator="DataTypeCheck" 
                                              Type="Double"
                                              ErrorMessage="Illegal format for numeric"
                                              Display="Dynamic" />
                        <asp:CompareValidator ID="UnitPriceAddNotZero" runat="server" 
                                              ControlToValidate="UnitPriceAddTextBox" 
                                              Operator="NotEqual"
                                              ValueToCompare="0"
                                              Type="Double"
                                              ErrorMessage="Retail Price should not be 0"
                                              Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="UnitPriceAddREVNN" runat="server"
                                                        ErrorMessage="Must be positive"
                                                        ControlToValidate="UnitPriceAddTextBox"
                                                        ValidationExpression="[+]?([0-9]*\.)?[0-9]+"
                                                        Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>Wholesale Price:</td>
                    <td><asp:TextBox ID="WholesalePriceAddTextBox" runat="server" 
                                     Text='<%# Bind("WholesalePrice") %>' /></td>
                    <td><asp:RequiredFieldValidator ID="WholesalePriceAddRFV" runat="server" 
                                                    ControlToValidate="WholesalePriceAddTextBox" 
                                                    ErrorMessage="Required" 
                                                    Display="Dynamic" />
                        <asp:CompareValidator ID="WholesalePriceAddCheckFormat" runat="server" 
                                              ControlToValidate="WholesalePriceAddTextBox" 
                                              Operator="DataTypeCheck" 
                                              Type="Double"
                                              ErrorMessage="Illegal format for numeric"
                                              Display="Dynamic" />
                        <asp:CompareValidator ID="WholesalePriceLessThanUnitPrice" runat="server" 
                                              ControlToValidate="WholesalePriceAddTextBox" 
                                              Operator="LessThan"
                                              Type="Double"
                                              ControlToCompare="UnitPriceAddTextBox"
                                              ErrorMessage="Wholesale Price is not less than Sale Price"
                                              Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="WholesalePriceAddREVNN" runat="server"
                                                        ErrorMessage="Must be positive"
                                                        ControlToValidate="WholesalePriceAddTextBox"
                                                        ValidationExpression="[+]?([0-9]*\.)?[0-9]+"
                                                        Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>Weight:</td>
                    <td><asp:TextBox ID="WeightAddTextBox" runat="server" Text='<%# Bind("Weight") %>' /></td>
                    <td><asp:RequiredFieldValidator ID="WeightAddRFV" runat="server" 
                                                    ControlToValidate="WeightAddTextBox" 
                                                    ErrorMessage="Required" 
                                                    Display="Dynamic" />
                        <asp:CompareValidator ID="WeightAddCheckFormat" runat="server" 
                                              ControlToValidate="WeightAddTextBox" 
                                              Operator="DataTypeCheck" 
                                              Type="Double"
                                              ErrorMessage="Illegal format for numeric"
                                              Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="WeightAddREVNN" runat="server"
                                                        ErrorMessage="Must be positive"
                                                        ControlToValidate="WeightAddTextBox"
                                                        ValidationExpression="[+]?([0-9]*\.)?[0-9]+"
                                                        Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>Units In Stock:</td>
                    <td><asp:TextBox ID="UnitsInStockAddTextBox" runat="server" Text='<%# Bind("UnitsInStock") %>' /></td>
                    <td><asp:RequiredFieldValidator ID="UnitsInStockAddRFV" runat="server" 
                                                    ControlToValidate="UnitsInStockAddTextBox" 
                                                    ErrorMessage="Required" 
                                                    Display="Dynamic" />
                        <asp:CompareValidator ID="UnitsInStockAddCheckFormat" runat="server" 
                                              ControlToValidate="UnitsInStockAddTextBox" 
                                              Operator="DataTypeCheck" 
                                              Type="Integer"
                                              ErrorMessage="Illegal format for numeric"
                                              Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="UnitsInStockAddREVNN" runat="server"
                                                        ErrorMessage="Must be positive"
                                                        ControlToValidate="UnitsInStockAddTextBox"
                                                        ValidationExpression="[+]?([0-9]*\.)?[0-9]+"
                                                        Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>Units On Order:</td>
                    <td><asp:TextBox ID="UnitsOnOrderAddTextBox" runat="server" Text='<%# Bind("UnitsOnOrder") %>' /></td>
                    <td><asp:RequiredFieldValidator ID="UnitsOnOrderAddRFV" runat="server" 
                                                    ControlToValidate="UnitsOnOrderAddTextBox" 
                                                    ErrorMessage="Required" 
                                                    Display="Dynamic" />
                        <asp:CompareValidator ID="UnitsOnOrderAddCheckFormat" runat="server" 
                                              ControlToValidate="UnitsOnOrderAddTextBox" 
                                              Operator="DataTypeCheck" 
                                              Type="Integer"
                                              ErrorMessage="Illegal format for numeric"
                                              Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="UnitsOnOrderAddREVNN" runat="server"
                                                        ErrorMessage="Must be positive"
                                                        ControlToValidate="UnitsOnOrderAddTextBox"
                                                        ValidationExpression="[+]?([0-9]*\.)?[0-9]+"
                                                        Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td>ReOrderLevel:</td>
                    <td><asp:TextBox ID="ReOrderLevelAddTextBox" runat="server" Text='<%# Bind("ReOrderLevel") %>' /></td>
                    <td><asp:RequiredFieldValidator ID="ReOrderRFV" runat="server" 
                                                    ControlToValidate="ReOrderLevelAddTextBox" 
                                                    ErrorMessage="Required" 
                                                    Display="Dynamic" />
                        <asp:CompareValidator ID="ReOrderAddCheckFormat" runat="server" 
                                              ControlToValidate="ReOrderLevelAddTextBox" 
                                              Operator="DataTypeCheck" 
                                              Type="Integer"
                                              ErrorMessage="Illegal format for numeric"
                                              Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="ReOrderAddREVNN" runat="server"
                                                        ErrorMessage="Must be positive"
                                                        ControlToValidate="ReOrderLevelAddTextBox"
                                                        ValidationExpression="[+]?([0-9]*\.)?[0-9]+"
                                                        Display="Dynamic" />
                    </td>
                </tr>
                 <tr>
                    <td>Active:</td>
                    <td>
                        <yesNo:YesNoDDL ID="ActiveAddDDL" runat="server"
                                        SelectedValue='<%# Bind("Active") %>' />
                     </td>
                </tr>
                 <tr>
                    <td>Is On Sale:</td>
                    <td>
                        <%--<yesNo:YesNoDDL ID="OnSaleAddDDL" runat="server"
                                        SelectedValue='<%# Bind("IsOnSale") %>'
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="OnSaleAddDropDownList_SelectedIndexChanged" />--%>
                        <asp:DropDownList ID="OnSaleAddDropDownList" runat="server" 
                                          SelectedValue='<%# Bind("IsOnSale") %>'
                                          AutoPostBack="True"
                                          OnSelectedIndexChanged="OnSaleAddDropDownList_SelectedIndexChanged">
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:DropDownList>
                     </td>
                 </tr>
                 <tr>
                    <td>Sale Price:</td>
                    <td><asp:TextBox ID="DiscountUnitPriceAddTextBox" runat="server" Text='<%# Bind("DiscountUnitPrice") %>' /></td>
                    <td><asp:RequiredFieldValidator ID="DiscountUnitPriceAddRFV" runat="server" 
                                                    ControlToValidate="DiscountUnitPriceAddTextBox" 
                                                    ErrorMessage="Required" 
                                                    Display="Dynamic" />
                        <asp:CompareValidator ID="DiscUnitPriceAddCheckFormat" runat="server" 
                                              ControlToValidate="DiscountUnitPriceAddTextBox" 
                                              Operator="DataTypeCheck" 
                                              Type="Double"
                                              ErrorMessage="Illegal format for numeric"
                                              Display="Dynamic" />
                        <asp:CompareValidator ID="DiscountUnitPriceAddCheckQuantum" runat="server" 
                                              ControlToValidate="DiscountUnitPriceAddTextBox" 
                                              Operator="GreaterThan"
                                              ControlToCompare="WholesalePriceAddTextBox"
                                              ErrorMessage="Sale Price must be greater than wholesale price"
                                              Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="DiscUnitPriceAddREVNN" runat="server"
                                                        ErrorMessage="Must be positive"
                                                        ControlToValidate="DiscountUnitPriceAddTextBox"
                                                        ValidationExpression="[+]?([0-9]*\.)?[0-9]+"
                                                        Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <th colspan="2">SEO SETTINGS</th>
                </tr>
                <tr>
                    <td>Title:</td>
                    <td><asp:TextBox ID="SEOTitleAddTextBox" runat="server" Text='<%# Bind("SEOTitle")%>' /></td>
                </tr>
                <tr>
                    <td>Keywords:</td>
                    <td><asp:TextBox ID="SEOKeywordsAddTextBox" runat="server" Text='<%# Bind("SEOKeywords")%>'  /></td>
                </tr>
                <tr>
                    <td>Description:</td>
                    <td><asp:TextBox ID="SEODescAddTextBox" runat="server" Text='<%# Bind("SEODescription")%>' /></td>
                </tr>
                <tr>
                    <td>Friendly Name:</td>
                    <td><asp:TextBox ID="SEOFriendlyNameURLAddTextBox" runat="server" Text='<%# Bind("SEOFriendlyNameURL")%>' /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" CssClass="linkButton" Text="Save" CommandName="Insert" ValidationGroup="ProductGroup" CausesValidation="True" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="linkButton" Text="Cancel" CommandName="Cancel" OnClick="Cancel_Click" CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </InsertItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="ProductODS" runat="server" 
                          TypeName="eStoreAdminBLL.ProductsBLL"
                          OldValuesParameterFormatString="original_{0}"
                          InsertMethod="AddProduct" >
        <InsertParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="DepID" Type="Int32" />
            <asp:Parameter Name="CatID" Type="Int32" />
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
        </InsertParameters>
    </asp:ObjectDataSource>
</asp:Content>