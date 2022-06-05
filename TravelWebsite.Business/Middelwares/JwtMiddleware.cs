using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.Business.Helpers;
using TravelWebsite.Business.Services;

namespace TravelWebsite.Business.Middelwares;
public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = jwtUtils.ValidateJwtToken(token);
        if (userId != null)
        {
            // attach user to context on successful jwt validation
            var user = await userService.GetById(userId.Value);
            context.Items["User"] = await userService.GetById(userId.Value);
        }

        await _next(context);
    }
}