using Microsoft.EntityFrameworkCore;
using WebApi.Model;
using WebApi;
using static System.Runtime.InteropServices.JavaScript.JSType;


var builder = WebApplication.CreateBuilder(args);
string connection = "Server=localhost;Database=MyBase;User=Noitorra;Password=Passw0rd;trustservercertificate=True";
builder.Services.AddDbContext<MyBaseContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
Autho autho = new Autho();
app.MapGet("/api/authorization", (string login, string password) => autho.Authorization(login, password));

app.Run();

