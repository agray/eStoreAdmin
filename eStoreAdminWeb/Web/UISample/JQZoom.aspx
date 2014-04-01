<%@ Page Title="JQZoom" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="JQZoom.aspx.cs" Inherits="eStoreAdminWeb.Web.UISample.JQZoom" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>JQZoom</title>
    <script type="text/javascript" src="<%=ResolveUrl("~/js/jquery-1.9.0.min.js")%>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/js/jquery.jqzoom-core.js")%>" ></script>
    
    <link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~/StyleSheets/jquery.jqzoom.css")%>" />
    <%--<link rel="stylesheet" type="text/css" href="../../StyleSheets/magiczoomplus.css"  media="screen"/>--%>

    <style type="text/css">

        ul#thumblist{display:block;}
        ul#thumblist li{float:left;margin-right:2px;list-style:none;}
        ul#thumblist li a{display:block;border:1px solid #CCC;}
        ul#thumblist li a.zoomThumbActive{border:1px solid red;}

        .jqzoom{
	        text-decoration:none;
	        float:left;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.jqzoom').jqzoom({
                zoomType: 'standard',
                position: 'left',
                lens: true,
                preloadImages: true,
                alwaysOn: false
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <h1>JQZoom</h1>
    <a href="http://www.mind-projects.it/projects/jqzoom/demos.php#demo1" target="_blank">HomePage</a>

    <%--<div class="clearfix" id="content">--%>
        <table>
            <tr>
                <td>
                    <a href="SampleImages/triumph_big1.jpg" class="jqzoom" rel='gal1'  title="triumph" >
                        <img alt="a" src="SampleImages/triumph_small1.jpg"  title="triumph" />
                    </a>
                </td>
            </tr>
            <tr>
                <td>
	                <ul id="thumblist">
		                <li><a class="zoomThumbActive" href='javascript:void(0);' rel="{gallery: 'gal1', smallimage: 'SampleImages/triumph_small1.jpg',largeimage: 'SampleImages/triumph_big1.jpg'}"><img alt="3" src='SampleImages/thumbs/triumph_thumb1.jpg'/></a></li>
		                <li><a href='javascript:void(0);' rel="{gallery: 'gal1', smallimage: 'SampleImages/triumph_small2.jpg',largeimage: 'SampleImages/triumph_big2.jpg'}"><img alt="1" src='SampleImages/thumbs/triumph_thumb2.jpg'/></a></li>
		                <li><a  href='javascript:void(0);' rel="{gallery: 'gal1', smallimage: 'SampleImages/triumph_small3.jpg',largeimage: 'SampleImages/triumph_big3.jpg'}"><img alt="2" src='SampleImages/thumbs/triumph_thumb3.jpg'/></a></li>
	                </ul>
                </td>
            </tr>
        </table>
    <%--</div>--%>
<%--    <table class="mtbl">
        <tr>
            <td class="rTd">
                <p><a name="dissolve">Dissolve effect</a></p>
                <a id="Zoomer" href="SampleImages/harley1c.jpg" class="MagicZoomPlus" rel="selectors-effect-speed: 600;" title="Harley-Davidson Dyna Wide Glide"><img src="SampleImages/harley1b.jpg"/></a> <br/>

                <a href="SampleImages/harley1c.jpg" rel="zoom-id: Zoomer" rev="SampleImages/harley1b.jpg"><img src="SampleImages/harley1a.jpg"/></a>
                <a href="SampleImages/harley2c.jpg" rel="zoom-id: Zoomer" rev="SampleImages/harley2b.jpg"><img src="SampleImages/harley2a.jpg"/></a>
            </td>
        </tr>
    <//table>--%>
</asp:Content>