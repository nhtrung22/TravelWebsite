using Microsoft.EntityFrameworkCore;
using DataAccess.EF;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Business.Services;
using Business.Services.PlaceService;
using DataAccess.Entities;
using AutoMapper;
using DataAccess.DTO;
using Business.Services.config;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddDbContext<TravelDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("TravelDatabase")
    ));



builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPlaceService, PlaceService>();
var app = builder.Build();

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new PlaceMappingProfile());
});

config.CreateMapper();

app.UseSwaggerUI(options =>
{
    options.DefaultModelsExpandDepth(-1);
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();