using FluentValidation;
using Microsoft.AspNetCore.Builder;
using MongoDB.Driver;
using TutoringPlatformBackEnd.User.Actors;
using TutoringPlatformBackEnd.User.Models;
using TutoringPlatformBackEnd.User.Services;
using Microsoft.AspNetCore.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IValidator<SignupRequest>, SignupRequestValidator>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<AuthActor>();
builder.Services.AddSingleton<SignupRequestValidatorActor>();

// Add the user authentication service
//builder.Services.AddScoped<AuthController>();

// Configure MongoDB connection
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = "mongodb://localhost:27017";
    return new MongoClient(connectionString);
});


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