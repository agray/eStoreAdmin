<%@ Page Title="Import/Export Home" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ImportExportHome.aspx.cs" Inherits="eStoreAdminWeb.ImportExportHome" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Import / Export</h1>
    <p>Use the links in this section to import and export catalog items to and from eStore.</p>
    <hr />
    <h1>DOWNLOAD FUNCTIONS</h1>
    
    <p>
        <asp:HyperLink ID="Hyperlink17" runat="server" 
                       CssClass="heading2Link"
                       Text="DOWNLOAD TRANSACTIONS" 
                       NavigateUrl="ManageTransactionExport.aspx" /><br/>
        Download Transaction details. This downloaded file includes all the transactions entered through the system.
    </p>

    <p>
        <asp:HyperLink ID="Hyperlink13" runat="server" 
                       CssClass="heading2Link"
                       Text="DOWNLOAD DEPARTMENTS" 
                       NavigateUrl="ManageDepartmentExport.aspx" /><br/>
        Download Department details. This downloaded file can be updated by you and re-uploaded using the Update Department function.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink14" runat="server" 
                       CssClass="heading2Link"
                       Text="DOWNLOAD CATEGORIES" 
                       NavigateUrl="ManageCategoryExport.aspx" /><br/>
        Download Category details. This downloaded file can be updated by you and re-uploaded using the Update Category function.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink1" runat="server" 
                       CssClass="heading2Link"
                       Text="DOWNLOAD PRODUCTS" 
                       NavigateUrl="ManageProductExport.aspx" /><br/>
        Download Product details. This function will only download product details.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink2" runat="server" 
                       CssClass="heading2Link"
                       Text="DOWNLOAD PRODUCT INVENTORY" 
                       NavigateUrl="ManageProductInventoryExport.aspx" /><br/>
        Download inventory levels for Products. You can then edit this file and re-upload it to update inventory levels if required.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink3" runat="server" 
                       CssClass="heading2Link"
                       Text="DOWNLOAD PRODUCT PRICING" 
                       NavigateUrl="ManageProductPricingExport.aspx" /><br/>
        Download pricing for Products. This downloaded file can be updated by you and re-uploaded using the Update Pricing function.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink4" runat="server" 
                       CssClass="heading2Link"
                       Text="DOWNLOAD SUPPLIERS" 
                       NavigateUrl="ManageSupplierExport.aspx" /><br/>
        Download Suppliers. This downloaded file can be updated by you and re-uploaded using the Update Supplier function.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink5" runat="server" 
                       CssClass="heading2Link"
                       Text="DOWNLOAD TESTIMONIALS" 
                       NavigateUrl="ManageTestimonialExport.aspx" /><br/>
        Download Testimonials. This downloaded file can be updated by you and re-uploaded using the Update Testimonial function.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink6" runat="server" 
                       CssClass="heading2Link"
                       Text="DOWNLOAD LINKS" 
                       NavigateUrl="ManageLinkExport.aspx" /><br/>
        Download Links. This downloaded file can be updated by you and re-uploaded using the Update Link function.
    </p>
    
    <h1>UPLOAD FUNCTIONS</h1>
    
    <p>
        <asp:HyperLink ID="Hyperlink15" runat="server" 
                       CssClass="heading2Link"
                       Text="UPLOAD DEPARTMENTS" 
                       NavigateUrl="ManageDepartmentImport.aspx" /><br/>
        Upload Departments. You can use the Download Department function to get an initial department list that you can re-upload using this function.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink16" runat="server" 
                       CssClass="heading2Link"
                       Text="UPLOAD CATEGORIES" 
                       NavigateUrl="ManageCategoryImport.aspx" /><br/>
        Upload Categories. You can use the Download Category function to get an initial category list that you can re-upload using this function.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink7" runat="server" 
                       CssClass="heading2Link"
                       Text="UPLOAD PRODUCTS" 
                       NavigateUrl="ManageProductImport.aspx" /><br/>
        Update existing products in your catalog. This function will only upload products to the catalog.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink8" runat="server" 
                       CssClass="heading2Link"
                       Text="UPLOAD PRODUCT INVENTORY" 
                       NavigateUrl="ManageProductInventoryImport.aspx" /><br/>
        Upload inventory levels for Products. You can use the Download Inventory function to get an initial inventory file that you can update and re-upload.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink9" runat="server" 
                       CssClass="heading2Link"
                       Text="UPLOAD PRODUCT PRICING" 
                       NavigateUrl="ManageProductPricingImport.aspx" /><br/>
        Upload pricing for Products. You can use the Download Pricing function to get initial prices that you can re-upload using this function.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink10" runat="server" 
                       CssClass="heading2Link"
                       Text="UPLOAD SUPPLIERS" 
                       NavigateUrl="ManageSupplierImport.aspx" /><br/>
        Upload Suppliers. You can use the Download Supplier function to get an initial supplier list that you can re-upload using this function.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink11" runat="server" 
                       CssClass="heading2Link"
                       Text="UPLOAD TESTIMONIALS" 
                       NavigateUrl="ManageTestimonialImport.aspx" /><br/>
        Upload Testimonials. You can use the Download Testimonial function to get an initial testimonial list that you can re-upload using this function.
    </p>
    
    <p>
        <asp:HyperLink ID="Hyperlink12" runat="server" 
                       CssClass="heading2Link"
                       Text="UPLOAD LINKS" 
                       NavigateUrl="ManageLinkImport.aspx" /><br/>
        Upload Links. You can use the Download Link function to get an initial link list that you can re-upload using this function.
    </p>
</asp:Content>