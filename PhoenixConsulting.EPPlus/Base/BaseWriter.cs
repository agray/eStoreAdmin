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
using com.phoenixconsulting.epplus.Base;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.IO;

namespace phoenixconsulting.epplus.Base {
    public abstract class BaseWriter {
        protected ExcelPackage package;

        public abstract string GetFilename();
        public abstract MemoryStream Write(string rootPath);

        protected MemoryStream WriteToStream() {
            //Write the stream data of workbook to the root directory
            return new MemoryStream(package.GetAsByteArray());
        }

        protected void InitializeWorkbook(string rootPath, string template, string sheetTitle) {
            //read the template via FileStream, it is suggested to use FileAccess.Read to prevent file lock.
            //template is an Excel-2007-generated file, so some new unknown BIFF records are added. 
            FileStream file = new FileStream(rootPath + template, FileMode.Open, FileAccess.Read);

            package = new ExcelPackage(file);
            package.Workbook.Properties.Company = "Full Circle Solutions";
            package.Workbook.Properties.Subject = "eStore Extract";
            package.Workbook.Properties.Author = "Full Circle Solutions";
            package.Workbook.Properties.Title = sheetTitle;
        }

        protected void AddBorder(int rownum) {
            // Style the cell with borders all around.
            ExcelRow row = package.Workbook.Worksheets[0].Row(rownum);
            row.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
        }

        protected void SetCellValueAndFormat(int row, int col, object value, DataFormat dfrmt = DataFormat.NONE) {
            ExcelWorksheet sheet = package.Workbook.Worksheets[0];
            ExcelRange cell = sheet.Cells[row, col];
            
            string val = value.ToString();

            if(dfrmt.Equals(DataFormat.NONE)) {
                package.Workbook.Worksheets[0].Cells[row, col].Value = val;
            } else {
                double dbl;

                switch(dfrmt) {
                    case DataFormat.PLAIN_NUMBER:
                        double.TryParse(val, out dbl);
                        cell.Value = dbl;
                        cell.Style.Numberformat.Format = "0";
                        break;
                    case DataFormat.PERCENT:
                        cell.Value = val;
                        cell.Style.Numberformat.Format = "0%";
                        break;
                    case DataFormat.CURRENCY:
                        double.TryParse(val, out dbl);
                        cell.Value = dbl;
                        cell.Style.Numberformat.Format = "$#,##0.00";
                        break;
                    case DataFormat.PHONE_NUMBER:
                        cell.Value = val;
                        cell.Style.Numberformat.Format = "000-00000000";
                        break;
                    case DataFormat.CHINESE_CAPS_NUM:
                        cell.Value = val;
                        cell.Style.Numberformat.Format = "[DbNum2][$-804]0 元";
                        break;
                    case DataFormat.CHINESE_DATE_STRING:
                        cell.Value = val;
                        cell.Style.Numberformat.Format = "yyyy年m月d日";
                        break;
                }
            }
        }
    }
}