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
using eStoreAdminBLL;
using NLog;
using eStoreAdminDAL;
using OfficeOpenXml;

namespace phoenixconsulting.epplus.writers {
    public class SupplierWriter : BaseWriter {

        private const string template = "Templates/Suppliers.xls";
        private const string sheetName = "Suppliers";
        private const string exportFilename = "Suppliers.xls";
        private const string sheetTitle = "Supplier Extract";

        public override string GetFilename() {
            return exportFilename;
        }

        public override MemoryStream Write(string rootPath) {
            InitializeWorkbook(rootPath, template, sheetTitle);
            return createSheetInMemory();
        }

        private MemoryStream createSheetInMemory() {
            Logger logger = LogManager.GetLogger("TraceFileAndEventLogger");
            logger.Debug("Starting SupplierWriter");

            DAL.SupplierDataTable supplierDataTable = (new SuppliersBLL()).GetSuppliers();

            ExcelWorksheet sheet1 = package.Workbook.Worksheets[sheetName];
            int lastRowNum;

            int rowCount = 1;
            int colCount = 0;

            foreach(DAL.SupplierRow row in supplierDataTable.Rows) {
                sheet1.InsertRow(sheet1.Dimension.End.Row, 1);
                lastRowNum = sheet1.Dimension.End.Row;
                colCount = 0;

                SetCellValueAndFormat(lastRowNum, colCount++, row["ID"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["CompanyName"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["ContactName"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["Address"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["CitySuburb"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["StateProvinceRegion"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["ZipPostcode"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["Country"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["BusinessPhone"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["MobilePhone"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["EmailAddress"]);
                
                AddBorder(lastRowNum);

                rowCount++;
            }

            sheet1.Cells[sheet1.Dimension.Address].AutoFitColumns();
            sheet1.Cells[sheet1.Dimension.Address].AutoFilter = true;

            logger.Debug("Exported {0} suppliers", supplierDataTable.Rows.Count);
            logger.Debug("Completed SupplierWriter.createSheetInMemory");

            return WriteToStream();
        }
    }
}