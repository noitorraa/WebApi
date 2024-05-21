using Microsoft.EntityFrameworkCore;
using WebApi.bd;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebApi.Model;
var builder = WebApplication.CreateBuilder(args);

string connection = "data source=localhost; initial catalog = MyBase; Integrated Security=True; trustservercertificate = True";
builder.Services.AddDbContext<appContext>(options => options.UseSqlServer(connection));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api", async (appContext db) => await db.AllUsers.ToListAsync());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
