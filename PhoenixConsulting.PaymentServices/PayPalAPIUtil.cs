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
using System.Web;
using com.phoenixconsulting.exceptions;
using com.paypal.sdk.profiles;
using com.paypal.sdk.services;
using com.paypal.soap.api;
using NLog;
using phoenixconsulting.common.handlers;

namespace eStorePayments.paypal {
    public class PayPalAPIUtil {
        static Logger logger = LogManager.GetLogger("ErrorLogger");

        #region "RefundMethods"
        //****************************
        //Refund Methods
        //****************************
        public static string RefundTransactionCode(String refundType,
                                                   String transactionId,
                                                   String amount,
                                                   String note) {
            CallerServices caller = new CallerServices();
            caller.APIProfile = BuildPayPalWebservice();

            // Create the request object.
            RefundTransactionRequestType concreteRequest = new RefundTransactionRequestType();
            concreteRequest.Version = ApplicationHandler.Instance.PaypalVersion;

            // Add request-specific fields to the request.
            if((amount != null && amount.Length > 0) && (refundType.Equals("Partial"))) {
                BasicAmountType amtType = new BasicAmountType();
                amtType.Value = amount;
                amtType.currencyID = CurrencyCodeType.AUD;
                concreteRequest.Amount = amtType;
                concreteRequest.RefundType = RefundType.Partial;
            } else {
                concreteRequest.RefundType = RefundType.Full;
            }
            concreteRequest.RefundTypeSpecified = true;
            concreteRequest.TransactionID = transactionId;
            concreteRequest.Memo = note;

            // Execute the API operation and obtain the response.
            RefundTransactionResponseType pp_response = new RefundTransactionResponseType();
            pp_response = (RefundTransactionResponseType)caller.Call("RefundTransaction", concreteRequest);
            return pp_response.Ack.ToString();
        }

        #endregion

        #region "UtilMethods"
        //****************************
        //Util Methods
        //****************************
        public static IAPIProfile BuildPayPalWebservice() {
            IAPIProfile profile = ProfileFactory.createSignatureAPIProfile();
            /*
             WARNING: Do not embed plaintext credentials in your application code.
             Doing so is insecure and against best practices.
             Your API credentials must be handled securely. Please consider
             encrypting them for use in any production environment, and ensure
             that only authorized individuals may view or modify them.
            */

            // Set up your API credentials, PayPal end point, and API version.
            profile.APIUsername = ApplicationHandler.Instance.PaypalAPIUsername;
            profile.APIPassword = ApplicationHandler.Instance.PaypalAPIPassword;
            profile.APISignature = ApplicationHandler.Instance.PaypalAPISignature;
            profile.Environment = "sandbox";

            return profile;
        }

        internal static void HandleError(AbstractResponseType resp) {
            if(resp.Errors != null && resp.Errors.Length > 0) {
                //errors occured - log them
                throw new PayPalException(resp.Errors);
            }
        }

        #endregion
    }
}