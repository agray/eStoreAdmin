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
using phoenixconsulting.common.basepages;

namespace phoenixconsulting.common.handlers {
    public sealed class ApplicationHandler : HTTPScopeHandlerBase {

    #region Singleton setup
        //Singleton from http://csharpindepth.com/Articles/General/Singleton.aspx. Fifth version.
        private ApplicationHandler() {
        }

        public static ApplicationHandler Instance { get { return Nested.instance; } }

        private class Nested {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() {
                //Initialisation of the instance can go here
            }

            internal static readonly ApplicationHandler instance = new ApplicationHandler();
        }
    #endregion

    #region Application Variable Name Constants
        //Declare a string variable to hold the key name of the application variable
        //and use this string variable instead of typing the key name
        //in order to avoid spelling mistakes
        private const string _tradingName = "TradingName";

        //General
        private const string _merchantID = "MerchantID";
        private const string _password = "Password";
        private const string _paymentType = "PaymentType";
        private const string _liveEchoURL = "LiveEchoURL";
        private const string _testEchoURL = "TestEchoURL";
        private const string _livePaymentURL = "LivePaymentURL";
        private const string _testPaymentURL = "TestPaymentURL";
        private const string _livePaymentDCURL = "LivePaymentDCURL";
        private const string _testPaymentDCURL = "TestPaymentDCURL";
        private const string _CCProcessorRequestType = "CCRequestType";
        private const string _CCProcessorServer = "CCServer";
        private const string _refundAdminFeePercent = "RefundAdminFeePercent";
        private const string _cancelAdminFeePercent = "CancelAdminFeePercent";
        private const string _smtpServer = "SMTPServer";
        private const string _homePageURL = "HomePageURL";
        private const string _adminEmail = "AdminEmail";
        private const string _fromEmailAddress = "FromEmailAddress";
        private const string _systemEmailAddress = "SystemEmailAddress";
        private const string _ccAuthTarget = "CCAuthTarget";
        private const string _encryptionPassword = "EncryptionPassword";
        private const string _managerRoleHomePage = "ManagerRoleHomePage";
        private const string _adminRoleHomePage = "AdminRoleHomePage";
        private const string _staffRoleHomePage = "StaffRoleHomePage";
        private const string _emailSalutation = "EmailSalutation";
        private const string _emailResponseOpening = "EmailResponseOpening";
        private const string _emailResponseClosing = "EmailResponseClosing";
        private const string _refundPaymentType = "RefundPaymentType";
        private const string _supportEmail = "SupportEmail";
        private const string _paypalVersion = "PaypalVersion";
        private const string _paypalAPIUsername = "PaypalAPIUsername";
        private const string _paypalAPIPassword = "PaypalAPIPassword";
        private const string _paypalAPISignature = "PaypalAPISignature";
        private const string _paypalAPIURL = "PaypalAPIURL";
        private const string _masterPage = "MasterPagePath";

        //Local Database Details
        private const string _serverName = "ServerName";
        private const string _dbName = "DBName";
        private const string _dbUserID = "DBUserID";
        private const string _dbPassword = "DBPassword";

   #endregion

    #region Properties
        public string TradingName {
            get { return getString(_tradingName); }
            set { setString(_tradingName, value); }
        }

        public string MerchantID {
            get { return getString(_merchantID); }
            set { setString(_merchantID, value); }
        }

        public string Password {
            get { return getString(_password); }
            set { setString(_password, value); }
        }

        public int PaymentType {
            get { return getInt(_paymentType); }
            set { setInt(_paymentType, value); }
        }

        public string LiveEchoURL {
            get { return getString(_liveEchoURL); }
            set { setString(_liveEchoURL, value); }
        }

        public string TestEchoURL {
            get { return getString(_testEchoURL); }
            set { setString(_testEchoURL, value); }
        }

        public string LivePaymentURL {
            get { return getString(_livePaymentURL); }
            set { setString(_livePaymentURL, value); }
        }

        public string TestPaymentURL {
            get { return getString(_testPaymentURL); }
            set { setString(_testPaymentURL, value); }
        }

        public string LivePaymentDCURL {
            get { return getString(_livePaymentDCURL); }
            set { setString(_livePaymentDCURL, value); }
        }

        public string TestPaymentDCURL {
            get { return getString(_testPaymentDCURL); }
            set { setString(_testPaymentDCURL, value); }
        }

        public string CCProcessorRequestType {
            get { return getString(_CCProcessorRequestType); }
            set { setString(_CCProcessorRequestType, value); }
        }

        public string CCProcessorServer {
            get { return getString(_CCProcessorServer); }
            set { setString(_CCProcessorServer, value); }
        }

        public double RefundAdminFeePercent {
            get { return getDouble(_refundAdminFeePercent); }
            set { setDouble(_refundAdminFeePercent, value); }
        }

