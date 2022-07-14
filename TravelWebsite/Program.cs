using AutoMapper;
using Business.Common.MappingConfig;
using Business.Services.PlaceService;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Stripe;
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
// This is a public sample test API key.
// Don’t submit any personally identifiable information in requests made with this key.
// Sign in to see your own test API key embedded in code samples.
StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";
//var options = new SetupIntentCreateOptions
//{
//    PaymentMethodTypes = new List<string>
//  {
//    "card",
//  },
//};
//var service = new SetupIntentService();
//service.Create(options);
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

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});

//trasient scoped singleton
builder.Services.AddTransient<IAdminService, AdminService>();
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
    cfg.AddProfile(new PropertyMappingProfile());
    cfg.AddProfile(new PropertyTypeMappingProfile());
    cfg.AddProfile(new UserMappingProfile());
    cfg.AddProfile(new BookingMappingProfile());
    cfg.AddProfile(new CityMappingProfile());
    cfg.AddProfile(new PropertyImageMappingProfile());
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
app.UseStaticFiles();
app.UseSpaStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


// global cors policy
app.UseCors(x => x
    .SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";
    if (app.Environment.IsDevelopment())
    {
        spa.UseReactDevelopmentServer(npmScript: "start");
    }
});

app.Run();