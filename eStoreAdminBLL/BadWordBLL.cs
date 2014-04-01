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
using System.Data;
using eStoreAdminBLL.Base;
using eStoreAdminDAL;
using eStoreAdminDAL.DALTableAdapters;

namespace eStoreAdminBLL {
    [DataObject]
    public class BadWordBLL : BaseBLL {
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public DAL.BadWordDataTable GetBadWords() {
            return BLLAdapter.Instance.BadWordAdapter.GetBadWords();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.BadWordDataTable GetBadWordById(int ID) {
            return BLLAdapter.Instance.BadWordAdapter.GetBadWordByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public bool AddBadWord(string badWord) {
            DAL.BadWordDataTable words = new DAL.BadWordDataTable();
            //Create a new BadWordRow instance
            DAL.BadWordRow word = words.NewBadWordRow();

            word.BadWord = badWord;

            //Add the new BadWord
            words.AddBadWordRow(word);
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.BadWordAdapter.Update(words));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public bool UpdateBadWord(int original_ID, string badWord) {

            DAL.BadWordDataTable word = BLLAdapter.Instance.BadWordAdapter.GetBadWordByID(original_ID);

            if (word.Count == 0) {
                //No matching records found, return false
                return false;
            }

            word.Rows[0]["BadWord"] = badWord;

            //Update the product record
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.BadWordAdapter.Update(word));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public bool DeleteBadWord(int original_ID) {
            DAL.BadWordDataTable words = BLLAdapter.Instance.BadWordAdapter.GetBadWordByID(original_ID);
            return Delete(words, BLLAdapter.Instance.BadWordAdapter.GetType());
            
            //if (words.Count == 0) {
            //    //No matching records found, return false
            //    return false;
            //}

            //words.Rows[0].Delete();

            ////Update the department records
            //return WasOnlyOneRecordAffected(BLLAdapter.Instance.BadWordAdapter.Update(words));
        }
    }
}