using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobFix.Repositories
{
    public class ContactTypeRepository
    {
        MySqlContactTypeHelper MySqlContactTypeHelper = new MySqlContactTypeHelper();


        public ContactType GetContactType(int ContactTypeID, string ContactTypeDescription)
        {
            string fetchContactType = $"SELECT * FROM Mobifix_DB.CONTACT_TYPE WHERE LOWER CONTACT_TYPE_ID  () = '{ ContactTypeID.ToString() }'";
            var dtResult = MySqlContactTypeHelper.ExecuteQuery(fetchContactType);
            var contacttype = FillContactTypeModel(dtResult);
            return contacttype.FirstOrDefault<ContactType>();
        }

        public IList<ContactType> GetAllContactTypes()
        {
            string fetchContactType = $"SELECT * FROM Mobifix_DB.CONTACT_TYPE";
            var dtResult = MySqlContactTypeHelper.ExecuteQuery(fetchContactType);
            var contacttype = FillContactTypeModel(dtResult);
            return contacttype;

        }
        public int UpdateContactTypeStatus(ContactType contacttype)
        {
            string updateContactTypeInfo = $"UPDATE Mobifix_DB.CONTACT_TYPE SET CONTACT_TYPE_DESC = '{contacttype.ContactTypeDescription}' WHERE LOWER(CONTACT_TYPE_ID) = '{contacttype.ContactTypeID.ToString()}' ";
            return MySqlContactTypeHelper.ExecuteNonQuery(updateContactTypeInfo);
        }
        private IList<ContactType> FillContactTypeModel(DataTable dtContactType)
        {
            var contacttypeList = new List<ContactType>();
            if (null != dtContactType && dtContactType.Rows.Count > 0)
            {
                foreach (DataRow row in dtContactType.Rows)
                {
                    var contacttype = new ContactType();

                    contacttype.ContactTypeID = Convert.ToInt32(row["CONTACT_TYPE_ID"]);
                    //contacttype.ContactTypeDescription = Convert.ToChar(row["CONTACT_TYPE_DESC"]);

                    contacttypeList.Add(contacttype);
                }
            }
            return contacttypeList;
        }
    }
}