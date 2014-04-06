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
using System.IO;
using OfficeOpenXml;
using phoenixconsulting.epplus.Base;
using NLog;
using com.phoenixconsulting.epplus.validators;
using eStoreAdminBLL;

namespace phoenixconsulting.epplus.readers {
    public class SupplierReader : BaseReader {

        private const string sheetName = "Suppliers";   
        private ExcelRow row;
        private const int numCols = 11;
        private string[] titles = { "Supplier ID", "Company Name", "Contact Name", "Address", 
                                    "City / Suburb","State", "Zip / Postcode", "Country", 
                                    "Business Phone", "Mobile Phone", "Email"};
        private string supplierID, zipPostcode;
        private string companyName, contactName, address, citySuburb, stateProvinceRegion;
        private string country, emailAddress, businessPhone, mobilePhone;

        public void processFile(Stream fileContent) {
            Logger logger = LogManager.GetLogger("TraceFileAndEventLogger");
            int validCount, invalidCount, updatedCount, insertedCount;
            validCount = invalidCount = updatedCount = insertedCount = 0;

            //IEnumerator rows = getRowEnumerator(fileContent, sheetName);

            //if(rows == null) {
            //    logger.Info("File is empty. End Processing.");
            //    return;
            //}

            //Priming step to move pointer to first row - the title row.
            //rows.MoveNext();

            //if(!Validator.isCorrectStructure((IRow)rows.Current, numCols, titles)) {
            //    logger.Info("Expected Supplier file.  File provided does not have a valid structure.");
            //    return;
            //}

            //while(rows.MoveNext()) {
            //    row = (IRow)rows.Current;

            //    if(rowIsValid()) {
            //        validCount++;
            //        logger.Debug("Row " + row.RowNum.ToString() + " is valid.");

            //        if(updateSupplierRequirementsMet()) {
            //            //Both Primary Key and all Foreign Keys exist
            //            updateRow();
            //            logger.Debug("Updated row " + row.RowNum.ToString() + ".");
            //            updatedCount++;
            //        } else {
            //            if(insertSupplierRequirementsMet()) {
            //                //Only Foreign Keys exist
            //                insertRow();
            //                logger.Info("Inserted row " + row.RowNum.ToString() + ".");
            //                insertedCount++;
            //            } else {
            //                //Not enough correct data to process, skip
            //                logger.Info("Can't insert or update row. Requirements for either not met.");
            //                continue;
            //            }
            //        }
            //    } else {
            //        //at least one of the cells in the row is invalid
            //        invalidCount++;
            //        continue;
            //    }
            //}
            logger.Info("Completed processing Supplier file. " + 
                        validCount + " valid and, " + invalidCount + " invalid rows. " + 
                        updatedCount + " updated and " + insertedCount + " inserted rows.");
        }

        private bool updateSupplierRequirementsMet() {
            SuppliersBLL s = new SuppliersBLL();
            return (s.PrimaryKeyExists(int.Parse(supplierID)));
        }

        private bool insertSupplierRequirementsMet() {
            SuppliersBLL s = new SuppliersBLL();
            return (!(s.PrimaryKeyExists(int.Parse(supplierID))));
        }

        //private bool rowIsValid() {
        //    supplierID = GetCellValueAsString(row.GetCell(0));
        //    companyName = GetCellValueAsString(row.GetCell(1));
        //    contactName = GetCellValueAsString(row.GetCell(2));
        //    address = GetCellValueAsString(row.GetCell(3));
        //    citySuburb = GetCellValueAsString(row.GetCell(4));
        //    stateProvinceRegion = GetCellValueAsString(row.GetCell(5));
        //    zipPostcode = GetCellValueAsString(row.GetCell(6));
        //    country = GetCellValueAsString(row.GetCell(7));
        //    businessPhone = GetCellValueAsString(row.GetCell(8));
        //    mobilePhone = GetCellValueAsString(row.GetCell(9));
        //    emailAddress = GetCellValueAsString(row.GetCell(10));

        //    try {
        //        return Validator.ValidateInt(supplierID.ToString()) &&
        //               Validator.ValidateAlpha(companyName) &&
        //               Validator.ValidateAlpha(contactName) &&
        //               Validator.ValidateAlpha(address) &&
        //               Validator.ValidateAlpha(citySuburb) &&
        //               Validator.ValidateAlpha(stateProvinceRegion) &&
        //               Validator.ValidateDouble(zipPostcode.ToString()) &&
        //               Validator.ValidateAlpha(country) &&
        //               Validator.ValidateDouble(businessPhone) &&
        //               Validator.ValidateDouble(mobilePhone) &&
        //               Validator.ValidateEmail(emailAddress);
        //    } catch (ArgumentException){
        //        return false;
        //    }
        //}

        private void updateRow() {
            SuppliersBLL s = new SuppliersBLL();
            s.UpdateSupplier(int.Parse(supplierID), companyName, contactName, businessPhone, mobilePhone, 
                             emailAddress, address, citySuburb, stateProvinceRegion,
                             int.Parse(zipPostcode), country);
        }

        private void insertRow() {
            SuppliersBLL s = new SuppliersBLL();
            s.AddSupplier(companyName, contactName, businessPhone, mobilePhone, 
                          emailAddress, address, citySuburb, stateProvinceRegion, 
                          int.Parse(zipPostcode), country);
        }
    }
}