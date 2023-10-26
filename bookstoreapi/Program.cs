using Microsoft.EntityFrameworkCore;
using bookstoreapi.Entities;
using bookstoreapp.Models;
using murat.altay.Desktop.Project.bookstoreapp.DbOperations;
using System.Reflection;
using bookstoreapi.Middlewares;
using bookstoreapi.Services;
using bookstoreapi.DbOperations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.IncludeErrorDetails = true; // Default: true
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration.GetValue<string>("Token:Issuer"),
            ValidAudience= builder.Configuration.GetValue<string>("Token:Audience"),
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Token:SecurityKey"))),
            ClockSkew= TimeSpan.Zero
        };
    });
builder.Services.AddControllers();
builder.Services.AddDbContext<BookStoreDbContext>(opt => opt.UseInMemoryDatabase("BookDb"));
builder.Services.AddScoped<IBookStoreDbContext>(provider  => provider.GetService<BookStoreDbContext>());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();
builder.Services.AddSingleton<ILoggerService, DbLogger>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCustomExceptionMiddleware();

app.Run();
