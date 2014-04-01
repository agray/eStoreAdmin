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
    public class ColorsBLL : BaseBLL {
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public DAL.ProductColorDataTable GetColorsByProductId(int productID) {
            return BLLAdapter.Instance.ColorAdapter.GetProductColorsByProduct(productID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ProductColorDataTable GetColorById(int ID) {
            return BLLAdapter.Instance.ColorAdapter.GetProductColorByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public bool AddColor(int productID, string name) {
            DAL.ProductColorDataTable colors = new DAL.ProductColorDataTable();
            //Create a new ProductColorRow instance
            DAL.ProductColorRow color = colors.NewProductColorRow();

            color.ProductID = productID;
            color.Name = name;
            //Add the new Product Color
            colors.AddProductColorRow(color);

            //Return True if exactly one row was inserted, otherwise False
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ColorAdapter.Update(colors));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public bool UpdateColor(int original_ID, string name) {
            DAL.ProductColorDataTable colors = BLLAdapter.Instance.ColorAdapter.GetProductColorByID(original_ID);

            if (colors.Count == 0) {
                //No matching records found, return false
                return false;
            }

            colors.Rows[0]["Name"] = name;

            //Update the color records
            //Return True if exactly one row was updated, otherwise False
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ColorAdapter.Update(colors));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public bool DeleteColor(int original_ID) {
            DAL.ProductColorDataTable colors = BLLAdapter.Instance.ColorAdapter.GetProductColorByID(original_ID);

            if (colors.Count == 0) {
                //No matching records found, return false
                return false;
            }

            colors.Rows[0].Delete();

            //Update the color records
            //Return True if exactly one row was updated, otherwise False
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ColorAdapter.Update(colors));
        }
    }
}