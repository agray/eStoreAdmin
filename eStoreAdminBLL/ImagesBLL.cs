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
    public class ImagesBLL : BaseBLL {
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public DAL.ProductImageDataTable GetImagesByProductId(int productID) {
            return BLLAdapter.Instance.ImageAdapter.GetProductImagesByProduct(productID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ProductImageDataTable GetImageById(int ID) {
            return BLLAdapter.Instance.ImageAdapter.GetProductImageByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ProductImageDataTable GetCategoryImageByImageId(int ID) {
            return BLLAdapter.Instance.ImageAdapter.GetCategoryImageByImageID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ProductImageDataTable GetDepartmentImageByImageId(int ID) {
            return BLLAdapter.Instance.ImageAdapter.GetDepartmentImageByImageID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ProductImageDataTable GetImageByCategory(int ID) {
            return BLLAdapter.Instance.ImageAdapter.GetImageByCategory(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ProductImageDataTable GetImageByDepartment(int ID) {
            return BLLAdapter.Instance.ImageAdapter.GetImageByDepartment(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int AddImage(int original_ProductID, string imgPath, string imgName) {
            return int.Parse(BLLAdapter.Instance.ImageAdapter.AddImage(original_ProductID, imgPath, imgName).ToString());
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public bool UpdateImageName(int original_ID, string imgName) {
            //Update the image name
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ImageAdapter.ProductImageUpdateName(original_ID, imgName));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, false)]
        public bool UpdateImageMakeDefault(int original_ID, int prodID) {
            //Update the image record
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ImageAdapter.setDefaultProductImage(original_ID, prodID));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, false)]
        public bool UpdateCategoryImage(int catID, int original_ID, int isDefault) {
            //Update the image record
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ImageAdapter.UpdateCategoryImage(original_ID, catID));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, false)]
        public bool UpdateDepartmentImage(int depID, int original_ID, int isDefault) {

            if(BLLAdapter.Instance.ImageAdapter == null) {
                Console.WriteLine("imgAdapter is null.");
            }

            //Update the image record
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ImageAdapter.UpdateDepartmentImage(original_ID, depID));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, false)]
        public bool UpdateImagePathName(int ID, string imgPath, string imgLargePath) {
            //Update the product records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ImageAdapter.UpdateImagePathName(ID, imgPath, imgLargePath));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public bool DeleteImage(int original_ID) {
            //Delete the category records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ImageAdapter.Delete(original_ID));
        }
    }
}