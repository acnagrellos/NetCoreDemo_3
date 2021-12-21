using Customers.Api.Miiddewares;
using Customers.Services.Domain;
using Customers.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Settings>(builder.Configuration)
                .AddSingleton<ICustomerLogService, CustomerLogService>()
                .AddSingleton<ICustomersService, CustomerService>()
                .AddSwaggerGen()
                .AddControllers();

var app = builder.Build();

app.UseSwagger()
   .UseSwaggerUI()
   .UseMiddleware<LogCustomersMiddleware>()
   .UseMiddleware<CustomersCreatedMiddleware>();

app.MapControllers();

app.Run();
