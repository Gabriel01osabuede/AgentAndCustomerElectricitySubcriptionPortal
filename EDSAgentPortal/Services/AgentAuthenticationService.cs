using ElectricityDigitalSystem.AgentServices;
using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSAgentPortal.Services
{
    public class AgentAuthenticationService
    {
        
        public static string RegisterAgent(AgentsModel model)
        {
          
             AgentService service = new AgentService();
                string id = service.RegisterAgents(model);
                return id == null ? "Failed" : "Success";
        }

        public static AgentsModel LoginAgent(string email)
        {
           AgentService service = new AgentService();
            var Agentsfound = service.GetAgentsByEmail(email);
            return Agentsfound;
        }
      
    }
}
