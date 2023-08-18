using Question2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2.Services
{
    public class CustomerService
    {
        private List<Customer> customers = new List<Customer>();

        public void AddCustomers(List<Customer> newCustomers)
        {
            foreach (var newCustomer in newCustomers)
            {
                if (string.IsNullOrEmpty(newCustomer.FirstName) ||
                    string.IsNullOrEmpty(newCustomer.LastName) ||
                    newCustomer.Age <= 18)
                {
                    // Skip invalid customer data
                    continue;
                }

                // Check if ID is already used
                bool idExists = customers.Any(c => c.Id == newCustomer.Id);
                if (idExists)
                {
                    // Handle duplicate ID error
                    continue;
                }

                // Find the correct position to insert the customer
                int insertIndex = 0;
                while (insertIndex < customers.Count &&
                       string.Compare(customers[insertIndex].LastName, newCustomer.LastName, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    insertIndex++;
                }
                while (insertIndex < customers.Count &&
                       string.Compare(customers[insertIndex].FirstName, newCustomer.FirstName, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    insertIndex++;
                }

                // Insert the customer at the calculated index
                customers.Insert(insertIndex, newCustomer);
            }
        }


        public List<Customer> GetCustomers()
        {
            return customers;
        }

        // Other methods for validation, insertion, and persistence
    }
}
