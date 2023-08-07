using ParcelLib.Models;
using ParcelLib.ParcelDataAccess;
using ParcelLib.Services;
using ParcelLib.Services.IServices;
using ShipmentInfoAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IRetriveShipmentInfoFromXML, RetriveShipmentInfoFromXML>();
builder.Services.AddTransient<IHandleParcelService, HandleParcelService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.ConfigureApi();
app.Run();

