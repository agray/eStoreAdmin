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
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using eStoreAdminBLL;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.handlers;
using phoenixconsulting.common.logging;
using phoenixconsulting.common.navigation;

namespace eStoreWeb {
    public partial class CCAuth : AuditBasePage {
        private OrdersBLL _ordersAdapter;

        protected OrdersBLL OrderAdapter {
            get { return _ordersAdapter ?? (_ordersAdapter = new OrdersBLL()); }
        }

        // Define variables    
        private string messageID, messageTimestamp, apiVersion, requestType, merchantID, statusCode, statusDescription, txnType, txnSource, amount, currency, purchaseOrderNo, approved, responseCode, responseText, settlementDate, txnID, preauthID, pan, expiryDate, cardType, cardDescription, bsbNumber, accountNumber, accountName, strURL, message, timestamp;

        // Additional variables for Periodic Transactions.
        private string actionType, clientID, successful, recurringFlag, creditFlag, periodicType, paymentInterval, startDate, endDate, merchantID7Char, merchantID5Char; //, visaRecurring;

        protected void Page_Load(Object sender, EventArgs e) {
            //getRefundDetails(int.Parse(Request.QueryString["ID"]);
            logger.Debug("Attempting refund transaction...");
            SetMerchantId();
            SetTimestamp();
            SetUrlAndMessage();
            ProcessXmlMessage();

            SessionHandler.Instance.CCResponseText = responseText;
            SessionHandler.Instance.CCResponseCode = responseCode;
            SessionHandler.Instance.CCApproved = approved;

            if(isRefundApproved(approved, responseCode)) {
                logger.Debug("Refund approved for " + SessionHandler.Instance.RefundAmount);
                //Update order status with result of refund request from CC Processor.
                OrdersBLL order = new OrdersBLL();
                order.OrderRefunded(Convert.ToInt32(Request.QueryString["ID"]), txnID);
                order = null;
                logInfo(AuditEventType.ORDER_REFUNDED, null, null, null);
                GoTo.Instance.ManageOrdersPage();
                //Response.Redirect("ShowMe.aspx");
            } else {
                logger.Debug("Refund declined for " + SessionHandler.Instance.RefundAmount + " with reason code: " + responseCode);
            }
        }

        public bool isRefundApproved(string approved, string responseCode) {
            return (approved.Equals("Yes") && responseCode.Equals("00"));
        }

        public void SetMerchantId() {
            merchantID7Char = ApplicationHandler.Instance.MerchantID;
            merchantID5Char = ApplicationHandler.Instance.MerchantID.Remove(5, 2);
        }

        public void SetTimestamp() {
            // Generate GMT timestamp.
            DateTime value = DateTime.UtcNow;
            timestamp = value.ToString("yyyyMMddHHmmss000000zz");
            //Response.Write("myTimestamp = " + myTimestamp + "<br />");
        }

        public void SetUrlAndMessage() {
            switch(Request.QueryString["requestType"]) {
                case "echo":
                    if(Request.QueryString["server"] == "live") {
                        strURL = ApplicationHandler.Instance.LiveEchoURL;
                        message = SetEcho(merchantID7Char, timestamp);
                    } else {
                        strURL = ApplicationHandler.Instance.TestEchoURL;
                        //Or if using SSL:
                        //strURL = "https://www.securepay.com.au/test/payment";
                        message = SetEcho(merchantID7Char, timestamp);
                    }
                    break;

                case "payment":
                    if(Request.QueryString["server"] == "live") {
                        if(ApplicationHandler.Instance.RefundPaymentType.ToString() == "15" || ApplicationHandler.Instance.RefundPaymentType.ToString() == "17") {
                            //Direct Debit or Direct Credit
                            strURL = ApplicationHandler.Instance.LivePaymentDCURL;
                            message = SetPaymentDirectEntry(merchantID5Char, timestamp);
                        } else {
                            strURL = ApplicationHandler.Instance.LivePaymentURL;
                            logger.Debug("Refund request going to live server.");
                            message = SetPaymentCreditCard(merchantID7Char, timestamp);
                        }
                    } else {
                        if(ApplicationHandler.Instance.RefundPaymentType.ToString() == "15" || ApplicationHandler.Instance.RefundPaymentType.ToString() == "17") {
                            //Direct Debit or Direct Credit
                            strURL = ApplicationHandler.Instance.TestPaymentDCURL;
                            message = SetPaymentDirectEntry(merchantID5Char, timestamp);
                        } else {
                            strURL = ApplicationHandler.Instance.TestPaymentURL;
                            //Or if using SSL:
                            //strURL = "https://www.securepay.com.au/test/payment";
                            logger.Debug("Refund request going to test server.");
                            message = SetPaymentCreditCard(merchantID7Char, timestamp);
                        }
                    }
                    break;
            }
        }

