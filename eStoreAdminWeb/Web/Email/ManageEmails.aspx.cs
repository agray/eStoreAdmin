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
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Security.Principal;
using System.Web.UI.WebControls;
using eStoreAdminBLL;
using eStoreAdminDAL;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.mail;
using phoenixconsulting.common.logging;

namespace eStoreAdminWeb {
    partial class ManageEmails : BasePage {
        private EmailBLL _emailAdapter;
        private BadWordBLL _wordAdapter;

        protected EmailBLL EmailAdapter {
            get { return _emailAdapter ?? (_emailAdapter = new EmailBLL()); }
        }

        protected BadWordBLL WordAdapter {
            get { return _wordAdapter ?? (_wordAdapter = new BadWordBLL()); }
        }

        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider")]
        protected void SendReply(object sender, EventArgs e) {
            setErrorMessage("");

            if(IsMessageValid()) {
                //Send Customer Email
                logger.Debug("Sending customer reply email...");
                MailMessageBuilder.SendCustomerEmail(getEmailAddress(), getSubject(), getCustomerName(), getReplyMessage());
                EmailAdapter.UpdateEmail(Int32.Parse(((Button)sender).CommandArgument), getReplyMessage());
                EmailFormView.FindControl("ReplySentLabel").Visible = true;
            } else {
                //Send notification email to Administrator.
                logger.Debug("User " + WindowsIdentity.GetCurrent().Name + "used bad words, sending email to administrator...");
                MailMessageBuilder.SendAdminEmail(getCustomerName(), getEmailAddress(), getSubject(), getReplyMessage());
                setErrorMessage("Message contents are invalid, please edit before sending.");

            }
        }

        protected bool IsMessageValid() {
            DAL.BadWordDataTable wordsDataTable = new DAL.BadWordDataTable();

            wordsDataTable = WordAdapter.GetBadWords();

            foreach(DAL.BadWordRow wordRow in wordsDataTable) {
                if(getReplyMessage().ToLower().IndexOf(wordRow.BadWord) != -1) {
                    return false;
                }
            }

            return true;
        }

        private string getCustomerName() {
            Label customerName = (Label)EmailFormView.FindControl("CustomerNameLabel");
            return customerName.Text;
        }

        private string getEmailAddress() {
            Label emailAddress = (Label)EmailFormView.FindControl("EmailAddressLabel");
            return emailAddress.Text;
        }

        private string getSubject() {
            Label subject = (Label)EmailFormView.FindControl("SubjectLabel");
            return subject.Text;
        }

        private string getReplyMessage() {
            TextBox replyMessage = (TextBox)EmailFormView.FindControl("ReplyMessageTextBox");
            return replyMessage.Text;
        }

        private void setErrorMessage(string message) {
            Label errorMessage = (Label)EmailFormView.FindControl("ErrorMessage");
            errorMessage.Text = message;
            errorMessage.ForeColor = Color.Red;
        }
    }
}