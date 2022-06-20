using AutoMapper;
using Business.Common.MappingConfig;
using Business.Services.PlaceService;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Common.MappingConfig;
using TravelWebsite.Business.Common.Middelwares;
using TravelWebsite.Business.Common.Utils;
using TravelWebsite.Business.Models;
using TravelWebsite.Business.Services;
using TravelWebsite.Business.Services.PlaceService;
using TravelWebsite.DataAccess.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
if (builder.Configuration.GetValue<bool>("UseInMemoryDatabase"))
{
    builder.Services.AddDbContext<TravelDbContext>(options =>
        options.UseInMemoryDatabase("TravelDatabase"));
}
else
{
    builder.Services.AddDbContext<TravelDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("TravelDatabase"), x => x.UseNetTopologySuite()
    ));
}
builder.Services.AddScoped<ITravelDbContext>(provider => provider.GetRequiredService<TravelDbContext>());
builder.Services.AddScoped<TravelDbContextInitialiser>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument();
builder.Services.AddHttpClient();

//trasient scoped singleton
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<IPropertyService, PropertyService>();
builder.Services.AddTransient<IBookingService, BookingService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IJwtUtils, JwtUtils>();
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.Configure<MomoSettings>(builder.Configuration.GetSection("MomoSettings"));



builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new PlaceMappingProfile());
    cfg.AddProfile(new UserMappingProfile());
    cfg.AddProfile(new BookingMappingProfile());
    cfg.AddProfile(new PlaceImageMappingProfile());
    cfg.AddProfile(new RegisterModelMappingProfile());
    cfg.AddProfile(new UserUpdateMappingProfile());
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi3();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<TravelDbContextInitialiser>();
        await initialiser.InitialiseAsync();
        await initialiser.SeedAsync();
    }
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