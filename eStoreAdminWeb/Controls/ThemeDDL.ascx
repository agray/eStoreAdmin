<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThemeDDL.ascx.cs" Inherits="eStoreAdminWeb.Controls.ThemeDDL" %>
<asp:DropDownList ID="ThemeDropDownList" runat="server" 
                  DataSourceID="ThemesEDS" 
                  DataTextField="Name" 
                  DataValueField="ID"
                  OnSelectedIndexChanged="ddl_SelectedIndexChanged"  />
<asp:EntityDataSource ID="ThemesEDS" runat="server"
                      ConnectionString="name=eStoreEntities"
                      DefaultContainerName="eStoreAdminEntities"
                      EntitySetName="Themes"
                      EnableFlattening="False" />
<%--<asp:ObjectDataSource ID="ThemesODS" runat="server" 
                      TypeName="eStoreAdminBLL.ThemeBLL"
                      OldValuesParameterFormatString="original_{0}" 
                      SelectMethod="getThemes" />--%>