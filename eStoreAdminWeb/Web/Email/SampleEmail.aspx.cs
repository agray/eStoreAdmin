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
using System.Web.UI;
using phoenixconsulting.common.handlers;

namespace eStoreAdminWeb {
    public partial class SampleEmail : Page {

        public delegate void PageLoaded(object sender, PageLoadedEventArgs e);

        public SampleEmail() {
            PageLoaded pl = new PageLoaded(OnPageLoaded);
        }

        public void OnPageLoaded(object sender, PageLoadedEventArgs e) {
            setSalutation();
            setCustomerName("Customer Name");
            setOpening();
            setClosing();
            setTradingName();
        }

        private void setSalutation() {
            EmailSalutationLabel.Text = ApplicationHandler.Instance.EmailSalutation;
        }

        private void setCustomerName(string customerName) {
            CustomerNameLabel.Text = customerName;
        }

        private void setOpening() {
            OpeningLabel.Text = ApplicationHandler.Instance.EmailResponseOpening;
        }

        private void setClosing() {
            ClosingLabel.Text = ApplicationHandler.Instance.EmailResponseClosing;
        }

        private void setTradingName() {
            TradingNameLabel.Text = ApplicationHandler.Instance.TradingName + " Team";
        }
    }
}