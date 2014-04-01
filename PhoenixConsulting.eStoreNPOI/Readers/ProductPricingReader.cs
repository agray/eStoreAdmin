using System;
using System.Collections;
using System.IO;
using eStoreAdminBLL;
using NLog;
using NPOI.SS.UserModel;

namespace com.phoenixconsulting.npoi {
    public class ProductPricingReader : NPOIReader {

        private const string sheetName = "Pricing";
        private const int numCols = 5;
        private string[] titles = { "Product ID", "Name", "Retail Price ($)", "Sale Price ($)", "Wholesale Price ($)" };
        private IRow row;
        private string prodID, unitPrice, discountPrice, wholesalePrice;

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
            //    logger.Info("Expected Product Pricing file.  File provided does not have a valid structure.");
            //    return;
            //}

            //while(rows.MoveNext()) {
            //    row = (IRow)rows.Current;

            //    if(rowIsValid()) {
            //        validCount++;
            //        logger.Debug("Row " + row.RowNum.ToString() + " is valid.");

            //        if(updatePricingRequirementsMet()) {
            //            //Both Primary Key and all Foreign Keys exist
            //            updateRow(row);
            //            logger.Debug("Updated row " + row.RowNum.ToString() + ".");
            //            updatedCount++;
            //        } else {
            //            //Not enough correct data to process, skip
            //            logger.Info("Can't update row. Requirements not met.");
            //            continue;
            //        }
            //    } else {
            //        //at least one of the cells in the row is invalid
            //        invalidCount++;
            //        continue;
            //    }
            //}
            logger.Info("Completed processing Product Pricing file. " +
                        validCount + " valid and, " + invalidCount + " invalid rows. " +
                        updatedCount + " updated and " + insertedCount + " inserted rows.");
        }

        private bool updatePricingRequirementsMet() {
            ProductsBLL p = new ProductsBLL();
            return (p.PrimaryKeyExists(int.Parse(prodID)));
        }

        private bool rowIsValid() {
            prodID = getCellValueAsString(row.GetCell(0));
            unitPrice = getCellValueAsString(row.GetCell(2));
            discountPrice = getCellValueAsString(row.GetCell(3));
            wholesalePrice = getCellValueAsString(row.GetCell(4));

            try {
                if(Validator.validateInt(prodID.ToString()) &&
                   Validator.validateDouble(unitPrice.ToString()) &&
                   Validator.validateDouble(discountPrice.ToString()) &&
                   Validator.validateDouble(wholesalePrice.ToString())) {
                    return true;
                } else {
                    return false;
                }
            } catch(ArgumentException) {
                return false;
            }
        }

        private void updateRow(IRow row) {
            ProductsBLL p = new ProductsBLL();
            p.UpdateProductPricingFromExcel(int.Parse(prodID), 
                                            double.Parse(unitPrice), 
                                            double.Parse(discountPrice), 
                                            double.Parse(wholesalePrice));
        }
    }
}