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
using phoenixconsulting.common.basepages;
using eStoreAdminWeb.Web.Reporting.TableAdapters;
using eStoreAdminWeb.Web.Reporting.TableAdapters.InventoryDataTableAdapters;

namespace eStoreAdminWeb.Web.Reporting {
    public partial class InventoryReOrder : ReportBasePage {
        private InventoryDataTableAdapter _inventoryDataAdapter = null;

        protected InventoryDataTableAdapter InventoryAdapter {
            get { return _inventoryDataAdapter ?? (_inventoryDataAdapter = new InventoryDataTableAdapter()); }
        }

        protected void Page_Init(object sender, EventArgs e) {
            base.configureReport("InventoryReorder.rpt");
            specialiseReport();
            base.configureLogin();
        }

        protected void Page_Load(object sender, EventArgs e) {
        }

        private void specialiseReport() {
            cr.SetDataSource(getDataSet((InventoryData.InventoryDataDataTable)InventoryAdapter.GetInventoryReOrder()));
            CrystalReportViewer1.ReportSource = cr;
        }
    }
}