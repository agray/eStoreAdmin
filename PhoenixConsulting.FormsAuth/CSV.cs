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
using System;
using System.Collections;

namespace com.phoenixconsulting.util {

    public static class CSV {
        private static char[] DEFAULT_DELIMITER = { ',' };

        public static string toCSV(string[] inputArray)
        {
            return inputArray.Length == 0 ? String.Empty : String.Join(", ", inputArray);
        }

        public static ArrayList ArrayListFromCSV(string inputCSVString, char[] delimiter) {
            if(!inputCSVString.Contains(delimiter.ToString())) {
                //Not a CSV String that uses the delimiter
                return null;
            } 
            ArrayList list = new ArrayList();
            string trimmedCSVString = removeSpacesAfterDelimiter(inputCSVString, delimiter.ToString());
            string[] intermediate = trimmedCSVString.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            foreach(string s in intermediate) {
                list.Add(s);
            }
            return list;
        }

        public static string[] StringArrayFromCSV(string inputCSVString, char[] delimiter) {
            if(!inputCSVString.Contains(delimiter.ToString())) {
                //Not a CSV String that uses the delimiter
                return null;
            } 
                string trimmedCSVString = removeSpacesAfterDelimiter(inputCSVString, delimiter.ToString());
                return trimmedCSVString.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string[] StringArrayFromCSV(string inputCSVString) {
            return StringArrayFromCSV(inputCSVString, DEFAULT_DELIMITER);
        }

        public static ArrayList ArrayListFromCSV(string inputCSVString) {
            return ArrayListFromCSV(inputCSVString, DEFAULT_DELIMITER);
        }

        private static string removeSpacesAfterDelimiter(string inputCSVString, string delimiter) {
            return inputCSVString.Replace(delimiter + " ", delimiter);
        }
    }
}