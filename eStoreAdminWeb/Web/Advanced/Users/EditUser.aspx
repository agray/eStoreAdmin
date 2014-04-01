<%@ Page Title="Edit User" Language="C#" MasterPageFile="~/MasterPages/eStoreAdminMaster.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="eStoreAdminWeb.Web.Advanced.Users.EditUser" %>
<%@ MasterType VirtualPath="~/MasterPages/eStoreAdminMaster.Master" %>
<%@ Import Namespace="eStoreAdminWeb" %>
<%@ Import Namespace="phoenixconsulting.common.handlers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Stylesheets/Users.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%if (SessionHandler.isSessionTimedOut(Context, Page)) { %>
        <%FormsAuthentication.RedirectToLoginPage(); 
      } %>
    <table>
        <h1>Edit User</h1>
        <tr>
            <td valign="top">
                <h3>Roles:</h3>
                <asp:CheckBoxList ID="UserRoles" runat="server" />

                <h3>Main Info:</h3>
                <asp:DetailsView ID="UserInfo" runat="server"
                                 AutoGenerateRows="False" 
                                 DataSourceID="MemberData"
                                 OnItemUpdating="UserInfo_ItemUpdating">
          
                    <Fields>
                        <asp:BoundField DataField="UserName" HeaderText="User Name" ReadOnly="True" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Comment" HeaderText="Comment" />
                        <asp:CheckBoxField DataField="IsApproved" HeaderText="Active User" />
                        <asp:CheckBoxField DataField="IsLockedOut" HeaderText="Is Locked Out" ReadOnly="true" />                    	
                        <asp:CheckBoxField DataField="IsOnline" HeaderText="Is Online" ReadOnly="True"/>
                        <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" ReadOnly="True" />
                        <asp:BoundField DataField="LastActivityDate" HeaderText="LastActivityDate" ReadOnly="True" />
                        <asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate" ReadOnly="True" />
                        <asp:BoundField DataField="LastLockoutDate" HeaderText="LastLockoutDate" ReadOnly="True" />
                        <asp:BoundField DataField="LastPasswordChangedDate" HeaderText="LastPasswordChangedDate" ReadOnly="True" />
                        <asp:CommandField ButtonType="button" ShowEditButton="true" EditText="Edit User Info" />
                    </Fields>
                </asp:DetailsView>

                <div style="padding: 5px;">
                    <asp:Literal ID="UserUpdateMessage" runat="server">&nbsp;</asp:Literal>
                </div>

                <div style="text-align: right; width: 100%; margin: 20px 0px;">
                    <asp:Button ID="Button1" runat="server" 
                                Text="Unlock User" 
                                OnClick="UnlockUser" 
                                OnClientClick="return confirm('Click OK to unlock this user.')" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" 
                                Text="Delete User" 
                                OnClick="DeleteUser" 
                                OnClientClick="return confirm('Are Your Sure?')" />
                </div>
                <div>
                    <asp:HyperLink ID="BackToHyperLink" runat="server" Text="Back To Manage Users" />
                </div>

                <asp:ObjectDataSource ID="MemberData" runat="server" 
                                      DataObjectTypeName="System.Web.Security.MembershipUser" 
                                      TypeName="System.Web.Security.Membership"
                                      SelectMethod="GetUser" 
                                      UpdateMethod="UpdateUser">
	                <SelectParameters>
		                <asp:QueryStringParameter Name="username" QueryStringField="username" />
	                </SelectParameters>
                </asp:ObjectDataSource> 
            </td>
        </tr>
    </table>
</asp:Content>