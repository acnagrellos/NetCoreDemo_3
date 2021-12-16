using MyProject.Api.Middlewares;
using MyProject.Api.Models;
using MyProject.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Settings>(builder.Configuration)
                .AddSingleton<IStudentService, StudentsService>()
                .AddSingleton<ITimeServiceSingleton, TimeService>()
                .AddScoped<ITimeServiceScoped, TimeService>()
                .AddTransient<ITimeServiceTrasient, TimeService>()
                .AddScoped<IFormatLanguage, FormatLanguage>()
                .AddApiVersioning(options => 
                {
                    options.ReportApiVersions = true;
                })
                .AddSwaggerGen()
                .AddControllers();

var app = builder.Build();

app.Use(async (context, next) => {
        Console.WriteLine("Before Middleware");
        // Before the call
        await next();
        // After the call

        Console.WriteLine("After Middleware");
    })
    .UseMiddleware<CustomMiddlewares>();

app.UseSwagger()
   .UseSwaggerUI();

app.MapControllers();

app.Run();
