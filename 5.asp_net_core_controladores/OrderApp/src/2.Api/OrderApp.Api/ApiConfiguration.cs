using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrderApp.Services.Contracts;
using OrderApp.Services.MemoryServices;
using System.Reflection;

namespace OrderApp.Api
{
    public static class ApiConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services) 
        {
            services.AddSingleton<ICustomerService, CustomerMemoryService>()
                    .AddControllers()
                    .AddApplicationPart(typeof(ApiConfiguration).GetTypeInfo().Assembly)
                    .AddControllersAsServices();
        }

        public static WebApplication UseApiConfiguration(this WebApplication app)
        {
            return app;
        }

        public static ControllerActionEndpointConventionBuilder MapApiEndpoints(this IEndpointRouteBuilder endpoints)
        {
            return endpoints.MapControllers();
        }
    }
}
