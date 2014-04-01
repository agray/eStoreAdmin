#region Licence
/*
 * The MIT License
 *
 * Copyright (c) 2008-2013, Andrew Gray
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
#endregion
using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using com.phoenixconsulting.authentication;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.logging;
using phoenixconsulting.common.navigation;

namespace eStoreAdminWeb.Web.Advanced.Users {
    public partial class EditUser : AuditBasePage {

        private string username;
        private MembershipUser user;

        protected void Page_Load(object sender, EventArgs e) {
            username = Request.QueryString["username"];
            if(string.IsNullOrEmpty(username)) {
                Response.Redirect("UsersTest.aspx");
            }
            user = FormsAuthenticator.getUser(username);
            UserUpdateMessage.Text = "";
        }

        protected void Page_PreRender() {
            // Load the User Roles into checkboxes.
            UserRoles.DataSource = Roles.GetAllRoles();
            UserRoles.DataBind();

            // Disable checkboxes if appropriate:
            if(UserInfo.CurrentMode != DetailsViewMode.Edit) {
                foreach(ListItem checkbox in UserRoles.Items) {
                    checkbox.Enabled = false;
                }
            }

            // Bind these checkboxes to the User's own set of roles.
            string[] userRoles = Roles.GetRolesForUser(username);
            foreach(string role in userRoles) {
                ListItem checkbox = UserRoles.Items.FindByValue(role);
                checkbox.Selected = true;
            }

            setNavigateURL(BackToHyperLink, Pages.MANAGE_USERS);
        }

        protected void UserInfo_ItemUpdating(object sender, DetailsViewUpdateEventArgs e) {
            //Need to handle the update manually because MembershipUser does not have a
            //parameterless constructor  

            user.Email = (string)e.NewValues[0];
            user.Comment = (string)e.NewValues[1];
            user.IsApproved = (bool)e.NewValues[2];

            try {
                // Update user info:
                FormsAuthenticator.updateUser(user);

                // Update user roles:
                UpdateUserRoles();

                UserUpdateMessage.Text = "Update Successful.";
                logInfo(AuditEventType.USER_LOGIN_UPDATED, e.NewValues[0].ToString(), e.OldValues[0].ToString(), null);
                e.Cancel = true;
                UserInfo.ChangeMode(DetailsViewMode.ReadOnly);
            } catch(Exception ex) {
                UserUpdateMessage.Text = "Update Failed: " + ex.Message;
                e.Cancel = true;
                UserInfo.ChangeMode(DetailsViewMode.ReadOnly);
            }
        }

        private void UpdateUserRoles() {
            foreach(ListItem rolebox in UserRoles.Items) {
                if(rolebox.Selected) {
                    if(!Roles.IsUserInRole(username, rolebox.Text)) {
                        Roles.AddUserToRole(username, rolebox.Text);
                        logInfo(AuditEventType.USER_ADDED_TO_ROLE, null, null, "User " + username + " added to role " + rolebox.Text);
                    }
                } else {
                    if(Roles.IsUserInRole(username, rolebox.Text)) {
                        Roles.RemoveUserFromRole(username, rolebox.Text);
                        logInfo(AuditEventType.USER_REMOVED_FROM_ROLE, null, null, "User " + username + " added to role " + rolebox.Text);
                    }
                }
            }
        }

        protected void DeleteUser(object sender, EventArgs e) {
            //Membership.DeleteUser(username, false); // DC: My apps will NEVER delete the related data.
            FormsAuthenticator.deleteUser(username, true); // DC: except during testing, of course!
            logInfo(AuditEventType.USER_LOGIN_DELETED, null, username, null);
            GoTo.Instance.ManageUsersPage();
        }

        protected void UnlockUser(object sender, EventArgs e) {
            FormsAuthenticator.unlockUser(user);

            // DataBind the GridView to reflect same.
            UserInfo.DataBind();
            logInfo(AuditEventType.USER_LOGIN_UNLOCKED, null, null, "User " + user + " unlocked");
        }
    }
}