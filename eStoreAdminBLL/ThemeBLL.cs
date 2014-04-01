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
    public class ThemeBLL : BaseBLL {
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public DAL.ThemeDataTable GetThemes() {
            return BLLAdapter.Instance.ThemeAdapter.GetThemes();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ThemeDataTable GetThemeById(int ID) {
            return BLLAdapter.Instance.ThemeAdapter.GetThemeByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public bool AddTheme(string theme, string masterPage) {
            DAL.ThemeDataTable themes = new DAL.ThemeDataTable();
            //Create a new BadWordRow instance
            DAL.ThemeRow themeRow = themes.NewThemeRow();

            themeRow.Name = theme;
            themeRow.MasterPage = masterPage;

            //Add the new Theme
            themes.AddThemeRow(themeRow);
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ThemeAdapter.Update(themes));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public bool UpdateTheme(int original_ID, string name, string masterPage) {

            DAL.ThemeDataTable themes = BLLAdapter.Instance.ThemeAdapter.GetThemeByID(original_ID);

            if (themes.Count == 0) {
                //No matching records found, return false
                return false;
            }

            themes.Rows[0]["Name"] = name;
            themes.Rows[0]["MasterPage"] = masterPage;

            //Update the product record
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ThemeAdapter.Update(themes));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public bool DeleteTheme(int original_ID) {
            DAL.ThemeDataTable themes = BLLAdapter.Instance.ThemeAdapter.GetThemeByID(original_ID);

            if(themes.Count == 0) {
                //No matching records found, return false
                return false;
            }

            themes.Rows[0].Delete();
            //Update the theme records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.ThemeAdapter.Update(themes));
        }
    }
}