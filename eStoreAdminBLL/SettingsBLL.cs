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
    public class SettingsBLL : BaseBLL {
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public DAL.SettingsDataTable GetSettings() {
            return BLLAdapter.Instance.SettingAdapter.GetSettings();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.SettingsDataTable GetSettingsEverything() {
            return BLLAdapter.Instance.SettingAdapter.GetSettingsEverything();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public string GetThemeSetting() {
            return BLLAdapter.Instance.SettingAdapter.GetThemeSetting().ToString();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.SettingsDataTable GetSettingById(int ID) {
            return BLLAdapter.Instance.SettingAdapter.GetSettingsByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public bool UpdateSetting(int original_ID,
                                  string name,
                                  string value,
                                  string type) {
            DAL.SettingsDataTable settings = BLLAdapter.Instance.SettingAdapter.GetSettingsByID(original_ID);

            if(settings.Count == 0) {
                //No matching records found, return false
                return false;
            }

            settings.Rows[0]["Name"] = name;
            settings.Rows[0]["Value"] = value;
            settings.Rows[0]["Type"] = type;

            //Update the product records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.SettingAdapter.Update(settings));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, false)]
        public bool UpdateThemeSetting(int newThemeID) {
            //Update the Theme setting
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.SettingAdapter.UpdateThemeSetting(newThemeID));
        }
    }
}