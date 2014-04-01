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
using System.ComponentModel;
using eStoreAdminBLL.Base;
using eStoreAdminDAL;

namespace eStoreAdminBLL {
    [DataObject]
    public class CategoriesBLL : BaseBLL {
        private const int NUM_PRIMARY_KEYS = 1; //Primary Keys

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.CategoryDataTable GetSocialByDepId(int departmentID) {
            return BLLAdapter.Instance.CategoryAdapter.GetSocialByDepID(departmentID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.CategoryDataTable GetSocialById(int ID) {
            return BLLAdapter.Instance.CategoryAdapter.GetSocialByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public DAL.CategoryDataTable GetCategories() {
            return BLLAdapter.Instance.CategoryAdapter.GetCategories();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.CategoryDataTable GetCategoriesByDepartmentId(int departmentID) {
            return BLLAdapter.Instance.CategoryAdapter.GetCategoriesByDepartment(departmentID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public bool HasProducts(int categoryID) {
            return new ProductsBLL().GetProductsByCategoryId(categoryID).Count > 0;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.CategoryRow GetFirst(int departmentID) {
            return GetCategoriesByDepartmentId(departmentID)[0];
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.CategoryRow FindFirstWithProduct(int departmentID) {
            DAL.CategoryDataTable categories = GetCategoriesByDepartmentId(departmentID);
            foreach(DAL.CategoryRow category in categories) {
                if(HasProducts(category.ID)) {
                    return category;
                }
            }
            return null;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.CategoryDataTable GetCategoriesByDepartmentIdAndCurrencyId(int departmentID, int currencyID) {
            return BLLAdapter.Instance.CategoryAdapter.GetCategoriesByDepartmentIDAndCurrencyID(departmentID, currencyID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.CategoryDataTable GetCategoryById(int ID) {
            return BLLAdapter.Instance.CategoryAdapter.GetCategoryByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.CategoryDataTable GetMissingImages() {
            return BLLAdapter.Instance.CategoryAdapter.GetMissingImages();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public bool PrimaryKeyExists(int ID) {
            return (NUM_PRIMARY_KEYS == (int)BLLAdapter.Instance.CategoryAdapter.CategoryPrimaryKeyExists(ID));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public bool AddCategory(int original_ID, int depID, string name, string description,
                                string SEOTitle, string SEOKeywords,
                                string SEODescription, string SEOFriendlyNameURL) {
            DAL.CategoryDataTable categories = new DAL.CategoryDataTable();
            //Create a new CategoryRow instance
            DAL.CategoryRow category = categories.NewCategoryRow();

            category.DepID = depID;
            category.Name = name;
            category.Description = description;
            category.SEOTitle = SEOTitle;
            category.SEOKeywords = SEOKeywords;
            category.SEODescription = SEODescription;
            category.SEOFriendlyNameURL = SEOFriendlyNameURL;

            //Add the new Category
            categories.AddCategoryRow(category);
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.CategoryAdapter.Update(categories));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public bool UpdateCategory(int original_ID, string name, string description,
                                   string SEOTitle, string SEOKeywords,
                                   string SEODescription, string SEOFriendlyNameURL) {
            DAL.CategoryDataTable categories = BLLAdapter.Instance.CategoryAdapter.GetCategoryByID(original_ID);

            if (categories.Count == 0) {
                //No matching records found, return false
                return false;
            }

            categories.Rows[0]["Name"] = name;
            categories.Rows[0]["Description"] = description;
            categories.Rows[0]["SEOTitle"] = SEOTitle;
            categories.Rows[0]["SEOKeywords"] = SEOKeywords;
            categories.Rows[0]["SEODescription"] = SEODescription;
            categories.Rows[0]["SEOFriendlyNameURL"] = SEOFriendlyNameURL;

            //Update the department records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.CategoryAdapter.Update(categories));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, false)]
        public bool UpdateSocial(int original_ID, int AllHaveSN, string name, int hasSN, int CatID) {
            try {
                BLLAdapter.Instance.CategoryAdapter.CategoryUpdateSocial(original_ID, AllHaveSN);
            } catch (Exception) {
                return false;
            }

            //Return True if no exception thrown.
            return true;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public bool DeleteCategory(int original_ID) {
            //Delete the category records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.CategoryAdapter.Delete(original_ID));
        }
    }
}