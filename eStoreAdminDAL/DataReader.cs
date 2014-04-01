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
using System;
using System.Data;
using System.Data.SqlClient;
using eStoreAdminDAL.Properties;

namespace eStoreAdminDAL {
    public class DataReader {

        private SqlConnection _conn = new SqlConnection(Settings.Default.eStoreAdminConnectionString);

        public DAL.AlertsDataTable getAlerts() {
            DAL.AlertsDataTable dt = new DAL.AlertsDataTable();

            try {
                _conn.Open();
                SqlCommand comm = _conn.CreateCommand();
                comm.CommandText = "exec uspAlertGetAll";
                SqlDataReader reader = comm.ExecuteReader();


                DataRow newAlertsRow = dt.NewAlertsRow();
                reader.Read();
                newAlertsRow["LowInventoryCount"] = reader["LowInventoryCount"];
                newAlertsRow["DeclinedTransCount"] = reader["DeclinedTransCount"];
                dt.Rows.Add(newAlertsRow);
                _conn.Close();

            } catch(SqlException sex) {
                Console.WriteLine(sex.Message);
            }

            return dt;
        }


        public DAL.MetricsDataTable getMetrics() {
            DAL.MetricsDataTable dt = new DAL.MetricsDataTable();

            try {
                _conn.Open();
                SqlCommand comm = _conn.CreateCommand();
                comm.CommandText = "exec uspMetricGetAll";
                SqlDataReader reader = comm.ExecuteReader();

                DataRow newMetricsRow = dt.NewMetricsRow();
                reader.Read();
                newMetricsRow["NetSalesYTDCount"] = reader["NetSalesYTDCount"];
                newMetricsRow["NetSalesMTDCount"] = reader["NetSalesMTDCount"];
                newMetricsRow["NetSalesTodayCount"] = reader["NetSalesTodayCount"];
                newMetricsRow["TotalOrdersCount"] = reader["TotalOrdersCount"];
                newMetricsRow["TotalOrdersMTDCount"] = reader["TotalOrdersMTDCount"];
                dt.Rows.Add(newMetricsRow);
                _conn.Close();
            
            } catch(SqlException sex) {
                Console.WriteLine(sex.Message);
            }

            return dt;
        }
    }
}