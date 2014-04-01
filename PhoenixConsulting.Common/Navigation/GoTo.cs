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
using System.Web;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.handlers;

namespace phoenixconsulting.common.navigation {
    public sealed class GoTo : HTTPScopeHandlerBase {
    #region Singleton setup
        //Singleton from http://csharpindepth.com/Articles/General/Singleton.aspx. Fifth version.
        private GoTo() {
        }

        public static GoTo Instance { get { return Nested.instance; } }

        private class Nested {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() {
                //initialisation can go here
            }

            internal static readonly GoTo instance = new GoTo();
        }
    #endregion

    #region Page Methods
        public void RefreshPage(string queryString) {
            redirectBrowser("~" + GetCurrentPath() + queryString);
        }

        public void HomePage() {
            redirectBrowser(ROOT_DIR);
        }

        public void HomePage(string userName) {
            redirectBrowser(getHomePage(userName));
        }
        
        public void MyErrorPage() {
            redirectBrowser(Pages.ERROR);
        }
                
        public void RegisterPage() {
            redirectBrowser(Pages.REGISTER);
        }

        public void ManageDepartmentsPage() {
            redirectBrowser(Pages.MANAGE_DEPARTMENTS);
        }

        public void ManageDepartmentPage() {
            redirectBrowser(Pages.MANAGE_DEPARTMENT + QueryStringHelper.Instance.DepartmentLevel());
        }

        public void ManageDepartmentImagePage() {
            redirectBrowser(Pages.MANAGE_DEPARTMENT_IMAGE + QueryStringHelper.Instance.DepartmentLevel());
        }

        public void ManageDepartmentImagePage(int depID, string depName) {
            redirectBrowser(Pages.MANAGE_DEPARTMENT_IMAGE + QueryStringHelper.Instance.DepartmentLevel(depID, depName));
        }

        public void AddDepartmentPage() {
            redirectBrowser(Pages.ADD_DEPARTMENT);
        }
        
        public void AddCategoryPage() {
            redirectBrowser(Pages.ADD_CATEGORY + QueryStringHelper.Instance.DepartmentLevel());
        }

        public void ManageCategoryImagePage() {
            redirectBrowser(Pages.MANAGE_CATEGORY_IMAGE + QueryStringHelper.Instance.CategoryLevel());
        }

        public void ManageCategoryImagePage(int catID, string catName) {
            redirectBrowser(Pages.MANAGE_CATEGORY_IMAGE + 
                            QueryStringHelper.Instance.CategoryLevel(RequestHandler.Instance.DepartmentID, 
                                                                     RequestHandler.Instance.DepartmentName, 
                                                                     catID, catName));
        }

        public void ManageCategoryPage() {
            redirectBrowser(Pages.MANAGE_CATEGORY +
                            QueryStringHelper.Instance.CategoryLevel(RequestHandler.Instance.CategoryID,
                                                                     RequestHandler.Instance.CategoryName));
        }

        public void AddProductPage() {
            redirectBrowser(Pages.ADD_PRODUCT +
                            QueryStringHelper.Instance.CategoryLevel(RequestHandler.Instance.CategoryID,
                                                                     RequestHandler.Instance.CategoryName));
        }

        public void ManageProductImagePage() {
            redirectBrowser(Pages.MANAGE_PRODUCT_IMAGE +
                            QueryStringHelper.Instance.ProductLevel(RequestHandler.Instance.ProductID,
                                                                    RequestHandler.Instance.ProductName));
        }

        public void ImportExportHomePage() {
            redirectBrowser(Pages.IMPORT_EXPORT_HOME);
        }

        public void ManageColorsPage() {
            redirectBrowser(Pages.MANAGE_COLORS);
        }

        public void ManageWordsPage() {
            redirectBrowser(Pages.MANAGE_WORDS);
        }

        public void ManageCountriesPage() {
            redirectBrowser(Pages.MANAGE_COUNTRIES);
        }

        public void ManageSocialByDepPage() {
            redirectBrowser(Pages.MANAGE_SOCIAL_BY_DEPARTMENT);
        }

        public void ManageSocialByCatPage() {
            redirectBrowser(Pages.MANAGE_SOCIAL_BY_CATEGORY);
        }

        public void ManageSocialByProdPage() {
            redirectBrowser(Pages.MANAGE_SOCIAL_BY_PRODUCT);
        }

        public void ManageCCYearsPage() {
            redirectBrowser(Pages.MANAGE_CC_YEARS);
        }

        public void ManageUsersPage() {
            redirectBrowser(Pages.MANAGE_USERS);
        }

        public void UpdatingCurrenciesPage() {
            redirectBrowser(Pages.UPDATING_CURRENCIES);
        }

        public void ManageCurrenciesPage() {
            redirectBrowser(Pages.MANAGE_CURRENCIES);
        }

        public void ManageOrdersPage() {
            redirectBrowser(Pages.MANAGE_ORDERS);
        }

        public void ManageColorsPage(string name) {
            redirectBrowser(Pages.MANAGE_COLORS + QueryStringHelper.Instance.ProductColor(name));
        }

        public void ManageSizesPage(string name) {
            redirectBrowser(Pages.MANAGE_SIZES + QueryStringHelper.Instance.ProductSize(name));
        }

        public void CCProcessorPage(string orderID) {
            redirectBrowser(ApplicationHandler.Instance.CCAuthTarget + orderID);
        }

        public void OrdersPage() {
            redirectBrowser(Pages.ORDERS);
        }

        public void SetThemePage() {
            redirectBrowser(Pages.SET_THEME);
        }

    #endregion

        public void ReturnUrl(string userName, string returnUrl) {
            if(string.IsNullOrEmpty(returnUrl) || returnUrl.Contains("Default.aspx")) {
                HomePage(userName);
            } else {
                redirectBrowser(returnUrl);
            }
        }

        private void redirectBrowser(string url) {
            HttpContext.Current.Response.Redirect(url, true);
            return;
        }
    }
}