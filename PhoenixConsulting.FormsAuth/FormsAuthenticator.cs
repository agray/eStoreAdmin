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
using System.Web;
using System.Web.Security;
using com.phoenixconsulting.util;

namespace com.phoenixconsulting.authentication {
    public static class FormsAuthenticator {
        public static MembershipUser getUser() {
            return Membership.GetUser();
        }

        public static MembershipUser getUser(string username) {
            return Membership.GetUser(username);
        }

        public static MembershipUserCollection getAllUsers() {
            return Membership.GetAllUsers();
        }

        public static string getUserNameByEmail(string emailToMatch) {
            return Membership.GetUserNameByEmail(emailToMatch);
        }

        public static MembershipUserCollection findUsersByName(string usernameToMatch) {
            return Membership.FindUsersByName(usernameToMatch);
        }

        public static string[] getRoles() {
            return Roles.GetRolesForUser();
        }

        public static string[] getRoles(string username) {
            return Roles.GetRolesForUser(username);
        }

        public static string getRolesAsCSV(string username) {
            string[] roles = Roles.GetRolesForUser(username);
            return CSV.toCSV(roles);
        }

        public static string getRolesAsCSV() {
            string[] roles = Roles.GetRolesForUser();
            return CSV.toCSV(roles);
        }

        public static void addUser(string username,
                                   string password,
                                   string email,
                                   string question,
                                   string answer) {
            MembershipCreateStatus createStatus;

            MembershipUser newUser = Membership.CreateUser(HttpUtility.HtmlEncode(username.Trim()),
                                                           HttpUtility.HtmlEncode(password.Trim()),
                                                           HttpUtility.HtmlEncode(email.Trim()),
                                                           HttpUtility.HtmlEncode(question.Trim()),
                                                           HttpUtility.HtmlEncode(answer.Trim()),
                                                           true,
                                                           out createStatus);
            string CreateResultMessage = "";

            switch(createStatus) {
                case MembershipCreateStatus.Success:
                    CreateResultMessage = "&raquo; The user was successfully created. &laquo;";
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    CreateResultMessage = "The user name was not found in the database.";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    CreateResultMessage = "The password is not formatted correctly.";
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    CreateResultMessage = "The password question is not formatted correctly.";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    CreateResultMessage = "The password answer is not formatted correctly.";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    CreateResultMessage = "The e-mail address is not formatted correctly.";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    CreateResultMessage = "The user name already exists in the database for the application.";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    CreateResultMessage = "The e-mail address already exists in the database for the application.";
                    break;
                case MembershipCreateStatus.UserRejected:
                    CreateResultMessage = "The user was not created, for a reason defined by the provider.";
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    CreateResultMessage = "The provider user key is of an invalid type or format.";
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    CreateResultMessage = "The ProviderUserKey already exists in the database for the application.";
                    break;
                case MembershipCreateStatus.ProviderError:
                    CreateResultMessage = "The provider returned an error that is not described by other ";
                    CreateResultMessage += "MembershipCreateStatus enumeration values.";
                    break;
            }

            if(createStatus != MembershipCreateStatus.Success) {
                //lblCreateResultMessage.CssClass = "ValidationError";
                //lblCreateResultMessage.Text = CreateResultMessage;
                //btnAddUser.Visible = true;
                //divResultMessage.Visible = true;
            } else {
                //lblCreateResultMessage.CssClass = "bold";
                //btnAddUser.Visible = false;
                FormsAuthentication.SetAuthCookie(newUser.UserName, false);
                //string continueUrl = Session["ContinueDestinationPageUrl"].ToString();

                //if(String.IsNullOrEmpty(continueUrl)) {
                //    continueUrl = "~/";
                //}
                //Response.Redirect(continueUrl);
            }
        }

        public static void updateUser(MembershipUser user) {
            Membership.UpdateUser(user);
        }

        public static void deleteUser(string username) {
            //Membership.DeleteUser(username, false); // DC: My apps will NEVER delete the related data.
            Membership.DeleteUser(username, true); // DC: except during testing, of course!
        }

        public static void deleteUser(string username, bool deleteAllRelatedData) {
            Membership.DeleteUser(username, deleteAllRelatedData);
        }

        public static void unlockUser(MembershipUser user) {
            user.UnlockUser();
        }

        public static bool validateUser(string username, string password) {
            return Membership.ValidateUser(username, password);
        }

        public static int getLockedUserCount() {
            int lockedCount = 0;
            MembershipUserCollection allUsers = Membership.GetAllUsers();
            foreach(MembershipUser user in allUsers) {
                if(user.IsLockedOut) {
                    lockedCount++;
                }
            }
            return lockedCount;
        }
    }
}