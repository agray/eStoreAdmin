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
using CrystalDecisions.CrystalReports.Engine;
using phoenixconsulting.common.handlers;
using phoenixconsulting.common.navigation;

namespace phoenixconsulting.common.basepages {
    public class ReportBasePage : BasePage {
        protected ReportDocument cr;

        protected void Page_PreInit(object sender, EventArgs e) {
            MasterPageFile = Pages.REPORT_MASTER;
        }

        protected void configureReport(string reportFilename) {
            cr = new ReportDocument();
            string RptName = Server.MapPath(".\\Reports\\" + reportFilename);
            cr.Load(RptName);
        }

        protected void configureLogin() {
            cr.SetDatabaseLogon(ApplicationHandler.Instance.DBUserID, ApplicationHandler.Instance.DBPassword);
            //ConnectionInfo myConnectionInfo = new ConnectionInfo();

            //myConnectionInfo.ServerName = ApplicationHandler.Instance.ServerName;
            //myConnectionInfo.DatabaseName = ApplicationHandler.Instance.DBName;
            //myConnectionInfo.UserID = ApplicationHandler.Instance.DBUserID;
            //myConnectionInfo.Password = ApplicationHandler.Instance.DBPassword;
            //return myConnectionInfo;
        }

        //protected void setLogon(ConnectionInfo myconnectioninfo, CrystalReportViewer crv) {
        //    TableLogOnInfos mytableloginfos = new TableLogOnInfos();
        //    mytableloginfos = crv.LogOnInfo;
        //    foreach(TableLogOnInfo myTableLogOnInfo in mytableloginfos) {
        //        myTableLogOnInfo.ConnectionInfo = myconnectioninfo;
        //    }
        //}

        public static DataSet getDataSet(DataTable dt) {
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }
    }
}