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
//HttpSimulator
using NUnit.Framework;
using Subtext.TestLibrary;
using phoenixconsulting.common.handlers;

namespace eStoreAdminTests {
    [TestFixture]
    public class SessionHandlerTests {
        [SetUp]
        public void SetUp() {
            //nothing to go here
        }

        [TearDown]
        public void TearDown() {
            //nothing to go here
        }   

        [Test]
        public void CanGetSetCCResponseText() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                SessionHandler.Instance.CCResponseText = "Approved";
                Assert.AreEqual("Approved", SessionHandler.Instance.CCResponseText, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetCCResponseCode() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                SessionHandler.Instance.CCResponseCode = "00";
                Assert.AreEqual("00", SessionHandler.Instance.CCResponseCode, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetCCApproved() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                SessionHandler.Instance.CCApproved = "Yes";
                Assert.AreEqual("Yes", SessionHandler.Instance.CCApproved, "Was not able to retrieve session variable.");
            }
        }

        [Test]
        public void CanGetSetRefundAmount() {
            using(new HttpSimulator("/", "c:\\inetpub\\").SimulateRequest()) {
                SessionHandler.Instance.RefundAmount = 10.25;
                Assert.AreEqual(10.25, SessionHandler.Instance.RefundAmount, "Was not able to retrieve session variable.");
            }
        }

    }
}