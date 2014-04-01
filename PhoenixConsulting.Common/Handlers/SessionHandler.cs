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
using System.Web;
using System.Web.UI;
using phoenixconsulting.common.basepages;

namespace phoenixconsulting.common.handlers {
    public sealed class SessionHandler : HTTPScopeHandlerBase {

    #region Singleton setup
        //Singleton from http://csharpindepth.com/Articles/General/Singleton.aspx. Fifth version.
        private SessionHandler() {
        }

        public static SessionHandler Instance { get { return Nested.instance; } }

        public void SetCurrency(string code, double XRate, string id) {
            Instance.CurrencyValue = code;
            Instance.CurrencyXRate = XRate;
            Instance.Currency = id;
        }

        private class Nested {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() {
                //initialise currency
                SessionHandler.Instance.SetCurrency("AUD", 1, "1");
                //initialiseCurrency();
            }

            //private static void initialiseCurrency() {
            //    SessionHandler.Instance.CurrencyValue = "AUD";
            //    SessionHandler.Instance.CurrencyXRate = 1;
            //    SessionHandler.Instance.Currency = "1";
            //}

            internal static readonly SessionHandler instance = new SessionHandler();
        }
    #endregion

    #region Session Variable Name Constants
        //Declare a string variable to hold the key name of the session variable
        //and use this string variable instead of typing the key name
        //in order to avoid spelling mistakes
        private const string _currencyXRate = "CurrencyXRate";
        private const string _currency = "Currency";
        private const string _currencyValue = "CurrencyValue";

        private const string _ccResponseText = "ResponseText";
        private const string _ccResponseCode = "ResponseCode";
        private const string _ccApproved = "Approved";
        private const string _refundAmount = "RefundAmount";

        //Customer Login Fields
        private const string _loginFirstName = "LoginFirstName";
        private const string _loginLastName = "LoginLastName";
        private const string _loginEmail = "LoginEmail";
        private const string _loginRequireNewsletter = "LoginRequireNewsletter";

    #endregion

    #region Properties And Methods
        public double CurrencyXRate {
            get { return getDouble(SessionHandler._currencyXRate); }
            set { setDouble(SessionHandler._currencyXRate, value); }
        }

        public string Currency {
            get { return getString(SessionHandler._currency); }
            set { setString(SessionHandler._currency, value); }
        }

        public string CurrencyValue {
            get { return getString(SessionHandler._currencyValue); }
            set {
                setString(SessionHandler._currencyValue, value);
            }
        }

        public string CCResponseText {
            get { return getString(SessionHandler._ccResponseText); }
            set { setString(SessionHandler._ccResponseText, value); }
        }

        public string CCResponseCode {
            get { return getString(SessionHandler._ccResponseCode); }
            set { setString(SessionHandler._ccResponseCode, value); }
        }

        public string CCApproved {
            get { return getString(SessionHandler._ccApproved); }
            set { setString(SessionHandler._ccApproved, value); }
        }

        public double RefundAmount {
            get { return getDouble(SessionHandler._refundAmount); }
            set { setDouble(SessionHandler._refundAmount, value); }
        }

        public string LoginFirstName {
            get { return getString(SessionHandler._loginFirstName); }
            set { setString(SessionHandler._loginFirstName, value); }
        }

        public string LoginLastName {
            get { return getString(SessionHandler._loginLastName); }
            set { setString(SessionHandler._loginLastName, value); }
        }

        public string LoginEmailAddress {
            get { return getString(SessionHandler._loginEmail); }
            set { setString(SessionHandler._loginEmail, value); }
        }

        public bool LoginRequireNewsletter {
            get { return getBool(SessionHandler._loginRequireNewsletter); }
            set { setBool(SessionHandler._loginRequireNewsletter, value); }
        }
    

        //**********************************
        // NON-PROPERTY METHODS
        //**********************************
        public static void resetSession() {
            //SessionHandler.UserExists = false;
            //SessionHandler.UserID = 0;
            //WindowsIdentity.GetCurrent().Name = "";
            //SessionHandler.HasLoggedInBefore = false;
            //SessionHandler.IsRegistered = false;
            //SessionHandler.IsLockedOut = false;
        }

        public static bool isSessionTimedOut(HttpContext context, Page page) {
            if(context.Session != null) {
                if(context.Session.IsNewSession) {
                    string cookieHeader = page.Request.Headers["Cookie"];

                    if(cookieHeader != null) {
                        if(cookieHeader.ToUpper().IndexOf("ASP.NET_SESSIONID") >= 0) {
                            //On timeouts, redirect user to timeout page.
                            return true;
                        } else {
                            return false;
                        }
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }
    #endregion

    #region Convenience Methods
        private void setInt(string variableName, int val) {
            setInt(variableName, HTTPScope.SESSION, val);
        }

        private void setString(string variableName, string val) {
            setString(variableName, HTTPScope.SESSION, val);
        }

        private void setDouble(string variableName, double val) {
            setDouble(variableName, HTTPScope.SESSION, val);
        }

        private void setBool(string variableName, bool val) {
            setBool(variableName, HTTPScope.SESSION, val);
        }

        private int getInt(string variableName) {
            return getInt(variableName, HTTPScope.SESSION);
        }

        private string getString(string variableName) {
            return getString(variableName, HTTPScope.SESSION);
        }

        private double getDouble(string variableName) {
            return getDouble(variableName, HTTPScope.SESSION);
        }

        private bool getBool(string variableName) {
            return getBool(variableName, HTTPScope.APPLICATION);
        }
    #endregion
    }
}