using AutoMapper;
using TW.Business.Common.Interfaces;
using TW.DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TW.DataAccess.EF;
using TravelWebsite.Jwt;

namespace TravelWebsite.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    //[Authorize]
    public class AuthenticateController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManagerRepository;
        //private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AuthenticateController(IJWTManagerRepository jWTManagerRepository, IMapper mapper)
        {
            _mapper = mapper;
            _jWTManagerRepository = jWTManagerRepository;
            //_userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var user = "abc";
            //var user = await _userService.Login(login.UserName, login.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var token = _jWTManagerRepository.Authenticate(login);

            var result = new AutheResultModel();
            result.UserName = login.UserName;
            result.Token = token.Token;
            result.RefreshToken = token.RefreshToken;


            return Ok(result);
        }

    }
}
