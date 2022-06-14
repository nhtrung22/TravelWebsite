namespace TravelWebsite.API.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelWebsite.Business.Attributes;
using TravelWebsite.Business.Models.Jwt;
using TravelWebsite.Business.Services;
using TravelWebsite.DataAccess.Entities;

[Authorize]
public class UserController : BaseController
{
    private IUserService _userService;
    private IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
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
        try
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }
        
        catch
        {
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, UpdateRequest model)
    {
        _userService.Update(id, model); 
        return Ok(new { message = "User updated" });
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Create([FromBody] RegisterModel model)
    {
        // map model to entity
        var user = _mapper.Map<User>(model);
        // create user
        _userService.Create(user, model.PasswordHash);
        return Ok();
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _userService.Delete(id);
        return Ok(new { message = "User deleted" });
    }
}