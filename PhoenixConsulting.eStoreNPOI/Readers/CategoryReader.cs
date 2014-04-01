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
using System;
using System.Collections;
using System.IO;
using eStoreAdminBLL;
using NLog;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace com.phoenixconsulting.npoi {
    public class CategoryReader : NPOIReader {
        private const string sheetName = "Category";
        private const int numCols = 7;
        private string[] titles = { "Category ID", "Name", "Description", "SEO Title", "SEO Keywords", "SEO Description", "SEO Friendly Name" };
        private IRow row;
        private int categoryID;
        private string name, description, seoTitle, seoKeywords, seoDescription, seoFriendlyName;

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
            //    logger.Info("Expected Category file.  File provided does not have a valid structure.");
            //    return;
            //}

            //while(rows.MoveNext()) {
            //    row = (IRow)rows.Current;

            //    if(!rowIsValid()) {
            //        //at least one of the cells in the row is invalid
            //        invalidCount++;
            //        continue;
            //    } else {
            //        validCount++;
            //        logger.Debug("Row " + row.RowNum.ToString() + " is valid.");

            //        if(updateCategoryRequirementsMet()) {
            //            //Both Primary Key and all Foreign Keys exist
            //            updateRow();
            //            logger.Debug("Updated row " + row.RowNum.ToString() + ".");
            //            updatedCount++;
            //        } else {
            //            //Not enough correct data to process, skip
            //            logger.Info("Can't update row. Requirements not met.");
            //            continue;
            //        }   
            //    }
            //}
            logger.Info("Completed processing Category file. " +
                        validCount + " valid and, " + invalidCount + " invalid rows. " +
                        updatedCount + " updated and " + insertedCount + " inserted rows.");
        }

        private bool updateCategoryRequirementsMet() {
            CategoriesBLL c = new CategoriesBLL();
            return (c.PrimaryKeyExists(categoryID));
        }

        private bool rowIsValid() {
            categoryID = int.Parse(getCellValueAsString(row.GetCell(0)));
            name = getCellValueAsString(row.GetCell(1));
            description = getCellValueAsString(row.GetCell(2));
            seoTitle = getCellValueAsString(row.GetCell(3));
            seoKeywords = getCellValueAsString(row.GetCell(4));
            seoDescription = getCellValueAsString(row.GetCell(5));
            seoFriendlyName = getCellValueAsString(row.GetCell(6));

            try {
                return Validator.validateInt(categoryID.ToString()) &&
                       Validator.validateAlpha(name) &&
                       Validator.validateAlpha(description) &&
                       Validator.validateAlpha(seoTitle) &&
                       Validator.validateAlpha(seoKeywords) &&
                       Validator.validateAlpha(seoDescription) &&
                       Validator.validateAlpha(seoFriendlyName);
            } catch(ArgumentException) {
                return false;
            }
        }

        private void updateRow() {
            CategoriesBLL c = new CategoriesBLL();
            c.UpdateCategory(categoryID, name, description,
                             seoTitle, seoKeywords, 
                             seoDescription, seoFriendlyName);
        }
    }
}