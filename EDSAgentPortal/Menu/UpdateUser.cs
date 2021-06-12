using System;
using System.Threading;
using System.Collections.Generic;
using EDSAgentPortal.AppData;
using ElectricityDigitalSystem.AgentServices;
using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.Models;
using ElectricityDigitalSystem.ClientServices;

namespace EDSAgentPortal.Menu
{
    public class UpdateUserDetails
    {
        public static void UserInputUpdate()
        {
            Console.Clear();
            Console.WriteLine("Welcome!!! \n Please Update user records");
            CustomerService customerService = new CustomerService();
            JsonFileService jsonFileService = new JsonFileService();
            Console.WriteLine("Enter an Email or -1 to go back: ");
            var input = Console.ReadLine();

            if (input == "-1")
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
                    Console.WriteLine("No such customer registered please check the details provided");
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
            Console.WriteLine(customer.FirstName);
            Console.WriteLine("Which customer data would you like to update\n press 1 for FirstName\nPress 2 for LastName\nPress 3 for Email Address\nPress 4 for Phone Number\nPress 5 for Password\nPress 6 for Meter Number");
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
            AgentSecondScreen.ChoseMenu();

        }
    }
}