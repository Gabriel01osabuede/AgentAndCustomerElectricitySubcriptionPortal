using System;
using System.Collections.Generic;
using EDSAgentPortal.AppData;
using System.Threading;
using ElectricityDigitalSystem.AgentServices;
using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.Models;
using ElectricityDigitalSystem.ClientServices;


namespace EDSAgentPortal{
public class RegisterUserDetails{
    public static void NavigateToRegisterPage()
    {
        Console.Clear();
        Dictionary<string, string> navItemDic = new Dictionary<string, string>();
                
        List<string> navigationItems = new List<string>
       {
           "FirstName", "LastName" ,"Email" , "Password","Meter Number","Phone Number"
       };

        Console.Clear();
        Console.WriteLine("*** Register your Details ******* \n");
        CustomerModel customerModel = new CustomerModel();

                
        for(int index =0; index < navigationItems.Count; index++)
        {
            Console.Write($"Enter your  {navigationItems[index]} : " );
            string value = Console.ReadLine();
            navItemDic.Add(navigationItems[index], value);
        }

        CustomerModel customerForm = new CustomerModel();
        string FirstName,LastName,EmailAddress , Password, MeterNumber,PhoneNumber;

        customerModel.Id =  "CUS-" + Guid.NewGuid().ToString();
            
        FirstName = navItemDic["FirstName"];
        LastName = navItemDic["LastName"];
        EmailAddress= navItemDic["Email"];
        Password = navItemDic["Password"];
        MeterNumber = navItemDic["Meter Number"];
        PhoneNumber = navItemDic["Phone Number"];

        customerForm.Id = customerModel.Id;
        customerForm.FirstName = FirstName;
        customerForm.LastName = LastName;
        customerForm.EmailAddress = EmailAddress;
        customerForm.Password = Password;
        customerForm.MeterNumber = MeterNumber;
        customerForm.PhoneNumber = PhoneNumber;
                
        CustomerService customer=new CustomerService();
        string response = customer.RegisterCustomer(customerForm);

        if (response == "Success")
        {
            Console.WriteLine("Registered Successfully ---> Redirecting To Home Page");
            Thread.Sleep(3000);
        }
        else
        {
            Console.WriteLine("An Error Has Occured");
        } 

        AgentSecondScreen.ChoseMenu();

        }
    }       
} 