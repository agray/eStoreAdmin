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
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using eStoreAdminBLL;
using eStoreAdminDAL;
using phoenixconsulting.common;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.navigation;

namespace eStoreAdminWeb.Web.Advanced {
    public partial class ManageIncompleteItems : AuditBasePage {
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected string GetDepNavigateURL(object productCount, object categoryCount, string depID, string depName) {
            int prodCount = toInt(productCount);
            int catCount = toInt(categoryCount);
            DAL.CategoryRow category;

            if(catCount == 0) {
                //Go to Department to Add Categories
                return Pages.MANAGE_DEPARTMENT + QueryStringHelper.Instance.DepartmentLevel(toInt(depID), depName);
            }
            if(prodCount == 0) {
                //Go to first Category in Department to Add products
                category = new CategoriesBLL().GetFirst(toInt(depID));
                return Pages.MANAGE_CATEGORY + QueryStringHelper.Instance.CategoryLevel(category.ID, category.Name);
            }
            //Go to first Product that can be found to Add images
            category = new CategoriesBLL().FindFirstWithProduct(toInt(depID));
            DAL.ProductRow product = new ProductsBLL().GetFirst(category.ID);
            return Pages.MANAGE_PRODUCT_IMAGE + QueryStringHelper.Instance.ProductLevel(product.ID, product.Name);
        }

        protected string GetCatNavigateURL(string depID, string depName, string catID, string catName) {
            CategoriesBLL categoryBLL = new CategoriesBLL();
            ProductsBLL productsBLL = new ProductsBLL();
            if(categoryBLL.HasProducts(toInt(catID))) {
                //Go to first product found to Add images
                DAL.ProductRow product = productsBLL.GetFirst(toInt(catID));
                return Pages.MANAGE_PRODUCT_IMAGE + QueryStringHelper.Instance.ProductLevel(product.ID, product.Name);
            }
            //Go to Category to Add Products
            return Pages.MANAGE_CATEGORY + QueryStringHelper.Instance.CategoryLevel(toInt(catID), catName);
        }

        private HyperLink GetHyperLink(Control control, string id) {
            ControlFinder<HyperLink>.FindChildControlsRecursive(control, id);
            return ((List<HyperLink>)ControlFinder<HyperLink>.FoundControls)[0];
        }
    }
}