using Microsoft.EntityFrameworkCore;
using DataAccess.EF;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Business.Services.PlaceService;
using DataAccess.Entities;
using AutoMapper;
using DataAccess.DTO;
using Business.Common.MappingConfig;
using Business.Common.Interfaces;
using TravelWebsite.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddTransient<IJWTManagerRepository, JWTManagerRepository>();
builder.Services.AddCors();

//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(o =>
//{
//    var Key = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
//    o.SaveToken = true;
//    o.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = false,
//        ValidateAudience = false,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = Configuration["JWT:Issuer"],
//        ValidAudience = Configuration["JWT:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Key)
//    };
//});


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

app.UseAuthorization();

app.MapControllers();

app.Run();