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
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace phoenixconsulting.epplus.Base {
    public class BaseWriter {
        protected ExcelWorkbook excelWorkbook;

        public abstract string getFilename();
        public abstract MemoryStream write(string rootPath);

        protected MemoryStream WriteToStream() {
            //Write the stream data of workbook to the root directory
            MemoryStream stream = new MemoryStream();
            hssfworkbook.Write(stream);
            return stream;
        }

        protected void InitializeWorkbook(string rootPath, string template, string sheetTitle) {
            //read the template via FileStream, it is suggested to use FileAccess.Read to prevent file lock.
            //template is an Excel-2007-generated file, so some new unknown BIFF records are added. 
            FileStream file = new FileStream(rootPath + template, FileMode.Open, FileAccess.Read);

            hssfworkbook = new HSSFWorkbook(file);

            //create a entry of DocumentSummaryInformation
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "Pheonix Consulting";
            hssfworkbook.DocumentSummaryInformation = dsi;

            //create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "eStore Extract";
            si.Author = "Pheonix Consulting";
            si.Title = sheetTitle;
            hssfworkbook.SummaryInformation = si;
        }

        protected void addBorder(ExcelRow excelRow, int cols) {
            // Style the cell with borders all around.
            ExcelStyles styles = excelWorkbook.Styles;
            styles.Borders.BorderBottom = ExcelBorderStyle.Thin;
            styles.BottomBorderColor = HSSFColor.BLACK.index;
            styles.BorderLeft = ExcelBorderStyle.Thin;
            styles.LeftBorderColor = HSSFColor.BLACK.index;
            styles.BorderRight = ExcelBorderStyle.Thin;
            styles.RightBorderColor = HSSFColor.BLACK.index;
            styles.BorderTop = ExcelBorderStyle.Thin;
            styles.TopBorderColor = HSSFColor.BLACK.index;

            for(int i = 0; i < cols; i++) {
                ExcelCell cell = excelRow.GetCell(i);
                cell.CellStyle = styles;
            }
        }

        protected void setCellValueAndFormat(ExcelRow row, int colCount, object value, DataFormat dfrmt = ExcelDataFormat.NONE) {
            ExcelCellBase cell = row.CreateCell(colCount);
            string val = value.ToString();

            if(dfrmt.Equals(DataFormat.NONE)) {
                cell.SetCellValue(val);
            } else {
                IDataFormat format = workbook.CreateDataForm();
                ICellStyle cellStyle = ExcelWorkbook.CreateCellStyle();
                double dbl;

                switch(dfrmt) {
                    case DataFormat.PLAIN_NUMBER:
                        double.TryParse(val, out dbl);
                        cell.SetCellValue(dbl);
                        cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                        break;
                    case DataFormat.PERCENT:
                        cell.SetCellValue(val);
                        cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00%");
                        break;
                    case DataFormat.CURRENCY:
                        double.TryParse(val, out dbl);
                        cell.SetCellValue(dbl);
                        cellStyle.DataFormat = format.GetFormat("$#,##0.00");
                        break;
                    case DataFormat.SCIENTIFIC:
                        cell.SetCellValue(val);
                        cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00E+00");
                        break;
                    case DataFormat.PHONE_NUMBER:
                        cell.SetCellValue(val);
                        cellStyle.DataFormat = format.GetFormat("000-00000000");
                        break;
                    case DataFormat.CHINESE_CAPS_NUM:
                        cell.SetCellValue(val);
                        cellStyle.DataFormat = format.GetFormat("[DbNum2][$-804]0 元");
                        break;
                    case DataFormat.CHINESE_DATE_STRING:
                        cell.SetCellValue(val);
                        cellStyle.DataFormat = format.GetFormat("yyyy年m月d日");
                        break;
                }
                cell.CellStyle = cellStyle;
            }
        }
    }
}
