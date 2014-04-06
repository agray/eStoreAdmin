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
using eStoreAdminBLL;
using com.phoenixconsulting.epplus.validators;

namespace phoenixconsulting.epplus.readers {
    public class ProductReader : BaseReader {

        private const string sheetName = "Products";
        private const int numCols = 20;
        private string[] titles = { "Product ID", "Department ID", "Category ID", "Brand ID", "Supplier ID", "Name",
                                    "Description", "Retail Price ($)", "Sale Price ($)", "Wholesale Price ($)", 
                                    "Quantity Per Unit", "Weight (KG)", "Active?", "On Sale?", "Units In Stock",
                                    "Units On Order", "ReOrder Level", "SEO Title", "SEO Keywords", "SEO Description", "SEO Friendly Name"};
        private ExcelRow row;
        private string prodID, depID, catID, brandID, productName, description, supplierID, quantityPerUnit, unitsOnOrder, reorderLevel;
        private string unitPrice, discountPrice, wholesalePrice;
        private string weight, unitsInStock;
        private string isActive, isOnSale;
        private string seoTitle, seoKeywords, seoDescription, seoFriendlyName;

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
            //    logger.Info("Expected Product file.  File provided does not have a valid structure.");
            //    return;
            //}

            //while(rows.MoveNext()) {
            //    row = (IRow)rows.Current;

            //    if(rowIsValid()) {
            //        validCount++;
            //        logger.Debug("Row " + row.RowNum.ToString() + " is valid.");

            //        if(updateProductRequirementsMet()) {
            //            //Both Primary Key and all Foreign Keys exist
            //            updateRow();
            //            logger.Debug("Updated row " + row.RowNum.ToString() + ".");
            //            updatedCount++;
            //        } else {
            //            if(insertProductRequirementsMet()) {
            //                //Only Foreign Keys exist
            //                insertRow();
            //                logger.Debug("Inserted row " + row.RowNum.ToString() + ".");
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
            logger.Info("Completed processing Product file. " +
                        validCount + " valid and, " + invalidCount + " invalid rows. " +
                        updatedCount + " updated and " + insertedCount + " inserted rows.");
        }

        private bool updateProductRequirementsMet() {
            ProductsBLL p = new ProductsBLL();
            return (p.PrimaryKeyExists(int.Parse(prodID)) &&
                    p.ForeignKeysExist(int.Parse(depID), int.Parse(catID), int.Parse(supplierID), int.Parse(brandID)));
        }

        private bool insertProductRequirementsMet() {
            ProductsBLL p = new ProductsBLL();
            return (!(p.PrimaryKeyExists(int.Parse(prodID)) &&
                    p.ForeignKeysExist(int.Parse(depID), int.Parse(catID), int.Parse(supplierID), int.Parse(brandID))));
        }

        //private bool rowIsValid() {
        //    prodID = GetCellValueAsString(row.GetCell(0));
        //    depID = GetCellValueAsString(row.GetCell(1));
        //    catID = GetCellValueAsString(row.GetCell(2));
        //    brandID = GetCellValueAsString(row.GetCell(3));
        //    supplierID = GetCellValueAsString(row.GetCell(4));
        //    productName = GetCellValueAsString(row.GetCell(5));
        //    description = GetCellValueAsString(row.GetCell(6));
        //    unitPrice = GetCellValueAsString(row.GetCell(7));
        //    discountPrice = GetCellValueAsString(row.GetCell(8));
        //    wholesalePrice = GetCellValueAsString(row.GetCell(9));
        //    quantityPerUnit = GetCellValueAsString(row.GetCell(10));
        //    weight = GetCellValueAsString(row.GetCell(11));
        //    isActive = GetCellValueAsString(row.GetCell(12));
        //    isOnSale = GetCellValueAsString(row.GetCell(13));
        //    unitsInStock = GetCellValueAsString(row.GetCell(14));
        //    unitsOnOrder = GetCellValueAsString(row.GetCell(15));
        //    reorderLevel = GetCellValueAsString(row.GetCell(16));
        //    seoTitle = GetCellValueAsString(row.GetCell(17));
        //    seoKeywords = GetCellValueAsString(row.GetCell(18));
        //    seoDescription = GetCellValueAsString(row.GetCell(19));
        //    seoFriendlyName = GetCellValueAsString(row.GetCell(20));

        //    try {
        //        return Validator.ValidateInt(prodID) &&
        //               Validator.ValidateInt(depID) &&
        //               Validator.ValidateInt(catID) &&
        //               Validator.ValidateInt(brandID) &&
        //               Validator.ValidateInt(supplierID) &&
        //               Validator.ValidateDouble(unitPrice) &&
        //               Validator.ValidateDouble(discountPrice) &&
        //               Validator.ValidateDouble(wholesalePrice) &&
        //               Validator.ValidateInt(quantityPerUnit) &&
        //               Validator.ValidateDouble(weight) &&
        //               (isActive.Equals("Yes") || isActive.Equals("No")) &&
        //               (isOnSale.Equals("Yes") || isOnSale.Equals("No")) &&
        //               Validator.ValidateInt(unitsInStock) &&
        //               Validator.ValidateInt(unitsOnOrder) &&
        //               Validator.ValidateInt(reorderLevel) &&
        //               Validator.ValidateAlpha(seoTitle) &&
        //               Validator.ValidateAlpha(seoKeywords) &&
        //               Validator.ValidateAlpha(seoDescription) &&
        //               Validator.ValidateAlpha(seoFriendlyName);
        //    } catch (ArgumentException) {
        //        return false;
        //    }
        //}

        private void updateRow() {
            ProductsBLL p = new ProductsBLL();
            p.UpdateProduct(int.Parse(prodID), int.Parse(brandID), productName, description, int.Parse(supplierID), 
                            int.Parse(quantityPerUnit), double.Parse(unitPrice), double.Parse(weight), int.Parse(unitsInStock),
                            int.Parse(unitsOnOrder), int.Parse(reorderLevel), isActive.Equals("Yes") ? 1 : 0, 
                            isOnSale.Equals("Yes") ? 1 : 0, double.Parse(discountPrice), double.Parse(wholesalePrice), 
                            seoTitle, seoKeywords, seoDescription, seoFriendlyName);
        }

        private void insertRow() {
            ProductsBLL p = new ProductsBLL();
            p.AddProduct(int.Parse(prodID), int.Parse(depID), int.Parse(catID), int.Parse(brandID), productName, description, 
                         int.Parse(supplierID), int.Parse(quantityPerUnit), double.Parse(unitPrice), 
                         double.Parse(weight), int.Parse(unitsInStock), int.Parse(unitsOnOrder),
                         int.Parse(reorderLevel), isActive.Equals("Yes") ? 1 : 0,
                         isOnSale.Equals("Yes") ? 1 : 0, double.Parse(discountPrice), double.Parse(wholesalePrice), 
                         seoTitle, seoKeywords, seoDescription, seoFriendlyName);
        }
    }
}