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
using phoenixconsulting.common.basepages;

namespace eStoreAdminWeb.Web.Advanced.Users {
    public partial class UsersByRole : BasePage {
        protected void Page_Init() {
            ((DropDownList)UserRolesDDL.FindControl("UserRolesDropDownList")).DataSource = Roles.GetAllRoles();
            UserRolesDDL.FindControl("UserRolesDropDownList").DataBind();
        }
        
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Page_PreRender() {
            /*
             * Dan Clem, 3/7/2007 and 4/27/2007.
             * The logic here is necessitated by the limitations of the built-in object model.
             * The Membership class does not provide a method to get users by role.
             * The Roles class DOES provide a GetUsersInRole method, but it returns an array of UserName strings
             * rather than a proper collection of MembershipUser objects.
             * 
             * This is my workaround.
             * 
             * Note to self: the two-collection approach is necessitated because you can't remove items from a collection
             * while iterating through it: "Collection was modified; enumeration operation may not execute."
             */

            MembershipUserCollection allUsers = Membership.GetAllUsers();
            MembershipUserCollection filteredUsers = new MembershipUserCollection();

            if(UserRolesDDL.SelectedIndex > 0) {
                string[] usersInRole = Roles.GetUsersInRole(UserRolesDDL.SelectedValue);
                foreach(MembershipUser user in allUsers) {
                    foreach(string userInRole in usersInRole) {
                        if(userInRole == user.UserName) {
                            filteredUsers.Add(user);
                            break; // Breaks out of the inner foreach loop to avoid unneeded checking.
                        }
                    }
                }
            } else {
                filteredUsers = allUsers;
            }
            Users.DataSource = filteredUsers;
            Users.DataBind();
        }
    }
}