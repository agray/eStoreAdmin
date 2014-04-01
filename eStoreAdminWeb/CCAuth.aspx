<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CCAuth.aspx.cs" Inherits="eStoreWeb.CCAuth" %>

<%
// Do not allow browser to cache this page.
Response.CacheControl = "no-cache";
%>

<%
/*
This example is based on the SecureXML documentation and should be used in conjunction with that documentation. Please feel free to edit this code to suit your own requirements. This example comes with no warranty or support. Use at your own risk.

Important Note
---------------
If you receive the following error: “HttpWebRequet Protocol Error, the underlying HTTP connection has been closed.”

Try adding the following to your web.config file :
<system.net>
	<settings>
		<httpWebRequest useUnsafeHeaderParsing="true" />
	</settings>
 </system.net>

In .NET Framework 1.1 Service Pack 1, Microsoft locked down the logic in their HTTP protocol API's to prevent possible security holes. With this change, .NET applications will now throw an HTTP protocol violation if the server responds with any HTTP headers that Microsoft considers invalid. It is likely that if you get this error, it is because the server is sending back a header named 'Last Modified' instead of the standard header named 'last-modified'.
*/
%>

<html>
    <head></head>
    <body></body>
</html>
