using Microsoft.OpenApi.Models;
using RentACar.BLL.Infrastructure.CarRentalAbstractFactory;
using RentACar.BLL.Infrastructure.RentalBuilders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRentalBuilder, RentalBuilder>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting(); // UseRouting() yöntemini burada çaðýrýn

// ... diðer ara yazýlým ayarlarý devam eder

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();

