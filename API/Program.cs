using System.Text;
using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200"));

// do you have a vaild token
app.UseAuthentication();
// what are you allowed to do with token
app.UseAuthorization();

app.MapControllers();

app.Run();
