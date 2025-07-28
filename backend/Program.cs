using backend.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:5257")
            .AllowAnyHeader()
            .AllowAnyMethod()
    )
);

var app = builder.Build();

app.UseCors();

app.ConfigureImaExpEndpoints();

app.ConfigureReverseEndpoints();

app.ConfigureCollatzEndpoints();

app.Run();