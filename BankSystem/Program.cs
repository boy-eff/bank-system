using BankSystem;
using BankSystem.Extensions;
using BankSystem.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BankDbContext>(options => options.UseNpgsql(config.GetConnectionString("Default")));
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUpdateUserModelValidator>();
builder.Services.AddFluentValidationAutoValidation();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

await app.RecreateAndSeedDatabaseAsync();

app.Run();