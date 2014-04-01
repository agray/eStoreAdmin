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
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using eStoreAdminBLL;
using eStoreAdminDAL;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.logging;
using phoenixconsulting.common.navigation;

namespace eStoreAdminWeb.Web.Advanced {
    partial class ManageCurrencies : AuditBasePage {
        private string[] fieldNames = {"Name", "Value", "Exchange Rate"};

        protected void Page_Load(object sender, EventArgs e) {
            if(!Page.IsPostBack) {
                if(!IsUpToDate()) {
                    UpdateCurrencies();
                }
            }
        }

        public void UpdateCurrencies() {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eStoreAdminConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();

            logger.Debug("Attempting to call DB job to update currencies...");

            // Call SSIS Package
            string sql = "exec msdb.dbo.sp_start_job N'UpdateExchangeRates'";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            connection.Close();

            logger.Debug("Completed call to DB job to update currencies.");

            GoTo.Instance.UpdatingCurrenciesPage();
        }

        protected void CurrencyDetails_ItemDeleted(object sender, FormViewDeletedEventArgs e) {
            logger.Debug(LoggerUtil.getText(fieldNames, e, "Currency"));
            CurrenciesGridView.DataBind();
            logInfo(AuditEventType.CURRENCY_DELETED, null, e.Values[0].ToString(), null);
            if(CurrenciesGridView.Rows.Count == 0) {
                GoTo.Instance.ManageCurrenciesPage();
            }
        }

        protected void CurrencyDetails_ItemInserted(object sender, FormViewInsertedEventArgs e) {
            logger.Debug(LoggerUtil.getText(fieldNames, e, "Currency"));
            CurrenciesGridView.DataBind();
            logInfo(AuditEventType.CURRENCY_ADDED, e.Values[0].ToString(), null, null);
            CurrencyDetails.DefaultMode = FormViewMode.ReadOnly;
        }

        protected void CurrencyDetails_ItemUpdated(object sender, FormViewUpdatedEventArgs e) {
            logger.Debug(LoggerUtil.getText(fieldNames, e, "Currency"));
            CurrenciesGridView.DataBind();
            logInfo(AuditEventType.CURRENCY_UPDATED, e.NewValues[0].ToString(), e.OldValues[0].ToString(), null);
        }

        protected void CurrenciesGridView_DataBound(object sender, EventArgs e) {
            CurrencyDetails.DefaultMode = CurrenciesGridView.Rows.Count == 0 ? FormViewMode.Insert : FormViewMode.ReadOnly;
        }

        public bool IsUpToDate() {
            CurrenciesBLL currTableAdapter = new CurrenciesBLL();
            DAL.CurrencyDataTable currDataTable = currTableAdapter.GetCurrencies();

            foreach(DAL.CurrencyRow currRow in currDataTable) {
                if(currRow.ID == 1) {
                    //Australia - don't care.
                    continue;
                }
                if(!currRow.IsNull("LastUpdated")) {
                    TimeSpan ts = DateTime.Now - currRow.LastUpdated;
                    if(ts.Days >= 1 || ts.Hours > 6) {
                        logger.Debug("Currencies out of date.");
                        return false;
                    }
                }
            }
            logger.Debug("Currencies up to date.");
            return true;
        }
    }
}