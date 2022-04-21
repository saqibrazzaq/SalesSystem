using Microsoft.EntityFrameworkCore;
using products_api.Data;
using products_api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Db context
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

// Add custom services
builder.Services.AddCustomServices();

// Add http context
builder.Services.AddHttpContextAccessor();

//services cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins(new string[] { "http://localhost:3000" }).AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Static files
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }