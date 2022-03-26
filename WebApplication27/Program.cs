using WebApiContrib.Core;
using WebApplication24.Services;
using WebApplication25.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



var app = builder.Build();

app.UseBranchWithServices("/api1",
    (services) =>
    {
        services.AddTransient<ITestService, TestService>();
        services.AddTransient<ITestInternalService, TestInternalService>();
        services.AddTransient(sp => "api1");
        services.AddMvc(opt => { opt.EnableEndpointRouting = false; }).AddApplicationPart(typeof(HomeController).Assembly);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    },
    (appBuilder) =>
    {
        appBuilder.UseSwagger();
        appBuilder.UseSwaggerUI();
        appBuilder.UseHttpsRedirection();
        appBuilder.UseMvc();

        appBuilder.Run(async c =>
        {
            await c.Response.WriteAsync("Hi api1!");
        });
    });

app.UseBranchWithServices("/api2",
    (services) =>
    {
        services.AddTransient<ITestService, TestService>();
        services.AddScoped<ITestInternalService, TestInternalService>();
        services.AddTransient(sp => "api2");
        services.AddMvc(opt => { opt.EnableEndpointRouting = false; }).AddApplicationPart(typeof(HomeController).Assembly);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    },
    (appBuilder) =>
    {
        appBuilder.UseSwagger();
        appBuilder.UseSwaggerUI();
        appBuilder.UseHttpsRedirection();
        appBuilder.UseMvc();

        appBuilder.Run(async c =>
        {
            await c.Response.WriteAsync("Hi api2!");
        });
    });

app.Run(async c =>
{
    await c.Response.WriteAsync("Hi!");
});
app.Run();
