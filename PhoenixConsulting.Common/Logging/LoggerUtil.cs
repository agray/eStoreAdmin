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
using System.Security.Principal;
using System.Text;
using System.Web.UI.WebControls;
using NLog;
using phoenixconsulting.common.basepages;

namespace phoenixconsulting.common.logging {
    public class LoggerUtil : BasePage {
        private static Logger auditLogger = LogManager.GetLogger("AuditLogger");
        private static Logger errorLogger = LogManager.GetLogger("ErrorLogger");

        public static void logError(string msg){
            errorLogger.Error(msg);
        }

        public static void infoAuditLog(AuditEventType eventType,
                                        string site,
                                        string newValue,
                                        string oldValue,
                                        string errorMessage,
                                        string details) {
            auditLog(LogLevel.Info, eventType, site, newValue, oldValue, errorMessage, details);
        }

        public static void errorAuditLog(AuditEventType eventType,
                                         string site,
                                         string newValue,
                                         string oldValue,
                                         string errorMessage,
                                         string details) {
            auditLog(LogLevel.Error, eventType, site, newValue, oldValue, errorMessage, details);
        }

        public static void fatalAuditLog(AuditEventType eventType,
                                         string site,
                                         string newValue,
                                         string oldValue,
                                         string errorMessage,
                                         string details) {
            auditLog(LogLevel.Fatal, eventType, site, newValue, oldValue, errorMessage, details);
        }

        public static void debugAuditLog(AuditEventType eventType,
                                         string site,
                                         string newValue,
                                         string oldValue,
                                         string errorMessage,
                                         string details) {
            auditLog(LogLevel.Debug, eventType, site, newValue, oldValue, errorMessage, details);
        }

        //****************************
        // AUDIT LOGGER HELPER METHODS
        //****************************
        private static void auditLog(LogLevel ll,
                                     AuditEventType eventType,
                                     string site,
                                     string newValue,
                                     string oldValue,
                                     string errorMessage, 
                                     string details) {
            LogEventInfo lei = createEventInfoObject(ll, 
                                                     (int)eventType,
                                                     site, 
                                                     newValue,
                                                     oldValue,
                                                     errorMessage, 
                                                     details);
            auditLogger.Log(lei);
        }

        private static LogEventInfo createEventInfoObject(LogLevel ll,
                                                          int typeID,
                                                          string storeName,
                                                          string newValue,
                                                          string oldValue,
                                                          string errorMessage,
                                                          string details) {
            LogEventInfo eventInfo = new LogEventInfo(ll, auditLogger.Name, "");
            eventInfo.Properties["StoreName"] = storeName;
            eventInfo.Properties["TypeID"] = typeID;
            eventInfo.Properties["NewValue"] = newValue;
            eventInfo.Properties["OldValue"] = oldValue;
            eventInfo.Properties["ErrorMessage"] = errorMessage;
            eventInfo.Properties["UserID"] = CurrentUserName();
            eventInfo.Properties["CreatedDate"] = DateTime.Now;
            eventInfo.Properties["Details"] = details;
            return eventInfo;
        }

        //***********************
        // MULTIPLE ITEM METHODS
        //***********************
        public static string getText(string[] fieldNames, FormViewInsertedEventArgs e, string objectType) {
            return getObjectValues(fieldNames, e, " inserted ", objectType);
        }

        public static string getText(string[] fieldNames, FormViewUpdatedEventArgs e, string objectType) {
            return getObjectValues(fieldNames, e, " updated ", objectType);
        }

        public static string getText(string[] fieldNames, FormViewUpdateEventArgs e, string objectType) {
            return getObjectValues(fieldNames, e, " updating ", objectType);
        }

        public static string getText(string[] fieldNames, FormViewDeletedEventArgs e, string objectType) {
            return getObjectValues(fieldNames, e, " deleted ", objectType);
        }

        //************

        public static string getText(string[] fieldNames, ListViewInsertedEventArgs e, string objectType) {
            return getObjectValues(fieldNames, e, " inserted ", objectType);
        }

        public static string getText(string[] fieldNames, ListViewUpdatedEventArgs e, string objectType) {
            return getObjectValues(fieldNames, e, " updated ", objectType);
        }

        public static string getText(string[] fieldNames, ListViewUpdateEventArgs e, string objectType) {
            return getObjectValues(fieldNames, e, " updating ", objectType);
        }

        public static string getText(string[] fieldNames, ListViewDeletedEventArgs e, string objectType) {
            return getObjectValues(fieldNames, e, " deleted ", objectType);
        }


        //***********************
        // SINGLE ITEM METHODS
        //***********************
        public static string getText(FormViewInsertedEventArgs e, string objectType) {
            StringBuilder sb = new StringBuilder();
            return sb.Append("User ")
                     .Append(WindowsIdentity.GetCurrent().Name)
                     .Append(" INSERTED ")
                     .Append(objectType)
                     .Append(" ")
                     .Append(getObjectValue(e)).ToString();
        }

        public static string getText(FormViewUpdatedEventArgs e, string objectType) {
            string username = WindowsIdentity.GetCurrent() != null ? WindowsIdentity.GetCurrent().Name : String.Empty;

            StringBuilder sb = new StringBuilder();
            return sb.Append("User ")
                     .Append(username)
                     .Append(" UPDATED ")
                     .Append(objectType)
                     .Append(" from ")
                     .Append(getObjectValue(e, "old"))
                     .Append(" to ")
                     .Append(getObjectValue(e, "new")).ToString();
        }

