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
using phoenixconsulting.common.basepages;

namespace eStoreAdminWeb.Web.Advanced {
    partial class ManageCountries2 : BasePage {
        private string[] fieldNames = { "Name", "Country Code", "Currency", "Zone" };

        //protected void CountryFormView_ItemDeleted(object sender, FormViewDeletedEventArgs e) {
        //    logger.Debug(LoggerUtil.getText(fieldNames, e, "Shipping Country"));
        //    CountriesGridView.DataBind();
        //    LoggerUtil.infoAuditLog(AuditEventType.COUNTRY_DELETED,
        //                            "AdminSite",
        //                            CurrentUserName(),
        //                            e.Values[0].ToString(), null, null, null, null);
        //    if(CountriesGridView.Rows.Count == 0) {
        //        GoTo.Instance.ManageCountriesPage();
        //    }
        //}

        //protected void CountryFormView_ItemInserted(object sender, FormViewInsertedEventArgs e) {
        //    logger.Debug(LoggerUtil.getText(fieldNames, e, "Shipping Country"));
        //    CountriesGridView.DataBind();
        //    LoggerUtil.infoAuditLog(AuditEventType.COUNTRY_ADDED,
        //                        "AdminSite",
        //                        CurrentUserName(),
        //                        e.Values[0].ToString(), null, null, null, null);
        //    CountryFormView.DefaultMode = FormViewMode.ReadOnly;
        //}

        protected void CountryODS_Inserting(object sender, ObjectDataSourceMethodEventArgs e) {
            addParameters("Add");
        }

        protected void CountryODS_Updating(object sender, ObjectDataSourceMethodEventArgs e) {
            addParameters("Edit");
        }

        private void addParameters(string mode) {
            CountryODS.InsertParameters.Add(new Parameter("name", TypeCode.String, ((TextBox)CountryFormView.FindControl("Value" + mode + "TextBox")).Text));
            CountryODS.InsertParameters.Add(new Parameter("zoneID", TypeCode.Int32, ((DropDownList)CountryFormView.FindControl("Zone" + mode + "DropDownList").FindControl("ZoneDropDownList")).SelectedValue));
            CountryODS.InsertParameters.Add(new Parameter("countryCode", TypeCode.String, ((TextBox)CountryFormView.FindControl("CountryCode" + mode + "TextBox")).Text));
            CountryODS.InsertParameters.Add(new Parameter("currencyID", TypeCode.Int32, ((DropDownList)CountryFormView.FindControl("Currency" + mode + "DropDownList").FindControl("CurrencyDropDownList")).SelectedValue));
        }

        //protected void CountryFormView_ItemUpdated(object sender, FormViewUpdatedEventArgs e) {
        //    logger.Debug(LoggerUtil.getText(fieldNames, e, "Shipping Country"));
        //    CountriesGridView.DataBind();
        //    LoggerUtil.infoAuditLog(
        //                        AuditEventType.COUNTRY_UPDATED,
        //                        "AdminSite",
        //                        CurrentUserName(),
        //                        e.OldValues[0].ToString(), e.NewValues[0].ToString(), null, null, null);
        //}

        protected void CountriesGridView_DataBound(object sender, EventArgs e) {
            if(CountriesGridView.Rows.Count == 0) {
                CountryFormView.DefaultMode = FormViewMode.Insert;
            } else {
                CountryFormView.DefaultMode = FormViewMode.ReadOnly;
            }
        }
    }
}