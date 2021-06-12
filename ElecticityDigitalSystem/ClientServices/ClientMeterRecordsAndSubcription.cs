using ElectricityDigitalSystem.ClientServices;
using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.Models;

namespace ElectricityDigitalSystem
{
    public class ClientMeterDetails : ClientServiceAPI
    {
        public string SaveMeterDetails(MeterModel meterDetails)
        {
           
           JsonFileService jsonFileService = new JsonFileService();
            fileService.database.Meters.Add(meterDetails);
            fileService.SaveChanges();
            return meterDetails.Id;
        }

        public string SaveMeterTariffDetails(TarriffModel tarrifDetails)
        {
           
           JsonFileService jsonFileService = new JsonFileService();
            fileService.database.Tariffs.Add(tarrifDetails);
            fileService.SaveChanges();
            return tarrifDetails.Id;
        }

        public string SaveCustomerSubcriptionDetails(CustomerSubcription customerSubcriptiondetails)
        {
           
           JsonFileService jsonFileService = new JsonFileService();
            fileService.database.Subcriptions.Add(customerSubcriptiondetails);
            fileService.SaveChanges();
            return customerSubcriptiondetails.Id;
        }
    }
}