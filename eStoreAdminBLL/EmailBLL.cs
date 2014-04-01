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
    public class EmailBLL : BaseBLL {
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public DAL.EmailDataTable GetEmails() {
            return BLLAdapter.Instance.EmailAdapter.GetEmails();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.EmailDataTable GetEmailById(int ID) {
            return BLLAdapter.Instance.EmailAdapter.GetEmailByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public bool UpdateEmail(int original_ID, string replyMessage) {
            DAL.EmailDataTable email = BLLAdapter.Instance.EmailAdapter.GetEmailByID(original_ID);

            if (email.Count == 0) {
                //No matching records found, return false
                return false;
            }

            email.Rows[0]["ReplyMessage"] = replyMessage;

            //Update the product records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.EmailAdapter.Update(email));
        }
    }
}