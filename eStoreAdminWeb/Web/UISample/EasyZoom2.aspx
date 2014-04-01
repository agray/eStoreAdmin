<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="EasyZoom2.aspx.cs" Inherits="eStoreAdminWeb.Web.UISample.EasyZoom2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<!-- Include jQuery. --><script type="text/javascript" src="<%=ResolveUrl("~/js/jquery-1.9.0.min.js") %>"></script><!-- Include Easy Zoom script. --><script type="text/javascript" src="<%=ResolveUrl("~/js/easyzoom.js") %>"></script>
<script type="text/javascript">
    jQuery(function ($) {

        $('a.zoom').easyZoom();

    });
</script>
<style type="text/css" runat="server">
/*
Copy/paste this into your own stylesheet.
Edit width, height and placement of the dynamically created image zoom box. 
*/

#easy_zoom{
	width:600px;
	height:400px;	
	border:1px solid #eee;
	background:#fff;
	color:#333;
	position:absolute;
	top:190px;
	left:510px;
	overflow:hidden;
	-moz-box-shadow:0 0 10px #777;
	-webkit-box-shadow:0 0 10px #777;
	box-shadow:0 0 10px #777;
	/* vertical and horizontal alignment used for preloader text */
	line-height:400px;
	text-align:center;
	}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="container">
        <h1>Easy Image Zoom jQuery Plugin</h1>
        <p>The easiest image zoomer there is!</p>
        <p>
            <asp:HyperLink runat="server" ID="zoomable" NavigateUrl="SampleImages/large.jpg" class="zoom">
                <asp:Image runat="server" ImageUrl="SampleImages/small.jpg" AlternateText="New York"/>
            </asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink runat="server" NavigateUrl="SampleImages/harley1c.jpg" rel="zoom-id: zoomable" rev="SampleImages/harley1b.jpg">
                <asp:Image runat="server" ImageUrl="SampleImages/harley1a.jpg"/>
            </asp:HyperLink>
            <asp:HyperLink runat="server" NavigateUrl="SampleImages/harley2c.jpg" rel="zoom-id: zoomable" rev="SampleImages/harley2b.jpg">
                <asp:Image runat="server" ImageUrl="SampleImages/harley2a.jpg"/>
            </asp:HyperLink>
        </p>
        <p>
            <em>Roll over the image to view details.</em>
        </p>
        <p>
            <asp:HyperLink runat="server" NavigateUrl="http://cssglobe.com/post/9711/jquery-plugin-easy-image-zoom" title="read more about this plugin">
                back to the article
            </asp:HyperLink>
        </p>
    </div>
</asp:Content>