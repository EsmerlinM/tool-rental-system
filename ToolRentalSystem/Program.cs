using Microsoft.EntityFrameworkCore;
using ToolRentalSystem.Application.Contract;
using ToolRentalSystem.Application.Services;
using ToolRentalSystem.Data;
using ToolRentalSystem.Domain.Core.Interfaces;
using ToolRentalSystem.Infrastructure.Context;
using ToolRentalSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ToolRentalSystem.Data.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ToolRentalSystem.Infrastructure.Context.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped<IToolService, ToolService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();