<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SupplierDDL.ascx.cs" Inherits="eStoreAdminWeb.Controls.SupplierDDL" %>
<asp:DropDownList ID="SupplierDropDownList" runat="server" 
                  DataSourceID="SupplierEDS"
                  DataTextField="CompanyName" 
                  DataValueField="ID"
                  OnSelectedIndexChanged="ddl_SelectedIndexChanged"/>
<asp:EntityDataSource ID="SupplierEDS" runat="server"
                      ConnectionString="name=eStoreEntities"
                      DefaultContainerName="eStoreAdminEntities"
                      EntitySetName="Suppliers"
                      EnableFlattening="False" />
<%--<asp:ObjectDataSource ID="SupplierODS" runat="server" 
                      OldValuesParameterFormatString="original_{0}" 
                      SelectMethod="getSuppliers" 
                      TypeName="eStoreAdminBLL.SuppliersBLL" />--%>