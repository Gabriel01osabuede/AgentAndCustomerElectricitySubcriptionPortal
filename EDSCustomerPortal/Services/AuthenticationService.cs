using ElectricityDigitalSystem.ClientServices;
using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDSCustomerPortal.Services
{
    public class AuthenticationService
    {
        public static string RegisterUser(CustomerModel model)
        {
          
                CustomerService service = new CustomerService();
                string id = service.RegisterCustomer(model);
                return id == null ? "Failed" : "Success";
        }

        public static CustomerModel LoginUser(string email)
        {
            CustomerService service = new CustomerService();
            var customerfound = service.GetCustomerByEmail(email);
            return customerfound;
        }
      
    }
}
