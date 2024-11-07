using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using PRM392_Backend.API;
using PRM392_Backend.API.Extensions;
using PRM392_Backend.Service.ChatHubs;
using PRM392_Backend.Service.Extension;
using PRM392_Backend.Service.PayOSLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var jwtSettings = builder.Configuration.GetSection("JwtSettings");

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    })
    .AddNewtonsoftJson(options =>
    {       
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
    });

builder.Services.AddSignalR();
// Retrieve the connection string
var connection = builder.Environment.IsDevelopment()
    ? builder.Configuration.GetConnectionString("azure_sql_connectionstring") + ";Connection Timeout=30;MultipleActiveResultSets=true;"
    : Environment.GetEnvironmentVariable("azure_sql_connectionstring") + ";Connection Timeout=30;MultipleActiveResultSets=true;";

// Ensure the connection string is not null or empty
if (string.IsNullOrEmpty(connection))
{
    throw new InvalidOperationException("No connection string found.");
}

builder.Services.AddSingleton(x =>
    new PayOSService(
        builder.Configuration["payOS:clientId"],
        builder.Configuration["payOS:apiKey"],
        builder.Configuration["payOS:checksumKey"]
    )
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n" +
            "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
            "Example: \"Bearer 12345abcdef\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oath2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});


builder.Services.ConfigureCors();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddManager();
builder.Services.AddAutoMapper();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddBlobService(builder.Configuration);
builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<ChatHub>("/chatHub");

app.UseExceptionHandler(opt => { });

// Configure the HTTP reque+st pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PRM392_Backend API v1");
});

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();