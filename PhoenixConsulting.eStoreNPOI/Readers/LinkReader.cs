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
    public class LinkReader : NPOIReader {
        Logger logger = LogManager.GetLogger("TraceFileAndEventLogger");

        private const string sheetName = "Links";
        private const int numCols = 5;
        private string[] titles = {"Link ID", "URL", "Hyperlink Text", "Description", "Type"};
        private IRow row;

        private string linkID, linkURL, linkText, linkDescription, linkType;

        public void read(Stream content) {
            InitializeWorkbook(content);
        }
        
        public void processFile(Stream fileContent) {    
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
            //    logger.Info("Expected Link file.  File provided does not have a valid structure.");
            //    return;
            //}

            //while(rows.MoveNext()) {
            //    row = (IRow)rows.Current;

            //    if(rowIsValid()) {
            //        validCount++;
            //        logger.Debug("Row " + row.RowNum.ToString() + " is valid.");

            //        if(updateLinkRequirementsMet()) {
            //            //Both Primary Key and all Foreign Keys exist
            //            updateRow();
            //            logger.Debug("Updated row " + row.RowNum.ToString() + ".");
            //            updatedCount++;
            //        } else {
            //            if(insertLinkRequirementsMet()) {
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
            logger.Info("Completed processing Link file. " +
                        validCount + " valid and, " + invalidCount + " invalid rows. " +
                        updatedCount + " updated and " + insertedCount + " inserted rows.");
        }

        private bool updateLinkRequirementsMet() {
            LinkBLL l = new LinkBLL();
            return (l.PrimaryKeyExists(int.Parse(linkID)));
        }

        private bool insertLinkRequirementsMet() {
            LinkBLL l = new LinkBLL();
            return (!(l.PrimaryKeyExists(int.Parse(linkID))));
        }

        private bool rowIsValid() {
            linkID = getCellValueAsString(row.GetCell(0));
            linkURL = getCellValueAsString(row.GetCell(1));
            linkText = getCellValueAsString(row.GetCell(2));
            linkDescription = getCellValueAsString(row.GetCell(3));
            linkType = getCellValueAsString(row.GetCell(4));

            try {
                if(Validator.validateInt(linkID.ToString()) &&
                   Validator.validateURL(linkURL) &&
                   Validator.validateLinkType(linkType)) {
                    return true;
                } else {
                    return false;
                }
            } catch (ArgumentException){
                return false;
            }
        }

        private void updateRow() {
            LinkBLL l = new LinkBLL();
            l.UpdateLink(int.Parse(linkID), linkURL, linkText, linkDescription, linkType);
        }

        private void insertRow() {
            LinkBLL l = new LinkBLL();
            l.AddLink(linkURL, linkText, linkDescription, linkType);
        }
    }
}