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
    public class CountriesBLL : BaseBLL {
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public DAL.ShipToCountryDataTable GetCountries() {
            return BLLAdapter.Instance.CountryAdapter.GetCountries();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ShipToCountryDataTable GetCountryById(int ID) {
            return BLLAdapter.Instance.CountryAdapter.GetCountryByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public bool AddCountry(string name, int zoneID, string countryCode, int currencyID) {
            DAL.ShipToCountryDataTable countries = new DAL.ShipToCountryDataTable();
            //Create a new CountriesRow instance
            DAL.ShipToCountryRow country = countries.NewShipToCountryRow();

            country.Name = name;
            country.ZoneID = zoneID;
            country.CountryCode = countryCode;
            country.CurrencyID = currencyID;

            //Add the new Country
            countries.AddShipToCountryRow(country);
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.CountryAdapter.Update(countries));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public bool UpdateCountry(int original_ID, string name, int zoneID, string countryCode, int currencyID) {
            DAL.ShipToCountryDataTable countries = BLLAdapter.Instance.CountryAdapter.GetCountryByID(original_ID);

            if (countries.Count == 0) {
                //No matching records found, return false
                return false;
            }

            countries.Rows[0]["Name"] = name;
            countries.Rows[0]["ZoneID"] = zoneID;
            countries.Rows[0]["CountryCode"] = countryCode;
            countries.Rows[0]["CurrencyID"] = currencyID;

            //Update the country records
            //Return True if exactly one row was updated, otherwise False
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.CountryAdapter.Update(countries));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public bool DeleteCountry(int original_ID) {
            //Delete the country records
            //Return True if exactly one row was updated, otherwise False
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.CountryAdapter.Delete(original_ID));
        }
    }
}