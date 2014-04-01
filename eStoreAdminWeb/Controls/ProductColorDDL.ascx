<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductColorDDL.ascx.cs" Inherits="eStoreAdminWeb.Controls.ProductColorDDL" %>
<asp:DropDownList ID="ColorDropDownList" runat="server" 
                  DataSourceID="ColorsODS" 
                  DataTextField="Name" 
                  DataValueField="ID">
</asp:DropDownList>
<%--<asp:EntityDataSource ID="ColorsEDS" runat="server"
                      ConnectionString="name=eStoreEntities"
                      DefaultContainerName="eStoreAdminEntities"
                      EntitySetName="ProductColors"
                      EnableFlattening="False"
                      Select="getColorsByProductID">
    <SelectParameters>
        <asp:QueryStringParameter Name="productID" 
                                  QueryStringField="ProdID" 
                                  Type="Int32" />
    </SelectParameters>
</asp:EntityDataSource>--%>
<asp:ObjectDataSource ID="ColorsODS" runat="server" 
                      TypeName="eStoreAdminBLL.ColorsBLL"
                      OldValuesParameterFormatString="original_{0}" 
                      SelectMethod="GetColorsByProductId">
    <SelectParameters>
        <asp:QueryStringParameter Name="productID" 
                                  QueryStringField="ProdID" 
                                  Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>