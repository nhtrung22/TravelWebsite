namespace TravelWebsite.API.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelWebsite.Business.Attributes;
using TravelWebsite.Business.Helpers;
using TravelWebsite.Business.JwtModel;
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
        var user = _userService.GetById(id);
        return Ok(user);
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
}