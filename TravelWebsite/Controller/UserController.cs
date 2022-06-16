namespace TravelWebsite.API.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelWebsite.Business.Common.Attributes;
using TravelWebsite.Business.Models.DTO;
using TravelWebsite.Business.Models.Jwt;
using TravelWebsite.Business.Services;
using TravelWebsite.DataAccess.Entities;

[Authorize("Admin")]
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
    public async Task<ActionResult> Update(Guid id, UpdateRequest model)
    {
        await _userService.Update(id, model);
        return NoContent();
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult> Create([FromBody] RegisterModel model)
    {
        // map model to entity
        var user = _mapper.Map<User>(model);
        // create user
        await _userService.Create(user, model.PasswordHash);
        return Ok();
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _userService.Delete(id);
        return NoContent();
    }
}