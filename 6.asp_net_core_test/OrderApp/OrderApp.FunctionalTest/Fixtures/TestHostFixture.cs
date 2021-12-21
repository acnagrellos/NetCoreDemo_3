using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using OrderApp.Services.Contracts;
using System;
using System.Linq;

namespace OrderApp.FunctionalTest.Fixtures
{
    public class TestHostFixture : IDisposable
    {
        public TestServer Server { get; set; }

        public static IServiceProvider Services;

        public TestHostFixture()
        {
            Server = new TestServerBuilder().Build();

            Services = Server.Services;
        }

        public static void ResetCustomerService() 
        {
            var customersService = Services.GetService<ICustomerService>()!;
            var customersTask = customersService.GetAlls();
            customersTask.Wait();
            var customers = customersTask.Result;

            customers.ToList().ForEach(customer => customersService.Delete(customer.Id));
        }

        public void Dispose()
        {
            Server.Dispose();
        }
    }
}
