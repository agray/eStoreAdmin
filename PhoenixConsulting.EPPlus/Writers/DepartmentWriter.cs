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
using eStoreAdminBLL;
using eStoreAdminDAL;
using NPOI.SS.UserModel;

namespace phoenixconsulting.npoi {
    public class DepartmentWriter : BaseWriter {

        private const string template = "Templates/Departments.xls";
        private const string sheetName = "Departments";
        private const string exportFilename = "Departments.xls";
        private const string sheetTitle = "Department Extract";

        public override string getFilename() {
            return exportFilename;
        }

        public override MemoryStream write(string rootPath) {
            InitializeWorkbook(rootPath, template, sheetTitle);
            return createSheetInMemory();
        }

        private MemoryStream createSheetInMemory() {
            Logger logger = LogManager.GetLogger("TraceFileAndEventLogger");
            logger.Debug("Starting DepartmentWriter");

            DepartmentsBLL departmentAdapter = new DepartmentsBLL();
            DAL.DepartmentDataTable departmentDataTable = null;
            departmentDataTable = departmentAdapter.GetDepartments();

            ISheet sheet1 = hssfworkbook.GetSheet(sheetName);
            IRow excelRow;

            int rowCount = 1;
            int colCount = 0;
            
            foreach(DAL.DepartmentRow row in departmentDataTable.Rows) {
                excelRow = sheet1.CreateRow(rowCount);
                colCount = 0;

                setCellValueAndFormat(excelRow, colCount++, row["ID"]);
                setCellValueAndFormat(excelRow, colCount++, row["Name"]);
                setCellValueAndFormat(excelRow, colCount++, row["SEOTitle"]);
                setCellValueAndFormat(excelRow, colCount++, row["SEOKeywords"]);
                setCellValueAndFormat(excelRow, colCount++, row["SEODescription"]);
                setCellValueAndFormat(excelRow, colCount++, row["SEOFriendlyNameURL"]);

                addBorder(excelRow, colCount);

                rowCount++;
            }

            for(int col = 0; col < colCount; col++) {
                sheet1.AutoSizeColumn(col, true);
            }

            sheet1.SetAutoFilter(getBoundingRange(rowCount, colCount));

            logger.Debug("Exported {0} departments", departmentDataTable.Rows.Count);
            logger.Debug("Completed DepartmentWriter.createSheetInMemory");

            return WriteToStream();
        }

        private CellRangeAddress getBoundingRange(int rows, int cols) {
            return new CellRangeAddress(0, rows, 0, cols - 1);
        }
    }
}