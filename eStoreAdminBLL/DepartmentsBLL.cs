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
    public class DepartmentsBLL : BaseBLL {
        private const int NUM_PRIMARY_KEYS = 1; //Primary Keys

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.DepartmentDataTable GetSocial() {
            return BLLAdapter.Instance.DepartmentAdapter.GetSocial();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.DepartmentDataTable GetSocialById(int ID) {
            return BLLAdapter.Instance.DepartmentAdapter.GetSocialByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public DAL.DepartmentDataTable GetDepartments() {
            return BLLAdapter.Instance.DepartmentAdapter.GetDepartments();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.DepartmentDataTable GetDepartmentById(int ID) {
            return BLLAdapter.Instance.DepartmentAdapter.GetDepartmentByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.DepartmentDataTable GetDepartmentDetailsByDepartmentIdAndCurrencyId(int departmentID, int currencyID) {
            return BLLAdapter.Instance.DepartmentAdapter.GetDepartmentDetailsByDepartmentAndCurrency(departmentID, currencyID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.DepartmentDataTable GetMissingImages() {
            return BLLAdapter.Instance.DepartmentAdapter.GetMissingImages();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public bool PrimaryKeyExists(int ID) {
            return (NUM_PRIMARY_KEYS == (int)BLLAdapter.Instance.DepartmentAdapter.DepartmentPrimaryKeyExists(ID));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public bool AddDepartment(string Name, string SEOTitle, string SEOKeywords,
                                  string SEODescription, string SEOFriendlyNameURL) {
            //Create a new DepartmentRow instance
            DAL.DepartmentDataTable departments = new DAL.DepartmentDataTable();
            DAL.DepartmentRow department = departments.NewDepartmentRow();

            department.Name = Name;
            department.SEOTitle = SEOTitle;
            department.SEOKeywords = SEOKeywords;
            department.SEODescription = SEODescription;
            department.SEOFriendlyNameURL = SEOFriendlyNameURL;

            //Add the new Department
            departments.AddDepartmentRow(department);
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.DepartmentAdapter.Update(departments));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public bool UpdateDepartment(int original_ID, string Name,
                                     string SEOTitle, string SEOKeywords,
                                     string SEODescription, string SEOFriendlyNameURL) {
            DAL.DepartmentDataTable departments = BLLAdapter.Instance.DepartmentAdapter.GetDepartmentByID(original_ID);

            if (departments.Count == 0) {
                //No matching records found, return false
                return false;
            }

            departments.Rows[0]["Name"] = Name;
            //departments.Rows[0]["Description"] = Name;
            departments.Rows[0]["SEOTitle"] = SEOTitle;
            departments.Rows[0]["SEOKeywords"] = SEOKeywords;
            departments.Rows[0]["SEODescription"] = SEODescription;
            departments.Rows[0]["SEOFriendlyNameURL"] = SEOFriendlyNameURL;

            //Update the department records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.DepartmentAdapter.Update(departments));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, false)]
        public bool UpdateSocial(int original_ID, int AllHaveSN, string name, int hasSN, int DepID) {
            try {
                BLLAdapter.Instance.DepartmentAdapter.DepartmentUpdateSocial(original_ID, AllHaveSN);
            } catch (Exception) {
                return false;
            }

            //Return True if no exception thrown.
            return true;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public bool DeleteDepartment(int original_ID) {
            //Update the department records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.DepartmentAdapter.Delete(original_ID));
        }
    }
}