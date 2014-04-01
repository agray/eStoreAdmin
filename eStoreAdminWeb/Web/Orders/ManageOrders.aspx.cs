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
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;
using eStoreAdminBLL;
using eStoreAdminDAL;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.navigation;

namespace eStoreAdminWeb {
    public partial class ManageOrders : BasePage {
        private OrdersBLL _ordersAdapter;

        protected OrdersBLL OrderAdapter {
            get { return _ordersAdapter ?? (_ordersAdapter = new OrdersBLL()); }
        }

        protected void TestRefund() {}

        protected void Page_Load(object sender, EventArgs e) {
            if(!Page.IsPostBack) {
                setNoResultsLabelVisibility(false);
            }
        }

        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider")]
        protected void ProcessSearch(object sender, EventArgs e) {
            string orderDate = String.Format("{0}", Request.Form["OrderDateDatePicker"]);
            string orderFromDate = String.Format("{0}", Request.Form["OrderDateDatePicker"]);
            string orderToDate = String.Format("{0}", Request.Form["OrderDateDatePicker"]);
            string shipDate = String.Format("{0}", Request.Form["OrderDateDatePicker"]);
            string shipFromDate = String.Format("{0}", Request.Form["OrderDateDatePicker"]);
            string shipToDate = String.Format("{0}", Request.Form["OrderDateDatePicker"]);

            logger.Debug("Processing Search...");

            DAL.OrderDataTable odt = OrderAdapter.SearchOrders(EmailTextBox.Text, BillingFirstNameTextBox.Text, BillingLastNameTextBox.Text, BillingAddressTextBox.Text, BillingSuburbCityTextBox.Text, BillingStateProvinceRegionTextBox.Text, BillingZipPostcodeTextBox.Text, BillingCountryDropDownList.SelectedValue, ShippingFirstNameTextBox.Text, ShippingLastNameTextBox.Text, ShippingAddressTextBox.Text, ShippingSuburbCityTextBox.Text, ShippingStateProvinceRegionTextBox.Text, ShippingZipPostcodeTextBox.Text, ShippingCountryDropDownList.SelectedValue, ShippingModeDropDownList.Text, ShippingCostTextBox.Text, shipDate, shipFromDate, shipToDate, orderDate, orderFromDate, orderToDate, Convert.ToInt32(ApprovedDDL.SelectedValue), Convert.ToInt32(ShippedDDL.SelectedValue), Convert.ToInt32(CommentDDL.SelectedValue), Convert.ToInt32(GiftTagDDL.SelectedValue));
            if(odt.Count == 0) {
                setNoResultsLabelVisibility(true);
                SearchResultsGridView.DataSource = null;
                SearchResultsGridView.DataBind();
            } else {
                setNoResultsLabelVisibility(false);

                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Approval Status");
                dt.Columns.Add("Item Total");
                dt.Columns.Add("Shipping Cost");
                dt.Columns.Add("Total");
                dt.Columns.Add("Order Date");
                dt.Columns.Add("Ship Date");
                dt.Columns.Add("Mode");
                dt.Columns.Add("User ID");

                foreach(DataRow source in odt) {
                    DataRow dest = dt.NewRow();
                    dest["ID"] = source["ID"];
                    dest["Approval Status"] = (int)source["CCApprovalStatus"] == 0 ? "Approved" : "Declined";
                    dest["Item Total"] = source["OrderTotal"];
                    dest["Shipping Cost"] = source["ShippingCost"];
                    dest["Total"] = source["TotalCost"];
                    dest["Order Date"] = source["OrderDate"];
                    dest["Ship Date"] = source["ShipDate"];
                    dest["Mode"] = source["ModeName"];
                    dest["User ID"] = source["UserID"];

                    dt.Rows.Add(dest);
                }

                SearchResultsGridView.DataSource = dt;
                SearchResultsGridView.DataBind();

                logger.Debug("Successfully retrieved results for user: " + User.Identity.Name);
            }
        }

        protected void ClearForm(object sender, EventArgs e) {
            GoTo.Instance.ManageOrdersPage();
        }


        private void setNoResultsLabelVisibility(bool visibleState) {
            NoResultsLabel.Visible = visibleState;
            SearchResultsGridView.Visible = !visibleState;
        }

        protected void SearchResultsGridView_RowCommand(object sender, GridViewCommandEventArgs e) {
            if(e.CommandName.CompareTo("RefundCustomer") == 0) {
                // Determine the ID of the product whose price was adjusted
                logger.Debug("Attempting to refund order " + e.CommandArgument);
                string orderID = (string)SearchResultsGridView.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;
                GoTo.Instance.CCProcessorPage(orderID);
            }
        }

        protected void SearchResultsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            SearchResultsGridView.PageIndex = e.NewPageIndex;
            SearchResultsGridView.DataBind();
        }

        protected bool IsRefunded(string refundedIndicator) {
            return int.Parse(refundedIndicator) == 1;
        }
    }
}