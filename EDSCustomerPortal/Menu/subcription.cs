using System;
using System.Threading;
using EDSCustomerPortal.AppData;
using ElectricityDigitalSystem;
using ElectricityDigitalSystem.ClientServices;

namespace EDSCustomerPortal
{
    public class Subcriptions
    {
        public static void subcribe()
        {
            Console.WriteLine("Welcome to the subcription Menu"); 
            PopulateMeterModel.PopulatingMeterModel();
            PopulateTariffModel.PopulatingTariffModel();
            PopulateCustomerSubcription.PopulatingCustomerSubcriptionModel();
            CustomersSecondScreen.UpdateAndSubcribeMenu();

        }

        public static void unSubcribeFromCurrentSubcription(string customerId)
        {
            bool status = true;
            do{
            Console.WriteLine("Are you sure you want to Unsubcribe this plan?\nYes Or No");
            string reply = Console.ReadLine();
            if(reply == "yes")
            {
                CustomerSubcriptionClass customerSubcriptionClass = new CustomerSubcriptionClass();
                Console.WriteLine(customerSubcriptionClass.Unsubscribe(customerId));
                status= false;
            }
            else if(reply == "no")
            {
                CustomersSecondScreen.UpdateAndSubcribeMenu();
                status= false;
            }
            else
            {
                Console.WriteLine("Invalid Selection");
            }
            }while(status);
            Console.WriteLine("Redirecting...");
            Thread.Sleep(3000);
            CustomersSecondScreen.UpdateAndSubcribeMenu();
            
        }

        public static void viewCurrentCustomerSubcription(string customerId)
        {


            CustomerSubcriptionClass customerSubcriptionClass = new CustomerSubcriptionClass();
            CustomerService customerService = new CustomerService();
            var customer = customerSubcriptionClass.getSubcriptions(customerId);
            var MeterType = customerSubcriptionClass.getMeterModel(CustomerApplicationData.CurrentCustomerMeterNumber);
            
            if(customer == null)
            {
                Console.WriteLine("You dont have any current Subcription");
                Console.ReadLine();
            }
            else
            {

            
                var currentCustomerId = CustomerApplicationData.CurrentCustomerId;
                var searchCustomer = customerService.GetCustomerById(customerId);
                var tariffDetails = customerSubcriptionClass.getTariffModel(customer.TariffId);

                Console.WriteLine("*** Your Current Subscription details are ***");
                Console.WriteLine($"Name : {searchCustomer.FirstName} {searchCustomer.LastName}");
                Console.WriteLine($"Meter Number : {CustomerApplicationData.CurrentCustomerMeterNumber}");
                Console.WriteLine($"Meter Type : {MeterType.Type}");
                Console.WriteLine($"Tariff Name : {tariffDetails.Name} Price Per Unit {tariffDetails.PricePerUnit}");
                Console.WriteLine($"Amount : {customer.Amount}");
                Console.ReadLine();
            }          
                CustomersSecondScreen.UpdateAndSubcribeMenu();
        }
    }
}