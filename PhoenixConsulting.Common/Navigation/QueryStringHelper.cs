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
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.handlers;

namespace phoenixconsulting.common.navigation {
    public class QueryStringHelper : BasePage {
    #region Singleton setup
        //Singleton from http://csharpindepth.com/Articles/General/Singleton.aspx. Fifth version.
        private QueryStringHelper() {
        }

        public static QueryStringHelper Instance { get { return Nested.instance; } }

        private class Nested {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() {
                //initialisation can go here
            }

            internal static readonly QueryStringHelper instance = new QueryStringHelper();
        }
    #endregion

    #region Variable Name Constants
        private const string DEPID = "?DepID";
        private const string DEPNAME = "&DepName";
        private const string CATID = "&CatID";
        private const string CATNAME = "&CatName";
        private const string PRODID = "&ProdID";
        private const string PRODNAME = "&ProdName";
        private const string COLORNAME = "&Name";
        private const string SIZENAME = "&Name";
        private const string EQUALS = "=";
    #endregion

    #region Convenience Methods
        public string DepartmentLevel() {
            return DEPID + EQUALS + RequestHandler.Instance.DepartmentID + DEPNAME + EQUALS + RequestHandler.Instance.DepartmentName;
        }

        public string DepartmentLevel(int depID, string depName) {
            return DEPID + EQUALS + depID + DEPNAME + EQUALS + depName;
        }

        public string CategoryLevel() {
            return DepartmentLevel() + CATID + EQUALS + RequestHandler.Instance.CategoryID + CATNAME + EQUALS + RequestHandler.Instance.CategoryName;
        }

        public string CategoryLevel(int catID, string catName) {
            return DepartmentLevel() + CATID + EQUALS + catID + CATNAME + EQUALS + catName;
        }

        public string CategoryLevel(int depID, string depName, int catID, string catName) {
            return DepartmentLevel(depID, depName) + CATID + EQUALS + catID + CATNAME + EQUALS + catName;
        }

        public string ProductLevel(int prodID, string prodName) {
            return CategoryLevel(RequestHandler.Instance.CategoryID, RequestHandler.Instance.CategoryName) +
                   PRODID + EQUALS + prodID + PRODNAME + EQUALS + prodName;
        }

        public string ProductColor(string name) {
            return ProductLevel(RequestHandler.Instance.ProductID, RequestHandler.Instance.ProductName) + 
                   COLORNAME + EQUALS + name;
        }

        public string ProductSize(string name) {
            return ProductLevel(RequestHandler.Instance.ProductID, RequestHandler.Instance.ProductName) +
                   SIZENAME + EQUALS + name;
        }
    #endregion
    }
}