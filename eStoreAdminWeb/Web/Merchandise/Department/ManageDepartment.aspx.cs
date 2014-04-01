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
using eStoreAdminWeb.Controls;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.logging;
using phoenixconsulting.common.navigation;

namespace eStoreAdminWeb.Web.Merchandise.Department {
    public partial class ManageDepartment : MerchandiseBasePage {
        protected void Page_Init(object sender, EventArgs e) {
            Master.CurrencyChanged += CurrencyChangedFromMasterPage;
        }

        private void CurrencyChangedFromMasterPage(object sender, CurrencyChangedEventArgs e) {
            DepartmentUpdatePanel.Update();
        }
        
        protected override void OnPreRender(EventArgs e) {
            setNavigateURL(BackToHyperlink1, "~/Web/Merchandise/Departments/ManageDepartments.aspx");
            base.OnPreRender(e);
        }

        protected void GoToAdd(object sender, EventArgs e) {
            GoTo.Instance.AddCategoryPage();
        }

        protected string constructNavigateURL(string catID, string catName) {
            return Pages.MANAGE_CATEGORY + 
                   QueryStringHelper.Instance.CategoryLevel(toInt(catID), catName);
        }
        
        protected void CategoryList_ItemCommand(object sender, ListViewCommandEventArgs e) {
            switch(e.CommandName) {
                case "ManageImage":
                    string[] args = split(e.CommandArgument.ToString(), '|');
                    GoTo.Instance.ManageCategoryImagePage(toInt(args[0]), args[1]);
                    break;
            }
        }

        protected void CategoryList_ItemUpdating(object sender, ListViewUpdateEventArgs e) {
            logger.Debug(LoggerUtil.getText(e, "Category"));
            logInfo(AuditEventType.CATEGORY_UPDATED, e.NewValues[0].ToString(), e.OldValues[0].ToString(), null);
        }

        protected void CategoryList_ItemDeleting(object sender, ListViewDeleteEventArgs e) {
            int index = e.ItemIndex;
            string itemName = ((Label)CategoryList.Items[index].FindControl("CategoryName")).Text;
            logger.Debug(LoggerUtil.getText(e, "Category" + itemName));
            logInfo(AuditEventType.CATEGORY_DELETED, null, itemName, null);
            if(CategoryList.Items.Count == 0) {
                GoTo.Instance.ManageDepartmentPage();
            }
        }

        protected void CategoryList_ItemDataBound(object sender, ListViewItemEventArgs e) {
            LinkButton linkButton = (LinkButton)e.Item.FindControl("PickImageButton");
            if(linkButton != null) {
                int imageCount = int.Parse(((Literal)e.Item.FindControl("ImageCount")).Text);
                linkButton.Visible = imageCount > 0;
            }
        }
    }
}