        public static string getText(FormViewDeletedEventArgs e, string objectType) {
            string username = WindowsIdentity.GetCurrent() != null ? WindowsIdentity.GetCurrent().Name : String.Empty;
            StringBuilder sb = new StringBuilder();
            return sb.Append("User ")
                     .Append(username)
                     .Append(" DELETED ")
                     .Append(objectType)
                     .Append(" ")
                     .Append(getObjectValue(e)).ToString();
        }

        //**********

        public static string getText(ListViewInsertedEventArgs e, string objectType) {
            string username = WindowsIdentity.GetCurrent() != null ? WindowsIdentity.GetCurrent().Name : String.Empty;
            StringBuilder sb = new StringBuilder();
            return sb.Append("User ")
                     .Append(username)
                     .Append(" INSERTED ")
                     .Append(objectType)
                     .Append(" ")
                     .Append(getObjectValue(e)).ToString();
        }

        public static string getText(ListViewUpdateEventArgs e, string objectType) {
            string username = WindowsIdentity.GetCurrent() != null ? WindowsIdentity.GetCurrent().Name : String.Empty;
            StringBuilder sb = new StringBuilder();
            return sb.Append("User ")
                     .Append(username)
                     .Append(" UPDATED ")
                     .Append(objectType)
                     .Append(" from ")
                     .Append(getObjectValue(e, "old"))
                     .Append(" to ")
                     .Append(getObjectValue(e, "new")).ToString();
        }

        public static string getText(ListViewUpdatedEventArgs e, string objectType) {
            string username = WindowsIdentity.GetCurrent() != null ? WindowsIdentity.GetCurrent().Name : String.Empty;
            StringBuilder sb = new StringBuilder();
            return sb.Append("User ")
                     .Append(username)
                     .Append(" UPDATED ")
                     .Append(objectType)
                     .Append(" from ")
                     .Append(getObjectValue(e, "old"))
                     .Append(" to ")
                     .Append(getObjectValue(e, "new")).ToString();
        }

        public static string getText(ListViewDeleteEventArgs e, string item) {
            string username = WindowsIdentity.GetCurrent() != null ? WindowsIdentity.GetCurrent().Name : String.Empty;
            StringBuilder sb = new StringBuilder();
            return sb.Append("User ")
                     .Append(username)
                     .Append(" DELETED ")
                     .Append(item).ToString();
        }
        
        //***********************
        // PRIVATE METHODS
        //***********************
        private static string getObjectValues(string[] fieldNames, EventArgs e, string mode, string objectType) {
            string username = WindowsIdentity.GetCurrent() != null ? WindowsIdentity.GetCurrent().Name : String.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append("User " + username + mode + objectType + ":\n");

            switch(mode) {
                case " inserted ":
                    for(int i = 0; i < fieldNames.Length; i++) {
                        sb.Append(fieldNames[i] + ": " + ((FormViewInsertedEventArgs)e).Values[i] + "\n");
                    }
                    break;
                case " updated ":
                    sb.Append("New Values:\n");
                    for(int i = 0; i < fieldNames.Length; i++) {
                        sb.Append(fieldNames[i] + ": " + ((FormViewUpdatedEventArgs)e).NewValues[i] + "\n");
                    }
                    break;
                //case " updating ":
                //    sb.Append("New Values:\n");
                //    for(int i = 0; i < fieldNames.Length; i++) {
                //        sb.Append(fieldNames[i] + ": " + ((FormViewUpdateEventArgs)e).NewValues[i] + "\n");
                //    }
                //    sb.Append("Old Values:\n");
                //    for(int j = 0; j < fieldNames.Length; j++) {
                //        sb.Append(fieldNames[j] + ": " + ((FormViewUpdateEventArgs)e).OldValues[j] + "\n");
                //    }
                //    break;
                case " deleted ":
                    if(((FormViewDeletedEventArgs)e).Values.Count != 0) {
                        for(int i = 0; i < fieldNames.Length; i++) {
                            sb.Append(fieldNames[i] + ": " + ((FormViewDeletedEventArgs)e).Values[i] + "\n");
                        }
                    } else {
                        sb.Append(objectType);
                    }
                    break;
            }

            return sb.ToString();
        }

        private static string getObjectValue(FormViewInsertedEventArgs e) {
            return e.Values[0].ToString();
        }

        private static string getObjectValue(FormViewUpdatedEventArgs e, string mode) {
            return mode.Equals("old") ? e.OldValues[0].ToString() : e.NewValues[0].ToString();
        }

        private static string getObjectValue(FormViewDeletedEventArgs e) {
            return e.Values[0].ToString();
        }

        private static string getObjectValue(ListViewInsertedEventArgs e){
            return e.Values[0].ToString();
        }

        private static string getObjectValue(ListViewUpdateEventArgs e, string mode) {
            return mode.Equals("old") ? e.OldValues[0].ToString() : e.NewValues[0].ToString();
        }

        private static string getObjectValue(ListViewUpdatedEventArgs e, string mode) {
            return mode.Equals("old") ? e.OldValues[0].ToString() : e.NewValues[0].ToString();
        }

        private static string getObjectValue(ListViewDeleteEventArgs e){
            return e.Values[0].ToString();
        }

        //private static string GetOldAndNewValues(string[] fieldNames,
        //                                         OrderedDictionary newValues,
        //                                         OrderedDictionary oldValues) {
        //    // Iterate through the new and old values. Display the
        //    // values on the page.
        //    StringBuilder sb = new StringBuilder("");

        //    //for(int i = 0; i < fieldNames.Length; i++) {
        //    for(int i = 0; i < oldValues.Count; i++) {
        //        sb.Append(fieldNames[i] + ": " +
        //                  "Old Value=" + oldValues[i].ToString() +
        //                  ", New Value=" + newValues[i].ToString() + "\n");
        //    }
        //    return sb.ToString();
        //}
    }
}