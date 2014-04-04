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
using phoenixconsulting.epplus.Base;
using OfficeOpenXml;
using NLog;
using eStoreAdminBLL;
using eStoreAdminDAL;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using com.phoenixconsulting.epplus.Base;

namespace phoenixconsulting.epplus.writers {
    public class TransactionWriter : BaseWriter {

        private const string template = "Templates/Transactions.xls";
        private const string sheetName = "Transactions";
        private const string exportFilename = "Transactions.xls";
        private const string sheetTitle = "Transaction Extract";

        public override string getFilename() {
            return exportFilename;
        }

        public override MemoryStream write(string rootPath) {
            InitializeWorkbook(rootPath, template, sheetTitle);
            return createSheetInMemory();
        }

        private MemoryStream createSheetInMemory() {
            Logger logger = LogManager.GetLogger("TraceFileAndEventLogger");
            logger.Debug("Starting TransactionWriter");

            DAL.OrderDataTable orderDataTable = (new OrdersBLL()).GetTransactions();
            
            ISheet sheet1 = hssfworkbook.GetSheet(sheetName);

            int rowCount = 2;
            int colCount = 0;

            foreach(DAL.OrderRow row in orderDataTable.Rows) {
                IRow excelRow = sheet1.CreateRow(rowCount);
                colCount = 0;

                setCellValueAndFormat(excelRow, colCount++, row["ID"]);
                setCellValueAndFormat(excelRow, colCount++, row["EmailAddress"]);
                setCellValueAndFormat(excelRow, colCount++, row["BillingFirstName"]);
                setCellValueAndFormat(excelRow, colCount++, row["BillingLastName"]);
                setCellValueAndFormat(excelRow, colCount++, row["BillingAddress"]);
                setCellValueAndFormat(excelRow, colCount++, row["BillingSuburbCity"]);
                setCellValueAndFormat(excelRow, colCount++, row["BillingStateProvinceRegion"]);
                setCellValueAndFormat(excelRow, colCount++, row["BillingZipPostcode"]);
                setCellValueAndFormat(excelRow, colCount++, row["BillingCountry"]);
                setCellValueAndFormat(excelRow, colCount++, row["ShippingFirstName"]);
                setCellValueAndFormat(excelRow, colCount++, row["ShippingLastName"]);
                setCellValueAndFormat(excelRow, colCount++, row["ShippingAddress"]);
                setCellValueAndFormat(excelRow, colCount++, row["ShippingSuburbCity"]);
                setCellValueAndFormat(excelRow, colCount++, row["ShippingStateProvinceRegion"]);
                setCellValueAndFormat(excelRow, colCount++, row["ShippingZipPostcode"]);
                setCellValueAndFormat(excelRow, colCount++, row["ShippingCountry"]);
                setCellValueAndFormat(excelRow, colCount++, row["ShippingMode"]);
                setCellValueAndFormat(excelRow, colCount++, row["ShippingCost"], DataFormat.CURRENCY);
                setCellValueAndFormat(excelRow, colCount++, row["CCApprovalStatus"]);
                setCellValueAndFormat(excelRow, colCount++, row["ShipDate"]);
                setCellValueAndFormat(excelRow, colCount++, row["OrderDate"]);
                setCellValueAndFormat(excelRow, colCount++, row["Comments"]);
                setCellValueAndFormat(excelRow, colCount++, row["GiftTag"]);
                setCellValueAndFormat(excelRow, colCount++, row["TxnID"]);
                setCellValueAndFormat(excelRow, colCount++, row["SettlementDate"]);
                setCellValueAndFormat(excelRow, colCount++, row["IsRefunded"]);
                setCellValueAndFormat(excelRow, colCount++, row["RefundPONum"]);
                setCellValueAndFormat(excelRow, colCount++, row["TotalCost"], DataFormat.CURRENCY);
                setCellValueAndFormat(excelRow, colCount++, row["OrderTotal"], DataFormat.CURRENCY);
                setCellValueAndFormat(excelRow, colCount++, row["PayPal_Ack"]);
                setCellValueAndFormat(excelRow, colCount++, row["PayPal_CorrelationID"]);
                setCellValueAndFormat(excelRow, colCount++, row["PayPal_TimeStamp"]);
                setCellValueAndFormat(excelRow, colCount++, row["PayPal_FeeAmount"], DataFormat.CURRENCY);
                setCellValueAndFormat(excelRow, colCount++, row["PayPal_PaymentStatus"]);
                setCellValueAndFormat(excelRow, colCount++, row["PayPal_ReasonCode"]);
                setCellValueAndFormat(excelRow, colCount++, row["PayPal_PaymentDate"]);
                setCellValueAndFormat(excelRow, colCount++, row["PayPal_NetOfFee"], DataFormat.CURRENCY);
                setCellValueAndFormat(excelRow, colCount++, row["PayPal_RefundTransactionID"]);
                setCellValueAndFormat(excelRow, colCount++, row["PayPal_FeeRefundAmount"], DataFormat.CURRENCY);
                setCellValueAndFormat(excelRow, colCount++, row["PayPal_GrossRefundAmount"], DataFormat.CURRENCY);
                setCellValueAndFormat(excelRow, colCount++, row["PayPal_NetRefundAmount"], DataFormat.CURRENCY);
                setCellValueAndFormat(excelRow, colCount++, row["PayPal_TotalRefundedAmount"], DataFormat.CURRENCY);
                setCellValueAndFormat(excelRow, colCount++, row["UserID"]);
                
                addBorder(excelRow, colCount);

                rowCount++;
            }

            for(int col = 0; col < colCount; col++) {
                sheet1.AutoSizeColumn(col, true);
            }

            sheet1.SetAutoFilter(getBoundingRange(rowCount, colCount));

            logger.Debug("Exported {0} transactions", orderDataTable.Rows.Count);
            logger.Debug("Completed TransactionWriter.createSheetInMemory");

            return WriteToStream();
        }

        private ExcelCellAddress getBoundingRange(int rows, int cols) {
            return new CellRangeAddress(1, rows, 0, cols - 1);
        }
    }
}