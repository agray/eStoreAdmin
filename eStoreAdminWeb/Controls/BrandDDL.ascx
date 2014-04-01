<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BrandDDL.ascx.cs" Inherits="eStoreAdminWeb.Controls.BrandDDL" %>
<asp:DropDownList ID="BrandDropDownList" runat="server" 
                  DataSourceID="BrandEDS"
                  DataTextField="Name" 
                  DataValueField="ID"
                  OnSelectedIndexChanged="ddl_SelectedIndexChanged"/>
<asp:EntityDataSource ID="BrandEDS" runat="server"
                      ConnectionString="name=eStoreEntities"
                      DefaultContainerName="eStoreAdminEntities"
                      EntitySetName="Brands"
                      EnableFlattening="False" />