using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using DataLayer;

namespace BusinessLayer
{
    // Hangi sorguyla hangi dataları çekeceğimi yapılandıracağım kısım
    // BusinessLayer projeme Models folder ekledim. (EF otomatik yapardı)
    // Customer çekecem
    public class BusinessLogicLayer
    {
        // Presentation Layer'dan ulaşıyor olacam bu methoda
        public List<Customer> Customers()
        {
            string query = "Select * From Customers"; // ADO.Net olduğu için böyle yazmak durumundayız.
            List<Customer> customers = new List<Customer>();

            DataAccessLayer dataLayer = new DataAccessLayer(); // Bu instance db'ye erişiyor olacak

            SqlCommand cmd = dataLayer.ExecuteCommand(query);

            // Burada dataya satır satır erişebilmek için
            SqlDataReader reader = cmd.ExecuteReader(); // satır ve sütunlardan oluşan bir data set döndürür

            while(reader.Read()) // while kayıt varsa anlamında
            {
                // ado'dan dolayı manuel mapping yaparız
                Customer customer = new Customer(); // her satırı bir customer objesine map edicem
                customer.CustomerID = reader["CustomerID"].ToString(); // reader: bir satır
                customer.CompanyName = reader["CompanyName"].ToString(); 
                customer.ContactTitle = reader["ContactTitle"].ToString(); 
                customer.ContactName = reader["ContactName"].ToString(); 
                customer.Address = reader["Address"].ToString();
                customer.PostalCode = reader["PostalCode"].ToString();
                customer.Country = reader["Country"].ToString();
                customer.Phone = reader["Phone"].ToString();
                customer.Region = reader["Region"].ToString();
                customer.Fax = reader["Fax"].ToString();
                customer.City = reader["City"].ToString();

                if(!customers.Contains(customer))
                {
                    customers.Add(customer);
                } 
            }

            dataLayer.CloseConnection(cmd.Connection);

            return customers;
        }
    }
}
