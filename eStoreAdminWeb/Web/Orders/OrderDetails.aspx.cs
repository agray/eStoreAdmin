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
using System.Web.UI;
using System.Web.UI.WebControls;
using phoenixconsulting.common.basepages;

namespace eStoreAdminWeb {
    public partial class OrderDetails : BasePage {
        private decimal priceTotal = 0;
        private decimal weightTotal = 0;

        protected override void OnPreRender(EventArgs e) {
            OrderDetailsHyperlinkTop.NavigateUrl = "AllDetails.aspx?ID=" + Request.QueryString["ID"];
            PaymentDetailsHyperLinkTop.NavigateUrl = "PaymentDetails.aspx?ID=" + Request.QueryString["ID"];
            SearchResultsHyperlinkTop.NavigateUrl = "ManageOrders.aspx";
            OrderDetailsHyperlinkBottom.NavigateUrl = "AllDetails.aspx?ID=" + Request.QueryString["ID"];
            PaymentDetailsHyperLinkBottom.NavigateUrl = "PaymentDetails.aspx?ID=" + Request.QueryString["ID"];
            SearchResultsHyperlinkBottom.NavigateUrl = "ManageOrders.aspx";

            base.OnPreRender(e);
        }

        protected void OrderDetailsGridView_RowDataBound(object sender, GridViewRowEventArgs e) {
            if(e.Row.RowType == DataControlRowType.DataRow) {
                // add the UnitPrice and QuantityTotal to the running total variables
                e.Row.Cells[4].HorizontalAlign = e.Row.Cells[5].HorizontalAlign = e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                //e.Row.Cells[6].Text = (double.Parse(e.Row.Cells[4].Text) * double.Parse(e.Row.Cells[5].Text)).ToString();
                priceTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "UnitPrice"));
                weightTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalWeight"));
            } else if(e.Row.RowType == DataControlRowType.Footer) {
                //totalsCalculated = true;
                e.Row.Cells[2].Text = "Totals:";
                // for the Footer, display the running totals
                e.Row.Cells[5].Text = priceTotal.ToString("c");
                e.Row.Cells[6].Text = weightTotal.ToString();

                e.Row.Cells[5].HorizontalAlign = e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Font.Bold = true;
            }
        }
    }
}