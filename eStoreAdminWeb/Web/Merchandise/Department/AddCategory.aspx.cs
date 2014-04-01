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
using phoenixconsulting.common.handlers;
using phoenixconsulting.common.logging;
using phoenixconsulting.common.navigation;

namespace eStoreAdminWeb.Web.Merchandise.Department {
    public partial class AddCategory : AuditBasePage {
        protected void Page_Load(object sender, EventArgs e) {
            AddCategoryFormView.DefaultMode = FormViewMode.Insert;
        }

        protected void AddCategoryFormView_ItemInserted(object sender, FormViewInsertedEventArgs e) {
            //Have to have Binds on aspx form so that e.Value array has elements.
            logger.Debug(LoggerUtil.getText(e, "Category"));
            logInfo(AuditEventType.CATEGORY_ADDED, e.Values[0].ToString(), null, null);
            GoTo.Instance.ManageDepartmentPage();
        }

        protected void AddCategoryFormView_ItemCommand(object sender, FormViewCommandEventArgs e) {
            if(e.CommandName == "Insert") {
                FormView f = (FormView)sender;
                ObjectDataSource o = (ObjectDataSource)f.NamingContainer.FindControl("CategoryODS");
                o.InsertParameters["DepID"].DefaultValue = RequestHandler.Instance.DepartmentID.ToString();
            }
        }

        protected void Cancel_Click(object sender, EventArgs e) {
            GoTo.Instance.ManageDepartmentPage();
        }

        //private TextBox getTextBox(string name) {
        //    FormView fv = AddCategoryFormView;
        //    return (TextBox)fv.FindControl(name);
        //}
    }
}