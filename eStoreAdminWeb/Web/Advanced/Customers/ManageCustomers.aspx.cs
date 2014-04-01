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
using System.Web.UI;
using System.Web.UI.WebControls;
using com.phoenixconsulting.AspNet.Membership;
using phoenixconsulting.common.basepages;

namespace eStoreAdminWeb.Web.Advanced.Customers {
    public partial class ManageCustomers : BasePage {
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void CustomersGridView_RowDataBound(object sender, GridViewRowEventArgs e) {
            if(e.Row.RowType == DataControlRowType.DataRow) {
                HyperLink editCustomer = (HyperLink)e.Row.FindControl("EditCustomerHyperlink");
                editCustomer.Text = DataBinder.Eval(e.Row.DataItem, "FirstName") + " " +
                                    DataBinder.Eval(e.Row.DataItem, "LastName");
                editCustomer.NavigateUrl = editCustomer.NavigateUrl + DataBinder.Eval(e.Row.DataItem, "UserName");
            }
        }

        private void Page_PreRender() {
            DTMembershipProvider dtmp = (DTMembershipProvider)Membership.Providers["DTMembershipProvider"];
            int totalRecords;
            CustomersGridView.DataSource = AlphaLinks.Letter == "All" 
                                         ? dtmp.GetAllUsers(0, 50, out totalRecords)
                                         : dtmp.FindUsersByName(AlphaLinks.Letter + "%", 0, 50, out totalRecords);
            CustomersGridView.DataBind();
        }
    }
}