        public double CancelAdminFeePercent {
            get { return getDouble(_cancelAdminFeePercent); }
            set { setDouble(_cancelAdminFeePercent, value); }
        }

        public string SMTPServer {
            get { return getString(_smtpServer); }
            set { setString(_smtpServer, value); }
        }

        public string HomePageURL {
            get { return getString(_homePageURL); }
            set { setString(_homePageURL, value); }
        }

        public string AdminEmail {
            get { return getString(_adminEmail); }
            set { setString(_adminEmail, value); }
        }

        public string FromEmailAddress {
            get { return getString(_fromEmailAddress); }
            set { setString(_fromEmailAddress, value); }
        }

        public string SystemEmailAddress {
            get { return getString(_systemEmailAddress); }
            set { setString(_systemEmailAddress, value); }
        }

        public string CCAuthTarget {
            get { return getString(_ccAuthTarget); }
            set { setString(_ccAuthTarget, value); }
        }

        public string EncryptionPassword {
            get { return getString(_encryptionPassword); }
            set { setString(_encryptionPassword, value); }
        }

        public string ManagerRoleHomePage {
            get { return getString(_managerRoleHomePage); }
            set { setString(_managerRoleHomePage, value); }
        }

        public string AdminRoleHomePage {
            get { return getString(_adminRoleHomePage); }
            set { setString(_adminRoleHomePage, value); }
        }

        public string StaffRoleHomePage {
            get { return getString(_staffRoleHomePage); }
            set { setString(_staffRoleHomePage, value); }
        }

        //public int AllowedLoginTries {
        //    get { return getInt(_allowedLoginTries); }
        //    set { HttpContext.Current.Application[_allowedLoginTries] = value; }
        //}

        public string EmailSalutation {
            get { return getString(_emailSalutation); }
            set { setString(_emailSalutation, value); }
        }

        public string EmailResponseOpening {
            get { return getString(_emailResponseOpening); }
            set { setString(_emailResponseOpening, value); }
        }

        public string EmailResponseClosing {
            get { return getString(_emailResponseClosing); }
            set { setString(_emailResponseClosing, value); }
        }

        public int RefundPaymentType {
            get { return getInt(_refundPaymentType); }
            set { setInt(_refundPaymentType, value); }
        }

        public string SupportEmail {
            get { return getString(_supportEmail); }
            set { setString(_supportEmail, value); }
        }

        public string PaypalVersion {
            get { return getString(_paypalVersion); }
            set { setString(_paypalVersion, value); }
        }

        //public string PaypalUsername {
        //    get { return getString(_paypalUsername); }
        //    set { HttpContext.Current.Application[_paypalUsername] = value; }
        //}

        //public string PaypalPassword {
        //    get { return getString(_paypalPassword); }
        //    set { HttpContext.Current.Application[_paypalPassword] = value; }
        //}

        //public string PaypalSignature {
        //    get { return getString(_paypalSignature); }
        //    set { HttpContext.Current.Application[_paypalSignature] = value; }
        //}

        public string PaypalAPIUsername {
            get { return getString(_paypalAPIUsername); }
            set { setString(_paypalAPIUsername, value); }
        }

        public string PaypalAPIPassword {
            get { return getString(_paypalAPIPassword); }
            set { setString(_paypalAPIPassword, value); }
        }

        public string PaypalAPISignature {
            get { return getString(_paypalAPISignature); }
            set { setString(_paypalAPISignature, value); }
        }

        public string PaypalAPIURL {
            get { return getString(_paypalAPIURL); }
            set { setString(_paypalAPIURL, value); }
        }

        public string ServerName {
            get { return getString(_serverName); }
            set { setString(_serverName, value); }
        }

        public string DBName {
            get { return getString(_dbName); }
            set { setString(_dbName, value); }
        }

        public string DBUserID {
            get { return getString(_dbUserID); }
            set { setString(_dbUserID, value); }
        }

        public string DBPassword {
            get { return getString(_dbPassword); }
            set { setString(_dbPassword, value); }
        }

        public string MasterPage {
            get { return getString(_masterPage); }
            set { setString(_masterPage, value); }
        }
    #endregion

    #region Convenience Methods
        private void setInt(string variableName, int val) {
            setInt(variableName, HTTPScope.APPLICATION, val);
        }

        private void setString(string variableName, string val) {
            setString(variableName, HTTPScope.APPLICATION, val);
        }

        private void setDouble(string variableName, double val) {
            setDouble(variableName, HTTPScope.APPLICATION, val);
        }

        private int getInt(string variableName) {
            return getInt(variableName, HTTPScope.APPLICATION);
        }

        private string getString(string variableName) {
            return getString(variableName, HTTPScope.APPLICATION);
        }

        private double getDouble(string variableName) {
            return getDouble(variableName, HTTPScope.APPLICATION);
        }
    #endregion
    }
}