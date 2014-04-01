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
using System.Web.UI.WebControls;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.navigation;
using phoenixconsulting.common.logging;

namespace eStoreAdminWeb.Web.Advanced {
    public partial class ManageModes : AuditBasePage {
        protected void ModesDetailsView_Inserted(object sender, DetailsViewInsertedEventArgs e) {
            logInfo(AuditEventType.MODE_ADDED, e.Values[0].ToString(), null, null);
            GoTo.Instance.RefreshPage(Request.Url.Query);
        }

        protected void ModeList_ItemUpdated(object sender, ListViewUpdatedEventArgs e) {
            logInfo(AuditEventType.MODE_UPDATED, e.NewValues[0].ToString(), e.OldValues[0].ToString(), null);
        }

        protected void ModeList_ItemDeleting(object sender, ListViewDeleteEventArgs e) {
            string mode = ((Label)ModeList.Items[e.ItemIndex].FindControl("NameLabel")).Text;
            logInfo(AuditEventType.MODE_DELETED, null, mode, null);
        }
    }
}