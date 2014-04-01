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
using eStoreAdminWeb.Controls;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.handlers;
using phoenixconsulting.common.logging;
using phoenixconsulting.common.navigation;

namespace eStoreAdminWeb.Web.Merchandise.Product {
    public partial class ManageProduct : MerchandiseBasePage {
        protected void Page_Init(object sender, EventArgs e) {
            Master.CurrencyChanged += CurrencyChangedFromMasterPage;
        }

        private void CurrencyChangedFromMasterPage(object sender, CurrencyChangedEventArgs e) {
            ProductUpdatePanel.Update();
        }

        private string[] fieldNames = { "Name", 
                                        "Description", 
                                        "Supplier", 
                                        "Quanitity Per Unit", 
                                        "Retail Price", 
                                        "Wholesale Price", 
                                        "Weight",
                                        "Units In Stock",
                                        "Units On Order",
                                        "Reorder Level",
                                        "Active",
                                        "Is On Sale",
                                        "Sale Price"};

        protected override void OnPreRender(EventArgs e) {
            setNavigateURL(BackToHyperlink1, 
                           Pages.MANAGE_CATEGORY,
                           QueryStringHelper.Instance.CategoryLevel(RequestHandler.Instance.CategoryID, 
                                                                    RequestHandler.Instance.CategoryName));
            base.OnPreRender(e);
        }

        protected void ProductFormView_DataBound(object sender, EventArgs e) {
            //if(ProductFormView.DataSourceID != "") {
            //    Label ProductNameLabel = (Label)ProductFormView.FindControl("HeaderNameLabel");
            //    if(ProductNameLabel == null) {
            //        Page.Title = "Product not found.";
            //    }
            //} else {
            //    Page.Title = "Product not found.";
            //}
        }

        protected void ProductFormView_ItemUpdated(object sender, FormViewUpdatedEventArgs e) {
            logger.Debug(LoggerUtil.getText(fieldNames, e, "Product"));
            ProductFormView.DefaultMode = FormViewMode.ReadOnly;
            ProductFormView.DataBind();
            logInfo(AuditEventType.PRODUCT_UPDATED, e.NewValues[0].ToString(), e.OldValues[0].ToString(), null);
        }

        protected void MiniImageListView_ItemDataBound(object sender, ListViewItemEventArgs e) {
            if(e.Item.ItemType == ListViewItemType.DataItem) {
                Image miniImage = (Image)e.Item.FindControl("MiniImage");
                string imageURL = getImageURL(miniImage.ImageUrl);
                miniImage.Attributes.Add("onMouseOver", "ctl00_ContentPlaceHolder1_ProductFormView_MainImage.src='" + imageURL + "';ctl00_ContentPlaceHolder1_ProductFormView_MainImage.alt='" + miniImage.AlternateText + "'");
            }
        }

        private static string getImageURL(string URL) {
            return URL.Replace("~", "../../..");
        }

        protected string ConcatKeys(string depID, string catID, string prodID) {
            return depID + " " + catID + " " + prodID;
        }

        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider")]
        protected bool HasSN() {
            Label label = (Label)ProductFormView.FindControl("HasSN");
            return (Int32.Parse(label.Text) == 1);
        }

        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider")]
        protected bool HasProductSizes() {
            Label label = (Label)ProductFormView.FindControl("NumProductSizes");
            return (Int32.Parse(label.Text) > 0);
        }

        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider")]
        protected bool HasProductColors() {
            Label label = (Label)ProductFormView.FindControl("NumProductColors");
            return (Int32.Parse(label.Text) > 0);
        }

        protected void UnitPriceEditTextBox_TextChanged(object sender, EventArgs e) {
            //setDiscUnitPriceMode(e);
            //setDiscUnitPrice(getUnitPriceTextBox().Text, e);
        }

        protected void OnSaleAddDropDownList_SelectedIndexChanged(object sender, EventArgs e) {
            //setDiscUnitPriceMode(e);
            //setDiscUnitPrice(getUnitPriceTextBox().Text, e);
        }

        protected void OnSaleEditDropDownList_SelectedIndexChanged(object sender, EventArgs e) {
            //setDiscUnitPriceMode(e);
            //setDiscUnitPrice(getUnitPriceTextBox().Text, e);
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

        private RequiredFieldValidator getDiscountUnitPriceRFV() {
            RequiredFieldValidator r = (RequiredFieldValidator)ProductFormView.FindControl("DiscountUnitPriceEditRFV");
            if(r != null) {
                return r;
            } 
            return (RequiredFieldValidator)ProductFormView.FindControl("DiscountUnitPriceAddRFV");
        }

        private CompareValidator getDiscountUnitPriceCV() {
            CompareValidator r = (CompareValidator)ProductFormView.FindControl("DiscountUnitPriceEditCheckQuantum");
            if(r != null) {
                return r;
            } 
            return (CompareValidator)ProductFormView.FindControl("DiscountUnitPriceAddCheckQuantum");
        }

        private void setDiscUnitPrice(string unitPrice) {
            TextBox discUnitPrice = getDiscUnitPriceTextBox();
            TextBox wholesalePrice = getWholesalePriceTextBox();
            Double dblUnitPrice;
            Double dblWholesalePrice;

            if(isValidDouble(unitPrice)) {
                dblUnitPrice = Double.Parse(unitPrice);
                dblWholesalePrice = Double.Parse(wholesalePrice.Text);
                dblUnitPrice = dblWholesalePrice < (dblUnitPrice * 0.9) 
                             ? dblUnitPrice * 0.9 
                             : dblWholesalePrice + ((dblUnitPrice - dblWholesalePrice) / 2);
            } else {
                dblUnitPrice = 0;
            }
            discUnitPrice.Text = dblUnitPrice.ToString();
        }

        private DropDownList getOnSaleDDL() {
            DropDownList d = (DropDownList)ProductFormView.FindControl("OnSaleEditDDL:YesNoDropDownList");
            //DropDownList d = (DropDownList)ProductFormView.FindControl("OnSaleEditDDL");
            return d ?? (DropDownList)ProductFormView.FindControl("OnSaleAddDDL:YesNoDropDownList");
        }

        private TextBox getDiscUnitPriceTextBox() {
            TextBox t = (TextBox)ProductFormView.FindControl("DiscountUnitPriceEditTextBox");
            return t ?? (TextBox)ProductFormView.FindControl("DiscountUnitPriceAddTextBox");
        }

        private TextBox getWholesalePriceTextBox() {
            TextBox t = (TextBox)ProductFormView.FindControl("WholesalePriceEditTextBox");
            return t ?? (TextBox)ProductFormView.FindControl("WholesalePriceAddTextBox");
        }

        private TextBox getUnitPriceTextBox() {
            TextBox t = (TextBox)ProductFormView.FindControl("UnitPriceEditTextBox");
            return t ?? (TextBox)ProductFormView.FindControl("UnitPriceAddTextBox");
        }
    }
}