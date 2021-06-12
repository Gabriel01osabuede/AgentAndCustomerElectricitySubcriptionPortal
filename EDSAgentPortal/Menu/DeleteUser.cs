using System;
using System.Collections.Generic;
using EDSAgentPortal.AppData;
using ElectricityDigitalSystem.AgentServices;
using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.Models;
using ElectricityDigitalSystem.ClientServices;
using System.Threading;

namespace EDSAgentPortal.Menu
{
    public class DeleteUser
    {
        public static void DeleteUserDetail()
        {
                Console.Clear();
                Console.WriteLine("Delete user records");
                CustomerService customerService = new CustomerService();
                JsonFileService jsonFileService = new JsonFileService();
               Console.WriteLine("Enter an Email or press b to go back: ");
                var input = Console.ReadLine();
                if(input == "b")
                         {
                            Console.WriteLine("Redirecting .....");
                            Thread.Sleep(2000);
                            AgentSecondScreen.ChoseMenu();
                         }
                var customer = customerService.GetCustomerByEmail(input);

                if(customer == null)
                {
                    do{
                        Console.WriteLine("No such user registered please check the details provided");
                        Console.WriteLine("Enter an Email or press b to go back: ");
                         input = Console.ReadLine();
                         if(input == "b")
                         {
                            Console.WriteLine("Redirecting .....");
                            Thread.Sleep(2000);
                            AgentSecondScreen.ChoseMenu();
                         }
                    }while (customer == null);
                
                }
                
                Console.WriteLine($"{customer.FirstName} Are you sure you would like to Delete this User \n press 1 for YES \nPress 2 for NO");
                var reply = Console.ReadLine();
                switch (reply)
                {
                    case "1":
                    DeleteUserTrueOption(input);
                    break;
                    
                    case "2":
                    AgentSecondScreen.ChoseMenu();
                    break;
                    
                    default: Console.WriteLine("Selected Option Deosn't exist");
                    break;
                }
        }
        public static void DeleteUserTrueOption(string input)
        {
                CustomerService customerService = new CustomerService();
                JsonFileService jsonFileService = new JsonFileService();
                var customer = customerService.GetCustomerByEmail(input);
                

            
                jsonFileService.SaveChanges();
                var response = customerService.DeleteCustomerByEmail(input);
                
                 if (response != false)
                {
                    Console.WriteLine("Redirecting ....");
                    Thread.Sleep(3000);
                  AgentSecondScreen.ChoseMenu();
                }          
                Console.WriteLine("Error Occured .....");
                Thread.Sleep(3000);
        }
       }
}