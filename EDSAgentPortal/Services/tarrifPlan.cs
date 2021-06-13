using System;
using System.Threading;
using ElectricityDigitalSystem;
using ElectricityDigitalSystem.AgentServices;
using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.Models;

namespace EDSAgentPortal
{
    public class TariffPlanPrices
    {
        private static void settingTariffPrices()
        {
            AgentService agentService = new AgentService();
            TariffName tariffName = new TariffName();
            var tariffPrice = agentService.GetTariffById("tariffprice");
            if (tariffPrice == null)
            {
                tariffName.Id = "tariffprice";
                Console.WriteLine("Please fill in all the prices");
                Console.WriteLine("Fill in Price for A3");
                tariffName.A3 = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Fill in Price for S1");
                tariffName.S1 = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Fill in Price for D1");
                tariffName.D1 = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Fill in Price for R3");
                tariffName.R3 = Convert.ToDecimal(Console.ReadLine());

                agentService.SaveTariffPrice(tariffName);
            }
            else
            {
                Console.WriteLine("You already have tariff Prices Set..You can only Update");
                Thread.Sleep(3000);
            }
            AgentSecondScreen.ChoseMenu();
        }

        public static void GetAcessToSetTariffPrices()
        {
            TariffPlanPrices.settingTariffPrices();
        }
        private static void UpdatingTariffPrice()
        {
            JsonFileService jsonFileService = new JsonFileService();
            TariffName tariffName = new TariffName();
            AgentService agentService = new AgentService();
            var tariffClass = agentService.GetTariffById("tariffprice");
            if (tariffClass != null)
            {
                Console.WriteLine("Please select which tariffPlan You would like to Update.");
                Console.WriteLine("Select from the list provided and set the Tariff Price");
                bool status = true;
                do
                {
                    Console.WriteLine("Press 1 for A3\nPress 2 for S1\nPress 3 for R3\nPress 4 for D1");
                    string selection = Console.ReadLine();
                    switch (selection)
                    {
                        case "1":
                            Console.WriteLine("A3");
                            tariffClass.A3 = Convert.ToDecimal(Console.ReadLine());
                            break;
                        case "2":
                            Console.WriteLine("S1");
                            tariffClass.S1 = Convert.ToDecimal(Console.ReadLine());
                            break;
                        case "3":
                            Console.WriteLine("R3");
                            tariffClass.R3 = Convert.ToDecimal(Console.ReadLine());
                            break;
                        case "4":
                            Console.WriteLine("D1");
                            tariffClass.D1 = Convert.ToDecimal(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Wrong Selection");
                            break;
                    }
                    Console.WriteLine("Do you want to update other prices\nYes or No");
                    string reply = Console.ReadLine().ToLower();
                    if (reply == "no")
                    {
                        status = false;
                        jsonFileService.SaveChanges();
                        agentService.UpdateTariffPrice(tariffClass);
                        Console.WriteLine("Prices Saved Successfully");
                        Console.WriteLine("Redirecting......");
                        Thread.Sleep(3000);
                    }

                } while (status);

            }
            else
            {
                Console.WriteLine("Please set Tariff Prices before you can update");
                Thread.Sleep(3000);
            }
            

            AgentSecondScreen.ChoseMenu();
        }

        public static void GetAcessToUpdateTariffPrice()
        {
            TariffPlanPrices.UpdatingTariffPrice();
        }
    }
}