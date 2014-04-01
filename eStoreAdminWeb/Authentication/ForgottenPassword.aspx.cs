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
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.logging;

namespace eStoreAdminWeb.Authentication {
    public partial class ForgottenPassword : LoginBasePage {
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void Cancel_Click(object sender, EventArgs e) {
        }

        protected void PasswordRecovery1_AnswerLookupError(object sender, EventArgs e) {
            logInfo(AuditEventType.USER_PASSWORD_RECOVERED_FAILURE, null, null, "Answer Lookup Error");
        }

        protected void PasswordRecovery1_SendMailError(object sender, EventArgs e) {
            logInfo(AuditEventType.USER_PASSWORD_RECOVERED_FAILURE, null, null, "Send Mail Error");
        }

        protected void PasswordRecovery1_UserLookupError(object sender, EventArgs e) {
            logInfo(AuditEventType.USER_PASSWORD_RECOVERED_FAILURE, null, null, "User Lookup Error");
        }

        protected void PasswordRecovery1_SendingMail(object sender, EventArgs e) {
            logInfo(AuditEventType.USER_PASSWORD_RECOVERED_SUCCESS, null, null, "Sending Mail");
        }
    }
}