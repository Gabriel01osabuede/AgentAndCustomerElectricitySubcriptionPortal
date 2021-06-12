using ElectricityDigitalSystem.Models;
using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.ClientServices;

namespace ElectricityDigitalSystem
{
    public class CustomerSubcriptionClass : ClientServiceAPI
    {
          public string Unsubscribe(string customerId)
        {
            CustomerSubcription found = fileService.database.Subcriptions.Find(c => c.CustomerId == customerId);
            if(found != null)
            {
                fileService.database.Subcriptions.Remove(found);
                fileService.SaveChanges();
                return "Subcription Deleted";
            }
            return "You dont have any Subcription";
            
        }

        public CustomerSubcription getSubcriptions(string customerId)
        {
            CustomerSubcription CustomerSubscription = fileService.database.Subcriptions.Find(c => c.CustomerId == customerId);
            if (CustomerSubscription != null)
            {
                return CustomerSubscription;
            }
            return null;

        }
        
        public MeterModel getMeterModel(string meterNumber)
        {
            MeterModel CustomerMeterNumber = fileService.database.Meters.Find(c => c.MeterNumber == meterNumber);
            if (CustomerMeterNumber != null)
            {
                return CustomerMeterNumber;
            }
            return null;

        }
           public TarriffModel getTariffModel(string tariffId)
        {
            TarriffModel CustomerTariffDetails = fileService.database.Tariffs.Find(c => c.Id == tariffId);
            if (CustomerTariffDetails != null)
            {
                return CustomerTariffDetails;
            }
            return null;

        }
    }
}