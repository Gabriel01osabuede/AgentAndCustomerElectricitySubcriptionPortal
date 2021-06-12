using System;
using System.Collections.Generic;
using EDSCustomerPortal.AppData;
using ElectricityDigitalSystem.ClientServices;
using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.Models;

namespace EDSCustomerPortal
{
    public class CustomerUpdateInputs
    {
        public static void CustomerInputingDetails()
        {
                Console.WriteLine("Welcome Please Update your records");
                CustomerService customerService = new CustomerService();
                JsonFileService jsonFileService = new JsonFileService();
                string id = CustomerApplicationData.CurrentCustomerId;
                var customer = customerService.GetCustomerById(id);
                Console.WriteLine(customer.FirstName);
                Console.WriteLine("Which data would you like to update\n press 1 for FirstName\nPress 2 for LastName\nPress 3 for Email Address\nPress 4 for Phone Number\nPress 5 for Password\nPress 6 for Meter Number");
                var reply = Console.ReadLine();

                switch (reply)
                {
                    case "1":
                    Console.WriteLine("Enter your new First Name");
                    string firstName = Console.ReadLine();
                    customer.FirstName = firstName;
                    break;
                    case "2":
                    Console.WriteLine("Enter your new Last Name");
                    string lastName = Console.ReadLine();
                    customer.LastName = lastName;
                    break;
                    case "3":
                    Console.WriteLine("Enter your new Email Address");
                    string email = Console.ReadLine();
                    customer.EmailAddress = email;
                    break;
                    case "4":
                    Console.WriteLine("Enter your new Phone Number");
                    string phoneNumber = Console.ReadLine();
                    customer.PhoneNumber = phoneNumber;
                    break;
                    case "5":
                    Console.WriteLine("Enter your new password");
                    string password = Console.ReadLine();
                    customer.Password = password;
                    break;
                    case "6":
                    Console.WriteLine("Enter your new Meter Number");
                    string meterNumber = Console.ReadLine();
                    customer.MeterNumber = meterNumber;
                    break;
                }

                jsonFileService.SaveChanges();
                customerService.UpdateCustomer(customer);
                Console.WriteLine("Redirecting ....");
                CustomersSecondScreen.UpdateAndSubcribeMenu();             
   
        }
    }
}