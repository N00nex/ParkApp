using ParkAPI.Data;
using ParkAPI.Helpers;
using ParkAPI.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using System;
using System.Net;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer; // Hinzugefügt für UseSqlServer-Erweiterungsmethode

var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();

string connectionString = builder.Configuration.GetConnectionString("ParkFinder");
modelBuilder.EntitySet<ParkHaus>("ParkHaus");
modelBuilder.EntitySet<PreisKlasse>("PreisKlasse");

builder.Services.AddControllers().AddOData(options =>
    options.Select().Filter().Expand().Count().OrderBy()
    .AddRouteComponents("", modelBuilder.GetEdmModel()));
// Provisorisch da
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

DatabaseHelper.Initialize(app.Services);

app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI();

app.UseRouting();

app.MapControllers();

app.Run();