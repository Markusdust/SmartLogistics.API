using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartLogistics.API.DataModels;
using SmartLogistics.API.Repositories;

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
builder.Services.AddScoped<IRoboterRepository, SqlRoboterRepository>();
builder.Services.AddScoped<ILagerplatzRepository, SqlLagerplatzRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
