<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RoleDDL.ascx.cs" Inherits="eStoreAdminWeb.Controls.RoleDDL" %>
<asp:DropDownList ID="UserRolesDropDownList" runat="server"
                  OnSelectedIndexChanged="OnSelectedIndexChanged"
                  AppendDataBoundItems="true" />