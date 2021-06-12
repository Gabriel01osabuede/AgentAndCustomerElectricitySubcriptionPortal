using ElectricityDigitalSystem.Data;
using ElectricityDigitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityDigitalSystem.ClientServices
{
    public class CustomerService :ClientServiceAPI
    {
        public string RegisterCustomer(CustomerModel customer)
        {
           
           JsonFileService jsonFileService = new JsonFileService();
            fileService.database.Customers.Add(customer);
            fileService.SaveChanges();
            return customer.Id;
        
        }
public bool DeleteCustomerByEmail(string email)
        {
            CustomerModel customer = fileService.database.Customers.Find(c => c.EmailAddress == email);
            if (customer != null)
            {
                fileService.database.Customers.Remove(customer);
                fileService.SaveChanges();
                // var response = Console.WriteLine("RECORDS SUCCESSFULLY DELETED");
                // return response;
                return true;
            }
            return false;
        }
        
        //Get Customer by
        public CustomerModel GetCustomerById(string customerId)
        {
            
            CustomerModel foundcustomer = fileService.database.Customers.Find(c => c.Id == customerId);
            if (foundcustomer != null)
            {
                return foundcustomer;
            }
            return null;
        }

        //Find Customer via Email
        public CustomerModel GetCustomerByEmail(string email)
        {
            CustomerModel foundcustomer = fileService.database.Customers.Find(c => c.EmailAddress == email);
            if (foundcustomer != null)
            {
                return foundcustomer;
                
            }
            return null;
        }

        public string UpdateCustomer(CustomerModel modifiedCustomer)
        {
            CustomerModel customer = this.GetCustomerById(modifiedCustomer.Id);
            if(customer != null)
            {
                int indexOfCustomer = fileService.database.Customers.IndexOf(customer);
                //fileService.database.Customers.Insert(indexOfCustomer, modifiedCustomer);
                fileService.SaveChanges();
                Console.WriteLine("RECORDS SUCCESSFULLY UPDATED");
                return "RECORDS SUCCESSFULLY UPDATED";
            }
            return "Failed, Customer not found";
        }

       
    }
}
