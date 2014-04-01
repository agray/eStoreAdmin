﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CurrencyDDL_NoSIC.ascx.cs" Inherits="eStoreAdminWeb.Controls.CurrencyDDL_NoSIC" %>

<asp:DropDownList ID="CurrencyDropDownList_NoSIC" runat="server" 
                  DataSourceID="CurrenciesEDS" 
                  DataTextField="Name" 
                  DataValueField="ID"
                  AutoPostBack="True" 
                  EnableViewState="True"/>
<asp:EntityDataSource ID="CurrenciesEDS" runat="server"
                      ConnectionString="name=eStoreEntities"
                      DefaultContainerName="eStoreAdminEntities"
                      EntitySetName="Currencies"
                      EnableFlattening="False" />
<%--<asp:ObjectDataSource ID="CurrenciesODS" runat="server" 
                      TypeName="eStoreAdminBLL.CurrenciesBLL"
                      OldValuesParameterFormatString="original_{0}"
                      SelectMethod="getCurrencies"
                      EnableCaching="True"
                      CacheDuration="3600"
                      CacheExpirationPolicy="Absolute" />--%>