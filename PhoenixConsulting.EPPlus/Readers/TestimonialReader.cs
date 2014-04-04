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

namespace phoenixconsulting.epplus.readers {
    public class TestimonialReader : BaseReader {

        private const string sheetName = "Testimonials";
        private const int numCols = 4;
        private string[] titles = { "Testimonial ID", "Customer Name", "Customer Country", "Testimonial Text" };
        private ExcelRow row;
        private int testimonialID;
        private string customerName, customerCountry, testimonialText;

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
            //    logger.Info("Expected Testimonial file.  File provided does not have a valid structure.");
            //    return;
            //}

            //while(rows.MoveNext()) {
            //    row = (IRow)rows.Current;

            //    if(rowIsValid()) {
            //        validCount++;
            //        logger.Debug("Row " + row.RowNum.ToString() + " is valid.");

            //        if(updateTestimonialRequirementsMet()) {
            //            //Both Primary Key and all Foreign Keys exist
            //            updateRow();
            //            logger.Debug("Updated row " + row.RowNum.ToString() + ".");
            //            updatedCount++;
            //        } else {
            //            if(insertTestimonialRequirementsMet()) {
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
            logger.Info("Completed processing Testimonial file. " +
                        validCount + " valid and, " + invalidCount + " invalid rows. " +
                        updatedCount + " updated and " + insertedCount + " inserted rows.");
        }

        private bool updateTestimonialRequirementsMet() {
            TestimonialBLL t = new TestimonialBLL();
            return (t.PrimaryKeyExists(testimonialID));
        }

        private bool insertTestimonialRequirementsMet() {
            TestimonialBLL t = new TestimonialBLL();
            return (!(t.PrimaryKeyExists(testimonialID)));
        }

        private bool rowIsValid() {
            testimonialID = int.Parse(getCellValueAsString(row.GetCell(0)));
            customerName = getCellValueAsString(row.GetCell(1));
            customerCountry = getCellValueAsString(row.GetCell(2));
            testimonialText = getCellValueAsString(row.GetCell(3));

            try {
                if(Validator.validateInt(testimonialID.ToString()) &&
                   Validator.validateAlpha(customerName) &&
                   Validator.validateAlpha(customerCountry)) {
                    return true;
                } else {
                    return false;
                }
            } catch (ArgumentException){
                return false;
            }
        }

        private void updateRow() {
            TestimonialBLL t = new TestimonialBLL();
            t.UpdateTestimonial(testimonialID, customerName, customerCountry, testimonialText);
        }

        private void insertRow() {
            TestimonialBLL t = new TestimonialBLL();
            t.AddTestimonial(customerName, customerCountry, testimonialText);
        }
    }
}