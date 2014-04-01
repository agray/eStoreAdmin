﻿/*
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
using System.IO;
using eStoreAdminBLL;
using eStoreAdminDAL;
using NLog;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace com.phoenixconsulting.npoi {
    public class CategoryWriter : NPOIWriter {

        private const string template = "Templates/Categories.xls";
        private const string sheetName = "Categories";
        private const string exportFilename = "Categories.xls";
        private const string sheetTitle = "Category Extract";

        public override string getFilename() {
            return exportFilename;
        }
        
        public override MemoryStream write(string rootPath) {
            InitializeWorkbook(rootPath, template, sheetTitle);
            return createSheetInMemory();
        }

        private MemoryStream createSheetInMemory() {
            Logger logger = LogManager.GetLogger("TraceFileAndEventLogger");
            logger.Debug("Starting CategoryWriter");

            CategoriesBLL categoryAdapter = new CategoriesBLL();
            DAL.CategoryDataTable categoryDataTable = null;
            categoryDataTable = categoryAdapter.GetCategories();

            ISheet sheet1 = hssfworkbook.GetSheet(sheetName);
            IRow excelRow;

            int rowCount = 1;
            int colCount = 0;

            foreach(DAL.CategoryRow row in categoryDataTable.Rows) {
                excelRow = sheet1.CreateRow(rowCount);
                colCount = 0;

                setCellValueAndFormat(excelRow, colCount++, row["ID"]);
                setCellValueAndFormat(excelRow, colCount++, row["Name"]);
                setCellValueAndFormat(excelRow, colCount++, row["Description"]);
                setCellValueAndFormat(excelRow, colCount++, row["SEOTitle"]);
                setCellValueAndFormat(excelRow, colCount++, row["SEOKeywords"]);
                setCellValueAndFormat(excelRow, colCount++, row["SEODescription"]);
                setCellValueAndFormat(excelRow, colCount++, row["SEOFriendlyNameURL"]);
                
                addBorder(excelRow, colCount);

                rowCount++;
            }

            for(int col = 0; col < colCount; col++) {
                sheet1.AutoSizeColumn(col);
            }

            sheet1.SetAutoFilter(getBoundingRange(rowCount, colCount));
            
            logger.Debug("Exported {0} categories", categoryDataTable.Rows.Count);
            logger.Debug("Completed CategoryWriter.createSheetInMemory");

            return WriteToStream();
        }

        private CellRangeAddress getBoundingRange(int rows, int cols) {
            return new CellRangeAddress(0, rows, 0, cols - 1);
        }
    }
}