<%@ Page Title="Manage Export" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="ManageProductImport.aspx.cs" Inherits="eStoreAdminWeb.Web.ImportExport.ManageProductImport" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
        <h1>Upload Products</h1>
        
        <table>
            <tr>
                <td align="right">
                    <asp:Label ID="ImageLabel" runat="server" Text="File to Upload:"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="FileUploader" runat="server" />
                    <asp:RequiredFieldValidator ID="FileUploaderRFV" runat="server" 
                                                ControlToValidate="FileUploader" 
                                                ErrorMessage="No file selected">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="UploadButton" runat="server" 
                                Text="Upload" 
                                OnClick="UploadButton_Click"
                                CausesValidation="true" />
                    <asp:Button ID="CancelButton" runat="server" 
                                Text="Cancel"
                                OnClick="ReturnToHomePage"
                                CausesValidation="false" />
                </td>
            </tr>
       </table>
</asp:Content>