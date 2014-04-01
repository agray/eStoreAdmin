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
using System.Configuration;
using System.IO;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls;
using eStoreAdminWeb.Controls;
using phoenixconsulting.common.basepages;

namespace eStoreAdminWeb.Web.Advanced.Users {
    public partial class AccessRuleSummary : BasePage {
        private const string VirtualImageRoot = "~/";
        private string selectedRole, selectedUser;

        protected void Page_Init() {
            ((DropDownList)UserRolesDDL.FindControl("UserRolesDropDownList")).DataSource = Roles.GetAllRoles();
            UserRolesDDL.FindControl("UserRolesDropDownList").DataBind();

            ((DropDownList)UserDDL.FindControl("UserDropDownList")).DataSource = Membership.GetAllUsers();
            UserDDL.FindControl("UserDropDownList").DataBind();

            FolderTree.Nodes.Clear();
        }
        
        
        protected void Page_Load(object sender, EventArgs e) {
            selectedRole = UserRolesDDL.SelectedValue;
            selectedUser = UserDDL.SelectedValue;
        }

        protected void Page_PreRender() {
        }

        protected void PopulateTree(string byUserOrRole) {
            /*
             * Dan Clem, 4/15/2007.
             * The PopulateTree and AddNodeAndDescendents are taken almost verbatim from Scott Mitchell's article
             * "Using the TreeView Control and a DataList to Create an Online Image Gallery", which is located at 
             * http://aspnet.4guysfromrolla.com/articles/083006-1.aspx
             */

            // Populate the tree based on the subfolders of the specified VirtualImageRoot
            DirectoryInfo rootFolder = new DirectoryInfo(Server.MapPath(VirtualImageRoot));
            TreeNode root = AddNodeAndDescendents(byUserOrRole, rootFolder, null);
            FolderTree.Nodes.Add(root);
        }

        protected TreeNode AddNodeAndDescendents(string byUserOrRole, DirectoryInfo folder, TreeNode parentNode) {
            /*
             * Dan Clem, 4/15/2007.
             * The PopulateTree and AddNodeAndDescendents are taken almost verbatim from Scott Mitchell's article
             * "Using the TreeView Control and a DataList to Create an Online Image Gallery", which is located at 
             * http://aspnet.4guysfromrolla.com/articles/083006-1.aspx
             */

            // Add the TreeNode, displaying the folder's name and storing the full path to the folder as the value...
            string virtualFolderPath;
            virtualFolderPath = parentNode == null ? VirtualImageRoot : parentNode.Value + folder.Name + "/";

            // Instantiate the objects that we'll use to check folder security on each tree node.
            Configuration config = WebConfigurationManager.OpenWebConfiguration(virtualFolderPath);
            SystemWebSectionGroup systemWeb = (SystemWebSectionGroup)config.GetSectionGroup("system.web");
            AuthorizationSection section = (AuthorizationSection)systemWeb.Sections["authorization"];

            string action;
            switch(byUserOrRole) {
                case "ByRole":
                    action = GetTheRuleForThisRole(section, virtualFolderPath);
                    break;
                case "ByUser":
                    action = GetTheRuleForThisUser(section, virtualFolderPath);
                    break;
                default:
                    action = "";
                    break;
            }

            //  This is where I wanna adjust the folder name.
            TreeNode node = new TreeNode(folder.Name + " (" + action + ")", virtualFolderPath);
            node.ImageUrl = (action.Substring(0, 5) == "ALLOW") ? SYSTEM_IMAGE_DIR + "greenlight.gif" : SYSTEM_IMAGE_DIR + "redlight.gif";
            node.NavigateUrl = "ManageAccessRules.aspx?selectedFolderName=" + folder.Name;

            // Recurse through this folder's subfolders
            DirectoryInfo[] subFolders = folder.GetDirectories();
            foreach(DirectoryInfo subFolder in subFolders) {
                // You could use this filter out certain folders.
                if(subFolder.Name != "_controls" && subFolder.Name != "App_Data") {
                    TreeNode child = AddNodeAndDescendents(byUserOrRole, subFolder, node);
                    node.ChildNodes.Add(child);
                }
            }
            return node; // Return the new TreeNode
        }

