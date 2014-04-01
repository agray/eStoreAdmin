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
using System.Web.UI;
using System.Web.UI.WebControls;
using eStoreAdminBLL;
using eStoreAdminDAL;
using eStoreAdminWeb.Controls;
using NLog;
using phoenixconsulting.common.handlers;

namespace eStoreAdminWeb {
    public partial class MerchandiseMaster : MasterPage {
        private static Logger logger = LogManager.GetLogger("TraceFileAndEventLogger");
        public bool ShowScriptManager { get; set; }

        public delegate void CurrencyChangedEventHandler(object sender, CurrencyChangedEventArgs e);
        public event CurrencyChangedEventHandler CurrencyChanged;

        protected virtual void OnCurrencyChanged(CurrencyChangedEventArgs e) {
            DropDownList ddl = (DropDownList)currencyDDL.FindControl("CurrencyDropDownList");
            DAL.CurrencyRow row = getCurrencyById(int.Parse(ddl.SelectedValue));
            SessionHandler.Instance.SetCurrency(row.Value, row.ExchangeRate, row.ID.ToString());

            if(CurrencyChanged != null) {
                CurrencyChanged(this, e);
            }
        }

        public DAL.CurrencyRow getCurrencyById(int id) {
            CurrenciesBLL currTableAdapter = new CurrenciesBLL();
            return currTableAdapter.GetCurrencyById(id)[0];
        }
        
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly")]
        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider")]
        protected void currencyDDL_IndexChanged(object sender, EventArgs e) {
            OnCurrencyChanged((CurrencyChangedEventArgs)e);
        }

        protected void Page_Init(object sender, EventArgs e) {
            if(!IsPostBack) {
                ShowScriptManager = true;
            }
            if(Page.IsPostBack) {
                CurrencyDDL currencyDDL = (CurrencyDDL)FindControl("currencyDDL");
                currencyDDL.IndexChanged += new IndexChangedEventHandler(currencyDDL_IndexChanged);
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                ScriptManager1.Visible = ShowScriptManager;
                currencyDDL.Text = SessionHandler.Instance.Currency;
            }
            MasterUpdatePanel.Update();
        }
    }
}