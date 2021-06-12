using System;
using System.Collections.Generic;
using System.Text;
using ElectricityDigitalSystem.Models;
using ElectricityDigitalSystem.Data;

namespace ElectricityDigitalSystem.AgentServices
{
  public  class AgentService : AgentServiceAPI
    {
        public string RegisterAgents(AgentsModel agent)
        {
           
           JsonFileService jsonFileService = new JsonFileService();
            fileService.database.Agents.Add(agent);
            fileService.SaveChanges();
            return agent.Id;
        
        }

        public AgentsModel GetAgentById(string agentId)
        {
            
            AgentsModel data = fileService.database.Agents.Find(c => c.Id == agentId);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public AgentsModel GetAgentsByEmail(string email)
        {
            AgentsModel data = fileService.database.Agents.Find(c => c.EmailAddress == email);
            if (data != null)
            {
                return data;
                
            }
            return null;
        }

        public string UpdateAgent(AgentsModel model)
        {
            AgentsModel data = this.GetAgentById(model.Id);
            if(data != null)
            {
                int result = fileService.database.Agents.IndexOf(data);
                //fileService.database.Agents.Insert(indexOfCustomer, model);
                fileService.SaveChanges();
                Console.WriteLine("RECORDS SUCCESSFULLY UPDATED");
                return "RECORDS SUCCESSFULLY UPDATED";
            }
            return "Failed, Agent not found";
        }

        
          public string RegisterCustomerSubcription(AcceptAndProcessPaymentModel PaymentDetails)
        {
           
           JsonFileService jsonFileService = new JsonFileService();
            fileService.database.AcceptingPayment.Add(PaymentDetails);
            fileService.SaveChanges();
            return PaymentDetails.Id;
        
        }

        // public AgentsModel GetAgentById(string AgentId)
        // {
            
        //     AgentsModel foundAgents = fileService.database.Agents.Find(A => A.Id == AgentId);
        //     if (foundAgents != null)
        //     {
        //         return foundAgents;
        //     }
        //     return null;
        // }
        public string SavePaymentDetails(AcceptAndProcessPaymentModel PaymentDetails)
        {
           
           JsonFileService jsonFileService = new JsonFileService();
            fileService.database.AcceptingPayment.Add(PaymentDetails);
            fileService.SaveChanges();
            return PaymentDetails.Id;
        }
        public AcceptAndProcessPaymentModel GetCustomerPersonalTariffInformation(string meterNumber)
        {
            
            AcceptAndProcessPaymentModel foundCustomer = fileService.database.AcceptingPayment.Find(A => A.CustomerMeterNumber == meterNumber);
            if (foundCustomer != null)
            {
                return foundCustomer;
            }
            return null;
        }


    }
}
