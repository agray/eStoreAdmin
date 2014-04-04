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
using NPOI.SS.Util;
using NLog;
using eStoreAdminDAL;
using eStoreAdminBLL;
using NPOI.SS.UserModel;

namespace phoenixconsulting.epplus.writers {
    public class ProductInventoryWriter : BaseWriter {

        private const string template = @"Templates\ProductInventory.xls";
        private const string sheetName = "ProductInventory";
        private const string exportFilename = "ProductInventory.xls";
        private const string sheetTitle = "Product Inventory Extract";

        public override string getFilename() {
            return exportFilename;
        }

        public override MemoryStream write(string rootPath) {
            InitializeWorkbook(rootPath, template, sheetTitle);
            return createSheetInMemory();
        }

        private MemoryStream createSheetInMemory() {
            Logger logger = LogManager.GetLogger("TraceFileAndEventLogger");
            logger.Debug("Starting ProductInventoryWriter");

            DAL.ProductDataTable productDataTable = (new ProductsBLL()).GetProducts();

            ISheet sheet1 = hssfworkbook.GetSheet(sheetName);
            IRow excelRow;

            int rowCount = 1;
            int colCount = 0;

            foreach(DAL.ProductRow row in productDataTable.Rows) {
                excelRow = sheet1.CreateRow(rowCount);
                colCount = 0;

                setCellValueAndFormat(excelRow, colCount++, row["ID"]);
                setCellValueAndFormat(excelRow, colCount++, row["Name"]);
                setCellValueAndFormat(excelRow, colCount++, row["UnitsInStock"]);
                setCellValueAndFormat(excelRow, colCount++, row["UnitsOnOrder"]);
                setCellValueAndFormat(excelRow, colCount++, row["ReOrderLevel"]);

                addBorder(excelRow, colCount);

                rowCount++;
            }

            for(int col = 0; col < colCount; col++) {
                sheet1.AutoSizeColumn(col);
            }

            sheet1.SetAutoFilter(getBoundingRange(rowCount, colCount));

            logger.Debug("Exported {0} product products", productDataTable.Rows.Count);
            logger.Debug("Completed ProductInventoryWriter.createSheetInMemory");

            return WriteToStream();
        }

        private CellRangeAddress getBoundingRange(int rows, int cols) {
            return new CellRangeAddress(0, rows, 0, cols - 1);
        }
    }
}