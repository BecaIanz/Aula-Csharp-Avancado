using AppNamoro.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppNamoroDbContext>(
    options => options.UseSqlServer(
        Environment.GetEnvironmentVariable("CONNECTION_STRING")
    )
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
