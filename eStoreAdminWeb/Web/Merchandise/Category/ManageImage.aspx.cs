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
using eStoreAdminBLL;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.handlers;
using phoenixconsulting.common.logging;
using phoenixconsulting.common.navigation;

namespace eStoreAdminWeb.Web.Merchandise.Category {
    public partial class ManageImage : ImageBasePage {
        protected override void OnPreRender(EventArgs e) {
			setNavigateURL(BackToHyperlink,
                           Pages.MANAGE_DEPARTMENT,
                           QueryStringHelper.Instance.DepartmentLevel());
            base.OnPreRender(e);
        }

        protected void CategoryImageListView_ItemCommand(object sender, ListViewCommandEventArgs e) {
            switch(e.CommandName) {
                case "MakeDefault":
                    int imageID = int.Parse(e.CommandArgument.ToString());
                    (new ImagesBLL()).UpdateCategoryImage(RequestHandler.Instance.CategoryID, imageID, 1);
                    logInfo(AuditEventType.CATEGORY_IMAGE_MAKE_DEFAULT, null, null, null);
                    GoTo.Instance.ManageCategoryImagePage();
                    break;
            }
        }        
    }
}