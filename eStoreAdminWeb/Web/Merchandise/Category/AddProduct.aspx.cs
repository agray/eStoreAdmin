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
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.logging;
using phoenixconsulting.common.navigation;
using NLog;
using phoenixconsulting.common.handlers;

namespace eStoreAdminWeb.Web.Merchandise.Category {
    public partial class AddProduct : BasePage {
        protected void Page_Load(object sender, EventArgs e) {
            AddProductFormView.DefaultMode = FormViewMode.Insert;
        }

        protected void AddProductFormView_ItemInserted(object sender, FormViewInsertedEventArgs e) {
            //Have to have Binds on aspx form so that e.Value array has elements.
            logger.Debug(LoggerUtil.getText(e, "Category"));
            LoggerUtil.infoAuditLog(AuditEventType.PRODUCT_ADDED,
                                    "AdminSite", e.Values[0].ToString(), null, null, null);
            GoTo.Instance.ManageCategoryPage();
                }

        protected void AddProductFormView_ItemCommand(object sender, FormViewCommandEventArgs e) {
            if(e.CommandName == "Insert") {
                FormView f = (FormView)sender;
                ObjectDataSource o = (ObjectDataSource)f.NamingContainer.FindControl("ProductODS");
                o.InsertParameters["DepID"].DefaultValue = RequestHandler.Instance.DepartmentID.ToString();
                o.InsertParameters["CatID"].DefaultValue = RequestHandler.Instance.CategoryID.ToString();
            }
        }

        protected void Cancel_Click(object sender, EventArgs e) {
            GoTo.Instance.ManageCategoryPage();
        }

        //private TextBox getTextBox(string name) {
        //    FormView fv = AddProductFormView;
        //    return (TextBox)fv.FindControl(name);
        //}

        protected void ProductFormView_DataBound(object sender, EventArgs e) {
            //if(ProductsGridView.Rows.Count != 0) {
                setDiscUnitPriceMode();
            //}
        }

        protected void UnitPriceEditTextBox_TextChanged(object sender, EventArgs e) {
            setDiscUnitPriceMode();
            setDiscUnitPrice(getUnitPriceTextBox().Text);
        }

        protected void OnSaleAddDropDownList_SelectedIndexChanged(object sender, EventArgs e) {
            setDiscUnitPriceMode();
            setDiscUnitPrice(getUnitPriceTextBox().Text);
        }

        protected void OnSaleEditDropDownList_SelectedIndexChanged(object sender, EventArgs e) {
            setDiscUnitPriceMode();
            setDiscUnitPrice(getUnitPriceTextBox().Text);
        }

        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider")]
        private void setDiscUnitPriceMode() {
            DropDownList OnSaleDDL = getOnSaleDDL();
            TextBox DiscUnitPrice = getDiscUnitPriceTextBox();
            RequiredFieldValidator DiscountUnitPriceRFV = getDiscountUnitPriceRFV();
            CompareValidator DiscountUnitPriceCheckQuantum = getDiscountUnitPriceCV();

            if(OnSaleDDL != null) {
                //Edit or Insert Mode 
                if(OnSaleDDL.SelectedItem.Text.Equals("Yes")) {
                    DiscUnitPrice.Enabled = true;
                    DiscountUnitPriceRFV.Enabled = true;
                    DiscountUnitPriceCheckQuantum.Enabled = true;
                } else {
                    DiscUnitPrice.Enabled = false;
                    DiscountUnitPriceRFV.Enabled = false;
                    DiscountUnitPriceCheckQuantum.Enabled = false;
                }
            }
        }

        private RequiredFieldValidator getDiscountUnitPriceRFV() {
            return (RequiredFieldValidator)AddProductFormView.FindControl("DiscountUnitPriceAddRFV");
        }

        private CompareValidator getDiscountUnitPriceCV() {
            return (CompareValidator)AddProductFormView.FindControl("DiscountUnitPriceAddCheckQuantum");
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
            return (DropDownList)AddProductFormView.FindControl("OnSaleAddDropDownList");
        }

        private TextBox getDiscUnitPriceTextBox() {
            return (TextBox)AddProductFormView.FindControl("DiscountUnitPriceAddTextBox");
        }

        private TextBox getWholesalePriceTextBox() {
            return (TextBox)AddProductFormView.FindControl("WholesalePriceAddTextBox");
        }

        private TextBox getUnitPriceTextBox() {
            return (TextBox)AddProductFormView.FindControl("UnitPriceAddTextBox");
        }
    }
}