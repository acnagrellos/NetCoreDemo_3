using Customers.Services.Services;
using System.Net;

namespace Customers.Api.Miiddewares
{
    public class LogCustomersMiddleware
    {
        private readonly RequestDelegate _next;

        public LogCustomersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ICustomerLogService logCustomerService)
        {
            if (context.Request.Method == HttpMethod.Get.ToString() &&
                context.Request.Path.HasValue &&
                context.Request.Path.Value.StartsWith("/api/customers") &&
                context.Request.Path.Value.Split('/').Count() == 4 &&
                context.Response.StatusCode == (int)HttpStatusCode.OK)
            {
                var customerIdParam = context.Request.RouteValues.FirstOrDefault(r => r.Key == "customerId");
                if (customerIdParam.Value != null)
                {
                    logCustomerService.AddCustomerLog(int.Parse(customerIdParam.Value.ToString()));
                }
            }

            await _next.Invoke(context);
        }
    }
}
