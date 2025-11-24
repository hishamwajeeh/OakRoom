using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OakRoom.API.Extensions;
using OakRoom.API.Middlewares;
using OakRoom.Application.Extensions;
using OakRoom.Core.Entities;
using OakRoom.Infrastructure.Extensions;
using OakRoom.Infrastructure.Persistence;
using OakRoom.Infrastructure.Sedders;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Single correct DbContext registration
builder.Services.AddDbContext<OakRoomDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging());

// Identity API endpoints (after DbContext)
builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<OakRoomDbContext>();


// Custom layers
builder.AddPresentation();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

// Seeder
using (var scope = app.Services.CreateScope())
{
    var sedder = scope.ServiceProvider.GetRequiredService<IRestaurantSedder>();
    await sedder.Seed();
}

// Middlewares
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeLoggingMiddleware>();
app.UseSerilogRequestLogging();

// Swagger in dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Identity endpoints mapping
app.MapGroup("api/identity")
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
