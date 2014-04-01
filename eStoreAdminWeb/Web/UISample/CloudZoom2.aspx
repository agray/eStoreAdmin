<%@ Page Title="CloudZoom" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="CloudZoom2.aspx.cs" Inherits="eStoreAdminWeb.Web.UISample.CloudZoom2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- Include jQuery. -->
    <script type="text/javascript" src="<%=ResolveUrl("~/js/jquery-1.9.0.min.js") %>"></script>
    <!-- Include Cloud Zoom CSS. -->
    <link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~/StyleSheets/cloudzoom.css") %>" />
    <!-- Include Cloud Zoom script. -->
    <script type="text/javascript" src="<%=ResolveUrl("~/js/cloudzoom.js") %>"></script>
    <!-- Call quick start function. -->
    <script type="text/javascript">CloudZoom.quickStart();</script>
    <script type="text/javascript">
        $(function () {
            $('#ctl00_ContentPlaceHolder1_zoom1').bind('click', function () {            // Bind a click event to a Cloud Zoom instance.
                var cloudZoom = $(this).data('CloudZoom');  // On click, get the Cloud Zoom object,
                alert('cloudZoom ' + cloudZoom);
                cloudZoom.closeZoom();
                $.fancybox.open(cloudZoom.getGalleryList()); // and pass Cloud Zoom's image list to Fancy Box.
                return false;
            });
        });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center">
	    <div style="border:1px solid #ccc; display:inline-block;line-height:0;">
	       <asp:Image runat="server" class="cloudzoom" 
                      AlternateText="Cloud Zoom small image" 
                      ID="zoom1" 
                      src="SampleImages/small/image1.jpg" 
                      title="Cloud Zoom has many configuration options to match the look and feel of your website" 
                      data-cloudzoom="{
					    'zoomImage':'SampleImages/large/image1.jpg',
					    'zoomMatchSize':true,
					    'tintColor':'#000',
					    'tintOpacity':0.25,
					    'captionPosition':'bottom'
					    }"/>
			     <div class="cloudzoom-caption" style="">Cloud Zoom has many configuration options to match the look and feel of your website.</div>
	    </div>
   
	    <div style="margin-top:10px">
		    <a href="SampleImages/large/image1.jpg" class="thumb-link">    
			    <asp:Image runat="server" class="cloudzoom-gallery" 
                           src="SampleImages/small/image1.jpg" 
                           title="Cloud Zoom has many configuration options to match the look and feel of your website" 
                           AlternateText="Jet Zoom thumb image" 
                           data-cloudzoom="{
				     'useZoom':'#ctl00_ContentPlaceHolder1_zoom1',
				     'image':'SampleImages/small/image1.jpg',
				     'zoomImage':'SampleImages/large/image1.jpg'}" width="64"/>
		    </a>
	   
		    <a href="SampleImages/large/image2.jpg" class="thumb-link">
			    <asp:Image runat="server" class="cloudzoom-gallery" 
                           src="SampleImages/small/image2.jpg" 
                           AlternateText="Jet Zoom thumb image" 
                           title="Works great with iPad and other touch-enabled devices" 
                           data-cloudzoom="{
				     'useZoom':'#ctl00_ContentPlaceHolder1_zoom1',
				     'image':'SampleImages/small/image2.jpg',
				     'zoomImage':'SampleImages/large/image2.jpg'}" width="64"/>
		    </a>

		    <a href="SampleImages/large/image3.jpg" class="thumb-link">
			    <asp:Image runat="server" class="cloudzoom-gallery" 
                           src="SampleImages/small/image3.jpg" 
                           AlternateText="Jet Zoom thumb image" 
                           title="Regular free updates and new features with technical support" 
                           data-cloudzoom="{
				     'useZoom':'#ctl00_ContentPlaceHolder1_zoom1',
				     'image':'SampleImages/small/image3.jpg'
				     'zoomImage':'SampleImages/large/image3.jpg'}" width="64"/>
		    </a>
	    </div>
    </div>
</asp:Content>
