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
using System.IO;

namespace phoenixconsulting.common.basepages {
    public class ImageBasePage : AuditBasePage {
        protected const string RED = " Red";
        protected const string GREEN = " Green";
        protected const string EDIT = " Edit";
        protected const string RED_EDIT = " Red Edit";
        protected const string GREEN_EDIT = " Green Edit";
        protected const string IMAGES_DIR = ROOT_DIR + "Images/";
        protected const string CATALOGUE_DIR = IMAGES_DIR + "Catalogue/";
        protected const string ZOOMABLE_DIR = CATALOGUE_DIR + "Zoomable/";
        protected const string LARGE_DIR = CATALOGUE_DIR + "Large/";
        protected string mappedImageRoot = mapPath(IMAGES_DIR);
        protected string mappedCatalogueRoot = mapPath(CATALOGUE_DIR);
        protected string mappedZoomableRoot = mapPath(ZOOMABLE_DIR);
        protected string mappedLargeRoot = mapPath(LARGE_DIR);
        
        public string getDivClass(string caller, string isDefault, bool inEditMode) {
            return isDefault.Equals("1") 
                ? (inEditMode ? caller + GREEN_EDIT : caller + GREEN) 
                : (inEditMode ? caller + EDIT : caller);
        }

        protected bool setEditVisibility(string isDefault)
        {
            return !isDefault.Equals("1");
        }

        protected void deleteFiles(int fileLeftPart) {
            string fullAdminPath = mappedZoomableRoot + fileLeftPart;
            string fullStorePath = GetSiteBasePath(mappedZoomableRoot, "CSStore") + fileLeftPart;
            string fullAdminPathLarge = mappedLargeRoot + fileLeftPart;
            string fullStorePathLarge = GetSiteBasePath(mappedLargeRoot, "CSStore") + fileLeftPart;

            deleteFile(fullAdminPath);
            deleteFile(fullStorePath);
            deleteFile(fullAdminPathLarge);
            deleteFile(fullStorePathLarge);
        }

        protected void deleteFile(string fullPath) {
            if(File.Exists(fullPath + ".gif")) {
                File.Delete(fullPath + ".gif");
            } else if(File.Exists(fullPath + ".jpg")) {
                File.Delete(fullPath + ".jpg");
            } else {
                File.Delete(fullPath + ".jpeg");
            }
        }
    }
}