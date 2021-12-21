using Microsoft.Extensions.DependencyInjection;
using OrderApp.FunctionalTest.Fixtures;
using OrderApp.Services.Contracts;

namespace OrderApp.FunctionalTest.Given
{
    public partial class GivenFixture
    {
        public ICustomerService CustomerService { get; set; }

        public GivenFixture(TestHostFixture host) 
        {
            CustomerService = host.Server.Services.GetService<ICustomerService>()!;
        }
    }
}
