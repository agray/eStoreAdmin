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
using phoenixconsulting.common.logging;
using phoenixconsulting.common.navigation;

namespace eStoreAdminWeb.Web.Advanced {
    public partial class ManageCosts : AuditBasePage {
        protected void Page_LoadComplete(object sender, EventArgs e) {
            ListItem zone = ZoneDDL.SelectedItem;
            if(zone == null || zone.Text.Equals("--Choose a Zone--")) {
                setVisibility(false);
            } else {
                ListItem mode = ModeDDL.SelectedItem;
                if(mode == null || mode.Text.Equals("--Choose a Mode--")) {
                    setVisibility(false);
                } else {
                    setVisibility(true);
                }
            }
        }

        private void setVisibility(bool isVisible){
            MaxWeightAddTextBox.Visible = isVisible;
            PriceAddTextBox.Visible = isVisible;
            btnAdd.Visible = isVisible;
            AddHR.Visible = isVisible;
        }

        protected void AddNewItem(object sender, EventArgs e) {
            CostsBLL costsBLL = new CostsBLL();
            costsBLL.AddCost(toInt(ZoneDDL.SelectedValue), 
                             toInt(ModeDDL.SelectedValue), 
                             toDouble(MaxWeightAddTextBox.Text), 
                             toDouble(PriceAddTextBox.Text));
            logInfo(AuditEventType.COST_ADDED, "Price: " + PriceAddTextBox.Text +
                                               " Weight " + MaxWeightAddTextBox.Text, null, null);
            GoTo.Instance.RefreshPage(Request.Url.Query);
        }

        protected void CostList_ItemUpdated(object sender, ListViewUpdatedEventArgs e) {
            logInfo(AuditEventType.COST_UPDATED, e.NewValues[0].ToString(), e.OldValues[0].ToString(), null);
        }

        protected void CostList_ItemDeleting(object sender, ListViewDeleteEventArgs e) {
            string weight = ((Label)CostList.Items[e.ItemIndex].FindControl("WeightLabel")).Text;
            string price = ((Label)CostList.Items[e.ItemIndex].FindControl("PriceLabel")).Text;
            logInfo(AuditEventType.COST_DELETED, null, "Price: " + price + " Weight: " + weight, null);

        }

        protected void ZonesDropDownList_SelectedIndexChanged(object sender, EventArgs e) {
            ModeDDL.SelectedIndex = 0;
        }
    }
}