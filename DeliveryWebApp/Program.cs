using DeliveryWebApp.Models.Abstractions;
using Microsoft.EntityFrameworkCore;
using DeliveryWebApp.Services;
using DeliveryWebApp.Data;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOrdersService, OrdersService>();

builder.Services.AddDbContext<OrderDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString(nameof(OrderDbContext)));
});

builder.Host.UseNLog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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