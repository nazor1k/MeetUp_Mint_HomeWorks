using Microsoft.EntityFrameworkCore;
using SSC.Eshop.Business.Services.UserService;
using SSC.EShop.Core.Interfaces;
using SSC.EShop.Infrastructure.Data;
using SSC.EShop.Infrastructure.Logging;
using SSC.EShop.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<EshopDbContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton(typeof(IAppLogger<>), typeof(LoggerAdapter<>));


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
