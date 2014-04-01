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

namespace eStoreAdminWeb {
    public partial class ManageLinks : AuditBasePage {
        private string[] fieldNames = {"URL", "Text", "Description", "Type"};

        protected void LinkFormView_ItemDeleted(object sender, FormViewDeletedEventArgs e) {
            logger.Debug(LoggerUtil.getText(fieldNames, e, "Link"));
            logInfo(AuditEventType.LINK_DELETED, null, e.Values[0].ToString(), null);
            GoTo.Instance.RefreshPage(Request.Url.Query);
        }

        protected void LinkFormView_ItemInserted(object sender, FormViewInsertedEventArgs e) {
            logger.Debug(LoggerUtil.getText(fieldNames, e, "Link"));
            LinksGridView.DataBind();
            logInfo(AuditEventType.LINK_ADDED, e.Values[0].ToString(), null, null);
            LinkFormView.DefaultMode = FormViewMode.ReadOnly;
        }

        protected void LinkFormView_ItemUpdated(object sender, FormViewUpdatedEventArgs e) {
            logger.Debug(LoggerUtil.getText(fieldNames, e, "Link"));
            LinksGridView.DataBind();
            logInfo(AuditEventType.LINK_UPDATED, e.OldValues[0].ToString(), e.NewValues[0].ToString(), null);
        }

        protected void LinksGridView_DataBound(object sender, EventArgs e) {
            if(LinksGridView.Rows.Count == 0) {
                LinkFormView.DefaultMode = FormViewMode.Insert;
            } else {
                LinkFormView.DefaultMode = FormViewMode.ReadOnly;
            }
        }
    }
}