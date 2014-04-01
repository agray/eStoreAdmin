using System;
using System.Collections;
using System.IO;
using eStoreAdminBLL;
using NLog;
using NPOI.SS.UserModel;

namespace com.phoenixconsulting.npoi {
    public class ProductInventoryReader : NPOIReader {

        private const string sheetName = "ProductInventory";
        private const int numCols = 5;
        private string[] titles = { "Product ID", "Name", "Units In Stock", "Units On Order", "ReOrder Level" };
        private IRow row;
        private string prodID, unitsInStock, unitsOnOrder, reorderLevel;

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
            //    logger.Info("Expected Product Inventory file.  File provided does not have a valid structure.");
            //    return;
            //}

            //while(rows.MoveNext()) {
            //    row = (IRow)rows.Current;

            //    if(rowIsValid()) {
            //        validCount++;
            //        logger.Debug("Row " + row.RowNum.ToString() + " is valid.");

            //        if(updateInventoryRequirementsMet()) {
            //            //Both Primary Key and all Foreign Keys exist
            //            updateRow();
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
            logger.Info("Completed processing Product Inventory file. " +
                        validCount + " valid and, " + invalidCount + " invalid rows. " +
                        updatedCount + " updated and " + insertedCount + " inserted rows.");
        }

        private bool rowIsValid() {
            prodID = getCellValueAsString(row.GetCell(0));
            unitsInStock = getCellValueAsString(row.GetCell(2));
            unitsOnOrder = getCellValueAsString(row.GetCell(3));
            reorderLevel = getCellValueAsString(row.GetCell(4));

            try {
                if(Validator.validateInt(prodID.ToString()) &&
                   Validator.validateInt(unitsInStock.ToString()) &&
                   Validator.validateInt(unitsOnOrder.ToString()) &&
                   Validator.validateInt(reorderLevel.ToString())) {
                    return true;
                } else {
                    return false;
                }
            } catch(ArgumentException) {
                return false;
            }
        }

        private bool updateInventoryRequirementsMet() {
            ProductsBLL p = new ProductsBLL();
            return (p.PrimaryKeyExists(int.Parse(prodID)));
        }

        private void updateRow() {
            ProductsBLL p = new ProductsBLL();
            p.UpdateProductInventoryFromExcel(int.Parse(prodID), 
                                              int.Parse(unitsInStock), 
                                              int.Parse(unitsOnOrder), 
                                              int.Parse(reorderLevel));
        }
    }
}