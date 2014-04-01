﻿#region Licence
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
using System.Web.UI;
using System.Web.UI.WebControls;
using com.phoenixconsulting.AspNet.Membership;
using phoenixconsulting.common.basepages;

namespace eStoreAdminWeb.Web.Advanced.Customers {
    public partial class LockedCustomers : BasePage {
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void LockedCustomersGridView_RowDataBound(object sender, GridViewRowEventArgs e) {
            if(e.Row.RowType == DataControlRowType.DataRow) {
                HyperLink lockedCustomer = (HyperLink)e.Row.FindControl("LockedCustomerHyperlink");
                lockedCustomer.Text = DataBinder.Eval(e.Row.DataItem, "FirstName") + " " +
                                    DataBinder.Eval(e.Row.DataItem, "LastName");
                lockedCustomer.NavigateUrl = lockedCustomer.NavigateUrl +
                                           DataBinder.Eval(e.Row.DataItem, "UserName");
            }
        }

        protected void Page_PreRender() {
            int totalRecords;
            DTMembershipProvider dtmp = (DTMembershipProvider)Membership.Providers["DTMembershipProvider"];
            MembershipUserCollection allUsers = dtmp.GetAllUsers(0, 50, out totalRecords);
            MembershipUserCollection filteredUsers = new MembershipUserCollection();

            //MembershipUserCollection allUsers = Membership.GetAllUsers();
            //MembershipUserCollection filteredUsers = new MembershipUserCollection();
            foreach(MembershipUser user in allUsers) {
                if(user.IsLockedOut) {
                    filteredUsers.Add(user);
                }
            }
            LockedCustomersGridView.DataSource = filteredUsers;
            LockedCustomersGridView.DataBind();
        }
    }
}