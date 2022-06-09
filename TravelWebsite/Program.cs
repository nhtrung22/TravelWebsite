using AutoMapper;
using Business.Common.MappingConfig;
using Business.Services.PlaceService;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Common.MappingConfig;
using TravelWebsite.Business.Context;
using TravelWebsite.Business.Helpers;
using TravelWebsite.Business.Middelwares;
using TravelWebsite.Business.Services;
using TravelWebsite.Business.Services.PlaceService;
using TravelWebsite.Business.Utils;
using TravelWebsite.DataAccess.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddDbContext<TravelDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("TravelDatabase"), x => x.UseNetTopologySuite()
    ));

builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//trasient scoped singleton
builder.Services.AddTransient<IPlaceService, PlaceService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IJwtUtils, JwtUtils>();
builder.Services.AddScoped<ITravelWebsiteUserContext, TravelWebsiteUserContext>();



builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new PlaceMappingProfile());
    cfg.AddProfile(new UserMappingProfile());
    cfg.AddProfile(new RegisterModelMappingProfile());
    cfg.AddProfile(new UserUpdateMappingProfile());
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

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


// global cors policy
app.UseCors(x => x
    .SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.MapControllers();

app.Run();