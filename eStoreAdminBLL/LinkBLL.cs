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
    public class LinkBLL : BaseBLL {
        private const int NUM_PRIMARY_KEYS = 1; //Primary Keys

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public DAL.LinksDataTable GetLinks() {
            return BLLAdapter.Instance.LinkAdapter.GetLinks();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.LinksDataTable GetLinkById(int ID) {
            return BLLAdapter.Instance.LinkAdapter.GetLinkByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public bool PrimaryKeyExists(int ID) {
            return (NUM_PRIMARY_KEYS == (int)BLLAdapter.Instance.LinkAdapter.LinkPrimaryKeyExists(ID));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public bool AddLink(string linkURL,
                            string linkText,
                            string linkDescription,
                            string linkType) {
            DAL.LinksDataTable links = new DAL.LinksDataTable();
            //Create a new LinksRow instance
            DAL.LinksRow link = links.NewLinksRow();

            link.LinkURL = linkURL;
            link.LinkText = linkText;
            link.LinkDescription = linkDescription;
            link.LinkType = linkType;

            //Add the new Link
            links.AddLinksRow(link);
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.LinkAdapter.Update(links));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public bool UpdateLink(int original_ID,
                               string linkURL,
                               string linkText,
                               string linkDescription,
                               string linkType) {
            DAL.LinksDataTable links = BLLAdapter.Instance.LinkAdapter.GetLinkByID(original_ID);

            if(links.Count == 0) {
                //No matching records found, return false
                return false;
            }

            links.Rows[0]["LinkURL"] = linkURL;
            links.Rows[0]["LinkText"] = linkText;
            links.Rows[0]["LinkDescription"] = linkDescription;
            links.Rows[0]["LinkType"] = linkType;
            
            //Update the product records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.LinkAdapter.Update(links));

        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public bool DeleteLink(int original_ID) {
            //Delete the Link record
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.LinkAdapter.Delete(original_ID));
        }
    }
}