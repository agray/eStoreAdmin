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
using System.Web.Security;
using com.phoenixconsulting.authentication;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.handlers;
using phoenixconsulting.common.logging;
using phoenixconsulting.common.navigation;

namespace eStoreAdminWeb.Authentication {
    public partial class LoginPage : LoginBasePage {
        protected void Page_Load(object sender, EventArgs e) {}

        protected void Login_Authenticate(object sender, EventArgs e) {
            clearPreviousCookies();
            if(FormsAuthenticator.validateUser(Login.UserName, Login.Password)) {
                //Login Successful
                LoggerUtil.infoAuditLog(AuditEventType.LOGIN_SUCCESS, "eStoreAdmin", Login.UserName, null, null, null);
                FormsAuthentication.SetAuthCookie(Login.UserName, Login.RememberMeSet);
                GoTo.Instance.ReturnUrl(Login.UserName, RequestHandler.Instance.ReturnURL);
            } else {
                //Login Failed
                LoggerUtil.errorAuditLog(AuditEventType.LOGIN_FAILED, "eStoreAdmin", Login.UserName, null, null, null);
            }
        }

        private void clearPreviousCookies() {
            if(Request.Cookies["ASP.NET_SessionId"] != null) {
                buildCookie("ASP.NET_SessionId");
            }
            if(Request.Cookies["eStoreAdminAuth"] != null) {
                buildCookie("eStoreAdminAuth");
            }
        }

        private void buildCookie(string cookieName) {
            HttpCookie myCookie = new HttpCookie(cookieName);
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
        }

    }
}