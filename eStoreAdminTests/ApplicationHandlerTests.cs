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
using phoenixconsulting.common;
//HttpSimulator
using NUnit.Framework;
using Subtext.TestLibrary;
using phoenixconsulting.common.handlers;

namespace eStoreAdminTests {
    [TestFixture]
    public class ApplicationHandlerTests {
        [SetUp]
        public void SetUp() {
            //nothing to go here
        }

        [TearDown]
        public void TearDown() {
            //nothing to go here
        }

        [Test]
        public void CanGetSetTradingName() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.TradingName = "PetsParadise";
                Assert.AreEqual("PetsParadise", ApplicationHandler.Instance.TradingName, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetMerchantID() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.MerchantID = "ACBFDF123";
                Assert.AreEqual("ACBFDF123", ApplicationHandler.Instance.MerchantID, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetPassword() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.Password = "PetsParadise";
                Assert.AreEqual("PetsParadise", ApplicationHandler.Instance.Password, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetPaymentType() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.PaymentType = 0;
                Assert.AreEqual(0, ApplicationHandler.Instance.PaymentType, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetLiveEchoURL() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.LiveEchoURL = "https://theurl.com";
                Assert.AreEqual("https://theurl.com", ApplicationHandler.Instance.LiveEchoURL, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetTestEchoURL() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.TestEchoURL = "https://theurl.com";
                Assert.AreEqual("https://theurl.com", ApplicationHandler.Instance.TestEchoURL, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetLivePaymentURL() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.LivePaymentURL = "https://theurl.com";
                Assert.AreEqual("https://theurl.com", ApplicationHandler.Instance.LivePaymentURL, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetTestPaymentURL() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.TestPaymentURL = "https://theurl.com";
                Assert.AreEqual("https://theurl.com", ApplicationHandler.Instance.TestPaymentURL, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetLivePaymentDCURL() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.LivePaymentDCURL = "https://theurl.com";
                Assert.AreEqual("https://theurl.com", ApplicationHandler.Instance.LivePaymentDCURL, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetTestPaymentDCURL() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.TestPaymentDCURL = "https://theurl.com";
                Assert.AreEqual("https://theurl.com", ApplicationHandler.Instance.TestPaymentDCURL, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetRefundAdminFeePercent() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.RefundAdminFeePercent = 10;
                Assert.AreEqual(10, ApplicationHandler.Instance.RefundAdminFeePercent, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetCancelAdminFeePercent() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.CancelAdminFeePercent = 5;
                Assert.AreEqual(5, ApplicationHandler.Instance.CancelAdminFeePercent, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetSMTPServer() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.SMTPServer = "https://theurl.com";
                Assert.AreEqual("https://theurl.com", ApplicationHandler.Instance.SMTPServer, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetHomePageURL() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.HomePageURL = "http://theurl.com";
                Assert.AreEqual("http://theurl.com", ApplicationHandler.Instance.HomePageURL, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetAdminEmail() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.AdminEmail = "mail@mail.com.au";
                Assert.AreEqual("mail@mail.com.au", ApplicationHandler.Instance.AdminEmail, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetFromEmailAddress() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.FromEmailAddress = "mail@mail.com.au";
                Assert.AreEqual("mail@mail.com.au", ApplicationHandler.Instance.FromEmailAddress, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetSystemEmailAddress() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.SystemEmailAddress = "system@mail.com";
                Assert.AreEqual("system@mail.com", ApplicationHandler.Instance.SystemEmailAddress, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetCCAuthTarget() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.CCAuthTarget = "here.aspx?var1=2&var2=3";
                Assert.AreEqual("here.aspx?var1=2&var2=3", ApplicationHandler.Instance.CCAuthTarget, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetEncryptionPassword() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.EncryptionPassword = "something";
                Assert.AreEqual("something", ApplicationHandler.Instance.EncryptionPassword, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetManagerRoleHomePage() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.ManagerRoleHomePage = "ManageEverything.aspx";
                Assert.AreEqual("ManageEverything.aspx", ApplicationHandler.Instance.ManagerRoleHomePage, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetAdminRoleHomePage() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.AdminRoleHomePage = "ManageSomeThings";
                Assert.AreEqual("ManageSomeThings", ApplicationHandler.Instance.AdminRoleHomePage, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetStaffRoleHomePage() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.StaffRoleHomePage = "ManageSmallThings";
                Assert.AreEqual("ManageSmallThings", ApplicationHandler.Instance.StaffRoleHomePage, "Was not able to retrieve session variable.");
            }
        }

        //[Test]
        //public void CanGetSetAllowedLoginTries() {
        //    using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
        //        ApplicationHandler.Instance.AllowedLoginTries = 3;
        //        Assert.AreEqual(3, ApplicationHandler.Instance.AllowedLoginTries, "Was not able to retrieve session variable.");
        //    }
        //}

        [Test]
        public void CanGetSetEmailSalutation() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.EmailSalutation = "Hi there";
                Assert.AreEqual("Hi there", ApplicationHandler.Instance.EmailSalutation, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetEmailResponseOpening() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.EmailResponseOpening = "Thank you for your email.";
                Assert.AreEqual("Thank you for your email.", ApplicationHandler.Instance.EmailResponseOpening, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetEmailResponseClosing() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.EmailResponseClosing = "Regards,";
                Assert.AreEqual("Regards,", ApplicationHandler.Instance.EmailResponseClosing, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetRefundPaymentType() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                ApplicationHandler.Instance.RefundPaymentType = 4;
                Assert.AreEqual(4, ApplicationHandler.Instance.RefundPaymentType, "Was not able to retrieve session variable.");
            }
        }
    }
}