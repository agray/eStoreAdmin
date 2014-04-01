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
using System.Web.UI.WebControls;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.logging;
using phoenixconsulting.common.navigation;
using NLog;

namespace eStoreAdminWeb {
    public partial class ManageSocialByProd : AuditBasePage {
        protected void Page_Load(object sender, EventArgs e) {}

        protected void SNFormView_ItemUpdated(object sender, FormViewUpdatedEventArgs e) {
            string username = CurrentUserName();
            logger.Debug("User " + username + " updated Social Networking Setting " + e.OldValues[0] + " to " + e.NewValues[0] + " for product " + SNsGridView.DataKeys[0].Value);
            SNsGridView.DataBind();
            logInfo(AuditEventType.SNPROD_UPDATED, e.NewValues[0].ToString(), e.OldValues[0].ToString(), null);

            if(SNsGridView.Rows.Count == 0) {
                GoTo.Instance.ManageSocialByProdPage();
            }
        }

        protected void CategoriesDropDownList_SelectedIndexChanged(object sender, EventArgs e) {
            SNsGridView.Visible = true;
        }

        protected void CategoriesDropDownList_DataBound(object sender, EventArgs e) {
            CategoriesDropDownList.Items.Insert(0, new ListItem("-- Choose a Category --", "-1", true));
            CategoriesDropDownList.Items[0].Selected = true;
            SNsGridView.Visible = false;
        }
    }
}