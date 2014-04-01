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
using System.Net;
using System.Net.Mail;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.logging;
using NLog;
using phoenixconsulting.common.handlers;

namespace phoenixconsulting.common.mail {
    public class MailSender : BasePage {
        private static Logger errorLogger = LogManager.GetLogger("ErrorLogger");

        //******************************************
        // Utility Mail Sending Functions
        //******************************************

        //
        // actually send the message via SMTP
        //
        public static void SendMail(MailMessage msg) {

            try {
                SmtpClient smtp = new SmtpClient(ApplicationHandler.Instance.SMTPServer, 587); //was "iinet.net.au", 25
                smtp.EnableSsl = true;
                NetworkCredential cred = new NetworkCredential("andrew.paul.gray@gmail.com",
                                                               "Gray67^&and");

                smtp.Credentials = cred;
                smtp.Send(msg);
                LoggerUtil.infoAuditLog(AuditEventType.MAILSEND_SUCCESS,
                                        "AdminSite", null, null, null,
                                        msg.Priority + " priority message to " + msg.To + " with subject: " + msg.Subject);
            } catch(Exception ex) {
                errorLogger.Error("Unable to send mail! " + ex.Message);
                LoggerUtil.infoAuditLog(AuditEventType.MAILSEND_FAILED,
                                        "AdminSite", null, null, null,
                                        msg.Priority + " priority message to " + msg.To + " with subject: " + msg.Subject);
            } finally {
                msg = null;
            }
        }
    }
}