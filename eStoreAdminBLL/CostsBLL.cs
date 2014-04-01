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
    public class CostsBLL : BaseBLL {
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public DAL.ShipCostDataTable GetCosts(int zoneID, int modeID) {
            return BLLAdapter.Instance.CostAdapter.GetCostsByZoneAndMode(zoneID, modeID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.ShipCostDataTable GetCostById(int ID) {
            return BLLAdapter.Instance.CostAdapter.GetCostByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public bool AddCost(int zoneID, int modeID, double maxWeight, double price) {
            DAL.ShipCostDataTable costs = new DAL.ShipCostDataTable();
            //Create a new ShipCostRow instance
            DAL.ShipCostRow cost = costs.NewShipCostRow();

            cost.ZoneID = zoneID;
            cost.ModeID = modeID;
            cost.MaxWeight = maxWeight;
            cost.Price = price;

            //Add the new ShipCost
            costs.AddShipCostRow(cost);

            //Return True if exactly one row was inserted, otherwise False
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.CostAdapter.Update(costs));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public bool UpdateCost(int original_ID, double maxWeight, double price) {
            DAL.ShipCostDataTable costs = BLLAdapter.Instance.CostAdapter.GetCostByID(original_ID);

            if (costs.Count == 0) {
                //No matching records found, return false
                return false;
            }

            costs.Rows[0]["MaxWeight"] = maxWeight;
            costs.Rows[0]["Price"] = price;

            //Update the cost record
            //Return True if exactly one row was updated, otherwise False
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.CostAdapter.Update(costs));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public bool DeleteCost(int original_ID) {

            //Update the cost record
            //Return True if exactly one row was updated, otherwise False
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.CostAdapter.Delete(original_ID));
        }
    }
}