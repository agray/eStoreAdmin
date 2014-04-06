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
using System.Text.RegularExpressions;
using OfficeOpenXml;
using phoenixconsulting.epplus.Base;

namespace com.phoenixconsulting.epplus.validators {
    public class Validator : BaseReader {
        //*****************************************
        //  Custom Validator Methods
        //*****************************************
        public static bool ValidateInt(string s) {
            int throwaway;
            return int.TryParse(s, out throwaway);
        }

        public static bool ValidateDouble(string s) {
            double throwaway;
            return double.TryParse(s, out throwaway);
        }

        public static bool ValidateLinkType(string s) {
            return s.Equals("Shopping") || s.Equals("Resources") || s.Equals("Other");
        }

        public static bool ValidateAlpha(string s) {
            Regex objPattern = new Regex("[A-Za-z ]*");
            return objPattern.IsMatch(s);
        }

        public static bool ValidateURL(string s) {
            Regex objPattern = new Regex("((https?|ftp|gopher|http|telnet|file|notes|ms-help):((//)|(\\\\))+[\\w\\d:#@%/;$()~_?\\+-=\\\\.&]*)");
            return objPattern.IsMatch(s);
        }

        public static bool ValidateEmail(string s) {
            Regex objPattern = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
            return objPattern.IsMatch(s);
        }

        public static bool ValidateLength(string s, int length) {
            return s.Length <= length;
        }

        //public static bool isCorrectStructure(ExcelRow row, int expectedCols, string[] titles) {
        //    return IsCorrectNumColumns(row.LastCellNum, expectedCols) &&
        //           TitlesCorrect(row, titles);
        //}

        //private static bool TitlesCorrect(ExcelRow row, string[] titles) {
        //    for(int i = 0; i < row.LastCellNum; i++) {
        //        if(!GetCellValueAsString(row.GetCell(i)).Equals(titles[i])) {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //private static bool IsCorrectNumColumns(int numCols, int expectedCols) {
        //    return numCols == expectedCols;
        //}
    }
}