using EmailProject.EmailInfo;
using EmailProject.Services;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using UserProject.Middlewares;
using UserProject.Repositories;
using UserProject.Services;
using MongoDB.Bson.Serialization.Conventions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDbConnection");

var databaseName = "PhishingDB";

builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(mongoConnectionString));

// Optionally register the IMongoDatabase so that you can directly inject it into your repositories
builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IMongoClient>().GetDatabase(databaseName));

builder.Services.Configure<EmailProject.EmailInfo.EmailSettings>(
    builder.Configuration.GetSection("EmailSettings")
);

builder.Services.AddScoped<IUsersAttemptService, UsersAttemptService>();
builder.Services.AddScoped<IUsersAttemptRepository, UsersAttemptRepository>();

builder.Services.AddTransient<IEmailSender, EmailSender>();


var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };

ConventionRegistry.Register("CamelCase", conventionPack, t => true);

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
