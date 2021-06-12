using System;
using System.Threading;
using EDSCustomerPortal.AppData;
using ElectricityDigitalSystem;
using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.Models;

namespace EDSCustomerPortal
{
    public class PopulateCustomerSubcription
    {
        public static void PopulatingCustomerSubcriptionModel()
        {
            
            ClientMeterDetails clientMeterDetails = new ClientMeterDetails();
            JsonFileService jsonFileService = new JsonFileService();
            CustomerSubcriptionClass customerSubcriptionClass = new CustomerSubcriptionClass();
            
            
            var tariffDetails = customerSubcriptionClass.getTariffModel(CustomerApplicationData.CurrentCustomerTarrifId);
            
            CustomerSubcription customerSubcription = new CustomerSubcription();



            customerSubcription.Id = Guid.NewGuid().ToString();
            Console.WriteLine("How Much Would You Like To Subcribe?");
            decimal Amount = Convert.ToInt32(Console.ReadLine());
            customerSubcription.Amount = Amount;
            customerSubcription.TariffId = CustomerApplicationData.CurrentCustomerTarrifId;
            customerSubcription.CustomerId = CustomerApplicationData.CurrentCustomerId;
            customerSubcription.AgentId = "AGT-" + Guid.NewGuid().ToString();

            decimal customerKwhBought = Amount / tariffDetails.PricePerUnit;
            Console.WriteLine($"You just purchased {customerKwhBought}kwh of electricity.");
            bool status = true;
            do{
            Console.WriteLine("Press Yes to activate Meter Now.\nEnter : ");
            var answer = Console.ReadLine();
            if(answer == "yes")
            {
                Console.WriteLine("Meter activated\nThank you.");
                Thread.Sleep(3000);
                status = false;
            }
            else{
                Console.WriteLine("Meter not yet activated");
            }
        }while(status);
        jsonFileService.SaveChanges();
        clientMeterDetails.SaveCustomerSubcriptionDetails(customerSubcription);
        
        }
    }
}