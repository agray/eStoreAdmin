<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductSizeDDL.ascx.cs" Inherits="eStoreAdminWeb.Controls.ProductSizeDDL" %>
<asp:DropDownList ID="SizeDropDownList" runat="server" 
                  DataSourceID="SizesODS" 
                  DataTextField="Name" 
                  DataValueField="ID" />
<%--<asp:EntityDataSource ID="SizesEDS" runat="server"
                      ConnectionString="name=eStoreEntities"
                      DefaultContainerName="eStoreAdminEntities"
                      EntitySetName="ProductSizes"
                      EnableFlattening="False"
                      Select="getSizesByProductID">
    <SelectParameters>
        <asp:QueryStringParameter Name="productID" 
                                  QueryStringField="ProdID" 
                                  Type="Int32" />
    </SelectParameters>
</asp:EntityDataSource>--%>
<asp:ObjectDataSource ID="SizesODS" runat="server" 
                      TypeName="eStoreAdminBLL.SizesBLL"
                      OldValuesParameterFormatString="original_{0}" 
                      SelectMethod="GetSizesByProductId">
    <SelectParameters>
        <asp:QueryStringParameter Name="productID" 
                                  QueryStringField="ProdID" 
                                  Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>