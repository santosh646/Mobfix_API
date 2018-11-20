using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobFix.Helper
{
    public class MySqlMobileOsHelper
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
            //query = "SELECT COUNT(*) FROM Mobifix_DB.MOBILE_OS_TYPE";
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