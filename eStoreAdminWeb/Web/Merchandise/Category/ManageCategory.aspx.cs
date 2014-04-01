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
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;
using phoenixconsulting.common;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.handlers;
using phoenixconsulting.common.logging;
using phoenixconsulting.common.navigation;
using eStoreAdminWeb.Controls;

namespace eStoreAdminWeb.Web.Merchandise.Category {
    public partial class ManageCategory : MerchandiseBasePage {
        protected void Page_Init(object sender, EventArgs e) {
            Master.CurrencyChanged += CurrencyChangedFromMasterPage;
        }

        private void CurrencyChangedFromMasterPage(object sender, CurrencyChangedEventArgs e) {
            CategoryUpdatePanel.Update();
        }
        
        protected override void OnPreRender(EventArgs e) {
            setNavigateURL(BackToHyperlink1, 
                           "~/Web/Merchandise/Department/ManageDepartment.aspx",
                           QueryStringHelper.Instance.DepartmentLevel());
            base.OnPreRender(e);
        }

        protected void GoToAdd(object sender, EventArgs e) {
            GoTo.Instance.AddProductPage();
        }

        protected string constructNavigateURL(string prodID, string prodName) {
            return "~/Web/Merchandise/Product/ManageProduct.aspx" +
                   QueryStringHelper.Instance.ProductLevel(toInt(prodID), prodName);
        }
        
        protected void ProductList_ItemCommand(object sender, ListViewCommandEventArgs e) {
            switch(e.CommandName) {
                case "ManageImage":
                    //string[] args = split(e.CommandArgument.ToString(), '|');
                    //GoTo.Instance.ManageProductImagePage(args[0], args[1], args[2], args[3], args[4], args[5]);
                    GoTo.Instance.ManageProductImagePage();
                    break;
            }
        }

        protected void ProductList_ItemDeleting(object sender, ListViewDeleteEventArgs e) {
            int index = e.ItemIndex;
            string itemName = ((Label)ProductList.Items[index].FindControl("ProductName")).Text;
            logger.Debug(LoggerUtil.getText(e, "Product" + itemName));
            logInfo(AuditEventType.PRODUCT_DELETED, null, itemName, null);
            if(ProductList.Items.Count == 0) {
                GoTo.Instance.ManageCategoryPage();
            }
        }

        protected void ProductList_ItemDataBound(object sender, ListViewItemEventArgs e) {
            LinkButton linkButton = (LinkButton)e.Item.FindControl("PickImageButton");
            if(linkButton != null) {
                int imageCount = int.Parse(((Literal)e.Item.FindControl("ImageCount")).Text);
                linkButton.Visible = imageCount > 0;
            }
        }

        protected void ProductListView_DataBound(object sender, EventArgs e) {
            if(ProductList.Items.Count > 0) {
                setDiscUnitPriceMode();
                PagerUtils.SetPageDetails(ProductList);
            }
        }

        protected void ProductListView_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e) {
            PagerUtils.SetPageDetails((ListView)sender);
        }

        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider")]
        private void setDiscUnitPriceMode() {
            //DropDownList OnSaleDDL = getOnSaleDDL();
            //TextBox DiscUnitPrice = getDiscUnitPriceTextBox();
            //RequiredFieldValidator DiscountUnitPriceRFV = getDiscountUnitPriceRFV();
            //CompareValidator DiscountUnitPriceCheckQuantum = getDiscountUnitPriceCV();

            //if(OnSaleDDL != null) {
            //    //Edit or Insert Mode 
            //    if(OnSaleDDL.SelectedItem.Text.Equals("Yes")) {
            //        DiscUnitPrice.Enabled = true;
            //        DiscountUnitPriceRFV.Enabled = true;
            //        DiscountUnitPriceCheckQuantum.Enabled = true;

            //    } else {
            //        DiscUnitPrice.Enabled = false;
            //        DiscountUnitPriceRFV.Enabled = false;
            //        DiscountUnitPriceCheckQuantum.Enabled = false;
            //    }
            //}
        }
    }
}