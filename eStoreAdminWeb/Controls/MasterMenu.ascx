<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MasterMenu.ascx.cs" Inherits="eStoreAdminWeb.Controls.MasterMenu" %>

<%@ Register Src="~/Controls/ManagerMenu.ascx" TagName="ManagerMenu" TagPrefix="eStore" %>
<%@ Register Src="~/Controls/AdminMenu.ascx" TagName="AdminMenu" TagPrefix="eStore" %>
<%@ Register Src="~/Controls/StaffMenu.ascx" TagName="StaffMenu" TagPrefix="eStore" %>

    <%if(Roles.IsUserInRole("Manager")) { %>
        <eStore:ManagerMenu ID="ManagerTopMenu" runat="server" />
    <%} else if(Roles.IsUserInRole("Administrator")) { %>
        <eStore:AdminMenu ID="AdminTopMenu" runat="server" />
    <%} else if(Roles.IsUserInRole("Staff")) { %>
        <eStore:StaffMenu ID="StaffTopMenu" runat="server" />
    <%} %>
