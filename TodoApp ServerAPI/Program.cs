
using auth.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TodoApp_ServerAPI.Data.Interfaces;
using TodoApp_ServerAPI.Data;
using TodoApp_ServerAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder =>
    {
        builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithOrigins("http://localhost:3000");
    });
});
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite("Data Source=./Data/AppDB.db"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<JwtService>();

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoApp", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(swaggerUiOptions =>
{
    swaggerUiOptions.DocumentTitle = "TodoApp";
    swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApp ServerSide");
    swaggerUiOptions.RoutePrefix = string.Empty;
});
app.MapControllers();

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");



app.Run();