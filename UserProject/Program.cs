using EmailProject.EmailInfo;
using EmailProject.Services;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using UserProject.Middlewares;
using UserProject.Repositories;
using UserProject.Services;
using MongoDB.Bson.Serialization.Conventions;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
       .AddControllers()
       .AddJsonOptions(o =>
       {
           o.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
       });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDbConnection");

var databaseName = builder.Configuration.GetConnectionString("Database");

builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(mongoConnectionString));

builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IMongoClient>().GetDatabase(databaseName));

builder.Services.Configure<EmailProject.EmailInfo.EmailSettings>(
    builder.Configuration.GetSection("EmailSettings")
);

builder.Services.AddSingleton<IUsersAttemptService, UsersAttemptService>();

builder.Services.AddSingleton<IUsersAttemptRepository, UsersAttemptRepository>();

builder.Services.AddSingleton<IEmailService, EmailService>();

builder.Services.AddSingleton<IEmailSender, EmailSender>();


var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };

ConventionRegistry.Register("CamelCase", conventionPack, t => true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
