namespace TravelWebsite.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using TravelWebsite.Business.Attributes;
using TravelWebsite.Business.Services;

[Authorize]
public class UserController : BaseController
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<OkObjectResult> GetAll()
    {
        var users = await _userService.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var user = _userService.GetById(id);
        return Ok(user);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public Task Register()
    {
        var user = _userService.Register();
        return user;
    }

}