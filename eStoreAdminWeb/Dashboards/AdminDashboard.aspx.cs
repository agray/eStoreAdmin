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
using com.phoenixconsulting.authentication;
using eStoreAdminBLL;
using eStoreAdminDAL;
using phoenixconsulting.common.basepages;

namespace eStoreAdminWeb {
    public partial class AdminDashboard : DashboardBasePage {
        protected void Page_Load(object sender, EventArgs e) {
            populateAlertsTab();
            populateMetricsTab();
        }

        private void populateAlertsTab() {
            DAL.AlertsDataTable dt = BLLAdapter.Instance.DashboardAdapter.getAlerts();

            LowInventoryLabel.Text = dt.Rows[0]["LowInventoryCount"].ToString();
            DeclinedTransactionsLabel.Text = dt.Rows[0]["DeclinedTransCount"].ToString();
            LockedOutUsersLabel.Text = FormsAuthenticator.getLockedUserCount().ToString();
        }

        private void populateMetricsTab() {
            DataTable dt = BLLAdapter.Instance.DashboardAdapter.getMetrics();

            NetSalesYTDLabel.Text = dt.Rows[0]["NetSalesYTDCount"].ToString();
            NetSalesMTDLabel.Text = dt.Rows[0]["NetSalesMTDCount"].ToString();
            NetSalesTodayLabel.Text = dt.Rows[0]["NetSalesTodayCount"].ToString();
            TotalOrdersLabel.Text = dt.Rows[0]["TotalOrdersCount"].ToString();
            TotalOrdersMTDLabel.Text = dt.Rows[0]["TotalOrdersMTDCount"].ToString();
        }
    }
}
