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
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace com.phoenixconsulting.npoi {
    public class NPOIReader {
        HSSFWorkbook hssfworkbook;

        protected void InitializeWorkbook(Stream content) {
            hssfworkbook = new HSSFWorkbook(content);
        }

        //public HSSFWorkbook readFile(Stream fileContent){
        //    return new HSSFWorkbook(fileContent);
        //}

        //protected IEnumerator getRowEnumerator(Stream fileContent, string sheetName) {
        //    HSSFWorkbook wb = readFile(fileContent);
        //    ISheet sheet = wb.GetSheet(sheetName);
        //    if(sheet == null) {
        //        return null;
        //    } else {
        //        return sheet.GetRowEnumerator();
        //    }
        //}

        protected static string getCellValueAsString(ICell cell) {
            switch(cell.CellType) {
                case CellType.STRING:
                    return cell.StringCellValue;
                case CellType.NUMERIC:
                    return cell.NumericCellValue.ToString();
                case CellType.FORMULA:
                    return "Cell type cannot be a formula";
                case CellType.BOOLEAN:
                    return cell.BooleanCellValue ? "true" : "false";
                case CellType.BLANK:
                    return "";
                case CellType.ERROR:
                    return cell.ErrorCellValue.ToString();
                default:
                    return "Unknown Value Type";
            }
        }
    }
}