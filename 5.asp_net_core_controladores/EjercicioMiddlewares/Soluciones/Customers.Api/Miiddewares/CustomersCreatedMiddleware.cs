using System.Net;

namespace Customers.Api.Miiddewares
{
    public class CustomersCreatedMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomersCreatedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);

            if (context.Request.Method == HttpMethod.Post.ToString() && 
                context.Request.Path == "/api/customers" && 
                context.Response.StatusCode == (int)HttpStatusCode.Created) 
            {
                Console.WriteLine("Customer created!");
            }

        }
    }
}
