using OrderApp.Models.Customers;
using System.Threading.Tasks;

namespace FunctionalTest.Given
{
    public partial class GivenFixture
    {
        public async Task<int> a_customer() 
        {
            var customer = new CreateCustomerRequest
            {
                Name = "Name",
                Surname = "Surname",
                Age = _random.Next(18, 80),
                Email = "email@email.com"
            };
            return await CustomerService.Create(customer);
        }

        public async Task<int> a_customer_desactive()
        {
            var customer = new CreateCustomerRequest
            {
                Name = "Name",
                Surname = "Surname",
                Age = _random.Next(18, 80),
                Email = "email@email.com"
            };
            var id = await CustomerService.Create(customer);
            await CustomerService.DesactiveUser(id);
            return id;
        }
    }
}
