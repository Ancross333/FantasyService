using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateUserValidator));
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddMediatR(config => 
{
    config.RegisterServicesFromAssemblies(new[] {Assembly.GetExecutingAssembly() });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();