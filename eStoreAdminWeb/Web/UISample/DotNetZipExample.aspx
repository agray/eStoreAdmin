<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="DotNetZipExample.aspx.cs" Inherits="eStoreAdminWeb.Web.UISample.DotNetZipExample" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>DotNetZip Example</title>
    <link rel="stylesheet" href="style/basic.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h3> <span id="Span1" runat="server" />Zip Files from ASP.NET </h3>

      <p>This page uses the .NET Zip library
      (see <a href="http://www.codeplex.com/DotNetZip">http://www.codeplex.com/DotNetZip</a>)
       to dynamically create a zip archive, and then download it to the browser through Response.OutputStream</p>

      <span class="SampleTitle"><b>Check the boxes to select the files, then click the button to zip them up.</b></span>
      <br/>
      <br/>
      <asp:Button id="Button1" Text="Zip checked files" OnClick="btnGo_Click" runat="server"/>

      <br/>
      <br/>
      <span style="color:red" id="ErrorMessage" runat="server"/>
      <br/>

      <asp:ListView ID="FileListView" runat="server">

        <LayoutTemplate>
          <table>
            <tr ID="itemPlaceholder" runat="server" />
          </table>
        </LayoutTemplate>

        <ItemTemplate>
          <tr>
            <td><asp:Checkbox ID="include" runat="server"/></td>
            <td><asp:Label id="label" runat="server" Text="<%# Container.DataItem %>" /></td>
          </tr>
        </ItemTemplate>

        <EmptyDataTemplate>
          <div>Nothing to see here...</div>
        </EmptyDataTemplate>

      </asp:ListView>
</asp:Content>