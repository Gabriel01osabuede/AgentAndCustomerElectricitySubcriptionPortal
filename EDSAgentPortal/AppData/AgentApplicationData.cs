using System;
using System.Collections.Generic;
using System.Text;

namespace EDSAgentPortal.AppData
{
    public class AgentApplicationData
    {
        public DateTime LastLoginDate { get; set; }
        public static string CurrentAgentId { get; set; } = null;
      
    }
}
