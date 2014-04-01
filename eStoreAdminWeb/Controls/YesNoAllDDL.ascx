<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YesNoAllDDL.ascx.cs" Inherits="eStoreAdminWeb.Controls.YesNoAllDDL" %>
<asp:DropDownList ID="YesNoAllDropDownList" runat="server"
                  OnSelectedIndexChanged="ddl_SelectedIndexChanged">
    <asp:ListItem Selected="True" Value="2">All</asp:ListItem>
    <asp:ListItem Value="1">Yes</asp:ListItem>
    <asp:ListItem Value="0">No</asp:ListItem>
</asp:DropDownList>