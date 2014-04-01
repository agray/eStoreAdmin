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

namespace phoenixconsulting.common.navigation {
    public class Pages : BasePage {
        public const string ERROR = ROOT_DIR + "Error.aspx";
        public const string REGISTER = ROOT_DIR + "Home/Register.aspx";
        public const string SEARCH = ROOT_DIR + "Search.aspx";
        public const string MANAGE_DEPARTMENTS = ROOT_DIR + "Web/Merchandise/Departments/ManageDepartments.aspx";
        public const string MANAGE_DEPARTMENT = ROOT_DIR + "Web/Merchandise/Department/ManageDepartment.aspx";
        public const string MANAGE_DEPARTMENT_IMAGE = ROOT_DIR + "Web/Merchandise/Department/ManageImage.aspx";
        public const string ADD_DEPARTMENT = "AddDepartment.aspx";
        public const string ADD_CATEGORY = "AddCategory.aspx";
        public const string MANAGE_CATEGORY_IMAGE = ROOT_DIR + "Web/Merchandise/Category/ManageImage.aspx";
        public const string MANAGE_CATEGORY = ROOT_DIR + "Web/Merchandise/Category/ManageCategory.aspx";
        public const string MANAGE_PRODUCT = ROOT_DIR + "Web/Merchandise/Product/ManageProduct.aspx";
        public const string ADD_PRODUCT = ROOT_DIR + "Web/Merchandise/Category/AddProduct.aspx";
        public const string MANAGE_PRODUCT_IMAGE = ROOT_DIR + "Web/Merchandise/Product/ManageImage.aspx";
        public const string IMPORT_EXPORT_HOME = ROOT_DIR + "Web/ImportExport/ImportExportHome.aspx";
        public const string MANAGE_COLORS = "ManageColors.aspx";
        public const string MANAGE_WORDS = "ManageWords.aspx";
        public const string MANAGE_COUNTRIES = "ManageCountries.aspx";
        public const string MANAGE_SOCIAL_BY_DEPARTMENT = "ManageSocialByDep.aspx";
        public const string MANAGE_SOCIAL_BY_CATEGORY = "ManageSocialByCat.aspx";
        public const string MANAGE_SOCIAL_BY_PRODUCT = "ManageSocialByProd.aspx";
        public const string MANAGE_CC_YEARS = "ManageCCYears.aspx";
        public const string MANAGE_USERS = "ManageUsers.aspx";
        public const string UPDATING_CURRENCIES = "UpdatingCurrencies.aspx";
        public const string MANAGE_CURRENCIES = "ManageCurrencies.aspx";
        public const string MANAGE_ORDERS = "ManageOrders.aspx";
        public const string MANAGE_SIZES = "ManageSizes.aspx";
        public const string ORDERS = "Orders.aspx";
        public const string SET_THEME = "SetTheme.aspx";
        public const string NO_ROLES = ROOT_DIR + "Authentication/NoRoles.aspx";
        
        public const string REPORT_MASTER = ROOT_DIR + "MasterPages/ReportMaster.Master";
        public const string DASHBOARD_MASTER = ROOT_DIR + "MasterPages/DashboardMaster.Master";
        public const string LOGIN_MASTER = ROOT_DIR + "MasterPages/eStoreAdminLoginMaster.Master";
        public const string ADMIN_MASTER = ROOT_DIR + "MasterPages/eStoreAdminMaster.Master";
        public const string MERCHANDISE_MASTER = ROOT_DIR + "MasterPages/MerchandiseMaster.Master";
    }
}