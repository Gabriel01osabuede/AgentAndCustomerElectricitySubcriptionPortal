using System;
using EDSCustomerPortal.AppData;
using ElectricityDigitalSystem;
using ElectricityDigitalSystem.ClientServices;
using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.Models;

namespace EDSCustomerPortal
{
   class PopulateMeterModel
   {
       public static void PopulatingMeterModel()
       {
            JsonFileService jsonFileService = new JsonFileService();
            
            ClientMeterDetails clientMeterDetails = new ClientMeterDetails();
            MeterModel meterModel = new MeterModel();
            CustomerSubcription customerSubcription = new CustomerSubcription();

            CustomerService customerService = new CustomerService();  
             var customer = customerService.GetCustomerById(CustomerApplicationData.CurrentCustomerId);
            
            meterModel.Id = Guid.NewGuid().ToString();
            meterModel.MeterNumber = customer.MeterNumber;
            Console.WriteLine("Whats Your Meter Type\nPress 1 for Single phase-meter\nPress 2 for 3 phase-Meter");
            int meterType = Convert.ToInt32(Console.ReadLine());
            switch (meterType)
            {
                case 1:
                meterModel.Type = MeterType.SINGLEPHASE;
                break;
                case 2:
                meterModel.Type = MeterType.THREEPHASE;
                break;
                default:
                Console.WriteLine("Wrong selection");
                break;
            }
            meterModel.ProductName = "EkEDC";
            
            jsonFileService.SaveChanges();
            clientMeterDetails.SaveMeterDetails(meterModel);
       }
   } 
}