        /*
         * It took me a bit to write the GetTheRuleForThisRole and GetTheRuleForThisUser methods. 
         * I had hoped that there would have been a built-in method, but there was not. I built 
         * these methods to mirror my understanding of how ASP.NET applies access rules based on 
         * the FIRST MATCHING RULE. From my testing, the methods appear to be accurate.
         * 
         * Here's what the GetTheRuleForThisUser method looks like. This logic is based on my 
         * discovery that access rules are returned IN ORDER when iterating through with a 
         * FOREACH block. We first check for a matching user and return a match if one is found. 
         * If there is no user-specific rule, then we search through all ROLES to which the 
         * selected user belongs. Again, the first match is returned. If no matching user or 
         * role is found, then the user has access, so we return ALLOW.
         */

        protected string GetTheRuleForThisRole(AuthorizationSection section, string folder) {
            /*
             * Dan Clem, 3/19/2007.
             * We know that rules are returned in order, so we can return upon first match.
             * Even if there were conflicting entries for the requested Role in the config file,
             * we know that the first rule for the given role will supersede the later entry.
             * 
             * I didn't readily find a method called "GetPermissionForThisRoleInThisFolder",
             * so I'm building the logic myself based on my understanding of things:
             * The first matching rule is applied, so the way I figure it, no matter whether we are 
             * testing for 1) an anonymous user, or 2) an authenticated user not belonging to a role, 
             * or 3) an actual role, the logic will be the same: take the first match on either the 
             * actual role OR the all users (*) symbol.
             * 
             * Note that I'm not checking for ALL ROLES (*), which does not appear to be a valid option.
             * I tested this by manually adding "<allow roles="*" />" to a config file.
             * This resulted in a page error as follows:
             * Parser Error Message: Authorization rule names cannot contain the '*' character.
             * 
             * Long story short, I've developed a best practice for providing role-based security on a folder:
             * ALLOW SPECIFIC ROLE, then DENY ALL USERS (*).
             */

            foreach(AuthorizationRule rule in section.Rules) {
                /*
                 * Dan Clem, March, 2007.
                 * Both Users and Roles are collections of strings, not a single string, 
                 * so even though my tool (as well as the WSAT
                 * that is accessed from Visual Studio 2005) provides a single-selection dropdownlist
                 * for specifying a single ROLE for a RULE, I'll treat it as the collection that it is,
                 * since it's possible that someone could modify the Web.config file manually.
                 * 
                 * Note to self: remember that it does not matter whether we first check the users 
                 * or first check the roles. Remember that we're dealing with a single rule inside
                 * this foreach block, and a rule can have only a single action. A match in either 
                 * users or roles is completely equivalent.
                 */
                foreach(string user in rule.Users) {
                    if(user == "*") {
                        return rule.Action.ToString().ToUpper() + ": All Users";
                    }
                }
                foreach(string role in rule.Roles) {
                    if(role == selectedRole) {
                        return rule.Action.ToString().ToUpper() + ": Role=" + role;
                    }
                }
            }
            /*
             * Dan Clem, 3/19/2007.
             * I think we'll always have a match, because the Machine.config or master Web.config
             * appears to have a default entry for ALLOW *.
             * Nevertheless, I'll return "Allow" because I haven't researched what happens if said 
             * default entry is manually deleted. Better to report a false ALLOW than a false DENY.
             */
            return "Allow";
        }

        protected string GetTheRuleForThisUser(AuthorizationSection section, string folder) {
            foreach(AuthorizationRule rule in section.Rules) {
                foreach(string user in rule.Users) {
                    if(user == "*") {
                        return rule.Action.ToString().ToUpper() + ": All Users";
                    }
                    if(user == selectedUser) {
                        return rule.Action.ToString().ToUpper() + ": User=" + user;
                    }
                }

                // Don't forget that users might belong to some roles!
                foreach(string role in rule.Roles) {
                    if(Roles.IsUserInRole(selectedUser, role)) {
                        return rule.Action.ToString().ToUpper() + ": Role=" + role;
                    }
                }
            }
            return "ALLOW";
        }

        protected void DisplayRoleSummary(object sender, EventArgs e) {
            FolderTree.Nodes.Clear();
            UserDDL.SelectedIndex = 0;
            if(UserRolesDDL.SelectedIndex > 0) {
                PopulateTree("ByRole");
                FolderTree.ExpandAll();
            }
        }

        protected void DisplayUserSummary(object sender, EventArgs e) {
            FolderTree.Nodes.Clear();
            UserRolesDDL.SelectedIndex = 0;
            if(UserDDL.SelectedIndex > 0) {
                PopulateTree("ByUser");
                FolderTree.ExpandAll();
            }
        }

        protected void DisplaySecuritySummary(object sender, TreeNodeEventArgs e) {
            e.Node.ShowCheckBox = true;
        }

        protected void FolderTree_SelectedNodeChanged(object sender, EventArgs e) {
        }
    }
}