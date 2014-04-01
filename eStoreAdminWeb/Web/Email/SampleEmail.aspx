<%@ Page Title="Sample Email" Language="C#" AutoEventWireup="true" CodeBehind="SampleEmail.aspx.cs" Inherits="eStoreAdminWeb.SampleEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Sample Customer Email</title>
        <link href="../../Stylesheets/PP_style.css" rel="stylesheet" type="text/css" />
    </head>
    <body>
        <div id="DivMain">
            <h1>Sample Email</h1>
            <table align="center" style="background-color:#E8E8E8">
                <tr align="left">
                    <td>
                        <asp:Label ID="EmailSalutationLabel" runat="server" />
                        <i><<asp:Label ID="CustomerNameLabel" runat="server" />>,</i>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr align="left">
                    <td><asp:Label ID="OpeningLabel" runat="server" /></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr align="left">
                    <td><i>Your message goes here</i></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr align="left">
                    <td><asp:Label ID="ClosingLabel" runat="server" /></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr align="left">
                    <td><asp:Label ID="TradingNameLabel" runat="server" /></td>
                </tr>
            </table>
        </div>
    </body>
</html>