        public string SetEcho(string merchantId, string time) {
            string tempMessage = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<SecurePayMessage>" + "<MessageInfo>" + "<messageID>" + Request.Form["message_id"] + "</messageID>" + "<messageTimestamp>" + time + "</messageTimestamp>" + "<timeoutValue>60</timeoutValue>" + "<apiVersion>xml-4.2</apiVersion>" + "</MessageInfo>" + "<MerchantInfo>" + "<merchantID>" + merchantId + "</merchantID>" + "<password>" + ApplicationHandler.Instance.Password + "</password>" + "</MerchantInfo>" + "<RequestType>" + Request.QueryString["requestType"] + "</RequestType>" + "</SecurePayMessage>";
            return tempMessage;
        }

        public string SetPaymentCreditCard(string merchantId, string time) {
            logger.Debug("Creating refund request...");
            string txnID = OrderAdapter.GetTransactionId(int.Parse(Request.QueryString["ID"]));
            double amount = OrderAdapter.GetOrderTotal(int.Parse(Request.QueryString["ID"]));
            double AdminFeePercent = ApplicationHandler.Instance.RefundAdminFeePercent / 100;
            double amountMinusAdminFee = amount * (1 - AdminFeePercent);
            //double amount = 100;  //This is to get Approved in Test Env
            string tempMessage = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<SecurePayMessage>" + "<MessageInfo>" + "<messageID>" + Request.QueryString["ID"] + "</messageID>" + "<messageTimestamp>" + time + "</messageTimestamp>" + "<timeoutValue>60</timeoutValue>" + "<apiVersion>xml-4.2</apiVersion>" + "</MessageInfo>" + "<MerchantInfo>" + "<merchantID>" + merchantId + "</merchantID>" + "<password>" + ApplicationHandler.Instance.Password + "</password>" + "</MerchantInfo>" + "<RequestType>" + Request.QueryString["requestType"] + "</RequestType>" + "<Payment>" + "<TxnList count=\"1\">" + "<Txn ID=\"1\">" + "<txnType>" + ApplicationHandler.Instance.RefundPaymentType + "</txnType>" + "<txnSource>23</txnSource>" + "<amount>" + amountMinusAdminFee.ToString("c").Replace(".", "").Replace(",", "").Replace("$", "") + "</amount>" + "<purchaseOrderNo>" + Request.QueryString["ID"] + "</purchaseOrderNo>" + "<currency>AUD</currency>" + "<preauthID></preauthID>" + "<txnID>" + txnID + "</txnID>" + "<CreditCardInfo>" + "<cardNumber></cardNumber>" + "<cvv></cvv>" + "<expiryDate></expiryDate>" + "</CreditCardInfo>" + "</Txn>" + "</TxnList>" + "</Payment>" + "</SecurePayMessage>";

            //SessionHandler.CCRequestXml = tempMessage;
            logger.Debug("Created refund request...");
            return tempMessage;
        }

        public string SetPaymentDirectEntry(string merchantId, string time) {
            string tempMessage = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "<SecurePayMessage>" + "<MessageInfo>" + "<messageID>" + Request.Form["message_id"] + "</messageID>" + "<messageTimestamp>" + time + "</messageTimestamp>" + "<timeoutValue>60</timeoutValue>" + "<apiVersion>xml-4.2</apiVersion>" + "</MessageInfo>" + "<MerchantInfo>" + "<merchantID>" + merchantId + "</merchantID>" + "<password>" + ApplicationHandler.Instance.Password + "</password>" + "</MerchantInfo>" + "<RequestType>" + Request.QueryString["requestType"] + "</RequestType>" + "<Payment>" + "<TxnList count=\"1\">" + "<Txn ID=\"1\">" + "<txnType>" + ApplicationHandler.Instance.RefundPaymentType + "</txnType>" + "<txnSource>23</txnSource>" + "<amount>" + Request.Form["payment_amount"].Replace(".", "") + "</amount>" + "<purchaseOrderNo>" + Request.Form["payment_reference"] + "</purchaseOrderNo>" + "<DirectEntryInfo>" + "<bsbNumber>" + Request.Form["bsb_number"] + "</bsbNumber>" + "<accountNumber>" + Request.Form["account_number"] + "</accountNumber>" + "<accountName>" + Request.Form["account_name"] + "</accountName>" + "</DirectEntryInfo>" + "</Txn>" + "</TxnList>" + "</Payment>" + "</SecurePayMessage>";
            return tempMessage;
        }

