using System;
using System.Collections.Generic;
using System.Threading;
using EDSAgentPortal.AppData;
using EDSAgentPortal.Services;
using ElectricityDigitalSystem.AgentServices;
using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.Models;

namespace EDSAgentPortal
{
    public class AgentMenu : AgentsModel
    {
        
            private static bool appIsRunning = true;
            private static bool inRegisterPage = false;
            private static bool inLoginPage = false;

            private static string id = null;
            
            
        public static void selection()
        {
            
            JsonFileService jsonFileService = new JsonFileService();
            jsonFileService.SaveChanges();
            


            while (appIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome To EDS AGENTS PORTAL.\n");

                Console.WriteLine("Choose an Option : 1. Login         2. Register         3. Exit App");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        inLoginPage = true;
                        
                       break;
                    case "2":
                        inRegisterPage = true;
                        break;
                    case "3":
                    Console.WriteLine("Thank you our dear esteem Agents");
                    Environment.Exit(1);
                    break;
                }

                while (inLoginPage)
                {
                    NavigateToLogInPage();
                    
                }
                while (inRegisterPage)
                {
                    NavigateToRegisterPage();
                }

                
            }
       

            static void NavigateToRegisterPage()
            {
                Dictionary<string, string> navItemDic = new Dictionary<string, string>();
                
                List<string> navigationItems = new List<string>
                {
                   "FirstName", "LastName" ,"Email" , "Password","Phone Number"
                };

                Console.Clear();
                Console.WriteLine("* Register your Details *** \n");
                AgentsModel model = new AgentsModel();

                
                for(int index =0; index < navigationItems.Count; index++)
                {
                    Console.Write($"Enter your  {navigationItems[index]} : " );
                    string value = Console.ReadLine();
                    navItemDic.Add(navigationItems[index], value);
                }

                AgentsModel agent = new AgentsModel();
                string FirstName,LastName,EmailAddress , Password, PhoneNumber;

                model.Id =  "AGT-" + Guid.NewGuid().ToString();
                
                FirstName = navItemDic["FirstName"];
                LastName = navItemDic["LastName"];
                EmailAddress= navItemDic["Email"];
                Password = navItemDic["Password"];
                PhoneNumber = navItemDic["Phone Number"];

                agent.Id = model.Id;
                agent.FirstName = FirstName;
                agent.LastName = LastName;
                agent.EmailAddress = EmailAddress;
                agent.Password = Password;
                agent.PhoneNumber = PhoneNumber;
                

                string response = AgentAuthenticationService.RegisterAgent(agent);

                if (response == "Success")
                {
                    Console.WriteLine("Registered Successfully ---> Redirecting To Home Page");
                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine("An Error Has Occured");
                } 

                inRegisterPage = false;

            }

            static  void NavigateToLogInPage()
            {   
                Console.WriteLine("Welcome Please input your details");
                bool status = true;

                do{
                   Console.WriteLine("Input Email");
                    string Email = Console.ReadLine();
                    var agent = AgentAuthenticationService.LoginAgent(Email);

                if(agent == null)
                {
                    Console.WriteLine("No such user registered please check the details provided");
                    Thread.Sleep(4000);

                    
                }
                else
                {
                  Console.WriteLine("Input Password");
                    string Password = Console.ReadLine();
                    if(agent.EmailAddress == Email && agent.Password != Password)
                    {
                        do
                        {   
                            Console.WriteLine("Wrong Password Inputed");
                            Console.WriteLine("Input Password");
                            Password = Console.ReadLine();
                        }while(agent.Password != Password);  
                    }
                    Console.WriteLine($"Welcome to the App {agent.FirstName} {agent.LastName}");
                    Console.WriteLine("* Redircting to Next Page *");
                    Thread.Sleep(4000);
                    id = agent.Id;
                    AgentApplicationData.CurrentAgentId = id;
                 
                status = false;
                }
            }while(status);
            
          AgentSecondScreen.ChoseMenu();
         
            inLoginPage = false;
        }     
    }
    }
}