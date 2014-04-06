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
using NLog;
using eStoreAdminDAL;
using eStoreAdminBLL;
using OfficeOpenXml;

namespace phoenixconsulting.epplus.writers {
    public class TestimonialWriter : BaseWriter {

        private const string template = "Templates/Testimonials.xls";
        private const string sheetName = "Testimonials";
        private const string exportFilename = "Testimonials.xls";
        private const string sheetTitle = "Testimonial Extract";

        public override string GetFilename() {
            return exportFilename;
        }

        public override MemoryStream Write(string rootPath) {
            InitializeWorkbook(rootPath, template, sheetTitle);
            return createSheetInMemory();
        }

        private MemoryStream createSheetInMemory() {
            Logger logger = LogManager.GetLogger("TraceFileAndEventLogger");
            logger.Debug("Starting TestimonialWriter");

            DAL.TestimonialsDataTable testimonialDataTable = (new TestimonialBLL()).GetTestimonials();

            ExcelWorksheet sheet1 = package.Workbook.Worksheets[sheetName];
            int lastRowNum;

            int rowCount = 1;
            int colCount = 0;

            foreach(DAL.TestimonialsRow row in testimonialDataTable.Rows) {
                sheet1.InsertRow(sheet1.Dimension.End.Row, 1);
                lastRowNum = sheet1.Dimension.End.Row;
                colCount = 0;

                SetCellValueAndFormat(lastRowNum, colCount++, row["ID"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["CustomerName"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["CustomerCountry"]);
                SetCellValueAndFormat(lastRowNum, colCount++, row["TestimonialText"]);

                AddBorder(lastRowNum);

                rowCount++;
            }

            sheet1.Cells[sheet1.Dimension.Address].AutoFitColumns();
            sheet1.Cells[sheet1.Dimension.Address].AutoFilter = true;

            logger.Debug("Exported {0} testimonials", testimonialDataTable.Rows.Count);
            logger.Debug("Completed TestimonialWriter.createSheetInMemory");

            return WriteToStream();
        }
    }
}