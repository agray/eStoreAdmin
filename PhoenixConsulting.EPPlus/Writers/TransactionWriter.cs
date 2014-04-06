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
using com.phoenixconsulting.epplus.Base;

namespace phoenixconsulting.epplus.writers {
    public class TransactionWriter : BaseWriter {

        private const string template = "Templates/Transactions.xls";
        private const string sheetName = "Transactions";
        private const string exportFilename = "Transactions.xls";
        private const string sheetTitle = "Transaction Extract";

        public override string GetFilename() {
            return exportFilename;
        }

        public override MemoryStream Write(string rootPath) {
            InitializeWorkbook(rootPath, template, sheetTitle);
            return createSheetInMemory();
        }

        private MemoryStream createSheetInMemory() {
            Logger logger = LogManager.GetLogger("TraceFileAndEventLogger");
            logger.Debug("Starting TransactionWriter");

            DAL.OrderDataTable orderDataTable = (new OrdersBLL()).GetTransactions();

            ExcelWorksheet sheet1 = package.Workbook.Worksheets[sheetName];
            int lastRowNum;

            int rowCount = 2;
            int colCount = 0;

            foreach(DAL.OrderRow row in orderDataTable.Rows) {
                sheet1.InsertRow(sheet1.Dimension.End.Row, 1);
                lastRowNum = sheet1.Dimension.End.Row;
                colCount = 0;

                SetCellValueAndFormat(lastRowNum, colCount++, row["ID"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["EmailAddress"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["BillingFirstName"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["BillingLastName"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["BillingAddress"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["BillingSuburbCity"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["BillingStateProvinceRegion"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["BillingZipPostcode"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["BillingCountry"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["ShippingFirstName"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["ShippingLastName"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["ShippingAddress"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["ShippingSuburbCity"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["ShippingStateProvinceRegion"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["ShippingZipPostcode"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["ShippingCountry"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["ShippingMode"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["ShippingCost"], DataFormat.CURRENCY);
                SetCellValueAndFormat(lastRowNum, colCount++, row["CCApprovalStatus"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["ShipDate"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["OrderDate"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["Comments"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["GiftTag"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["TxnID"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["SettlementDate"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["IsRefunded"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["RefundPONum"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["TotalCost"], DataFormat.CURRENCY);
                SetCellValueAndFormat(lastRowNum, colCount++, row["OrderTotal"], DataFormat.CURRENCY);
                SetCellValueAndFormat(lastRowNum, colCount++, row["PayPal_Ack"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["PayPal_CorrelationID"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["PayPal_TimeStamp"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["PayPal_FeeAmount"], DataFormat.CURRENCY);
                SetCellValueAndFormat(lastRowNum, colCount++, row["PayPal_PaymentStatus"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["PayPal_ReasonCode"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["PayPal_PaymentDate"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["PayPal_NetOfFee"], DataFormat.CURRENCY);
                SetCellValueAndFormat(lastRowNum, colCount++, row["PayPal_RefundTransactionID"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["PayPal_FeeRefundAmount"], DataFormat.CURRENCY);
                SetCellValueAndFormat(lastRowNum, colCount++, row["PayPal_GrossRefundAmount"], DataFormat.CURRENCY);
                SetCellValueAndFormat(lastRowNum, colCount++, row["PayPal_NetRefundAmount"], DataFormat.CURRENCY);
                SetCellValueAndFormat(lastRowNum, colCount++, row["PayPal_TotalRefundedAmount"], DataFormat.CURRENCY);
                SetCellValueAndFormat(lastRowNum, colCount++, row["UserID"]);
                
                AddBorder(lastRowNum);

                rowCount++;
            }

            sheet1.Cells[sheet1.Dimension.Address].AutoFitColumns();
            sheet1.Cells[sheet1.Dimension.Address].AutoFilter = true;

            logger.Debug("Exported {0} transactions", orderDataTable.Rows.Count);
            logger.Debug("Completed TransactionWriter.createSheetInMemory");

            return WriteToStream();
        }
    }
}