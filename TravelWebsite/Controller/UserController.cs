using AutoMapper;
using Business.Common.Interfaces;
using DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataAccess.EF;

namespace TravelWebsite.Controllers
{
    [Route("api/user")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet("get")]
        public async Task<List<UserDTO>> Get()
        {
            //validation
            return  await _userService.Get();
        }

        [HttpPost("add")]
        public async Task<UserDTO> Add(UserDTO user)
        {
            return await _userService.Add(user);
        }

        //[HttpDelete("delete")]
        //public async Task Remove(string email)
        //{
        //    await _userService.Remove(email);
        //}
            
        [HttpPut("put")]
        public async Task Update(UserDTO user)
        {
            await _userService.Update(user);
        }

        //[HttpPut]
        //public async Task Login(string userName, string password)
        //{
        //    //await _userService.Add(user);
        //}


    }
}
