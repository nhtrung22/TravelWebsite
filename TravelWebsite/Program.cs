using Microsoft.EntityFrameworkCore;
using DataAccess.EF;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Business.Services;
using Business.Services.PlaceService;
using DataAccess.Entities;
using AutoMapper;
using DataAccess.DTO;
<<<<<<< Updated upstream
using Business.Services.config;
=======
using Business.Common.MappingConfig;
using Business.Common.Interfaces;
using TravelWebsite.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Middleware.Example;
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
=======
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddTransient<IJWTManagerRepository, JWTManagerRepository>();
builder.Services.AddCors();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});
>>>>>>> Stashed changes


var app = builder.Build();

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new PlaceMappingProfile());
    cfg.AddProfile(new UserMappingProfile());
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

app.UseAuthentication();
app.UseAuthorization();

//middeware
//app.UseRequestCulture();
//app.UseMiddleware<RequestCultureMiddleware>();

app.MapControllers();

app.Run();