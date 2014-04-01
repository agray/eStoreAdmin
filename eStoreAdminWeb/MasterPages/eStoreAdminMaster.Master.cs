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
using eStoreAdminBLL;
using eStoreAdminDAL;
using NLog;

namespace eStoreAdminWeb {
    public partial class eStoreAdminMaster : MasterPage {
        private static Logger logger = LogManager.GetLogger("TraceFileAndEventLogger");

        public bool ShowScriptManager { get; set; }

        protected void Page_Init(object sender, EventArgs e) {
            if(!IsPostBack) {
                ShowScriptManager = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                ScriptManager1.Visible = ShowScriptManager;
            }
            //HomePageHyperlink.Text = ApplicationHandler.HomePageURL;
        }

        public static bool IsUpToDate() {
            CurrenciesBLL currTableAdapter = new CurrenciesBLL();
            DAL.CurrencyDataTable currDataTable = currTableAdapter.GetCurrencies();
            logger.Debug("Checking currencies are up to date...");

            foreach (DAL.CurrencyRow currRow in currDataTable) {
                if (!currRow.IsNull("LastUpdated")) {
                    TimeSpan ts = DateTime.Now - currRow.LastUpdated;
                    if (ts.Hours > 6) {
                        logger.Debug(currRow["Name"] + " is out of date, need to refresh from Internet.");
                        return false;
                    }
                }
            }
            logger.Debug("All currencies already up to date.");
            return true;
        }
    }
}