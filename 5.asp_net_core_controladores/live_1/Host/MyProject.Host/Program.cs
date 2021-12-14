var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(options => { options.ReportApiVersions = true; })
                .AddSwaggerGen()
                .AddControllers();

var app = builder.Build();

app.UseSwagger()
   .UseSwaggerUI();

app.MapControllers();

app.Run();
