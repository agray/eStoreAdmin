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
using eStoreAdminWeb.Controls;

namespace eStoreAdminWeb.Web.Merchandise.Departments {
    public partial class ManageDepartments : MerchandiseBasePage {
        protected void Page_Init(object sender, EventArgs e) {
            Master.CurrencyChanged += CurrencyChangedFromMasterPage;
        }

        private void CurrencyChangedFromMasterPage(object sender, CurrencyChangedEventArgs e) {
            DepartmentsUpdatePanel.Update();
        }

        protected void Page_Load() {
            //((CurrencyDDL)Master.FindControl("currencyDDL")).Text = SessionHandler.Instance.Currency;
        }

        protected void GoToAdd(object sender, EventArgs e) {
            GoTo.Instance.AddDepartmentPage();
        }

        protected void DepartmentsList_ItemCommand(object sender, ListViewCommandEventArgs e) {
            switch(e.CommandName) {
                case "ManageImage":
                    string[] args = split(e.CommandArgument.ToString(), '|');
                    GoTo.Instance.ManageDepartmentImagePage(toInt(args[0]), args[1]);
                    break;
            }
        }

        protected void DepartmentsList_ItemUpdated(object sender, ListViewUpdatedEventArgs e) {
            logger.Debug(LoggerUtil.getText(e, "Department "));
            logInfo(AuditEventType.DEPARTMENT_UPDATED, e.NewValues[0].ToString(), e.OldValues[0].ToString(), null);
        }

        protected void DepartmentsList_ItemDeleting(object sender, ListViewDeleteEventArgs e) {
            int index = e.ItemIndex;
            string itemName = ((Label)DepartmentsList.Items[index].FindControl("DepartmentName")).Text;
            logger.Debug(LoggerUtil.getText(e, "Department " + itemName));
            logInfo(AuditEventType.DEPARTMENT_DELETED, null, itemName, null);
            if(DepartmentsList.Items.Count == 0) {
                GoTo.Instance.ManageDepartmentsPage();
            }
        }

        protected void DepartmentsList_ItemDataBound(object sender, ListViewItemEventArgs e) {
            LinkButton linkButton = (LinkButton)e.Item.FindControl("PickImageButton");
            if(linkButton != null) {
                int imageCount = int.Parse(((Literal)e.Item.FindControl("ImageCount")).Text);
                linkButton.Visible = imageCount > 0;
            }
        }
    }
}