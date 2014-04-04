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
using eStoreAdminBLL;
using NLog;
using eStoreAdminDAL;
using NPOI.SS.UserModel;

namespace phoenixconsulting.epplus.writers {
    public class SupplierWriter : BaseWriter {

        private const string template = "Templates/Suppliers.xls";
        private const string sheetName = "Suppliers";
        private const string exportFilename = "Suppliers.xls";
        private const string sheetTitle = "Supplier Extract";

        public override string getFilename() {
            return exportFilename;
        }

        public override MemoryStream write(string rootPath) {
            InitializeWorkbook(rootPath, template, sheetTitle);
            return createSheetInMemory();
        }

        private MemoryStream createSheetInMemory() {
            Logger logger = LogManager.GetLogger("TraceFileAndEventLogger");
            logger.Debug("Starting SupplierWriter");

            DAL.SupplierDataTable supplierDataTable = (new SuppliersBLL()).GetSuppliers();

            ISheet sheet1 = hssfworkbook.GetSheet(sheetName);

            int rowCount = 1;
            int colCount = 0;

            foreach(DAL.SupplierRow row in supplierDataTable.Rows) {
                IRow excelRow = sheet1.CreateRow(rowCount);
                colCount = 0;

                setCellValueAndFormat(excelRow, colCount++, row["ID"]);
                setCellValueAndFormat(excelRow, colCount++, row["CompanyName"]);
                setCellValueAndFormat(excelRow, colCount++, row["ContactName"]);
                setCellValueAndFormat(excelRow, colCount++, row["Address"]);
                setCellValueAndFormat(excelRow, colCount++, row["CitySuburb"]);
                setCellValueAndFormat(excelRow, colCount++, row["StateProvinceRegion"]);
                setCellValueAndFormat(excelRow, colCount++, row["ZipPostcode"]);
                setCellValueAndFormat(excelRow, colCount++, row["Country"]);
                setCellValueAndFormat(excelRow, colCount++, row["BusinessPhone"]);
                setCellValueAndFormat(excelRow, colCount++, row["MobilePhone"]);
                setCellValueAndFormat(excelRow, colCount++, row["EmailAddress"]);
                
                addBorder(excelRow, colCount);

                rowCount++;
            }

            for(int col = 0; col < colCount; col++) {
                sheet1.AutoSizeColumn(col);
            }

            sheet1.SetAutoFilter(getBoundingRange(rowCount, colCount));

            logger.Debug("Exported {0} suppliers", supplierDataTable.Rows.Count);
            logger.Debug("Completed SupplierWriter.createSheetInMemory");

            return WriteToStream();
        }

        private CellRangeAddress getBoundingRange(int rows, int cols) {
            return new CellRangeAddress(0, rows, 0, cols - 1);
        }
    }
}