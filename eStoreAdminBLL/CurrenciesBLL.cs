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
    public class CurrenciesBLL : BaseBLL {
        
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public DAL.CurrencyDataTable GetCurrencies() {
            return BLLAdapter.Instance.CurrencyAdapter.GetCurrencies();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.CurrencyDataTable GetCurrencyById(int ID) {
            return BLLAdapter.Instance.CurrencyAdapter.GetCurrencyByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public bool AddCurrency(string name, string value, double exchangeRate) {
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.CurrencyAdapter.Insert(name, value, exchangeRate, DateTime.Now));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public bool UpdateCurrency(int original_ID, string name, string value, double exchangeRate) {
            DAL.CurrencyDataTable currencies = BLLAdapter.Instance.CurrencyAdapter.GetCurrencyByID(original_ID);

            if (currencies.Count == 0) {
                //No matching records found, return false
                return false;
            }

            currencies.Rows[0]["Name"] = name;
            currencies.Rows[0]["Value"] = value;
            currencies.Rows[0]["ExchangeRate"] = exchangeRate;

            //Update the department records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.CurrencyAdapter.Update(currencies));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public bool DeleteCurrency(int original_ID) {
            //Update the department records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.CurrencyAdapter.Delete(original_ID));
        }
    }
}