using System;
using System.Collections.Generic;

using ElectricityDigitalSystem.ClientServices;
using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.Models;
using System.Threading;

namespace EDSAgentPortal
{
    public class UserDetails
    {

        public static void ViewUserDetails()
        {
            Console.Clear();
            Console.WriteLine("View user records");
            CustomerService customerService = new CustomerService();
            JsonFileService jsonFileService = new JsonFileService();
            Console.WriteLine("Enter an Email or press b to go back: ");
            var input = Console.ReadLine();


            if (input == "b")
            {
                Console.WriteLine("Redirecting .....");

                Thread.Sleep(2000);
                AgentSecondScreen.ChoseMenu();
            }


            var customer = customerService.GetCustomerByEmail(input);
            if (customer == null)
            {
                do
                {
                    Console.WriteLine("No such user registered please check the details provided");
                    Console.WriteLine("Enter an Email or press b to go back: ");
                    input = Console.ReadLine();
                    if (input == "b")
                    {
                        Console.WriteLine("Redirecting .....");
                        Thread.Sleep(2000);
                        AgentSecondScreen.ChoseMenu();
                    }


                } while (customer == null);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("***Customer details*** ");
                Console.WriteLine("Customer FistName: " + customer.FirstName);
                Console.WriteLine("Customer LastName: " + customer.LastName);
                Console.WriteLine("Customer Email ID: " + customer.EmailAddress);
                Console.WriteLine("Customer PhoneNumber: " + customer.PhoneNumber);
                Console.WriteLine("Customer MeterNumber: " + customer.MeterNumber);

                Console.ReadLine();
                Console.WriteLine("Redirecting .....");
                Thread.Sleep(3000);
                AgentSecondScreen.ChoseMenu();
            }

        }
    }
}