using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityDigitalSystem.Models
{ 
    public class AcceptAndProcessPaymentModel
    {
         //Customer name
                //customer Meter Number
                //customer tariff option
                //Amount to subcribe for
                //Agent Id
                //Agent Name
        public string Id { get; set; }        
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string  CustomerMeterNumber { get; set; }
        public string TarrifName { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal CustomerAmount { get; set; }
        public string AgentId { get; set; }
        public string AgentName { get; set; }
        public DateTime PurchasedDate { get; set; } = DateTime.Now;
    }
}