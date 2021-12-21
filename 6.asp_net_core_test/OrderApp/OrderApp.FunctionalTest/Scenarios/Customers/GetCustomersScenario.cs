using FluentAssertions;
using OrderApp.Api;
using OrderApp.FunctionalTest.Extensions;
using OrderApp.FunctionalTest.Fixtures;
using OrderApp.FunctionalTest.Fixtures.Reset;
using OrderApp.FunctionalTest.Given;
using OrderApp.Models.Customers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OrderApp.FunctionalTest.Scenarios.Customers
{
    [Collection(TestConstants.TestCollectionName)]
    public class GetCustomersScenario
    {
        private readonly TestHostFixture _host;
        private readonly string _url = $"/{ApiConstants.BaseUri}/{ApiConstants.CustomersUri}";
        private readonly GivenFixture _given;

        public GetCustomersScenario(TestHostFixture host) 
        {
            this._host = host;
            this._given = new GivenFixture(host);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_ok_when_call_get_customers() 
        {
            // Arrange

            // Act
            var customers = await _host.Server
                                       .CreateClient()
                                       .GetJsonAsync<IEnumerable<CustomerResponse>>(_url);

            //Assert
            customers?.Count().Should().Be(0);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_ok_when_exists_3_customers()
        {
            // Arrange
            var customerId1 = _given.some_customer(3);

            // Act
            var customers = await _host.Server
                                       .CreateClient()
                                       .GetJsonAsync<IEnumerable<CustomerResponse>>(_url);

            //Assert
            customers?.Count().Should().Be(3);
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_ok_when_exists_8_customers()
        {
            // Arrange
            var numberOfCustomers = 8;
            var customerId1 = _given.some_customer(numberOfCustomers);

            // Act
            var customers = await _host.Server
                                       .CreateClient()
                                       .GetJsonAsync<IEnumerable<CustomerResponse>>(_url);

            //Assert
            customers?.Count().Should().Be(numberOfCustomers);
        }
    }
}
