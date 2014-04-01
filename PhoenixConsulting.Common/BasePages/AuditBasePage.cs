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
using System.IO;
using com.phoenixconsulting.npoi;
using phoenixconsulting.common.logging;

namespace phoenixconsulting.common.basepages {
    public class AuditBasePage : BasePage {
        private const string SITE = "AdminSite";

        protected void logInfo(AuditEventType eventType, string newValue, string oldValue, string details) {
            LoggerUtil.infoAuditLog(eventType, SITE, newValue, oldValue, null, details);
        }

        protected void logError(AuditEventType eventType, string newValue, string oldValue, string errorMessage, string details) {
            LoggerUtil.errorAuditLog(eventType, SITE, newValue, oldValue, errorMessage, details);
        }

        protected void logDebug(AuditEventType eventType, string newValue, string oldValue, string details) {
            LoggerUtil.debugAuditLog(eventType, SITE, newValue, oldValue, null, details);
        }

        protected void logFatal(AuditEventType eventType, string newValue, string oldValue, string errorMessage, string details) {
            LoggerUtil.fatalAuditLog(eventType, SITE, newValue, oldValue, null, details);
        }

        protected void exportData(NPOIWriter writer, AuditEventType auditEventType) {
            logger.Debug("Created {0}. Exporting file.", writer.GetType());
            MemoryStream stream = writer.write(mappedRootPath);

            logger.Debug(auditEventType + " file exported successfully.");
            logInfo(auditEventType, null, null, null);

            exportToExcel(writer.getFilename(), stream);
        }

        public void exportToExcel(string filename, MemoryStream stream) {
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", filename));
            Response.Clear();
            Response.BinaryWrite(stream.GetBuffer());
            Response.End();
        }
    }
}
