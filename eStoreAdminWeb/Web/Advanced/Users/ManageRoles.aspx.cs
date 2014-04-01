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
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.logging;

namespace eStoreAdminWeb.Web.Advanced.Users {
    public partial class ManageRoles : AuditBasePage {
        private bool createRoleSuccess = true;
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void Page_PreRender() {
            // Create a DataTable and define its columns
            DataTable RoleList = new DataTable();
            RoleList.Columns.Add("Role Name");
            RoleList.Columns.Add("User Count");

            string[] allRoles = Roles.GetAllRoles();

            // Get the list of roles in the system and how many users belong to each role
            foreach(string roleName in allRoles) {
                int numberOfUsersInRole = Roles.GetUsersInRole(roleName).Length;
                string[] roleRow = { roleName, numberOfUsersInRole.ToString() };
                RoleList.Rows.Add(roleRow);
            }

            // Bind the DataTable to the GridView
            UserRoles.DataSource = RoleList;
            UserRoles.DataBind();

            if(createRoleSuccess) {
                // Clears form field after a role was successfully added. Alternative to redirect technique I often use.
                NewRole.Text = "";
            }
        }

        protected void AddRole(object sender, EventArgs e) {
            try {
                Roles.CreateRole(NewRole.Text);
                string confirmationMsg = "New role " + NewRole.Text + " was added.";
                ConfirmationMessage.InnerText = confirmationMsg;
                createRoleSuccess = true;
                logInfo(AuditEventType.USER_ROLE_ADDED, NewRole.Text, null, confirmationMsg);
            } catch(Exception ex) {
                ConfirmationMessage.InnerText = ex.Message;
                createRoleSuccess = false;
            }
        }

        protected void DeleteRole(object sender, CommandEventArgs e) {
            try {
                Roles.DeleteRole(e.CommandArgument.ToString());
                ConfirmationMessage.InnerText = "Role '" + e.CommandArgument.ToString() + "' was deleted.";
                logInfo(AuditEventType.USER_ROLE_DELETED, null, e.CommandArgument.ToString(), null);
            } catch(Exception ex) {
                ConfirmationMessage.InnerText = ex.Message;
            }
        }

        protected void DisableRoleManager(object sender, EventArgs e) {
            /*
             * Dan Clem, 3/7/2007
             * I couldn't get this to work.
             * I wouldn't want it to work, anyway. I wouldn't want to disable roles from within my own application, anyway.
             * This is a bit unfortunate, since it compromises my vision of a fully integrated intranet.
             * This particular feature would need to be done using the Admin Tool or by editing the Config files manually.
             * The files or URL to the Admin Tool would need to be locked down using Windows Authentication.
             * 
             * Error message follows:
             * Description: An error occurred during the processing of a configuration file required to service this request. Please review the specific error details below and modify your configuration file appropriately. 

    Parser Error Message: An error occurred loading a configuration file: Access to the path 'C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\Config\9owcoing.tmp' is denied.

             * 
             * Configuration config = WebConfigurationManager.OpenWebConfiguration(null);
            RoleManagerSection roleSection = (RoleManagerSection)config.GetSection("system.web/roleManager");
            roleSection.Enabled = false;
            config.Save();
             */

        }
    }
}