﻿#region Licence
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
using eStoreAdminWeb.Web.Reporting.TableAdapters.CustomerAccountTableAdapters;
using phoenixconsulting.common.basepages;

namespace eStoreAdminWeb.Web.Reporting {
    public partial class Accounts : ReportBasePage {
        private CustomerAccountTableAdapter _customerAccountAdapter = null;

        protected CustomerAccountTableAdapter customerAccountAdapter {
            get { return _customerAccountAdapter ?? (_customerAccountAdapter = new CustomerAccountTableAdapter()); }
        }

        protected void Page_Init(object sender, EventArgs e) {
            configureReport("CustomerAccount.rpt");
            configureLogin();
            specialiseReport();
        }

        private void specialiseReport() {
            DataSet d = getDataSet(customerAccountAdapter.GetUsers("eStore"));
            cr.SetDataSource(d);
            CrystalReportViewer1.ReportSource = cr;
        }
    }
}