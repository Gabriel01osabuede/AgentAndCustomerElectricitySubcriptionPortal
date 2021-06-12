using System;
using System.Threading;
using EDSCustomerPortal.AppData;

namespace EDSCustomerPortal
{
    public class CustomersSecondScreen
    {
        public static void UpdateAndSubcribeMenu()
        {
            
            Menu menu = new Menu();
            Console.Clear();
            Console.WriteLine("Welcome");
            Console.WriteLine("Press 1 to Update your Records\nPress 2 to Subcribe To A Tariff plan\nPress 3 to Unsubcribe from your Tariff Plan\nPress 4 To View Current Subcription\nPress 5 to Logout");
            string reply = Console.ReadLine();
            switch (reply)
            {
                case "1":
                CustomerUpdateInputs.CustomerInputingDetails();
                break;
                case "2":
                Subcriptions.subcribe();
                break;
                case "3":
                Subcriptions.unSubcribeFromCurrentSubcription(CustomerApplicationData.CurrentCustomerId);
                break;
                case "4":
                Subcriptions.viewCurrentCustomerSubcription(CustomerApplicationData.CurrentCustomerId);
                break;
                case "5":
                Console.WriteLine("Redirecting");
                Thread.Sleep(2000);
                Menu.selection();
                break;
            }
        }
    }
}