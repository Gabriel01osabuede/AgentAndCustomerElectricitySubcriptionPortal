using System;
using EDSCustomerPortal.AppData;
using ElectricityDigitalSystem;
using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.Models;

namespace EDSCustomerPortal
{
    public class PopulateTariffModel
    {
        public static void PopulatingTariffModel()
        {
            JsonFileService jsonFileService = new JsonFileService();
            TarriffModel tarriffModel = new TarriffModel();
            ClientMeterDetails clientMeterDetails = new ClientMeterDetails();
            
            
            Console.WriteLine("Which Tariff are you subcribing for?");
            tarriffModel.Id = Guid.NewGuid().ToString();
            CustomerApplicationData.CurrentCustomerTarrifId = tarriffModel.Id;
            Console.WriteLine("Current Tariff Classes Are \nS1 = #16/KWH\nA3 = #25/KWH\nD1 = #23/KWH\nR3 = #18/KWH");
            Console.WriteLine("What Tariff Class Are You Subcribing To ?\nPress 1 for S1\nPress 2 for A3\nPress 3 for D1\nPress 4 for R3");
            int tariffName = Convert.ToInt32(Console.ReadLine());
            switch (tariffName)
            {
                case 1:
                tarriffModel.Name = "S1";
                tarriffModel.PricePerUnit = Convert.ToDecimal(TariffName.S1);
                break;
                case 2:
                tarriffModel.Name = "A3";
                tarriffModel.PricePerUnit = Convert.ToDecimal(TariffName.A3);
                break;
                case 3:
                tarriffModel.Name = "D1";
                tarriffModel.PricePerUnit = Convert.ToDecimal(TariffName.D1);
                break;
                case 4:
                tarriffModel.Name = "R3";
                tarriffModel.PricePerUnit = Convert.ToDecimal(TariffName.R3);
                break;
                default:
                Console.WriteLine("Wrong selection");
                break;

            }
            
            jsonFileService.SaveChanges();
            clientMeterDetails.SaveMeterTariffDetails(tarriffModel);
        }
    }
}