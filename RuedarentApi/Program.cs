using Microsoft.EntityFrameworkCore;
using RuedarentApi.Orders.Application.Internal.CommandServices;
using RuedarentApi.Orders.Application.Internal.QueryServices;
using RuedarentApi.Orders.Domain.Repositories;
using RuedarentApi.Orders.Domain.Services;
using RuedarentApi.Orders.Infraestructure.Repositories;
using RuedarentApi.Plans.Application.Internal.QueryServices;
using RuedarentApi.Plans.Domain.Repositories;
using RuedarentApi.Plans.Domain.Services;
using RuedarentApi.Plans.Infraestructure.Repositories;
using RuedarentApi.Shared.Domain.Repositories;
using RuedarentApi.Shared.Infraestructure.Interfaces.ASP.Configuratin;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Configuration;
using RuedarentApi.Shared.Infraestructure.Persistences.EFC.Repositories;
using RuedarentApi.UserProfile.Application.Internal.CommandService;
using RuedarentApi.UserProfile.Application.Internal.QueryService;
using RuedarentApi.UserProfile.Domain.Repositories;
using RuedarentApi.UserProfile.Domain.Services;
using RuedarentApi.UserProfile.Infraestructure.Repositories;
using RuedarentApi.Vehicle.Application.Internal.CommandService;
using RuedarentApi.Vehicle.Application.Internal.QueryService;
using RuedarentApi.Vehicle.Domain.Repositories;
using RuedarentApi.Vehicle.Domain.Services;
using RuedarentApi.Vehicle.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add DataBase Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Configure Databasse context and loggin levels
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
    });

//Configure LowerCase Urls
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IVehicleSourceRepository, VehicleSourceRepository>();
builder.Services.AddScoped<IVehicleSourceCommandService, VehicleSourceCommandService>();
builder.Services.AddScoped<IVehicleSourceQueryService, VehicleSourceQueryService>();
//USER
builder.Services.AddScoped<IUserSourceRepository, UserSourceRepository>();
builder.Services.AddScoped<IUserSourceCommandService, UserSourceCommandService>();
builder.Services.AddScoped<IUserSourceQueryService, UserSourceQueryService>();

//Order
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderCommandService, OrderCommandService>();
builder.Services.AddScoped<IOrderQueryService, OrderQueryService>();

//Plan
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IPlanQueryService, PlanQueryService>();


//agregar cada entidad y arquetipo

var app = builder.Build();
//Verify DataBase object are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();


app.Run();

