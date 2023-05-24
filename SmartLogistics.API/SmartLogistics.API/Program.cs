using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartLogistics.API;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.MqttConnection;
using SmartLogistics.API.Repositories;



TestWertebekommen versuch = new TestWertebekommen();
versuch.GetMethode();



var builder = WebApplication.CreateBuilder(args);
var isDevelopment = builder.Environment.IsDevelopment();
// Add services to the container.

builder.Services.AddCors((options) =>
{
    options.AddPolicy("angularApplication", (builder) =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithExposedHeaders("*");
    });
});
builder.Services.AddControllers();

if(isDevelopment)
{
    builder.Services.AddDbContext<SmartLogisticsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SmartLogisticsDEV")));
} else
{
    builder.Services.AddDbContext<SmartLogisticsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SmartLogisticsPROD")));
}


builder.Services.AddScoped<IKundenRepository, SqlKundenRepository>();
builder.Services.AddScoped<IGeschlechtRepsitory, SqlGeschlechtRepository>();
builder.Services.AddScoped<IProdukteRepository, SqlProduktRepository>();
builder.Services.AddSingleton<IMqttRepository, MqttRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var repo = app.Services.GetService<IMqttRepository>();


//MQTT subscribe starten
 ClientSubscribe.Connect_Client();
// Client_Subscriber.Subscribe_Topic();
 //ClientSubscribe.Handle_Received_Application_Message(repo);




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseRouting();

app.UseCors("angularApplication");

app.UseAuthorization();

app.MapControllers();

app.Run();

