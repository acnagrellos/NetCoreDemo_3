using OrderApp.Domain;

namespace OrderApp.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public void UpdateClient(Customer customer)
        {
            customer.Update(
                this.Name,
                this.Surname,
                this.Age,
                this.Email);
        }

        public static CustomerDto ToMapper(Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                Age = customer.Age,
                Email = customer.Email,
                Name = customer.Name,
                Surname = customer.Surname
            };
        }
    }
}
