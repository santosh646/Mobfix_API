using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MobFix.Models
{
    public enum UserStatus
    {
        [Description("Active")]
        A,
        [Description("Enrolled")]
        E,
        [Description("Revoked")]
        R,
        [Description("In Active")]
        I,
        [Description("Closed")]
        C,
        [Description("Locked")]
        L,
        [Description("Un Registered")]
        U

    }

    public enum OrderStatusDesc
    {
        Admin,
        Vendor,
        Customer
    }

    public static class EnumHelper
    {
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }
}