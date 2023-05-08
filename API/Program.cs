using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200"));

// do you have a vaild token
app.UseAuthentication();
// what are you allowed to do with token
app.UseAuthorization();

app.MapControllers();

app.Run();
