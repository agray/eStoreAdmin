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
using System.ComponentModel;
using eStoreAdminBLL.Base;
using eStoreAdminDAL;

namespace eStoreAdminBLL {
    [DataObject]
    public class SuppliersBLL : BaseBLL {
        private const int NUM_PRIMARY_KEYS = 1; //Primary Keys

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public DAL.SupplierDataTable GetSuppliers() {
            return BLLAdapter.Instance.SupplierAdapter.GetSuppliers();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.SupplierDataTable GetSupplierById(int ID) {
            return BLLAdapter.Instance.SupplierAdapter.GetSupplierByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public bool PrimaryKeyExists(int ID) {
            return (NUM_PRIMARY_KEYS == (int)BLLAdapter.Instance.SupplierAdapter.SupplierPrimaryKeyExists(ID));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public bool AddSupplier(string companyName,
                                string contactName,
                                string businessPhone,
                                string mobilePhone,
                                string emailAddress,
                                string address,
                                string citySuburb,
                                string stateProvinceRegion,
                                int zipPostcode,
                                string country) {
            DAL.SupplierDataTable suppliers = new DAL.SupplierDataTable();
            //Create a new SupplierRow instance
            DAL.SupplierRow supplier = suppliers.NewSupplierRow();

            supplier.CompanyName = companyName;
            supplier.ContactName = contactName;
            supplier.BusinessPhone = businessPhone;
            supplier.MobilePhone = mobilePhone;
            supplier.EmailAddress = emailAddress;
            supplier.Address = address;
            supplier.CitySuburb = citySuburb;
            supplier.StateProvinceRegion = stateProvinceRegion;
            supplier.ZipPostcode = zipPostcode;
            supplier.Country = country;

            //Add the new Supplier
            suppliers.AddSupplierRow(supplier);
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.SupplierAdapter.Update(suppliers));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public bool UpdateSupplier(int original_ID, string companyName,
                                   string contactName, string businessPhone,
                                   string mobilePhone, string emailAddress,
                                   string address, string citySuburb,
                                   string stateProvinceRegion, int zipPostcode,
                                   string country) {
            DAL.SupplierDataTable suppliers = BLLAdapter.Instance.SupplierAdapter.GetSupplierByID(original_ID);

            if (suppliers.Count == 0) {
                //No matching records found, return false
                return false;
            }

            suppliers.Rows[0]["CompanyName"] = companyName;
            suppliers.Rows[0]["ContactName"] = contactName;
            suppliers.Rows[0]["BusinessPhone"] = businessPhone;
            suppliers.Rows[0]["MobilePhone"] = mobilePhone;
            suppliers.Rows[0]["EmailAddress"] = emailAddress;
            suppliers.Rows[0]["Address"] = address;
            suppliers.Rows[0]["CitySuburb"] = citySuburb;
            suppliers.Rows[0]["StateProvinceRegion"] = stateProvinceRegion;
            suppliers.Rows[0]["ZipPostcode"] = zipPostcode;
            suppliers.Rows[0]["Country"] = country;

            //Update the product records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.SupplierAdapter.Update(suppliers));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public bool DeleteSupplier(int original_ID) {
            //Delete the Supplier records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.SupplierAdapter.Delete(original_ID));
        }
    }
}