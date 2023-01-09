using Microsoft.EntityFrameworkCore;
using WebApplication1.Middlewares;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using WebApplication1.Models;
using WebApplication1.Services;
using Microsoft.Extensions.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var logger = new LoggerConfiguration()
    .WriteTo.File("Logs/myapp.txt")
    .CreateLogger();

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
    loggingBuilder.AddSerilog(logger);
});

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
// Add dbContext from models package
builder.Services.AddDbContext<OrganDbContext>(opt =>
{
    opt.UseSqlServer("Data Source=db-mssql;Initial Catalog=s20781;Integrated Security=True;Encrypt=False");
});
builder.Services.AddControllers();
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

app.UseMiddleware<ErrorLogMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
