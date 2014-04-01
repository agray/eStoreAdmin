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
    public class ProductsBLL : BaseBLL {
        private const int NUM_PRIMARY_KEYS = 1; //Primary Keys
        private const int NUM_FOREIGN_KEYS = 4;//Foreign Keys

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public DAL.ProductDataTable GetProducts() {
            return BLLAdapter.Instance.ProductAdapter.GetProducts();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ProductDataTable GetProductByIdAndCurrencyId(int ID, int currencyID) {
            return BLLAdapter.Instance.ProductAdapter.GetProductByIDAndCurrency(ID, currencyID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ProductDataTable GetSocialByCatId(int categoryID) {
            return BLLAdapter.Instance.ProductAdapter.GetSocialByCatID(categoryID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ProductDataTable GetSocialById(int ID) {
            return BLLAdapter.Instance.ProductAdapter.GetSocialByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ProductDataTable GetMissingImages() {
            return BLLAdapter.Instance.ProductAdapter.GetMissingImages();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ProductDataTable GetMissingNames() {
            return BLLAdapter.Instance.ProductAdapter.GetMissingNames();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public bool PrimaryKeyExists(int ID) {
            return (NUM_PRIMARY_KEYS == (int)BLLAdapter.Instance.ProductAdapter.ProductPrimaryKeyExists(ID));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public bool ForeignKeysExist(int depID, int catID, int supplierID, int brandID) {
            //TODO: Fix this
            return (NUM_FOREIGN_KEYS == (int)BLLAdapter.Instance.ProductAdapter.ProductForeignKeysExist(depID, catID, supplierID, brandID));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ProductDataTable GetProductsByCategoryId(int categoryID) {
            return BLLAdapter.Instance.ProductAdapter.GetProductsByCategory(categoryID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ProductRow GetFirst(int categoryID) {
            return GetProductsByCategoryId(categoryID)[0];
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ProductRow FindFirstInDepartment(int departmentID) {
            CategoriesBLL categoriesBLL = new CategoriesBLL();
            DAL.ProductRow product = null;
            DAL.CategoryDataTable categories = categoriesBLL.GetCategoriesByDepartmentId(departmentID);
            foreach(DAL.CategoryRow category in categories) {
                if(categoriesBLL.HasProducts(category.ID)) {
                    product = new ProductsBLL().GetFirst(category.ID);
                }
            }
            return product;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ProductDataTable GetProductsByCategoryIdAndCurrId(int categoryID, int currencyID) {
            return BLLAdapter.Instance.ProductAdapter.GetProductsByCategoryAndCurrency(categoryID, currencyID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ProductDataTable GetProductById(int ID) {
            return BLLAdapter.Instance.ProductAdapter.GetProductByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public bool AddProduct(int original_ID,
                               int depID,
                               int catID,
                               int brandID,
                               string name,
                               string description,
                               int supplierID,
                               int quantityPerUnit,
                               double unitPrice,
                               double weight,
                               int unitsInStock,
                               int unitsOnOrder,
                               int reOrderLevel,
                               int active,
                               int isOnSale,
                               double discountUnitPrice,
                               double wholesalePrice,
                               string SEOTitle, 
                               string SEOKeywords,
                               string SEODescription, 
                               string SEOFriendlyNameURL) {
            DAL.ProductDataTable products = new DAL.ProductDataTable();
            //Create a new ProductRow instance
            DAL.ProductRow product = products.NewProductRow();

            product.DepID = depID;
            product.CatID = catID;
            product.BrandID = brandID;
            product.Name = name;
            product.Description = description;
            product.SupplierID = supplierID;
            product.QuantityPerUnit = quantityPerUnit;
            product.UnitPrice = (decimal)unitPrice;
            product.Weight = weight;
            product.UnitsInStock = unitsInStock;
            product.UnitsOnOrder = unitsOnOrder;
            product.ReOrderLevel = reOrderLevel;
            product.Active = active;
            product.IsOnSale = isOnSale;
            product.DiscountUnitPrice = (decimal)discountUnitPrice;
            product.WholesalePrice = (decimal)wholesalePrice;
            product.NumViews = 0;
            product._301Redirect = false;
            product.SEOTitle = SEOTitle;
            product.SEOKeywords = SEOKeywords;
            product.SEODescription = SEODescription;
            product.SEOFriendlyNameURL = SEOFriendlyNameURL;

            //Add the new Product
            products.AddProductRow(product);
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ProductAdapter.Update(products));

        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public bool UpdateProduct(int original_ID, int brandID,
                                  string name, string description,
                                  int supplierID, int quantityPerUnit,
                                  double unitPrice, double weight,
                                  int unitsInStock, int unitsOnOrder,
                                  int reOrderLevel, int active,
                                  int isOnSale, double discountUnitPrice,
                                  double wholesalePrice, string SEOTitle, 
                                  string SEOKeywords, string SEODescription, 
                                  string SEOFriendlyNameURL) {
            DAL.ProductDataTable products = BLLAdapter.Instance.ProductAdapter.GetProductByID(original_ID);

            if (products.Count == 0) {
                //No matching records found, return false
                return false;
            }

            products.Rows[0]["BrandID"] = brandID;
            products.Rows[0]["Name"] = name;
            products.Rows[0]["Description"] = description;
            products.Rows[0]["SupplierID"] = supplierID;
            products.Rows[0]["QuantityPerUnit"] = quantityPerUnit;
            products.Rows[0]["UnitPrice"] = (decimal)unitPrice;
            products.Rows[0]["Weight"] = weight;
            products.Rows[0]["UnitsInStock"] = unitsInStock;
            products.Rows[0]["UnitsOnOrder"] = unitsOnOrder;
            products.Rows[0]["ReOrderLevel"] = reOrderLevel;
            products.Rows[0]["Active"] = active;
            products.Rows[0]["IsOnSale"] = isOnSale;
            products.Rows[0]["DiscountUnitPrice"] = (decimal)discountUnitPrice;
            products.Rows[0]["WholesalePrice"] = (decimal)wholesalePrice;
            products.Rows[0]["SEOTitle"] = SEOTitle;
            products.Rows[0]["SEOKeywords"] = SEOKeywords;
            products.Rows[0]["SEODescription"] = SEODescription;
            products.Rows[0]["SEOFriendlyNameURL"] = SEOFriendlyNameURL;
            
            //Update the product records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ProductAdapter.Update(products));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, false)]
        public bool UpdateProductFromExcel(int original_ID,
                                           int depID,
                                           int catID,
                                           int brandID,
                                           string name,
                                           string description,
                                           int supplierID,
                                           int quantityPerUnit,
                                           double unitPrice,
                                           double weight,
                                           int unitsInStock,
                                           int unitsOnOrder,
                                           int reOrderLevel,
                                           int active,
                                           int isOnSale,
                                           double discountUnitPrice,
                                           double wholesalePrice) {
            DAL.ProductDataTable products = BLLAdapter.Instance.ProductAdapter.GetProductByID(original_ID);

            if(products.Count == 0) {
                //No matching records found, return false
                return false;
            }

            products.Rows[0]["DepID"] = depID;
            products.Rows[0]["CatID"] = catID;
            products.Rows[0]["BrandID"] = brandID;
            products.Rows[0]["Name"] = name;
            products.Rows[0]["Description"] = description;
            products.Rows[0]["SupplierID"] = supplierID;
            products.Rows[0]["QuantityPerUnit"] = quantityPerUnit;
            products.Rows[0]["UnitPrice"] = (decimal)unitPrice;
            products.Rows[0]["Weight"] = weight;
            products.Rows[0]["UnitsInStock"] = unitsInStock;
            products.Rows[0]["UnitsOnOrder"] = unitsOnOrder;
            products.Rows[0]["ReOrderLevel"] = reOrderLevel;
            products.Rows[0]["Active"] = active;
            products.Rows[0]["IsOnSale"] = isOnSale;
            products.Rows[0]["DiscountUnitPrice"] = (decimal)discountUnitPrice;
            products.Rows[0]["WholesalePrice"] = (decimal)wholesalePrice;

            //Update the product records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ProductAdapter.Update(products));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, false)]
        public bool UpdateProductInventoryFromExcel(int original_ID, int unitsInStock, int unitsOnOrder, int reOrderLevel) {
            DAL.ProductDataTable products = BLLAdapter.Instance.ProductAdapter.GetProductByID(original_ID);

            if(products.Count == 0) {
                //No matching records found, return false
                return false;
            }

            products.Rows[0]["UnitsInStock"] = unitsInStock;
            products.Rows[0]["UnitsOnOrder"] = unitsOnOrder;
            products.Rows[0]["ReOrderLevel"] = reOrderLevel;

            //Update the product records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ProductAdapter.Update(products));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, false)]
        public bool UpdateProductPricingFromExcel(int original_ID,
                                                  double unitPrice,
                                                  double discountUnitPrice,
                                                  double wholesalePrice) {
            DAL.ProductDataTable products = BLLAdapter.Instance.ProductAdapter.GetProductByID(original_ID);

            if(products.Count == 0) {
                //No matching records found, return false
                return false;
            }

            products.Rows[0]["UnitPrice"] = (decimal)unitPrice;
            products.Rows[0]["DiscountUnitPrice"] = (decimal)discountUnitPrice;
            products.Rows[0]["WholesalePrice"] = (decimal)wholesalePrice;

            //Update the product records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ProductAdapter.Update(products));

        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, false)]
        public bool UpdateSocial(int original_ID, int HaveSN, string Name, int HasSocialNetworking) {
            try {
                BLLAdapter.Instance.ProductAdapter.ProductUpdateSocial(original_ID, HasSocialNetworking);
            } catch (Exception) {
                return false;
            }

            //Return True if no exception thrown.
            return true;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public bool DeleteProduct(int original_ID) {
            DAL.ProductDataTable products = BLLAdapter.Instance.ProductAdapter.GetProductByID(original_ID);

            if (products.Count == 0) {
                //No matching records found, return false
                return false;
            }
            products.Rows[0].Delete();

            //Update the department records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ProductAdapter.Update(products));
        }
    }
}