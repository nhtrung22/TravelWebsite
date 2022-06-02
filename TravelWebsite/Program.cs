using Microsoft.EntityFrameworkCore;
using TravelWebsite.DataAccess.EF;
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
using Business.Services.PlaceService;
using TravelWebsite.DataAccess.Entities;
using AutoMapper;
using TravelWebsite.DataAccess.DTO;
using TravelWebsite.Business.Services;
//using TravelWebsite.Business.DTO;
using Business.Common.MappingConfig;
using TravelWebsite.Business.Common.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Services.PlaceService;
using TravelWebsite.Business.Helpers;
using TravelWebsite.Business.Jwt;
//using Middleware.Example;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.


builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
builder.Services.AddDbContext<TravelDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("TravelDatabase")
    ));



builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddTransient<IPlaceService, PlaceService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IJwtUtils, JwtUtils>();



builder.Services.AddCors();

//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(o =>
//{
//    var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
//    o.SaveToken = true;
//    o.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = false,
//        ValidateAudience = false,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["JWT:Issuer"],
//        ValidAudience = builder.Configuration["JWT:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Key)
//    };
//});

var app = builder.Build();

// add hardcoded test user to db on startup
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TravelDbContext>();
    var testUser = new User
    {
        UserName = "test",
        PasswordHash = BCrypt.Net.BCrypt.HashPassword("test")
    };
    context.User.Add(testUser);
    context.SaveChanges();
}



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
// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//middeware
//app.UseRequestCulture();
//app.UseMiddleware<RequestCultureMiddleware>();

// global cors policy
app.UseCors(x => x
    .SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();