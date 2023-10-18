using BusinessLogic.BusinessLogics;
using BusinessLogic.Interfaces;
using DatabaseImplement.Implements;
using RestApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IComponentStorage, ComponentStorage>();
builder.Services.AddScoped<IOrderStorage, OrderStorage>();
builder.Services.AddScoped<IProductStorage, ProductStorage>();
builder.Services.AddScoped<ComponentLogic>();
builder.Services.AddScoped<OrderLogic>();
builder.Services.AddScoped<ProductLogic>();
builder.Services.AddScoped<ReportLogic>();
builder.Services.AddScoped<ClientLogic>();

var app = builder.Build();

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
