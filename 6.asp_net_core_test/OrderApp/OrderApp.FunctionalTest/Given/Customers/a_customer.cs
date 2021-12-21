using OrderApp.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.FunctionalTest.Given
{
    public partial class GivenFixture
    {
        public async Task<int> a_customer(
            string name = "Pepe", 
            string surname = "Lopez", 
            int age = 23, 
            string email = "email@email.com") 
        {
            var requestCustomer = new CreateCustomerRequest
            {
                Name = name,
                Surname = surname,
                Age = age,
                Email = email
            };

            return await CustomerService.Create(requestCustomer);
        }

        public async Task some_customer(int numberOfCustomers)
        {
            await Task.WhenAll(
                Enumerable.Range(0, numberOfCustomers).Select(async number => 
                {
                    await a_customer();
                })
            );
        }
    }
}
