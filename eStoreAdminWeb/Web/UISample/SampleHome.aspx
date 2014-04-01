<%@ Page Title="Samples Home" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="SampleHome.aspx.cs" Inherits="eStoreAdminWeb.Web.UISample.SampleHome" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>Samples</h1>
    <p>See the samples.</p>
    <hr />
    
    <p>
        <asp:HyperLink ID="JQueryHyperlink" runat="server" 
                       CssClass="heading2Link"
                       Text="JQuery UI Samples" 
                       NavigateUrl="~/Web/UISample/JQWithMaster.aspx" /><br/>
        MasterPage JQuery Samples.
    </p>
    <p>
        <asp:HyperLink ID="HyperLink7" runat="server" 
                       CssClass="heading2Link"
                       Text="Cloud Zoom (No MasterPage)" 
                       NavigateUrl="~/Web/UISample/CloudZoom.aspx" /><br/>
        Cloud Zoom.
    </p>
    <p>
        <asp:HyperLink ID="HyperLink8" runat="server" 
                       CssClass="heading2Link"
                       Text="Cloud Zoom (MasterPage)" 
                       NavigateUrl="~/Web/UISample/CloudZoom2.aspx" /><br/>
        Cloud Zoom.
    </p>
    <p>
        <asp:HyperLink ID="HyperLink5" runat="server" 
                       CssClass="heading2Link"
                       Text="Easy Zoom (MasterPage)" 
                       NavigateUrl="~/Web/UISample/EasyZoom2.aspx" /><br/>
        Easy Zoom.
    </p>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" 
                       CssClass="heading2Link"
                       Text="JQuery Zoomer" 
                       NavigateUrl="~/Web/UISample/JQueryZoomer.aspx" /><br/>
        JQuery Zoomer (No MasterPage).
    </p>
    <p>
        <asp:HyperLink ID="HyperLink2" runat="server" 
                       CssClass="heading2Link"
                       Text="JQuery Zoomer" 
                       NavigateUrl="~/Web/UISample/JQueryZoomer2.aspx" /><br/>
        JQuery Zoomer (With MasterPage).
    </p>
    <p>
        <asp:HyperLink ID="HyperLink3" runat="server" 
                       CssClass="heading2Link"
                       Text="JQZoom" 
                       NavigateUrl="~/Web/UISample/JQZoom.aspx" /><br/>
        JQZoom (With MasterPage).
    </p>
    <p>
        <asp:HyperLink ID="HyperLink4" runat="server" 
                       CssClass="heading2Link"
                       Text="MagicZoom" 
                       NavigateUrl="~/Web/UISample/MagicZoom.aspx" /><br/>
        MagicZoom (With MasterPage).
    </p>
    <p>
        <asp:HyperLink ID="DotNetZipHyperLink" runat="server" 
                       CssClass="heading2Link"
                       Text="DotNetZip Example" 
                       NavigateUrl="~/Web/UISample/DotNetZipExample.aspx" /><br/>
        DotNetZip Example.
    </p>
    <p>
        <asp:HyperLink ID="EFHyperLink" runat="server" 
                       CssClass="heading2Link"
                       Text="Entity Framework Example" 
                       NavigateUrl="~/Web/UISample/EntityModelTest.aspx" /><br/>
        Entity Framework Example.
    </p>
</asp:Content>
