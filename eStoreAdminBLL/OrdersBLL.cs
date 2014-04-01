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
using System.ComponentModel;
using eStoreAdminBLL.Base;
using eStoreAdminDAL;
using System.Data;

namespace eStoreAdminBLL {
    [DataObject]
    public class OrdersBLL : BaseBLL {
        //########################################
        //######## ORDERDETAILS FUNCTIONS ########
        //########################################
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.OrderDetailDataTable GetOrderDetails() {
            return BLLAdapter.Instance.OrderDetailAdapter.GetOrderDetails();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.OrderDetailDataTable GetOrderDetailsByOrderId(int orderID) {
            return BLLAdapter.Instance.OrderDetailAdapter.GetOrderDetailsByOrderID(orderID);
        }

        //#################################
        //######## ORDER FUNCTIONS ########
        //#################################
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public DAL.OrderDataTable GetOrders() {
            return BLLAdapter.Instance.OrderAdapter.GetData();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.OrderDataTable GetOrdersById(int orderID) {
            return BLLAdapter.Instance.OrderAdapter.GetOrderByID(orderID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.OrderDataTable GetTransactions() {
            return BLLAdapter.Instance.OrderAdapter.GetTransactionDetails();
        }

        private DataTable CreateDataTable() {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("EmailAddress");
            return dt;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.OrderDataTable SearchOrders(string email,
                                               string billingFirstName,
                                               string billingLastName,
                                               string billingAddress,
                                               string billingSuburbCity,
                                               string billingStateProvinceRegion,
                                               string billingZipPostcode,
                                               string billingCountryID,
                                               string shippingFirstName,
                                               string shippingLastName,
                                               string shippingAddress,
                                               string shippingSuburbCity,
                                               string shippingStateProvinceRegion,
                                               string shippingZipPostcode,
                                               string shippingCountryID,
                                               string shippingModeID,
                                               string shippingCost,
                                               string shipDate,
                                               string shipFromDate,
                                               string shipToDate,
                                               string orderDate,
                                               string orderFromDate,
                                               string orderToDate,
                                               int isApproved,
                                               int isShipped,
                                               int hasComments,
                                               int hasGiftTag) {

            return BLLAdapter.Instance.OrderAdapter.GetSearchOrder(email, billingFirstName, billingLastName, billingAddress, billingSuburbCity,
                                                                   billingStateProvinceRegion, billingZipPostcode, billingCountryID, shippingFirstName,
                                                                   shippingLastName, shippingAddress, shippingSuburbCity, shippingStateProvinceRegion,
                                                                   shippingZipPostcode, shippingCountryID, shippingModeID, shippingCost, shipDate, shipFromDate,
                                                                   shipToDate, orderDate, orderFromDate, orderToDate,
                                                                   isApproved, isShipped, hasComments, hasGiftTag);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, false)]
        public int OrderRefunded(int ID, string refundPONum) {
            return (int)BLLAdapter.Instance.OrderAdapter.OrderRefunded(ID, refundPONum);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public double GetOrderTotal(int ID) {
            return (double)BLLAdapter.Instance.OrderAdapter.OrderGetOrderTotal(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public string GetTransactionId(int ID) {
            return BLLAdapter.Instance.OrderAdapter.OrderGetTxnID(ID).ToString();
        }
    }
}