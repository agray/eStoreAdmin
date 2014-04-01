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
using System.Net.Mail;
using System.Web.UI;
using com.phoenixconsulting.authentication;
using phoenixconsulting.common.handlers;
using System.Web.Security;

namespace phoenixconsulting.common.mail {
    public class MailMessageBuilder : Page {
        //
        // Send password email to forgetful user
        //
        public static void SendForgottenPasswordEmail(string emailAddress, string password) {
            MailSender.SendMail(CreateMailMessageObject(false,
                                                        MailPriority.Normal,
                                                        ApplicationHandler.Instance.FromEmailAddress,
                                                        emailAddress,
                                                        ApplicationHandler.Instance.TradingName + ": Password Reminder",
                                                        ApplicationHandler.Instance.EmailSalutation +
                                                        "Your password is: " + password +
                                                        "\n\n" + ApplicationHandler.Instance.EmailResponseClosing +
                                                        ApplicationHandler.Instance.TradingName + " Team"));
        }

        //
        // Send Reply email to Customer
        //
        public static void SendCustomerEmail(string emailAddress, 
                                             string subject, 
                                             string customerName, 
                                             string replyMessage) {
            MailSender.SendMail(CreateMailMessageObject(false,
                                                        MailPriority.Normal,
                                                        ApplicationHandler.Instance.FromEmailAddress,
                                                        emailAddress,
                                                        "RE: " + subject,
                                                        ApplicationHandler.Instance.EmailSalutation + customerName + ",\n\n" +
                                                        ApplicationHandler.Instance.EmailResponseOpening +
                                                        replyMessage +
                                                        "\n\n" + ApplicationHandler.Instance.EmailResponseClosing +
                                                        ApplicationHandler.Instance.TradingName + " Team"));
        }

        //
        // Send notification email to Administrator.
        //
        public static void SendAdminEmail(string customerName, string emailAddress, string subject, string replyMessage) {
            DateTime timeNow = DateTime.Now;
            MailSender.SendMail(CreateMailMessageObject(true,
                                                        MailPriority.High,
                                                        ApplicationHandler.Instance.SystemEmailAddress,
                                                        ApplicationHandler.Instance.AdminEmail,
                                                        "Attempted send of UNACCEPTABLE reply",
                                                        "<html><body>The following unacceptable reply was attempted by <font color='red'>" +
                                                        FormsAuthenticator.getUser().UserName + "</font>:" +
                                                        "<br/><br/><b>Date</b>: " + timeNow.ToLongDateString() +
                                                        "<br/><b>Time</b>: " + timeNow.ToLongTimeString() +
                                                        "<br/><b>Customer Name</b>: " + customerName +
                                                        "<br/><b>Customer's Email Address</b>: " + emailAddress +
                                                        "<br/><b>Subject</b>: " + subject +
                                                        "<br/><b>Email Body</b>:<br/>" + replyMessage + "</body></html>"));
        }

        //
        // Create a New User email object and send
        //
        public static void SendNewUserEmail(string email, string username, string password, string url) {
            MailSender.SendMail(CreateMailMessageObject(false,
                                                        MailPriority.Normal,
                                                        ApplicationHandler.Instance.FromEmailAddress,
                                                        email,
                                                        ApplicationHandler.Instance.TradingName + ": New User Notification",
                                                        ApplicationHandler.Instance.EmailSalutation +
                                                        "A new account has been created for you at " +
                                                        url + "\n\n" +
                                                        "Your login details are:\n\n" +
                                                        "Username: " + username + "\n" +
                                                        "Password: " + password + "\n\n" +
                                                        ApplicationHandler.Instance.EmailResponseClosing +
                                                        ApplicationHandler.Instance.TradingName + " Team"));
        }

        //
        // Create a Exception email object and send
        //
        public static void SendExceptionEmail(Exception ex) {
            MembershipUser user = FormsAuthenticator.getUser();
            string body = "<html><body>" +
                          "<b>Type:</b> " + ex.GetType() + "<br/><br/>" +
                          "<b>Message:</b> " + ex.Message + "<br/><br/>" +
                          "<b>Source:</b> " + ex.Source + "<br/><br/>" +
                          "<b>Method:</b> " + ex.TargetSite + "<br/><br/>" +
                          "<b>InnerException:</b> " + ex.InnerException + "<br/><br/>" +
                          "<b>Exception String:</b> <pre>" + ex.ToString() + "</pre>" +
                          "<b>Session Dump</b><br/>" +
                          "<i>User Name: </i>" +
                          user == null ? "" : user.UserName + 
                          "<br/>" +
                          "<i>User Role: </i>" + FormsAuthenticator.getRolesAsCSV() + "<br/>" +
                          "<i>Last Login: </i>" +
                          user == null ? "" : user.LastLoginDate + 
                          "<br/>" +
                          "<i>Is Locked Out: </i>" +
                          user == null ? "" : user.IsLockedOut + 
                          "<br/>" +
                          "</body></html>";
            MailSender.SendMail(CreateMailMessageObject(true,
                                                        MailPriority.High,
                                                        ApplicationHandler.Instance.SystemEmailAddress,
                                                        ApplicationHandler.Instance.SupportEmail,
                                                        "Exception occurred in Administration Website",
                                                        body));
        }
        
        //
        // Construct MailMessage object
        //
        private static MailMessage CreateMailMessageObject(bool isHtml, MailPriority priority, string from, string to, string subject, string body) {
            MailMessage oMsg = new MailMessage();

            oMsg.IsBodyHtml = isHtml;

            oMsg.From = new MailAddress(from);
            oMsg.To.Add(to);
            oMsg.Subject = subject;
            oMsg.Body = body;
            oMsg.Priority = priority;
            return oMsg;
        }
    }
}