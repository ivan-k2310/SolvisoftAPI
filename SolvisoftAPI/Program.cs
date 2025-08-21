using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SolvisoftAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200", "http://localhost:5000")
              .WithMethods("GET", "POST")
              .WithHeaders("Content-Type", "Authorization");
        });
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable OpenAPI in development mode "localhost:####/scalar/v1" 
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("Policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
