<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CloudZoom.aspx.cs" Inherits="eStoreAdminWeb.Web.UISample.CloudZoom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>

    <head>
        <title>Cloud Zoom</title>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <!-- Include jQuery. -->
        <script type="text/javascript" src="<%=ResolveUrl("~/js/jquery-1.9.0.min.js") %>"></script>
        <!-- Include Cloud Zoom CSS. -->
        <link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~/StyleSheets/cloudzoom.css") %>" />
        <!-- Include Cloud Zoom script. -->
        <script type="text/javascript" src="<%=ResolveUrl("~/js/cloudzoom.js") %>"></script>
        <!-- Call quick start function. -->
        <script type="text/javascript">CloudZoom.quickStart();</script>    
    </head>
    
    <body>
        <img class = "cloudzoom" src = "SampleImages/small/image1.jpg"
             data-cloudzoom = "zoomImage: 'SampleImages/large/image1.jpg'" />
    </body>

</html>