        public void ProcessXmlMessage() {
            //SessionHandler.Url = strURL;

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(strURL);
            ASCIIEncoding encoding = new ASCIIEncoding();
            Byte[] byte1 = encoding.GetBytes(message);

            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = byte1.Length;
            myRequest.Pipelined = false;
            myRequest.KeepAlive = false;

            Stream newStream;
            newStream = myRequest.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();

            try {
                logger.Debug("Processing response...");
                //Get the data as an HttpWebResponse object
                HttpWebResponse resp = (HttpWebResponse)myRequest.GetResponse();

                //Convert the data into a string (assumes that you are requesting text)
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                XmlTextReader xmlreader = new XmlTextReader(sr);

                xmlreader.WhitespaceHandling = WhitespaceHandling.None;
                XmlDocument myXMLdocument = new XmlDocument();
                myXMLdocument.Load(xmlreader);

                //SessionHandler.CCResponseXml = myXMLdocument.InnerXml;

                XmlNodeList myNodeList = myXMLdocument.GetElementsByTagName("*");

                sr.Close();
                xmlreader.Close();

                for(int counter = 1; counter < myNodeList.Count; counter++) {
                    XmlNode node = myNodeList.Item(counter);
                    if(node != null) {
                        switch(node.Name) {
                            case "messageID":
                                messageID = node.InnerXml;
                                break;
                            case "messageTimestamp":
                                messageTimestamp = node.InnerXml;
                                break;
                            case "apiVersion":
                                apiVersion = node.InnerXml;
                                break;
                            case "RequestType":
                                requestType = node.InnerXml;
                                break;
                            case "merchantID":
                                merchantID = node.InnerXml;
                                break;
                            case "statusCode":
                                statusCode = node.InnerXml;
                                break;
                            case "statusDescription":
                                statusDescription = node.InnerXml;
                                break;
                            case "txnType":
                                txnType = node.InnerXml;
                                break;
                            case "txnSource":
                                txnSource = node.InnerXml;
                                break;
                            case "amount":
                                amount = node.InnerXml;
                                break;
                            case "currency":
                                currency = node.InnerXml;
                                break;
                            case "purchaseOrderNo":
                                purchaseOrderNo = node.InnerXml;
                                break;
                            case "approved":
                                approved = node.InnerXml;
                                break;
                            case "responseCode":
                                responseCode = node.InnerXml;
                                break;
                            case "responseText":
                                responseText = node.InnerXml;
                                break;
                            case "settlementDate":
                                settlementDate = node.InnerXml;
                                break;
                            case "txnID":
                                txnID = node.InnerXml;
                                break;
                            case "preauthID":
                                preauthID = node.InnerXml;
                                break;
                            case "pan":
                                pan = node.InnerXml;
                                break;
                            case "expiryDate":
                                expiryDate = node.InnerXml;
                                break;
                            case "cardType":
                                cardType = node.InnerXml;
                                break;
                            case "cardDescription":
                                cardDescription = node.InnerXml;
                                break;
                            case "bsbNumber":
                                bsbNumber = node.InnerXml;
                                break;
                            case "accountNumber":
                                accountNumber = node.InnerXml;
                                break;
                            case "accountName":
                                accountName = node.InnerXml;
                                break;
                                // Additional Periodic values.    
                            case "actionType":
                                actionType = node.InnerXml;
                                break;
                            case "clientID":
                                clientID = node.InnerXml;
                                break;
                            case "successful":
                                successful = node.InnerXml;
                                break;
                            case "recurringFlag":
                                recurringFlag = node.InnerXml;
                                break;
                            case "creditFlag":
                                creditFlag = node.InnerXml;
                                break;
                            case "periodicType":
                                periodicType = node.InnerXml;
                                break;
                            case "paymentInterval":
                                paymentInterval = node.InnerXml;
                                break;
                            case "startDate":
                                startDate = node.InnerXml;
                                break;
                            case "endDate":
                                endDate = node.InnerXml;
                                break;
                        }
                    }
                }
                resp.Close();
            } catch(WebException wex) {
                logger.Error(wex.ToString());
                Response.Write("<font color=red>There has been an error.<br />Status: " + wex.Status + " Message: " + wex.Message + "</font>");
            }
        }
    }
}