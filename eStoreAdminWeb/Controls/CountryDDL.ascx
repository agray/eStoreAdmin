<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CountryDDL.ascx.cs" Inherits="eStoreAdminWeb.Controls.CountryDDL" %>
<%--<asp:DropDownList ID="CountryDropDownList" runat="server" 
                  OnSelectedIndexChanged="ddl_SelectedIndexChanged"
                  OnInit="OnInit" />--%>
<asp:DropDownList ID="CountryDropDownList" runat="server" 
                  DataSourceID="CountriesEDS" 
                  DataTextField="Name" 
                  DataValueField="ID"
                  OnSelectedIndexChanged="ddl_SelectedIndexChanged" />
<asp:EntityDataSource ID="CountriesEDS" runat="server"
                      ConnectionString="name=eStoreEntities"
                      DefaultContainerName="eStoreAdminEntities"
                      EntitySetName="ShipToCountries"
                      EnableFlattening="False" />