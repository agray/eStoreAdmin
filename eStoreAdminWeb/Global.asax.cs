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
using System.Web;
using eStoreAdminBLL;
using eStoreAdminDAL;
using phoenixconsulting.common.handlers;
using phoenixconsulting.common.logging;
using phoenixconsulting.common.mail;

namespace eStoreAdminWeb {
    public class Global : HttpApplication {
        //protected void Session_Start(Object sender, EventArgs e) {
        //     //Fires when the session is started
        //    HttpCookie cookie = Response.Cookies["ASP.NET_SessionId"];

        //    if(cookie != null) {
        //        cookie.Path = Request.ApplicationPath.ToLower();
        //    }
        //}

        protected void Session_End(object sender, EventArgs e) {
            try {
                string primer = SessionHandler.Instance.Currency;
                SessionHandler.Instance.SetCurrency("AUD", 1, "1");
                //SessionHandler.UserRole = "";
                //SessionHandler.UserExists = false;
                //SessionHandler.HasLoggedInBefore = false;
                //SessionHandler.IsRegistered = false;
                //SessionHandler.IsLockedOut = true;
                //SessionHandler.UnsuccessfulLoginCount = 0;
                //SessionHandler.UserID = 0;
                //WindowsIdentity.GetCurrent().Name = "";
            } catch(NullReferenceException) {
                //swallow it.
            }
        }

        protected void Application_Start(object sender, EventArgs e) {
            // Route to our own internal handler
            //App.OnApplicationStart();

            //SessionHandler.Instance.SetCurrency("AUD", 1, "1");

            SettingsBLL settings = new SettingsBLL();
            DAL.SettingsDataTable dt;
            dt = settings.GetSettingsEverything();

            try {
                ApplicationHandler.Instance.TradingName = getValue(dt, 0);
                ApplicationHandler.Instance.MerchantID = getValue(dt, 1);
                ApplicationHandler.Instance.Password = getValue(dt, 2);
                ApplicationHandler.Instance.PaymentType = int.Parse(getValue(dt, 3));
                ApplicationHandler.Instance.LiveEchoURL = getValue(dt, 4);
                ApplicationHandler.Instance.TestEchoURL = getValue(dt, 5);
                ApplicationHandler.Instance.LivePaymentURL = getValue(dt, 6);
                ApplicationHandler.Instance.TestPaymentURL = getValue(dt, 7);
                ApplicationHandler.Instance.LivePaymentDCURL = getValue(dt, 8);
                ApplicationHandler.Instance.TestPaymentDCURL = getValue(dt, 9);
                ApplicationHandler.Instance.CCProcessorRequestType = getValue(dt, 10);
                ApplicationHandler.Instance.CCProcessorServer = getValue(dt, 11);
                ApplicationHandler.Instance.RefundAdminFeePercent = double.Parse(getValue(dt, 12));
                ApplicationHandler.Instance.CancelAdminFeePercent = double.Parse(getValue(dt, 13));
                ApplicationHandler.Instance.SMTPServer = getValue(dt, 14);
                ApplicationHandler.Instance.HomePageURL = getValue(dt, 15);
                ApplicationHandler.Instance.AdminEmail = getValue(dt, 16);
                ApplicationHandler.Instance.FromEmailAddress = getValue(dt, 17);
                ApplicationHandler.Instance.SystemEmailAddress = getValue(dt, 18);
                ApplicationHandler.Instance.CCAuthTarget = getValue(dt, 19);
                ApplicationHandler.Instance.EncryptionPassword = getValue(dt, 20);
                ApplicationHandler.Instance.ManagerRoleHomePage = getValue(dt, 21);
                ApplicationHandler.Instance.AdminRoleHomePage = getValue(dt, 22);
                ApplicationHandler.Instance.StaffRoleHomePage = getValue(dt, 23);
                //ApplicationHandler.Instance.AllowedLoginTries = int.Parse(dt.Rows[22]["Value"].ToString());
                ApplicationHandler.Instance.EmailSalutation = getValue(dt, 25);
                ApplicationHandler.Instance.EmailResponseOpening = getValue(dt, 26);
                ApplicationHandler.Instance.EmailResponseClosing = getValue(dt, 27);
                ApplicationHandler.Instance.SupportEmail = getValue(dt, 29);
                ApplicationHandler.Instance.ServerName = getValue(dt, 37);
                ApplicationHandler.Instance.DBName = getValue(dt, 38);
                ApplicationHandler.Instance.DBUserID = getValue(dt, 39);
                ApplicationHandler.Instance.DBPassword = getValue(dt, 40);
                ApplicationHandler.Instance.MasterPage = getValue(dt, 41);
            } finally {
                settings = null;
                dt = null;
            }
        }

        private string getValue(DAL.SettingsDataTable dt, int row) {
            return dt.Rows[row]["Value"].ToString();
        }

        //public override string GetVaryByCustomString(HttpContext context, string custom) {
        //    if(custom == "GZIP") {
        //        if(PhoenixConsulting.Utilities.WebUtils.WebUtils.IsGZipSupported())
        //            return "GZip";
        //        return "";
        //    }

        //    return base.GetVaryByCustomString(context, custom);
        //}

        protected void Application_Error() {
            Exception lastException = Server.GetLastError().GetBaseException();
            LoggerUtil.logError(lastException.ToString());
            MailMessageBuilder.SendExceptionEmail(lastException);
        }
    }
}