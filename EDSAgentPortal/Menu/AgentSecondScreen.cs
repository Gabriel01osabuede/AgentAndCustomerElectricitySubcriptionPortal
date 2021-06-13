using System;
using System.Threading;
using EDSAgentPortal.AppData;
using EDSAgentPortal.Menu;
namespace EDSAgentPortal
{
    public class AgentSecondScreen
    {
        public static void ChoseMenu()
        {
            Console.Clear();
            AgentMenu menu = new AgentMenu();
            Console.Clear();
            Console.WriteLine("Welcome");
            Console.WriteLine("Press 1: to Register new user \nPress 2: Remove user \nPress 3: to Update user details \nPress 4: to view user details\nPress 5 :  To process a payment for a customer\nPress 6 : to view A customer Profile/Electricty Tariff Details.\nPress 7 : to Modify Current Tariff Prices\nPress 8 : to Set current Tariff Price.");
            string reply = Console.ReadLine();
            switch (reply)
            {
                case "1":
                    RegisterUserDetails.NavigateToRegisterPage();
                    break;
                case "2":
                    DeleteUser.DeleteUserDetail();
                    break;
                case "3":
                    UpdateUserDetails.UserInputUpdate();
                    break;
                case "4":
                    UserDetails.ViewUserDetails();
                    break;
                case "5":
                    AcceptPayment.AcceptUserDetailsForPayment();
                    break;
                case "6":
                    TariffInformation.ViewCustomerInformation();
                    break;
                case "7":
                    TariffPlanPrices.GetAcessToUpdateTariffPrice();
                    break;
                case "8":
                    TariffPlanPrices.GetAcessToSetTariffPrices();
                    break;
                default:
                    Console.WriteLine("Selected Option Deosn't exist");
                    Thread.Sleep(2000);
                    AgentMenu.selection();
                    break;
            }
        }
    }
}