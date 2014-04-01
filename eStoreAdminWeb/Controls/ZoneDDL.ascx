<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ZoneDDL.ascx.cs" Inherits="eStoreAdminWeb.Controls.ZoneDDL" %>
<asp:DropDownList ID="ZoneDropDownList" runat="server" 
                  DataSourceID="ZonesEDS" 
                  DataTextField="Name" 
                  DataValueField="ID"
                  OnSelectedIndexChanged="ddl_SelectedIndexChanged" />
<asp:EntityDataSource ID="ZonesEDS" runat="server"
                      ConnectionString="name=eStoreEntities"
                      DefaultContainerName="eStoreAdminEntities"
                      EntitySetName="Zones"
                      EnableFlattening="False" />