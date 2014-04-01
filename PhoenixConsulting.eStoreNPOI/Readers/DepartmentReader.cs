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
using NPOI.SS.UserModel;

namespace com.phoenixconsulting.npoi {
    public class DepartmentReader : NPOIReader {
        private const string sheetName = "Department";
        private const int numCols = 6;
        private string[] titles = { "Department ID", "Name", "SEO Title", "SEO Keywords", "SEO Description", "SEO Friendly Name" };
        private IRow row;
        private int departmentID;
        private string name, seoTitle, seoKeywords, seoDescription, seoFriendlyName;

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
            //    logger.Info("Expected Department file.  File provided does not have a valid structure.");
            //    return;
            //}

        //    while(rows.MoveNext()) {
        //        row = (IRow)rows.Current;

        //        if(!rowIsValid()) {
        //            //at least one of the cells in the row is invalid
        //            invalidCount++;
        //            continue;
        //        } else {
        //            validCount++;
        //            logger.Debug("Row " + row.RowNum.ToString() + " is valid.");

        //            if(updateDepartmentRequirementsMet()) {
        //                //Both Primary Key and all Foreign Keys exist
        //                updateRow();
        //                logger.Debug("Updated row " + row.RowNum.ToString() + ".");
        //                updatedCount++;
        //            } else {
        //                //Not enough correct data to process, skip
        //                logger.Info("Can't update row. Requirements not met.");
        //                continue;
        //            }   
        //        }
        //    }
            logger.Info("Completed processing Department file. " +
                        validCount + " valid and, " + invalidCount + " invalid rows. " +
                        updatedCount + " updated and " + insertedCount + " inserted rows.");
        }

        private bool updateDepartmentRequirementsMet() {
            DepartmentsBLL d = new DepartmentsBLL();
            return (d.PrimaryKeyExists(departmentID));
        }

        private bool rowIsValid() {
            departmentID = int.Parse(getCellValueAsString(row.GetCell(0)));
            name = getCellValueAsString(row.GetCell(1));
            seoTitle = getCellValueAsString(row.GetCell(2));
            seoKeywords = getCellValueAsString(row.GetCell(3));
            seoDescription = getCellValueAsString(row.GetCell(4));
            seoFriendlyName = getCellValueAsString(row.GetCell(5));

            try {
                if(Validator.validateInt(departmentID.ToString()) &&
                   Validator.validateAlpha(name) &&
                   Validator.validateAlpha(seoTitle) &&
                   Validator.validateAlpha(seoKeywords) &&
                   Validator.validateAlpha(seoDescription) &&
                   Validator.validateAlpha(seoFriendlyName)) {
                    return true;
                } else {
                    return false;
                }
            } catch(ArgumentException) {
                return false;
            }
        }

        private void updateRow() {
            DepartmentsBLL d = new DepartmentsBLL();
            d.UpdateDepartment(departmentID, name,
                               seoTitle, seoKeywords, 
                               seoDescription, seoFriendlyName);
        }
    }
}