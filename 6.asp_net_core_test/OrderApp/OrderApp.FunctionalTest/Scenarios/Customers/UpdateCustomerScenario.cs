using AutoFixture;
using FluentAssertions;
using OrderApp.Api;
using OrderApp.FunctionalTest.Extensions;
using OrderApp.FunctionalTest.Fixtures;
using OrderApp.FunctionalTest.Fixtures.Reset;
using OrderApp.FunctionalTest.Given;
using OrderApp.Models.Customers;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OrderApp.FunctionalTest.Scenarios.Customers
{
    [Collection(TestConstants.TestCollectionName)]
    public class UpdateCustomerScenario
    {
        private readonly TestHostFixture _host;
        private readonly Func<int, string> _url;
        private readonly GivenFixture _given;
        private readonly Fixture _autofixture;
        private readonly Random _random;

        public UpdateCustomerScenario(TestHostFixture host)
        {
            this._host = host;
            this._given = new GivenFixture(host);
            _url = (int id) => $"/{ApiConstants.BaseUri}/{ApiConstants.CustomersUri}/{id}";
            this._autofixture = new Fixture();
            _random = new Random();
        }

        [Fact]
        [ResetCustomersService]
        public async Task return_ok_when_pass_parameters_correct() 
        {
            // Arrange
            var customerId = await _given.a_customer();
            var request = _autofixture.Build<UpdateCustomerRequest>()
                                      .With(request => request.Email, "email@email.com")
                                      .With(request => request.Age, _random.Next(18, 100))
                                      .Create();

            // Act 
            var response = await _host.Server.CreateClient().PutJsonAsync(_url(customerId), request);

            // Asset
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task return_preconditionalfailed_when_pass_name_null()
        {
            // Arrange
            var customerId = await _given.a_customer();
            var request = _autofixture.Build<UpdateCustomerRequest>()
                                      .Without(request => request.Name)
                                      .With(request => request.Email, "email@email.com")
                                      .With(request => request.Age, _random.Next(18, 100))
                                      .Create();

            // Act 
            var response = await _host.Server.CreateClient().PutJsonAsync(_url(customerId), request);

            // Asset
            response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }

        [Fact]
        public async Task return_preconditionalfailed_when_pass_name_null()
        {
            // Arrange
            var customerId = await _given.a_customer();
            var request = _autofixture.Build<UpdateCustomerRequest>()
                                      .Without(request => request.Name)
                                      .With(request => request.Email, "email@email.com")
                                      .With(request => request.Age, _random.Next(18, 100))
                                      .Create();

            // Act 
            var response = await _host.Server.CreateClient().PutJsonAsync(_url(customerId), request);

            // Asset
            response.StatusCode.Should().Be(HttpStatusCode.PreconditionFailed);
        }
    }
}
