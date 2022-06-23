namespace TravelWebsite.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using TravelWebsite.Business.Common.Attributes;
using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Services;

[Authorize("Admin")]
public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDTO>>> Get()
    {
        var users = await _userService.GetAll();
        return users.ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetById(Guid id)
    {
        var user = await _userService.GetById(id);
        return user;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateUserCommand request)
    {
        await _userService.Update(id, request);
        return NoContent();
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult> Create([FromBody] CreateUserCommand request)
    {
        await _userService.Create(request, request.Password);
        return Ok();
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _userService.Delete(id);
        return NoContent();
    }
}