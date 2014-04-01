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
using AjaxControlToolkit;
using eStoreAdminBLL;
using ImageResizer;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.handlers;
using phoenixconsulting.common.navigation;
using phoenixconsulting.common.logging;

namespace eStoreAdminWeb {
    partial class MultipleUpload : ImageBasePage {
        private const string ZOOMABLE_IMG_PARAMETERS = "maxwidth=260&maxheight=300";
        private ImagesBLL _imagesAdapter;
        protected ImagesBLL ImageAdapter {
            get { return _imagesAdapter ?? (_imagesAdapter = new ImagesBLL()); }
        }
        
        protected override void OnPreRender(EventArgs e) {
            setNavigateURL(BackToHyperlink, 
                           "ManageImage.aspx",
                           QueryStringHelper.Instance.ProductLevel(RequestHandler.Instance.ProductID,
                                                                   RequestHandler.Instance.ProductName));
            base.OnPreRender(e);
        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxFileUploadEventArgs e) {
            logger.Debug("Started uploading files...");

            //Add record into database
            logger.Debug("Attempting to upload image " + e.FileName);
            int IDAdded = ImageAdapter.AddImage(Int32.Parse(Request["ProdID"]), "ReplaceMe", "");
            string newFileName = IDAdded + Path.GetExtension(e.FileName);

            string fullPathForAdminSite = mappedZoomableRoot + newFileName;
            string largePathForAdminSite = mappedLargeRoot + newFileName;
            string fullPathForStoreSite = GetSiteBasePath(mappedZoomableRoot, "CSStore") + newFileName;
            string largePathForStoreSite = GetSiteBasePath(mappedLargeRoot, "CSStore") + newFileName;
            string virtualPathForDB = ZOOMABLE_DIR + newFileName;
            string virtualLargePathForDB = LARGE_DIR + newFileName;

            //Save File to both CSAdmin AND CSStore Site Images directory
            AjaxFileUpload1.SaveAs(largePathForAdminSite);
            AjaxFileUpload1.SaveAs(largePathForStoreSite);

            logger.Debug("File " + e.FileName + " uploaded as " + newFileName);
            UploadStatusLabel.Text = "File Uploaded: " + e.FileName + " As " + newFileName;

            //Update Image PathName in DB
            ImageAdapter.UpdateImagePathName(IDAdded, virtualPathForDB, virtualLargePathForDB);
            logger.Debug("DB successfully updated for " + virtualPathForDB + "and" + virtualLargePathForDB);
            logInfo(AuditEventType.PRODUCTIMAGE_ADDED, null, null, newFileName);

            ShrinkAndSaveImages(largePathForAdminSite, fullPathForAdminSite, fullPathForStoreSite);
        }

        private void ShrinkAndSaveImages(string source, string destAdminPath, string destStorePath) {
            ResizeSettings rs = new ResizeSettings(ZOOMABLE_IMG_PARAMETERS);
            ImageBuilder.Current.Build(source, destAdminPath, rs);
            ImageBuilder.Current.Build(source, destStorePath, rs);
        }
    }
}