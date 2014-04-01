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

namespace eStoreAdminWeb.Web.Orders {
    public partial class AllDetails : BasePage {
        protected override void OnPreRender(EventArgs e) {
            AllDetailsHyperlinkTop.NavigateUrl = "OrderDetails.aspx?ID=" + Request.QueryString["ID"];
            PaymentDetailsHyperLinkTop.NavigateUrl = "PaymentDetails.aspx?ID=" + Request.QueryString["ID"];
            SearchResultsHyperlinkTop.NavigateUrl = "ManageOrders.aspx";
            base.OnPreRender(e);
        }

        public bool IsShipped() {
            Label ShipDateLabel;
            ShipDateLabel = (Label)AllDetailsFormView.FindControl("ShipDateLabel");
            if (String.IsNullOrEmpty(ShipDateLabel.Text)) {
                logger.Debug("Order " + AllDetailsFormView.DataKey.Value + " has not been shipped.");
                return false;
            } 
            logger.Debug("Order " + AllDetailsFormView.DataKey.Value + " has been shipped.");
            return true;
        }

        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider")]
        public bool IsOld() {
            Label OrderDateLabel;
            DateTime OrderDate;

            OrderDateLabel = (Label)AllDetailsFormView.FindControl("OrderDateLabel");
            OrderDate = DateTime.Parse(OrderDateLabel.Text);

            TimeSpan ts = DateTime.Now - OrderDate;
            if (ts.Days > 3) {
                logger.Debug("Order " + AllDetailsFormView.DataKey.Value + " is old.");
                return true;
            }
            logger.Debug("Order " + AllDetailsFormView.DataKey.Value + " is not yet old.");
            return false;
        }

        //public bool IsApproved() {
        //    Label CCApprovalStatusLabel;
        //    CCApprovalStatusLabel = (Label)AllDetailsFormView.FindControl("CCApprovalStatusLabel");

        //    return CCApprovalStatusLabel.Text.Equals("0");
        //}
    }
}