using Bsynchro.API.Dependencies;
using Bsynchro.API.MiddleWares;
using Bsynchro.Application.Services;
using Bsynchro.Contracts.IServices;
using Bsynchro.EntityFramework.Core;
using Bsynchro.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var CorsAngularPolicy = "P_ALLOW_ANGULAR_CORS";
var angularUrl = configuration["angular:url"];

// Add services to the container.
ReposResolver.Resolve(builder.Services);
ServiceResolver.Resolve(builder.Services);

//Add DbContext
builder.Services.AddDbContext<RJPDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("RJPConnection")));

//Add CORS Policy 
builder.Services.AddCors(option =>
{
    option.AddPolicy(CorsAngularPolicy, policy => { policy.AllowAnyOrigin(); policy.AllowAnyMethod(); policy.AllowAnyHeader(); });
});

builder.Services.AddControllers();
//    .AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//    options.JsonSerializerOptions.MaxDepth = 64; // or another higher value if needed
//}); ;
builder.Services.AddAutoMapper(typeof(ApplicationMapper));



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
else
{
    app.UseMiddleware<GlobalErrorHandlerMiddleware>();
}

app.UseHttpsRedirection();

app.UseCors(CorsAngularPolicy);

app.UseAuthorization();

app.MapControllers();


app.Run();
