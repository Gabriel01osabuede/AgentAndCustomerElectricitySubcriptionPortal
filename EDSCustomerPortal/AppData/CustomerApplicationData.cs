using System;
using System.Collections.Generic;
using System.Text;

namespace EDSCustomerPortal.AppData
{
    public class CustomerApplicationData
    {   public DateTime LastLoginDate { get; set; }
        public static string CurrentCustomerId { get; set; } = null;
        public static string CurrentCustomerTarrifId { get; set; } = null;
        public static string CurrentCustomerMeterNumber { get; set; } = null;
    }
}
