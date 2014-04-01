<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModeDDL.ascx.cs" Inherits="eStoreAdminWeb.Controls.ModeDDL" %>
<asp:DropDownList ID="ModeDropDownList" runat="server" 
                  DataSourceID="ModesEDS" 
                  DataTextField="Name" 
                  DataValueField="ID"
                  OnSelectedIndexChanged="ddl_SelectedIndexChanged"  />
<asp:EntityDataSource ID="ModesEDS" runat="server"
                      ConnectionString="name=eStoreEntities"
                      DefaultContainerName="eStoreAdminEntities"
                      EntitySetName="ShipToModes"
                      EnableFlattening="False" />