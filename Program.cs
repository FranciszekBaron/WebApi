using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
