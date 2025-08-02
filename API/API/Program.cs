using API.Data;
using API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var _connectionStrings = builder.Configuration.GetConnectionString("MySqlConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(_connectionStrings, ServerVersion.AutoDetect(_connectionStrings))
);

//Inclusion de servicios
//builder.Services.AddSingleton<ProductoService>();
builder.Services.AddScoped<ProductoService>();

//Inclusion de controladores
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(
    options =>
        {
            options.AddPolicy("PermirFrontend", policy =>
            {
                //policy.WithOrigins("https://localhost:7097")
                policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();

            }
        );
        }
    
    );


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

app.UseCors("PermirFrontend");

app.Run();
