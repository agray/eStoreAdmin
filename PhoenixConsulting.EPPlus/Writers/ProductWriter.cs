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

namespace phoenixconsulting.epplus.writers {
    public class ProductWriter : BaseWriter {

        private const string template = "Templates/Products.xls";
        private const string sheetName = "Products";
        private const string exportFilename = "Products.xls";
        private const string sheetTitle = "Product Extract";

        public override string getFilename() {
            return exportFilename;
        }

        public override MemoryStream write(string rootPath) {
            InitializeWorkbook(rootPath, template, sheetTitle);
            return createSheetInMemory();
        }

        private MemoryStream createSheetInMemory() {
            Logger logger = LogManager.GetLogger("TraceFileAndEventLogger");
            logger.Debug("Starting ProductWriter");
             DAL.ProductDataTable productDataTable = (new ProductsBLL()).GetProducts();

            ISheet sheet1 = hssfworkbook.GetSheet(sheetName);
            IRow excelRow;

            int rowCount = 1;
            int colCount = 0;

            foreach(DAL.ProductRow row in productDataTable.Rows) {
                excelRow = sheet1.CreateRow(rowCount);
                colCount = 0;

                setCellValueAndFormat(excelRow, colCount++, row["ID"]);
                setCellValueAndFormat(excelRow, colCount++, row["DepID"]);
                setCellValueAndFormat(excelRow, colCount++, row["CatID"]);
                setCellValueAndFormat(excelRow, colCount++, row["SupplierID"]);
                setCellValueAndFormat(excelRow, colCount++, row["BrandID"]);
                setCellValueAndFormat(excelRow, colCount++, row["Name"]);
                setCellValueAndFormat(excelRow, colCount++, row["Description"]);
                setCellValueAndFormat(excelRow, colCount++, row["UnitPrice"]);
                setCellValueAndFormat(excelRow, colCount++, row["DiscountUnitPrice"]);
                setCellValueAndFormat(excelRow, colCount++, row["WholesalePrice"]);
                setCellValueAndFormat(excelRow, colCount++, row["QuantityPerUnit"]);
                setCellValueAndFormat(excelRow, colCount++, row["Weight"]);
                
                if(row["Active"].ToString().Equals("1")) {
                    setCellValueAndFormat(excelRow, colCount++, "Yes");
                } else {
                    setCellValueAndFormat(excelRow, colCount++, "No");
                }

                if(row["IsOnSale"].ToString().Equals("1")) {
                    setCellValueAndFormat(excelRow, colCount++, "Yes");
                } else {
                    setCellValueAndFormat(excelRow, colCount++, "No");
                }

                setCellValueAndFormat(excelRow, colCount++, row["UnitsInStock"]);
                setCellValueAndFormat(excelRow, colCount++, row["UnitsOnOrder"]);
                setCellValueAndFormat(excelRow, colCount++, row["ReOrderLevel"]);
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

            logger.Debug("Exported {0} products", productDataTable.Rows.Count);
            logger.Debug("Completed ProductWriter.createSheetInMemory");

            return WriteToStream();
        }

        private CellRangeAddress getBoundingRange(int rows, int cols) {
            return new CellRangeAddress(0, rows, 0, cols - 1);
        }
    }
}