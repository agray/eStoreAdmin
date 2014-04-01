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
using System.Web.UI.WebControls;
using eStoreAdminBLL;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.handlers;
using phoenixconsulting.common.logging;
using phoenixconsulting.common.navigation;

namespace eStoreAdminWeb.Web.Merchandise.Product {
    public partial class ManageImage : ImageBasePage {
        protected override void OnPreRender(EventArgs e) {
            string querystring = QueryStringHelper.Instance.ProductLevel(RequestHandler.Instance.ProductID,
                                                                         RequestHandler.Instance.ProductName);
            setNavigateURL(BackToHyperlink, "ManageProduct.aspx", querystring);
            setNavigateURL(AddImages, "MultipleUpload.aspx", querystring);
            base.OnPreRender(e);
        }

        //protected void ProductImageListView_ItemUpdating(object sender, ListViewUpdateEventArgs e) {
        //    ListViewDataItem item = e. as ;

        //    string NameText = ((TextBox)FindControl("NameEditTextBox")).Text;
        //    (new ImagesBLL()).updateImageName(imageID, NameText, int.Parse(RequestHandler.Instance.ProductID));
        //}

        protected void ProductImageListView_ItemUpdated(object sender, ListViewUpdatedEventArgs e) {
            logInfo(AuditEventType.PRODUCTIMAGE_UPDATED, e.NewValues[0].ToString(), e.OldValues[0].ToString(), null);
            GoTo.Instance.RefreshPage(Request.Url.Query);
        }

        protected void ProductImageListView_ItemCommand(object sender, ListViewCommandEventArgs e) {
            int imageID;
            switch(e.CommandName) {
                case "Cancel":
                    GoTo.Instance.RefreshPage(Request.Url.Query);
                    break;
                case "MakeDefault":
                    imageID = int.Parse(e.CommandArgument.ToString());
                    (new ImagesBLL()).UpdateImageMakeDefault(imageID, RequestHandler.Instance.ProductID);
                    logInfo(AuditEventType.PRODUCT_IMAGE_MAKE_DEFAULT, null, null, null);
                    GoTo.Instance.RefreshPage(Request.Url.Query);
                    break;
                case "Delete":
                    imageID = int.Parse(e.CommandArgument.ToString());
                    //Delete record from database
                    (new ImagesBLL()).DeleteImage(imageID);
                    //Delete image from file system
                    deleteFiles(imageID);
                    logInfo(AuditEventType.PRODUCTIMAGE_DELETED, null, null, null);
                    GoTo.Instance.RefreshPage(Request.Url.Query);
                    break;
                case "Edit":
                    //ItemCommand is firing.  This case clause is here for readability 
                    //so it is not forgotten like orphan case.
                    break;
            }
        }
    }
}