using MobFix.Controllers;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using MobFix.Helper;

namespace MobFix.Repositories
{
    public class ContactStatusRepository
    {
        MySqlContactStatusHelper MySqlContactStatusHelper = new MySqlContactStatusHelper();


        public ContactStatus GetContactStatus(string ContactStatus, string ContactStatusDescription)
        {
            string fetchContactStatus = $"SELECT * FROM Mobifix_DB.CONTACT_STATUS WHERE LOWER CONTACT_STATUS_CD  () = '{ ContactStatus.ToString() }'";
            var dtResult = MySqlContactStatusHelper.ExecuteQuery(fetchContactStatus);
            var contactstatus = FillContactStatusModel(dtResult);
            return contactstatus.FirstOrDefault<ContactStatus>();

        }

        public IList<ContactStatus> GetAllContactStatus()
        {
            string fetchContactStatus = $"SELECT * FROM Mobifix_DB.CONTACT_STATUS";
            var dtResult = MySqlContactStatusHelper.ExecuteQuery(fetchContactStatus);
            var contactstatus = FillContactStatusModel(dtResult);
            return contactstatus;

        }

        public int UpdateContactStatus(ContactStatus contactstatus)
        {
            string updateContactStatusInfo = $"UPDATE Mobifix_DB.CONTACT_STATUS SET CONTACT_STATUS_DESC = '{contactstatus.ContactStatusDescription}' WHERE LOWER(CONTACT_STATUS_CD) = '{contactstatus.ContactStatusCD.ToString()}' ";
            return MySqlContactStatusHelper.ExecuteNonQuery(updateContactStatusInfo);
        }

        private IList<ContactStatus> FillContactStatusModel(DataTable dtContactStatus)
        {
            var contactstatusList = new List<ContactStatus>();
            if (null != dtContactStatus && dtContactStatus.Rows.Count > 0)
            {
                foreach (DataRow row in dtContactStatus.Rows)
                {
                    var contactstatus = new ContactStatus();
                    
                    contactstatus.ContactStatusCD = Convert.ToString (row["CONTACT_STATUS_CD"]);
                    contactstatus.ContactStatusDescription = Convert.ToString(row["CONTACT_STATUS_DESC"]);

                    contactstatusList.Add(contactstatus);
                }
            }
            return contactstatusList;
        }

        public int DeleteContactStatus(ContactStatus contactstatus)
        {
            string updateContactStatusInfo = $"DELETE FROM Mobifix_DB.CONTACT_STATUS  WHERE LOWER(CONTACT_STATUS_CD) = '{contactstatus.ContactStatusCD.ToString()}' ";
            return MySqlContactStatusHelper.ExecuteNonQuery(updateContactStatusInfo);
        }

    }
}