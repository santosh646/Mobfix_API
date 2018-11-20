using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace MobFix.Helper
{
    public class MySqlOrderTrackingHelper
    {
        string connectionString = "SERVER=ip-160-153-131-201.ip.secureserver.net;DATABASE=Mobifix_DB;UID=MBFXADMIN;PASSWORD=MBFXADMIN@123;SslMode=none";
        public DataTable ExecuteQuery(string query)
        {
            var result = new DataTable();
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    mySqlConnection.Open();
                    var mySqlDataAdapter = new MySqlDataAdapter(query, mySqlConnection);

                    mySqlDataAdapter.Fill(result);

                }
            }
            catch (Exception ex)
            {
                //use logging here.
                throw ex;
            }
            finally
            {


            }
            return result;
        }

        public int ExecuteNonQuery(string query)
        {
           // query = "SELECT COUNT(*) FROM Mobifix_DB.ORDER_TRACKING";
            var result = -1;
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connectionString))
                {
                    mySqlConnection.Open();
                    var mySqlCommand = new MySqlCommand(query, mySqlConnection);

                    result = mySqlCommand.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                //use logging here.
                throw ex;
            }
            finally
            {


            }
            return result;
        }
    }
}
