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
using com.phoenixconsulting.AspNet.Membership;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.logging;
using phoenixconsulting.common.navigation;

namespace eStoreAdminWeb.Web.Advanced.Customers {
    public partial class EditCustomer : AuditBasePage {
        private string username;
        private MembershipUser user;

        protected void Page_Load(object sender, EventArgs e) {
            DTMembershipProvider dtmp = (DTMembershipProvider)Membership.Providers["DTMembershipProvider"];
            username = Request.QueryString["username"];
            if(string.IsNullOrEmpty(username)) {
                GoTo.Instance.HomePage();
            }
            user = dtmp.GetUser(username, false);
            CustomerUpdateMessage.Text = String.Empty;
            CustomerInfo.DataBind();
        }

        //protected void Page_PreRender() {
        //    //Disable checkboxes if appropriate:
        //    if(CustomerInfo.CurrentMode != DetailsViewMode.Edit) {
        //        foreach(ListItem checkbox in UserRoles.Items) {
        //            checkbox.Enabled = false;
        //        }
        //    }
        //}

        protected void CustomerInfo_ItemUpdating(object sender, DetailsViewUpdateEventArgs e) {
            DTMembershipProvider dtmp = (DTMembershipProvider)Membership.Providers["DTMembershipProvider"];
            
            //Need to handle the update manually because MembershipUser does not have a
            //parameterless constructor  
            user.Email = (string)e.NewValues[0];
            user.Comment = (string)e.NewValues[1];
            user.IsApproved = (bool)e.NewValues[2];

            try {
                // Update customer info
                dtmp.UpdateUser(user);

                CustomerUpdateMessage.Text = "Update Successful.";
                logInfo(AuditEventType.CUSTOMER_LOGIN_UPDATED, e.NewValues[0].ToString(), e.OldValues[0].ToString(), null);
                e.Cancel = true;
                CustomerInfo.ChangeMode(DetailsViewMode.ReadOnly);
            } catch(Exception ex) {
                CustomerUpdateMessage.Text = "Update Failed: " + ex.Message;
                e.Cancel = true;
                CustomerInfo.ChangeMode(DetailsViewMode.ReadOnly);
            }
        }

        protected void UnlockCustomer(object sender, EventArgs e) {
            DTMembershipProvider dtmp = (DTMembershipProvider)Membership.Providers["DTMembershipProvider"];
            dtmp.UnlockUser(user.UserName);

            // DataBind the GridView to reflect same.
            CustomerInfo.DataBind();
            logInfo(AuditEventType.CUSTOMER_LOGIN_UNLOCKED, null, null, "Customer " + user.UserName + " unlocked");
        }
    }
}