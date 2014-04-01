<%@ Page Title="Updating Currencies" Language="C#" AutoEventWireup="true" CodeBehind="UpdatingCurrencies.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.UpdatingCurrencies" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <html>
        <head>
            <title>Updating Currencies</title>
            <link href="../../Stylesheets/PP_style.css" rel="stylesheet" type="text/css" />
        </head>
        <body>
            <h1>Updating Currencies...</h1>
        
            <p>Please wait 30 seconds...</p>
        </body>
    </html>