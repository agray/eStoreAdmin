<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JQueryZoomer.aspx.cs" Inherits="eStoreAdminWeb.Web.UISample.JQueryZoomer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>JQuery Zoomer</title>
    <link rel="stylesheet" href="<%=ResolveUrl("~/Stylesheets/multizoom.css")%>" type="text/css" />
    <script type="text/javascript" src="<%=ResolveUrl("~/js/jquery-1.9.0.min.js")%>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/js/multizoom.js")%>"></script>
    
    <script type="text/javascript">

    jQuery(document).ready(function ($) {

        $('#image1').addimagezoom({ // single image zoom
            zoomrange: [3, 10],
            magnifiersize: [300, 300],
            magnifierpos: 'right',
            cursorshade: true,
            largeimage: 'hayden.jpg' //<-- No comma after last option!
        })


        $('#image2').addimagezoom() // single image zoom with default options

        $('#multizoom1').addimagezoom({ // multi-zoom: options same as for previous Featured Image Zoomer's addimagezoom unless noted as '- new'
            descArea: '#description', // description selector (optional - but required if descriptions are used) - new
            speed: 1500, // duration of fade in for new zoomable images (in milliseconds, optional) - new
            descpos: true, // if set to true - description position follows image position at a set distance, defaults to false (optional) - new
            imagevertcenter: true, // zoomable image centers vertically in its container (optional) - new
            magvertcenter: true, // magnified area centers vertically in relation to the zoomable image (optional) - new
            zoomrange: [3, 10],
            magnifiersize: [250, 250],
            magnifierpos: 'right',
            cursorshadecolor: '#fdffd5',
            cursorshade: true //<-- No comma after last option!
        });

        $('#multizoom2').addimagezoom({ // multi-zoom: options same as for previous Featured Image Zoomer's addimagezoom unless noted as '- new'
            descArea: '#description2', // description selector (optional - but required if descriptions are used) - new
            disablewheel: true // even without variable zoom, mousewheel will not shift image position while mouse is over image (optional) - new
            //^-- No comma after last option!	
        });

    })
    </script>
</head>
<body>
    <a href="SampleHome.aspx">Return to Sample Home</a>
    <h3>Demo 1:</h3>

    <img id="image1" alt="image1" border="0" src="SampleImages/haydensmall.jpg" style="width:250px;height:338px"/>

    <h3>Demo 2:</h3>
    <img id="image2" alt="image2" border="0" src="SampleImages/listenmusic.jpg" style="width:200px;height:150px"/>

    <h3>Demo 3:</h3>
    <div class="targetarea" style="border:1px solid #eee"><img id="multizoom1" alt="zoomable" title="" src="SampleImages/millasmall.jpg"/></div>
    <div id="description">Milla Jojovitch</div>
    <div class="multizoom1 thumbs">
    <a href="SampleImages/millasmall.jpg" data-large="SampleImages/milla.jpg" data-title="Milla Jojovitch"><img src="SampleImages/milla_tmb.jpg" alt="Milla" title=""/></a> 
    <a href="SampleImages/saleensmall.jpg" data-lens="false" data-magsize="150,150" data-large="SampleImages/saleen.jpg" data-title="Saleen S7 Twin Turbo"><img src="SampleImages/saleen_tmb.jpg" alt="Saleen" title=""/></a> 
    <a href="SampleImages/haydensmall.jpg" data-large="SampleImages/hayden.jpg" data-title="Hayden Panettiere"><img src="SampleImages/hayden_tmb.jpg" alt="Hayden" title=""/></a> 
    <a href="SampleImages/jaguarsmall.jpg" data-large="SampleImages/jaguar.jpg" data-title="Jaguar Type E"><img src="SampleImages/jaguar_tmb.jpg" alt="Jaguar" title=""/></a>
    </div>
    
    <h3>Demo 4:</h3>
    <div class="targetarea diffheight"><img id="multizoom2" alt="zoomable" title="" src="SampleImages/angelinasmall.jpg"/></div>
    <div id="description2">Angelina Jolie</div>
    <div class="multizoom2 thumbs">
    <a href="SampleImages/angelinasmall.jpg" data-large="SampleImages/angelina.jpg" data-title="Angelina Jolie"><img src="SampleImages/angelina_tmb.jpg" alt="Angelina" title=""/></a>
    <a href="SampleImages/saleensmall.jpg" data-large="SampleImages/saleen.jpg" data-title="Saleen S7 Twin Turbo"><img src="SampleImages/saleen_tmb.jpg" alt="Saleen" title=""/></a>
    <a href="SampleImages/jaguarsmall.jpg" data-large="SampleImages/jaguar.jpg" data-title="Jaguar Type E"><img src="SampleImages/jaguar_tmb.jpg" alt="Jaguar" title=""/></a>
    <a href="SampleImages/listenmusic.jpg" data-title="Relaxing Music" data-dims="300, 225"><img src="SampleImages/listen_tmb.jpg" alt="Relaxing Music" title=""/></a>
    </div>
</body>
</html>
