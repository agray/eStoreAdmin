<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master"AutoEventWireup="true" CodeBehind="JQWithMaster.aspx.cs" Inherits="eStoreAdminWeb.MasterPages.JQWithMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>jQuery in MasterPage Example</title>
    <link rel="stylesheet" type="text/css" href="<%=ResolveUrl("~/StyleSheets/humanity/jquery-ui-1.10.0.custom.min.css") %>" />
    <script type="text/javascript" src="<%=ResolveUrl("~/js/jquery-1.9.0.min.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/js/jquery-ui-1.10.0.custom.min.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function() {
            // Datepicker
            $('#datepicker').datepicker({
                inline: true,
                dateFormat: "dd-mm-yy"
            });
            $("#<%=txtDate1.ClientID%>").datepicker({ dateFormat: "dd-mm-yy" });
            $("#<%=txtDate2.ClientID%>").datepicker({ dateFormat: "dd-mm-yy" });
            $("#<%=txtDate3.ClientID%>").datepicker({ dateFormat: "dd-mm-yy" });
            $("#tabbedContent").tabs();

            $("#slider-range-min").slider({
                range: "min",
                min: 0,
                max: 200,
                step: 0.25,
                slide: function(event, ui) {
                    $("#<%=amount.ClientID%>").val(ui.value);
                }
            });
            $("#<%=amount.ClientID%>").val($("#slider-range-min").slider("value"));
        });
    </script>
    
    <br />
    <!-- OnClick Datepickers -->
    <table>
        <tr>
            <td valign="top">
                <asp:Literal runat="server"><b>OnClick Datepickers</b></asp:Literal>
                <div>
                    <asp:Label ID="lblDate1" runat="server">Date 1: </asp:Label>
                    <asp:TextBox ID="txtDate1" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblDate2" runat="server">Date 2: </asp:Label>
                    <asp:TextBox ID="txtDate2" runat="server"></asp:TextBox><br />
                    <asp:Label ID="lblDate3" runat="server">Date 3: </asp:Label>
                    <asp:TextBox ID="txtDate3" runat="server"></asp:TextBox><br />
                </div>
            </td>
            <td valign="top">
                <!-- Inline Datepicker -->
	            <asp:Literal runat="server"><b>Inline Datepicker</b></asp:Literal>
	            <div id="datepicker"></div>
	        </td>
	    </tr>
	</table>
	<table>
	    <tr>
            <td colspan="2">
	            <!-- Tabs -->
	            <asp:Literal runat="server"><b>Tabs</b></asp:Literal>
	            <div id="tabbedContent">
	                <ul>
                        <li><a href="#tab1">Tab 1</a></li>
                        <li><a href="#tab2">Tab 2</a></li>
                        <li><a href="#tab3">Tab 3</a></li>
                        <li><a href="#tab4">Tab 4</a></li>
                    </ul>
                    <div id="tab1">
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed
                        do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
                    </div>
                    <div id="tab2">
                        <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco
                        laboris nisi ut aliquip ex ea commodo consequat.</p>
                    </div>
                    <div id="tab3">
                        <p>Duis aute irure dolor in reprehenderit in voluptate velit
                        esse cillum dolore eu fugiat nulla pariatur. </p>
                    </div>
                    <div id="tab4">
                        <p>Excepteur sint occaecat cupidatat non proident, sunt in culpa
                        qui officia deserunt mollit anim id est laborum</p>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Literal runat="server"><b>Slider</b></asp:Literal><br />
                <asp:TextBox ReadOnly="true" Width="100px" id="amount" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div id="slider-range-min"></div>
    
    
</asp:Content>
